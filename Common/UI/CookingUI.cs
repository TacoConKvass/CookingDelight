using CookingDelight.Common.EntitySources;
using CookingDelight.Common.Players;
using CookingDelight.Common.Systems;
using CookingDelight.Common.UI.Elements;
using CookingDelight.Content.Food;
using System.Linq;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.UI;

namespace CookingDelight.Common.UI;

public class CookingUI : UIState
{
	public UIPanel panel;
	public UIPanel cookButton;
	public UIText cookButtonText;
	public List<UIItemSlotWrapper> ingredientSlots;

	private int[] ingredientSlotsLeft = { 67, 0, 36, 96, 134 };
	private int[] ingredientSlotsTop = { 0, 60, 134, 134, 60 };

	public override void OnInitialize() {
		panel = new UIPanel();
		panel.Width.Set(192, 0);
		panel.Height.Set(192, 0);
		panel.OnUpdate += e => {
			if (e.IsMouseHovering) {
				Main.LocalPlayer.mouseInterface = true;
			}
		};
		Append(panel);

		cookButton = new UIPanel();
		cookButton.Width.Set(64, 0);
		cookButton.Height.Set(32, 0);
		cookButton.Left.Set(51, 0);
		cookButton.Top.Set(67, 0);
		cookButton.OnLeftClick += CookButton_LeftClick;
		panel.Append(cookButton);

		var text = Language.GetText("Mods.CookingDelight.CookButtonText");
		cookButtonText = new UIText(text);
		cookButtonText.VAlign = 0.5f;
		cookButtonText.HAlign = 0.5f;
		cookButton.Append(cookButtonText);

		ingredientSlots = new List<UIItemSlotWrapper>() {
			new UIItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new UIItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new UIItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new UIItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new UIItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			}
		};
		
		for (int index = 0; index < 5; index++) {
			ingredientSlots[index].Left.Set(ingredientSlotsLeft[index], 0);
			ingredientSlots[index].Top.Set(ingredientSlotsTop[index], 0);
			ingredientSlots[index].Width.Set(52 * 0.65f, 0);
			ingredientSlots[index].Height.Set(52 * 0.65f, 0);
			panel.Append(ingredientSlots[index]);
		}
	}

	public override void Update(GameTime gameTime) {
		if (ModContent.GetInstance<CookingUISystem>().CurrentCrockpotPosition != null) {
			base.Update(gameTime);
			Vector2 activeCrockpotPosition = Vector2.Transform((Vector2)ModContent.GetInstance<CookingUISystem>().CurrentCrockpotPosition - Main.screenPosition, Main.GameViewMatrix.ZoomMatrix) / Main.UIScale;
			panel.Left.Set(activeCrockpotPosition.X - 84, 0);
			panel.Top.Set(activeCrockpotPosition.Y - 224, 0);
			Recalculate();
		}
	}

	public override void OnDeactivate() {
		for (int i = 0; i < 5; i ++) {
			var item = ingredientSlots[i].Item;
			if (item.ModItem is FoodItem) {
				(item.ModItem as FoodItem).Categories = (ingredientSlots[i].Item.ModItem as FoodItem).Categories;
			}
			Main.LocalPlayer.QuickSpawnItem(new EntitySource_Misc("Closed cooking UI"), item, ingredientSlots[i].Item.stack);
			ingredientSlots[i].Item.TurnToAir();
		}
	}

	public override void Draw(SpriteBatch spriteBatch) {
		base.Draw(spriteBatch);
	}

	public void CookButton_LeftClick(UIMouseEvent evt, UIElement listeningElement) {
		List<Item> ingredient_types = new List<Item>() { };
		List<int> int_types = new List<int>() { };
		for (int i = 0; i< 5; i++) {
			if (ingredientSlots[i].Item.type == ItemID.None) {
				continue;
			}
			ingredient_types.Add(ingredientSlots[i].Item);
			int_types.Add(ingredientSlots[i].Item.type);
		}

		if (ingredient_types.Count < 2) {
			return;
		}

		string str_ingredient_types = int_types.Sorted().Join();

		int resultType = ModContent.ItemType<MixFoodItem>();

		if (RecipeRegister.CookBook.ContainsKey(str_ingredient_types)) {
			resultType = RecipeRegister.CookBook[str_ingredient_types];
		} else {
			foreach (var key in RecipeRegister.GenericFoodRequirements.Keys.Reverse()) {
				if (key.All(element => int_types.AmountOf(element) >= key.AmountOf(element))) {
					resultType = RecipeRegister.GenericFoodRequirements[key];
					break;
				}
			}
		}


		Main.LocalPlayer.QuickSpawnItem(new ItemSource_Cooking(ingredient_types), resultType);
		
		for (int i = 0; i < 5; i++) {
			ingredientSlots[i].Item.stack--;
			if (ingredientSlots[i].Item.stack <= 0) {
				ingredientSlots[i].Item.TurnToAir();
			}
		}
	}

	public bool IsValidInput(Item item) {
		bool vanillaFoodItem = false;
		bool allowedModFoodItem = item.ModItem is FoodItem && (item.ModItem as FoodItem).Categories.Count <= 5;
		foreach (FoodCategory foodCategory in Enum.GetValues(typeof(FoodCategory))) {
			if (VanillaFoodCategorizer.VanillaFoodByCategory[foodCategory].Contains(item.type)) {
				vanillaFoodItem = true;
				break;
			}
		}

		if (VanillaFoodCategorizer.VanillaFoodByCategory[FoodCategory.Spice].Contains(item.type) && item.type != ItemID.SpicyPepper) {
			vanillaFoodItem = false;
		}

		return item.IsAir || vanillaFoodItem || allowedModFoodItem;
	}
}
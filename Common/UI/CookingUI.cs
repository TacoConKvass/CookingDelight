using CookingDelight.Common.EntitySources;
using CookingDelight.Common.Players;
using CookingDelight.Common.UI.Elements;
using CookingDelight.Content.Food;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace CookingDelight.Common.UI;

public class CookingUI : UIState
{
	public UIPanel panel;
	public UIImageButton cookButton;
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
				Main.instance.MouseText("HOVERING!");
			}
		};
		Append(panel);

		cookButton = new UIImageButton(ModContent.Request<Texture2D>("CookingDelight/Common/UI/AlcoholBuff"));
		cookButton.Width.Set(32, 0);
		cookButton.Height.Set(32, 0);
		cookButton.Left.Set(67, 0);
		cookButton.Top.Set(67, 0);
		cookButton.OnLeftClick += CookButton_LeftClick;
		panel.Append(cookButton);

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
		base.Update(gameTime);
		Vector2 activeCrockpotPosition = (Vector2)Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition;
		activeCrockpotPosition = (activeCrockpotPosition - Main.screenPosition);
		panel.Left.Set(activeCrockpotPosition.X - 84, 0);
		panel.Top.Set(activeCrockpotPosition.Y - 224, 0);
		Recalculate();
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

	public void CookButton_LeftClick(UIMouseEvent evt, UIElement listeningElement) {
		List<Item> ingredient_types = new List<Item>() { };
		Main.NewText(ingredientSlots[1].Item.type);
		for (int i = 0; i< 5; i++) {
			ingredient_types.Add(ingredientSlots[i].Item);
			if (ingredientSlots[i].Item.type == ItemID.None) {
				return;
			}
		}

		ingredientSlots[0].Item.stack--;
		ingredientSlots[1].Item.stack--;
		ingredientSlots[2].Item.stack--;
		ingredientSlots[3].Item.stack--;
		ingredientSlots[4].Item.stack--;

		Main.LocalPlayer.QuickSpawnItem(new ItemSource_Cooking(ingredient_types), ModContent.ItemType<MixFoodItem>());
	}

	public bool IsValidInput(Item item) {
		bool vanillaFoodItemNotSpice = false;
		bool allowedModFoodItem = item.ModItem is FoodItem && !(item.ModItem as FoodItem).Categories.Contains(FoodCategory.Spice) && (item.ModItem as FoodItem).Categories.Count <= 5;
		foreach (FoodCategory foodCategory in Enum.GetValues(typeof(FoodCategory))) {
			if (VanillaFoodCategorizer.VanillaFoodByCategory[foodCategory].Contains(item.type)) {
				vanillaFoodItemNotSpice = true;
				break;
			}
		}

		if (VanillaFoodCategorizer.VanillaFoodByCategory[FoodCategory.Spice].Contains(item.type)) {
			vanillaFoodItemNotSpice = false;
		}

		return item.IsAir || vanillaFoodItemNotSpice || allowedModFoodItem;
	}
}
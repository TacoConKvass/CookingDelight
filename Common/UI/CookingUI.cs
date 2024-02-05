using CookingDelight.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace CookingDelight.Common.UI;

public class CookingUI : UIState
{
	public UIPanel panel;
	public UIImageButton cookButton;
	public List<ItemSlotWrapper> ingredientSlots;

	public override void OnInitialize() {
		panel = new UIPanel();
		panel.Width.Set(192, 0);
		panel.Height.Set(192, 0);

		ingredientSlots = new List<ItemSlotWrapper>() {
			new ItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new ItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new ItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new ItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			},
			new ItemSlotWrapper(scale: 0.65f) {
				ValidItemFunc = item => IsValidInput(item)
			}
		};
		for (int index = 0; index < 5; index++) {
			panel.Append(ingredientSlots[index]);
		}

		cookButton = new UIImageButton(ModContent.Request<Texture2D>("CookingDelight/Common/UI/AlcoholBuff"));
		cookButton.Width.Set(32, 0);
		cookButton.Height.Set(32, 0);
		cookButton.OnLeftClick += new MouseEvent(CookButton_LeftClick);
		panel.Append(cookButton);

		Append(panel);
	}

	public override void Update(GameTime gameTime) {
		base.Update(gameTime);
		Vector2 activeCrockpotPosition = (Vector2)Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition;
		activeCrockpotPosition = (activeCrockpotPosition - Main.screenPosition) * Main.GameViewMatrix.Zoom;
		panel.Left.Set(activeCrockpotPosition.X - 84, 0f);
		panel.Top.Set(activeCrockpotPosition.Y - 224, 0f);

		ingredientSlots[0].Left.Set(67, 0);
		ingredientSlots[0].Top.Set(0, 0);
		
		ingredientSlots[1].Left.Set(0, 0);
		ingredientSlots[1].Top.Set(60, 0);
		
		ingredientSlots[2].Left.Set(36, 0);
		ingredientSlots[2].Top.Set(134, 0);
		
		ingredientSlots[3].Left.Set(96, 0);
		ingredientSlots[3].Top.Set(134, 0);
		
		ingredientSlots[4].Left.Set(134, 0);
		ingredientSlots[4].Top.Set(60, 0);

		cookButton.Left.Set(67, 0);
		cookButton.Top.Set(67, 0);
	}

	public override void OnDeactivate() {
		for (int i = 0; i < 5; i ++) {
			Main.LocalPlayer.QuickSpawnItem(new EntitySource_Misc("Closed cooking UI"), ingredientSlots[i].Item, ingredientSlots[i].Item.stack);
			ingredientSlots[i].Item.TurnToAir();
		}
	}

	protected override void DrawSelf(SpriteBatch spriteBatch) {
		base.DrawSelf(spriteBatch);
		if (panel.ContainsPoint(Main.MouseScreen)) {
			Main.LocalPlayer.mouseInterface = true;
		}
	}

	public void CookButton_LeftClick(UIMouseEvent evt, UIElement listeningElement) {
		Main.NewText("Cookerd");
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
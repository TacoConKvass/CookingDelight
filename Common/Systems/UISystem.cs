using CookingDelight.Common.Players;
using CookingDelight.Common.UI;
using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.UI;

namespace CookingDelight.Common.Systems;

public class UISystem : ModSystem
{
	const string FoodBuffTexturePath = "CookingDelight/Common/UI";

	public UserInterface userInterface;
	public CookingUI cookingUI;

	private GameTime lastUpdateUiGameTime;


	public static Dictionary<int, string> foodBuffTextures = new Dictionary<int, string>() {
		{ (int)FoodCategory.Meat, $"{FoodBuffTexturePath}/MeatBuff" },
		{ (int)FoodCategory.Seafood, $"{FoodBuffTexturePath}/SeafoodBuff" },
		{ (int)FoodCategory.Fruit, $"{FoodBuffTexturePath}/FruitBuff" },
		{ (int)FoodCategory.Vegetable, $"{FoodBuffTexturePath}/VegetableBuff" },
		{ (int)FoodCategory.Sweet, $"{FoodBuffTexturePath}/SweetBuff" },
		{ (int)FoodCategory.Alcohol, $"{FoodBuffTexturePath}/AlcoholBuff" }
	};

	public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
		int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
		if (resourceBarIndex != -1) {
			layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
				"CookingDelight: Food Buff Display",
				delegate {
					DrawFoodBuffUI(Main.spriteBatch);
					return true;
				},
				InterfaceScaleType.UI
			));
		}

		int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
		if (mouseTextIndex != -1) {
			layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
				"CookingDelight : Cooking UI",
				delegate {
					if (lastUpdateUiGameTime != null && userInterface?.CurrentState != null) {
						userInterface.Draw(Main.spriteBatch, lastUpdateUiGameTime);
					}
					return true;
				},
				InterfaceScaleType.UI
			));
		}
	}

	public override void UpdateUI(GameTime gameTime) {
		lastUpdateUiGameTime = gameTime;
		if (userInterface?.CurrentState != null) {
			userInterface.Update(gameTime);
		}
	}

	public override void Load() {
		if (Main.dedServ) {
			return;
		}
		userInterface = new UserInterface();
		cookingUI = new CookingUI();
		cookingUI.Activate();
	}

	public override void Unload() {
		cookingUI = null;
	}

	public void DrawFoodBuffUI(SpriteBatch spriteBatch) {
		Main.LocalPlayer.TryGetModPlayer<CDFoodPlayer>(out CDFoodPlayer foodPlayer);
		Vector2 offset = new Vector2(0, 0);
		Rectangle mouserect = new Rectangle((int)Main.MouseScreen.X, (int)Main.MouseScreen.Y, 8, 8);
		string mousetext = "";
		for (int i = 0; i < 6; i++) {
			if (foodPlayer.FoodLevels[i] != 0) {
				Rectangle buffrect = new Rectangle(480 + (int)offset.X, 30, 32, 32);
				spriteBatch.Draw(ModContent.Request<Texture2D>(foodBuffTextures[i]).Value, new Vector2(480, 30) + offset, Color.White);
				if (buffrect.Intersects(mouserect)) {
					mousetext = Language.GetTextValue($"Mods.CookingDelight.FoodBuffDescriptions.{(FoodCategory)i}").FormatWith(foodPlayer.FoodLevels[i].ToRoman())
					+ "\n"
					+ Language.GetTextValue("Mods.CookingDelight.TimeLeftDescription").FormatWith(foodPlayer.FoodTimers[i] / 60);
				}
				offset += new Vector2(37, 0);
			}
		}
		if (mousetext != "") {
			Main.LocalPlayer.mouseInterface = true;
			Main.instance.MouseText(mousetext);
		}
	}

	public void ShowCookingUI() {
		userInterface?.SetState(cookingUI);
	}

	public void HideCookingUI() {
		userInterface?.SetState(null);
	}
}
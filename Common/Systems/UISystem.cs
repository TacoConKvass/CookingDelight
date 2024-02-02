using CookingDelight.Common.Players;
using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.UI;

namespace CookingDelight.Common.Systems;

public class UISystem : ModSystem
{
	const string FoodBuffTexturePath = "CookingDelight/Common/UI";

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
}
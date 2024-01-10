using CookingDelight.Common.Players;
using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria.Localization;

namespace CookingDelight.Common.UI;

public class FoodBuffDisplayUI {

	private const string AssetPath = "CookingDelight/Common/UI/";

	public static Dictionary<FoodCategory, Texture2D> foodBuffTextures = new Dictionary<FoodCategory, Texture2D>() { 
		{FoodCategory.Meat, ModContent.Request<Texture2D>(AssetPath + "MeatBuff").Value},
		{FoodCategory.Seafood, ModContent.Request<Texture2D>(AssetPath + "SeafoodBuff").Value},
		{FoodCategory.Fruit, ModContent.Request<Texture2D>(AssetPath + "FruitBuff").Value},
		{FoodCategory.Vegetable, ModContent.Request<Texture2D>(AssetPath + "VegetableBuff").Value},
		{FoodCategory.Sweet, ModContent.Request<Texture2D>(AssetPath + "SweetBuff").Value},
		{FoodCategory.Alcohol, ModContent.Request<Texture2D>(AssetPath + "AlcoholBuff").Value},
	};

	public Vector2 BaseDrawPosition = new Vector2(600f, 0f);
	public Vector2 Spacing = new Vector2(20f, 0);

	public void Draw(SpriteBatch spriteBatch) {
		if (Main.gameMenu || Main.playerInventory) { 
			return;
		}

		List<int> FoodLevels = Main.LocalPlayer.GetModPlayer<CDFoodPlayer>().FoodLevels.ToList();
		List<int> FoodTimers = Main.LocalPlayer.GetModPlayer<CDFoodPlayer>().FoodTimers.ToList();
		
		if (FoodLevels.Count() == 0) {
			return;
		}

		float UIScale = 1f;
		Vector2 drawPosition = BaseDrawPosition;
		int rectangleSide = (int)Math.Floor(foodBuffTextures[FoodCategory.Meat].Width * UIScale);
		Rectangle buffRectangle = new Rectangle((int)drawPosition.X - rectangleSide / 2, (int)drawPosition.Y - rectangleSide / 2, rectangleSide, rectangleSide);
		Rectangle mouseRectangle = new Rectangle((int)Main.MouseScreen.X, (int)Main.MouseScreen.Y, 8, 8);
		string mouseHover = "";

		foreach (FoodCategory category in Enum.GetValues(typeof(FoodCategory))) {
			if (FoodLevels[(int)category] == 0) {
				continue;
			}
			
			if (buffRectangle.Intersects(mouseRectangle)) {
				mouseHover = Language.GetTextValue($"Mods.CookingDelight.FoodBuffDescriptions.{category}Buff").FormatWith(FoodLevels[(int)category]);
			}

			var buffTexture = foodBuffTextures[category];

			spriteBatch.Draw(buffTexture, drawPosition, null, Color.White * 0.9f, 0f, buffTexture.Size() * 0.5f, UIScale, SpriteEffects.None, 0f);
		}
		
		if (mouseHover != "") {
			Main.LocalPlayer.mouseInterface = true;
			Main.instance.MouseText(mouseHover);
		}
	}
}
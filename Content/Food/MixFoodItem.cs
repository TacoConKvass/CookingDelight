using CookingDelight.Common;
using CookingDelight.Common.EntitySources;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace CookingDelight.Content.Food;

public class MixFoodItem : FoodItem
{
	public override List<FoodCategory> Categories => new List<FoodCategory>() { FoodCategory.Sweet };

	public override void SetDefaults() {
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.ResearchUnlockCount = 10;
	}
}
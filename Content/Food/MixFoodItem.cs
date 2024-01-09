using CookingDelight.Common;
using Microsoft.Xna.Framework;

namespace CookingDelight.Content.Food;

public class MixFoodItem : FoodItem
{
	public override List<FoodCategory> Categories => new List<FoodCategory>() { FoodCategory.Sweet, FoodCategory.Sweet, FoodCategory.Sweet, FoodCategory.Meat };

	public override int BuffTime => 600;

	public override void SetDefaults() {
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.consumable = true;

		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useAnimation = 30;
		Item.useTime = 30;

		Item.buffType = BuffID.WellFed;
	}
}
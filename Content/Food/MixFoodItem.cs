using CookingDelight.Common;
using Microsoft.Xna.Framework;

namespace CookingDelight.Content.Food;

public class MixFoodItem : FoodItem
{
	public override List<FoodCategory> Categories {
		get => new List<FoodCategory>() { FoodCategory.Sweet, FoodCategory.Sweet, FoodCategory.Sweet, FoodCategory.Meat };
		set => Categories = value;
	}


	public override int BuffTime {
		get => 600;
		set => BuffTime = value;
	}

	public override void SetDefaults() {
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.consumable = true;

		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useAnimation = 30;
		Item.useTime = 30;

		Item.buffType = BuffID.WellFed;
	}

	public override ModItem Clone(Item newEntity) {
		MixFoodItem clone = (MixFoodItem)base.Clone(newEntity);
		clone.Categories = Categories;
		clone.BuffTime = BuffTime;
		return clone;
	}
}
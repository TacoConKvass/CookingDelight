using CookingDelight.Common;
using Microsoft.Xna.Framework;

namespace CookingDelight.Content.Food;

public class MixFoodItem : FoodItem
{
	private List<FoodCategory> p_categories = new List<FoodCategory>() { FoodCategory.Sweet, FoodCategory.Sweet, FoodCategory.Meat, FoodCategory.Seafood, FoodCategory.Vegetable, FoodCategory.Vegetable};

	public override List<FoodCategory> Categories { 
		get => p_categories; 
		set => p_categories = value;
	}

	private int p_buffTime = 600;

	public override int BuffTime {
		get => p_buffTime;
		set => p_buffTime = value;
	}
	public override void SetDefaults() {
		base.SetDefaults();
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.consumable = true;
	
		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useAnimation = 30;
		Item.useTime = 30;
	}
}
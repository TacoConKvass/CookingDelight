namespace CookingDelight.Content.Food;

public class MixFoodItem : FoodItem {
	public override List<FoodCategory> Categories { get; set; } = new List<FoodCategory>() { 
		FoodCategory.Meat, 
		FoodCategory.Seafood,
		FoodCategory.Fruit,
		FoodCategory.Vegetable, 
		FoodCategory.Sweet,
		FoodCategory.Alcohol, 
		FoodCategory.Other 
	};

	public override int BuffTime { get; set; } = 3.Minutes();

	public override bool IsGenericFoodItem() => true;

	public override void SetDefaults() {
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.consumable = true;
	
		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useAnimation = 30;
		Item.useTime = 30;
	}
}
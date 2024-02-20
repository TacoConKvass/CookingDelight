namespace CookingDelight.Content.Food;

public class Breakfast : FoodItem 
{
	public override List<int> Recipe { get; } = new List<int>() { ItemID.FriedEgg, ItemID.Bacon };

	public override List<FoodCategory> Categories { get; set; } = new List<FoodCategory>() { FoodCategory.Meat, FoodCategory.Other, FoodCategory.Other };

	public override int BuffTime { get; set; } = 3.Minutes();

	public override void SetDefaults() {
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.consumable = true;

		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useAnimation = 30;
		Item.useTime = 30;
	}
}
namespace CookingDelight.Content.Food;

public class Terranade : FoodItem
{
	public override List<int> Recipe => new List<int>() { ItemID.Lemonade, ItemID.CreamSoda, ItemID.JojaCola };

	public override List<FoodCategory> Categories { get; set; } = new List<FoodCategory>() { FoodCategory.Sweet, FoodCategory.Sweet, FoodCategory.Sweet, FoodCategory.Sweet };

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
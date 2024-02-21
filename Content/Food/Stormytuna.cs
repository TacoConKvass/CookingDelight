namespace CookingDelight.Content.Food;

public class Stormytuna : FoodItem
{
	public override List<int> Recipe => new List<int>() { ItemID.Tuna, ItemID.Cloudfish };

	public override List<FoodCategory> Categories { get; set; } = new List<FoodCategory>() { FoodCategory.Seafood, FoodCategory.Seafood, FoodCategory.Sweet };

	public override int BuffTime { get; set; } = 4.Minutes();

	public override void SetDefaults() {
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.consumable = true;

		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useAnimation = 30;
		Item.useTime = 30;
	}
}
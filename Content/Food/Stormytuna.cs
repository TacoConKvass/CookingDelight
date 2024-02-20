using CookingDelight.Common.EntitySources;

namespace CookingDelight.Content.Food;

public class Stormytuna : FoodItem
{
	public override List<FoodCategory> Categories { get; set; } = new List<FoodCategory>() { FoodCategory.Seafood, FoodCategory.Seafood, FoodCategory.Sweet };

	public override int BuffTime { get; set; } = 4.Minutes();

	public override void SetDefaults() {
		base.SetDefaults();
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.consumable = true;

		Item.useStyle = ItemUseStyleID.EatFood;
		Item.useAnimation = 30;
		Item.useTime = 30;
	}

	public override void OnSpawn(IEntitySource source) {
		return;
	}
}
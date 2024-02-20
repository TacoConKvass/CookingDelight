using CookingDelight.Common.EntitySources;

namespace CookingDelight.Content.Food;

public class Breakfast : FoodItem 
{
	public override List<FoodCategory> Categories { get; set; } = new List<FoodCategory>() { FoodCategory.Meat, FoodCategory.Meat, FoodCategory.Other };

	public override int BuffTime { get; set; } = 3.Minutes();

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
		if (source is not ItemSource_Cooking) {
			return;
		}

		base.OnSpawn(source);
		Categories.Add(FoodCategory.Meat);
	}
}
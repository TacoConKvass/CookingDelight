namespace CookingDelight.Common;

/// <summary>
/// Abstract class describing a food item in a way that this mod intends.
/// </summary>
public abstract class FoodItem : ModItem
{
	/// <summary>
	/// List of FoodCategories this item belongs to.
	/// </summary>
	public abstract List<FoodCategory> Categories { get; }

	/// <summary>
	/// When using overriding this method make sure to call <code>base.SetStaticDefaults()</code>
	/// </summary>
	public override void SetStaticDefaults() {
		ItemID.Sets.IsFood[Item.type] = true;
		foreach (var category in Categories) { 
			FoodCategorizer.FoodByCategory[category].Add(Item.type);
		}
	}
}
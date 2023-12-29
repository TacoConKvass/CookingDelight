namespace CookingDelight.Common;

/// <summary>
/// Abstract class describing a food item in a way that this mod intends. <br/>
/// Override <see cref="Categories"/> to set which categories the item belongs to. <br/>
/// <see cref="ItemID.Sets.IsFood"/> is automatically set to <see langword="true"/>.
/// </summary>
public abstract class FoodItem : ModItem
{
	public abstract List<FoodCategory> Categories { get; }

	public override void SetStaticDefaults() {
		ItemID.Sets.IsFood[Item.type] = true;
		foreach (var category in Categories) { 
			FoodCategorizer.FoodByCategory[category].Add(Item.type);
		}
	}
}
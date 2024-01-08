using CookingDelight.Common.EntitySources;
using Terraria.DataStructures;

namespace CookingDelight.Common;

/// <summary>
/// Abstract class describing a food item in a way that this mod intends.
/// </summary>
public abstract class FoodItem : ModItem
{
	/// <summary>
	/// List of FoodCategories this item belongs to.
	/// </summary>
	public virtual List<FoodCategory> Categories { get; set; }

	public override void OnSpawn(IEntitySource source) {
		if (source is not ItemSource_Cooking) {
			return;
		}

		Categories.Clear();
		var ingredients = (source as ItemSource_Cooking).ingredients;
		foreach (int ingredient_type in ingredients) {
			// Vanilla item check
			if (ingredient_type > ItemID.None && ingredient_type < ItemID.Count) {

				//Iterate through the FoodByCategory dict
				foreach (var (category, list) in FoodCategorizer.FoodByCategory) {
					if (list.Contains(ingredient_type)) {
						Categories.Add(category);
					}
				}
			}

			else if (ModContent.GetModItem(ingredient_type) is FoodItem food_item_instance) {
				foreach (var category in food_item_instance.Categories) {
					Categories.Add(category);
				}
			}
		}
	}

	public override void OnConsumeItem(Player player) {

	}
}
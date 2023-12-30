#nullable enable
using Terraria.DataStructures;

namespace CookingDelight.Common.EntitySources;

public class ItemSource_Cooking : IEntitySource
{
	public List<int> input_ingredients;

	/// <summary>
	/// EntitySource meant to pass arguments to FoodItems OnSpawn hook.
	/// </summary>
	/// <param name="ingredients">List of IDs of the items, that are supposed to be used as ingredients in the cooking process</param>
	public ItemSource_Cooking(List<int> ingredients) {
		input_ingredients = ingredients;
	}
	public string? Context => null;
}
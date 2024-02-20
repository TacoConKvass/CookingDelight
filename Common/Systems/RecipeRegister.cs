using CookingDelight.Content.Food;

namespace CookingDelight.Common.Systems;

public class RecipeRegister : ModSystem
{
	public static Dictionary<string, int> CookBook;

	/// <summary>
	/// Contains lists of requirements for generic food cooking. <br></br>
	/// Make sure it's sorted by the list lenght.
	/// </summary>
	public static Dictionary<List<int>, int> GenericFoodRequirements;

	public override void PostSetupContent() {
		CookBook = new Dictionary<string, int>() {
			{ new List<int> { ItemID.FriedEgg, ItemID.Bacon }.Sorted().Join(), ModContent.ItemType<Breakfast>() },
			{ new List<int> { ItemID.Tuna, ItemID.Cloudfish }.Sorted().Join(), ModContent.ItemType<Stormytuna>() }
		};

		GenericFoodRequirements = new Dictionary<List<int>, int>() {
			{ new List<int> { }, ModContent.ItemType<MixFoodItem>() }
		};
	}

	public override void Unload() {
		CookBook = null;
	}
}
namespace CookingDelight.Common.Systems;

public class RecipeRegister : ModSystem
{
	/// <summary>
	/// Contains recipes for non-generic food items.
	/// </summary>
	public static Dictionary<string, int> CookBook = new Dictionary<string, int>();

	/// <summary>
	/// Contains lists of requirements for generic food cooking.
	/// </summary>
	public static SortedDictionary<List<int>, int> GenericFoodRequirements = new SortedDictionary<List<int>, int>(new ListComparer<int>());

	public override void Unload() {
		CookBook = null;
		GenericFoodRequirements = null;
	}
}
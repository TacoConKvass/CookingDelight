using CookingDelight.Content.Food;

namespace CookingDelight.Common.Systems;

public class RecipeRegister : ModSystem
{
	public static Dictionary<string, int> CookBook;

	public override void PostSetupContent() {
		CookBook = new Dictionary<string, int>() {
			{ new List<int> { ItemID.FriedEgg, ItemID.Bacon }.Sorted().Join(), ModContent.ItemType<Breakfast>() },
			{ new List<int> { ItemID.Tuna, ItemID.Cloudfish }.Sorted().Join(), ModContent.ItemType<Stormytuna>() }
		};
	}

	public override void Unload() {
		CookBook = null;
	}
}
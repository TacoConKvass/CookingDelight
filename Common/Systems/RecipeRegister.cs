namespace CookingDelight.Common.Systems;

public class RecipeRegister : ModSystem
{
	public static Dictionary<string, int> CookBook;

	public override void PostSetupContent() {
		CookBook = new Dictionary<string, int>() {
			//{ string.Join(" ", new List<int> { ItemID.Squirrel, ItemID.Squirrel }.Sorted()), ItemID.GrilledSquirrel },
		};
	}

	public override void Unload() {
		CookBook = null;
	}
}
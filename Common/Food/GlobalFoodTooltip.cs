using Humanizer;
using System.Linq;
using Terraria.Localization;

namespace CookingDelight.Common;

public class GlobalFoodTooltip : GlobalItem
{
	private static readonly Dictionary<int, string> foodLevelDisplay = new Dictionary<int, string>() {
		{ 1, "I" },
		{ 2, "II" },
		{ 3, "III" },
		{ 4, "IV" },
		{ 5, "V" },
	};

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		foreach (FoodCategory foodCategory in Enum.GetValues(typeof(FoodCategory))) {
			if (VanillaFoodCategorizer.VanillaFoodByCategory[foodCategory].Contains(item.type)) {
				var line = new TooltipLine(Mod, "foodCategory", Language.GetTextValue($"Mods.CookingDelight.FoodCategories.{foodCategory}"));
				tooltips.Add(line);
			}

			if (ModContent.GetModItem(item.type) is FoodItem food_item) {
				if (food_item.Categories.Contains(foodCategory)) {
					string food_level = foodLevelDisplay[food_item.Categories.Where(element => element == foodCategory).Count()];
					var line = new TooltipLine(Mod, "foodCategory", Language.GetTextValue($"Mods.CookingDelight.FoodCategories.{foodCategory}").FormatWith(food_level));
					tooltips.Add(line);	
				}
			}
		}
	}
}
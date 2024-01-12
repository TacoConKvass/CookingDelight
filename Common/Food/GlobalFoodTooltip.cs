using Humanizer;
using System.Linq;
using Terraria.Localization;

namespace CookingDelight.Common;

public class GlobalFoodTooltip : GlobalItem
{

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		foreach (FoodCategory foodCategory in Enum.GetValues(typeof(FoodCategory))) {
			if (VanillaFoodCategorizer.VanillaFoodByCategory[foodCategory].Contains(item.type)) {
				var line = new TooltipLine(Mod, "foodCategory", Language.GetTextValue($"Mods.CookingDelight.FoodCategories.{foodCategory}").FormatWith(1.ToRoman()));
				tooltips.Add(line);
			}
		}
	}
}
using Humanizer;
using System.Linq;
using Terraria.Localization;

namespace CookingDelight.Common;

public class GlobalFoodTooltip : GlobalItem
{

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		foreach (FoodCategory foodCategory in Enum.GetValues(typeof(FoodCategory))) {
			if (VanillaFoodCategorizer.VanillaFoodByCategory[foodCategory].Contains(item.type)) {
				foreach (var line in tooltips) {
					if (line.Name == "BuffTime" && line.Mod == "Terraria") {
						line.Hide();
					}
				}
				if (tooltips.Where(x => x.Name == "foodBuffTime").Count() == 0) {
					var line1 = new TooltipLine(Mod, "foodBuffTime", Language.GetTextValue("Mods.CookingDelight.MinutesDuration").FormatWith(VanillaFoodCategorizer.VanillaFoodBuffTime / 3600));
					tooltips.Add(line1);
				}

				var line2 = new TooltipLine(Mod, "foodCategory", Language.GetTextValue($"Mods.CookingDelight.FoodCategories.{foodCategory}").FormatWith(1.ToRoman()));
				tooltips.Add(line2);
			}
		}
	}
}
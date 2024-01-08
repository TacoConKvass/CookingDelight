using Terraria.Localization;

namespace CookingDelight.Common;

public class GlobalFoodTooltip : GlobalItem
{
	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		foreach (FoodCategory foodCategory in Enum.GetValues(typeof(FoodCategory))) {
			if (VanillaFoodCategorizer.VanillaFoodByCategory[foodCategory].Contains(item.type)) {
				var line = new TooltipLine(Mod, "foodCategory", Language.GetTextValue($"Mods.CookingDelight.FoodCategories.{foodCategory}"));
				tooltips.Add(line);
			}

			if (ModContent.GetModItem(item.type) is FoodItem food_item) {
				if (food_item.Categories.Contains(foodCategory)) {
					var line = new TooltipLine(Mod, "foodCategory", Language.GetTextValue($"Mods.CookingDelight.FoodCategories.{foodCategory}"));
					tooltips.Add(line);	
				}
			}
		}
	}
}
using CookingDelight.Common;
using CookingDelight.Common.EntitySources;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace CookingDelight.Content.Food;

public class MixFoodItem : FoodItem
{

	public override void SetDefaults() {
		Item.Size = new Vector2(16, 16);
		Item.maxStack = 9999;
		Item.ResearchUnlockCount = 10;
	}

	public override void OnSpawn(IEntitySource source) {
		if (source is ItemSource_Cooking) {
			var ingredients = (source as ItemSource_Cooking).ingredients;
			Categories.Clear();
			foreach (var ingredient in ingredients) {
				foreach (FoodCategory foodCategory in Enum.GetValues(typeof(FoodCategory))) {
					if (FoodCategorizer.FoodByCategory[foodCategory].Contains(ingredient)) {
						Categories.Add(foodCategory);
					}
				}
			}
		}
	}
}
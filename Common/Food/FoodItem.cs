using CookingDelight.Common.EntitySources;
using CookingDelight.Common.Players;
using System.Linq;
using Terraria.DataStructures;

namespace CookingDelight.Common;

/// <summary>
/// Abstract class describing a food item in a way that this mod intends.
/// </summary>
public abstract class FoodItem : ModItem {
	
	/// <summary>
	/// List of FoodCategories this item belongs to. <br>
	/// To raise the level of the effects, include the category multiple times.
	/// </summary>
	public abstract List<FoodCategory> Categories { get; }

	/// <summary>
	/// How long will the effects acquired from this food last
	/// </summary>
	public abstract int BuffTime { get; }

	/// <summary>
	/// Max level of the effects
	/// </summary>
	private readonly int maxLevel = 10;

	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 10;
		ItemID.Sets.IsFood[Type] = true;
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
	}

	public override void OnSpawn(IEntitySource source) {
		if (source is not ItemSource_Cooking) {
			return;
		}

		Categories.Clear();
		var ingredients = (source as ItemSource_Cooking).ingredients;
		foreach (int ingredient_type in ingredients) {

			// Vanilla item
			if (ingredient_type > ItemID.None && ingredient_type < ItemID.Count) {

				//Iterate through the VanillaFoodByCategory dict
				foreach (var (category, list) in VanillaFoodCategorizer.VanillaFoodByCategory) {
					if (list.Contains(ingredient_type)) {
						Categories.Add(category);
					}
				}
			}
			
			// Modded item inheriting from FoodItem
			else if (ModContent.GetModItem(ingredient_type) is FoodItem food_item_instance) {
				foreach (var category in food_item_instance.Categories) {
					Categories.Add(category);
				}
			}
		}
	}

	public override bool CanStack(Item source) {
		if ((source.ModItem as FoodItem).Categories.Except(Categories).Count() == 0) {
			return true;
		}

		return false;
	}

	public override void OnConsumeItem(Player player) {
		var foodPlayer = player.GetModPlayer<CDFoodPlayer>();

		// Clear already applied buffs 
		foodPlayer.FoodLevels = new int[7];
		foodPlayer.FoodTimers = new int[7];	

		foreach (var category in Categories) { 	
			if (foodPlayer.FoodLevels[(int)category] < maxLevel) {
				foodPlayer.FoodLevels[(int)category]++;
				Main.NewText(foodPlayer.FoodLevels[(int)category]);
			}

			foodPlayer.FoodTimers[(int)category] = BuffTime;
		}
	}
}
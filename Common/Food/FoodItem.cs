using CookingDelight.Common.EntitySources;
using CookingDelight.Common.Players;
using CookingDelight.Common.Systems;
using Humanizer;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.Social.Base;

namespace CookingDelight.Common;

/// <summary>
/// Abstract class describing a food item in a way that this mod intends.
/// </summary>
public abstract class FoodItem : ModItem
{

	/// <summary>
	/// List of FoodCategories this item belongs to. <br></br>
	/// To raise the level of the effects, include the category multiple times.
	/// </summary>
	public abstract List<FoodCategory> Categories { get; set; }

	/// <summary>
	/// How long will the effects acquired from this food last.
	/// </summary>
	public abstract int BuffTime { get; set; }

	/// <summary>
	/// Max level of the effects.
	/// </summary>
	private readonly int maxLevel = 10;

	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 10;
		ItemID.Sets.IsFood[Type] = true;
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
		if (IsGenericFoodItem()) {
			RecipeRegister.GenericFoodRequirements.Add(Recipe.Sorted(), Type);
		} else {
			RecipeRegister.CookBook.Add(Recipe.Sorted().Join(), Type);
			if (AdditionalRecipes != null) {
				foreach (var additionalRecipe in AdditionalRecipes) {
					RecipeRegister.CookBook.Add(additionalRecipe.Sorted().Join(), Type);
				}
			}
		}
	}

	/// <summary>
	/// Defines wether the items <see cref="Categories"/> are dynamically constructed in OnSpawn. <br></br>
	/// If set to <see langword="false"/> then it will always be spawned with the set <see cref="Categories"/>.
	/// </summary>
	public virtual bool IsGenericFoodItem() => false;

	/// <summary>
	/// Defines a list of items types that need to be inputted into the Crockpot to make the item. <br></br>
	/// If <see cref="IsGenericFoodItem"/> returns <see langword="true"/> this list represents at least which items have to be present to make this item.
	/// </summary>
	public abstract List<int> Recipe { get; }

	/// <summary>
	/// Defines a list of additional recipes.
	/// </summary>
	public virtual List<List<int>> AdditionalRecipes => null;

	public override void OnSpawn(IEntitySource source) {
		if (source is not ItemSource_Cooking || !IsGenericFoodItem()) {
			return;
		}

		Categories.Clear();
		var ingredients = (source as ItemSource_Cooking).ingredients;
		foreach (Item ingredient in ingredients) {

			// Vanilla item
			if (ingredient.type > ItemID.None && ingredient.type < ItemID.Count) {

				//Iterate through the VanillaFoodByCategory dict
				foreach (var (category, list) in VanillaFoodCategorizer.VanillaFoodByCategory) {
					if (list.Contains(ingredient.type) && category != FoodCategory.Spice) {
						Categories.Add(category);
					}
				}
			}

			// Modded item inheriting from FoodItem
			else if (ingredient.ModItem is FoodItem food_item_instance) {
				foreach (var category in food_item_instance.Categories) {
					if (category != FoodCategory.Spice) {
						Categories.Add(category);
					}
				}
			}
		}
	}

	public override bool CanStack(Item source) {
		var sourceCategories = (source.ModItem as FoodItem).Categories.ToList();
		sourceCategories.Sort();
		var cCategories = Categories.ToList();
		cCategories.Sort();
		if (sourceCategories.SequenceEqual(cCategories) && source.type == Type) {
			return true;
		}

		return false;
	}

	public override ModItem Clone(Item newEntity) {
		FoodItem clone = (FoodItem)base.Clone(newEntity);
		clone.Categories = Categories;
		clone.BuffTime = BuffTime;
		return clone;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips) {
		foreach (var line in tooltips) {
			if (line.Name == "BuffTime" && line.Mod == "Terraria") {
				line.Hide();
			}
		}

		foreach (FoodCategory category in Enum.GetValues(typeof(FoodCategory))) {
			if (!Categories.Contains(category)) {
				continue;
			}
			int level_cap = category == FoodCategory.Other ? 3 : 10;
			string food_level = Math.Clamp(Categories.AmountOf(category), 1, level_cap).ToRoman();
			var line = new TooltipLine(Mod, "foodCategory", Language.GetTextValue($"Mods.CookingDelight.FoodCategories.{category}").FormatWith(food_level));
			tooltips.Add(line);
		}
	}

	public override bool? UseItem(Player player) {
		var foodPlayer = player.GetModPlayer<CDFoodPlayer>();

		// Clear already applied buffs 
		foodPlayer.FoodLevels = new int[6];
		foodPlayer.FoodTimers = new int[6];
		player.ClearBuff(BuffID.WellFed);	
		player.ClearBuff(BuffID.WellFed2);
		player.ClearBuff(BuffID.WellFed3);

		foreach (var category in Categories) {
			if (category == FoodCategory.Spice) {
				continue;
			}

			if (category == FoodCategory.Other) {
				switch (Categories.Count(x => x == FoodCategory.Other)) {
					case 1:
						player.AddBuff(BuffID.WellFed, BuffTime);
						break;
					case 2:
						player.AddBuff(BuffID.WellFed2, BuffTime);
						break;
					default:
						player.AddBuff(BuffID.WellFed3, BuffTime);
						break;
				}
				continue;
			}

			if (foodPlayer.FoodLevels[(int)category] < maxLevel) {
				foodPlayer.FoodLevels[(int)category]++;
			}

			foodPlayer.FoodTimers[(int)category] = BuffTime;
		}
		return true;
	}

	public override void SaveData(TagCompound tag) {
		List<int> int_categories = Categories.Cast<int>().ToList();
		tag["Categories"] = int_categories;
		tag["BuffTime"] = BuffTime;
	}

	public override void LoadData(TagCompound tag) {
		List<int> int_categories = tag.Get<List<int>>("Categories");
		Categories = int_categories.Cast<FoodCategory>().ToList();
		BuffTime = tag.Get<int>("BuffTime");
	}
}
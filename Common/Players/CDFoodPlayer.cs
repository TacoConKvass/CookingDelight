using Terraria.ModLoader.IO;

namespace CookingDelight.Common.Players;

public class CDFoodPlayer : ModPlayer
{

	public int[] FoodLevels = new int[6];
	public int[] FoodTimers = new int[6];

	public override void PreUpdate() {
		for (int index = 0; index < 6; index++) {
			if (FoodTimers[index] > 0) {
				FoodTimers[index]--;
				continue;
			}

			// Reset food bonus if timer == 0
			FoodLevels[index] = 0;
		}
	}

	public override void PostUpdateBuffs() {
		if (FoodLevels[(int)FoodCategory.Meat] > 0) {
			Player.endurance += 0.025f * FoodLevels[(int)FoodCategory.Meat];
		}

		if (FoodLevels[(int)FoodCategory.Seafood] > 0) {
			Player.GetDamage(DamageClass.Generic) += 0.05f * FoodLevels[(int)FoodCategory.Seafood];
		}

		if (FoodLevels[(int)FoodCategory.Fruit] > 0) {
			Player.lifeRegen += 2 * FoodLevels[(int)FoodCategory.Fruit];
		}

		if (FoodLevels[(int)FoodCategory.Vegetable] > 0) {
			Player.statLifeMax2 += 10 * FoodLevels[(int)FoodCategory.Vegetable];
		}

		if (FoodLevels[(int)FoodCategory.Alcohol] > 0) {
			Player.statDefense -= 1 * FoodLevels[(int)FoodCategory.Alcohol];
			Player.GetDamage(DamageClass.Generic) += 0.02f * FoodLevels[(int)FoodCategory.Alcohol];
			Player.GetAttackSpeed(DamageClass.Generic) += 0.03f * FoodLevels[(int)FoodCategory.Alcohol];
		}
	}

	public override void PostUpdateRunSpeeds() {
		if (FoodLevels[(int)FoodCategory.Sweet] > 0) {
			Player.accRunSpeed += 0.3f * FoodLevels[(int)FoodCategory.Sweet];
			Player.runAcceleration += 0.1f * FoodLevels[(int)FoodCategory.Sweet];
		};
	}

	public override void SaveData(TagCompound tag) {
		tag["FoodLevels"] = FoodLevels;
		tag["FoodTimers"] = FoodTimers;
	}

	public override void LoadData(TagCompound tag) {
		FoodLevels = tag.Get<int[]>("FoodLevels");
		FoodTimers = tag.Get<int[]>("FoodTimers");
	}
}
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
		if (FoodTimers[(int)FoodCategory.Meat] > 0) {
			Player.endurance += 0.05f * FoodLevels[(int)FoodCategory.Meat];
		}
		if (FoodTimers[(int)FoodCategory.Seafood] > 0) {
			Player.GetDamage(DamageClass.Generic) += 0.1f * FoodLevels[(int)FoodCategory.Seafood];
		}
		if (FoodTimers[(int)FoodCategory.Fruit] > 0) {
			Player.lifeRegen += 2 * FoodLevels[(int)FoodCategory.Fruit];
		}
		if (FoodTimers[(int)FoodCategory.Vegetable] > 0) {
			Player.statLifeMax2 += 20 * FoodLevels[(int)FoodCategory.Vegetable];
		}
		if (FoodTimers[(int)FoodCategory.Sweet] > 0) {
			Player.maxRunSpeed += 0.4f * FoodLevels[(int)FoodCategory.Sweet];
			Player.runAcceleration += 0.1f * FoodLevels[(int)FoodCategory.Sweet];
		}
		if (FoodTimers[(int)FoodCategory.Alcohol] > 0) {
			Player.statDefense -= 2 * FoodLevels[(int)FoodCategory.Alcohol];
			Player.GetDamage(DamageClass.Generic) += 0.15f * FoodLevels[(int)FoodCategory.Alcohol];
			Player.GetAttackSpeed(DamageClass.Generic) += 0.1f * FoodLevels[(int)FoodCategory.Alcohol];
		}
	}
}
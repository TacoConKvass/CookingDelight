namespace CookingDelight.Common.Players;

public class CDFoodPlayer : ModPlayer {

	public int[] FoodLevels = new int[7];
	public int[] FoodTimers = new int[7];

	public override void PreUpdate() {
		for (int index = 0; index < 7; index++) {
			if (FoodTimers[index] > 0) {
				FoodTimers[index]--;
				break;
			}

			// Reset food bonus if timer == 0
			FoodLevels[index] = 0;
		}
	}

	public override void PostUpdateBuffs() {
		if (FoodTimers[(int)FoodCategory.Meat] > 0) {
			Player.endurance += (0.1f * FoodLevels[(int)FoodCategory.Meat]);
		}
		if (FoodTimers[(int)FoodCategory.Seafood] > 0) {
			Player.GetDamage(DamageClass.Generic) += 0.1f * FoodLevels[(int)FoodCategory.Seafood];
		}
		if (FoodTimers[(int)FoodCategory.Fruit] > 0) {
			Player.lifeRegen+= 2 * FoodLevels[(int)FoodCategory.Fruit];
		}
		if (FoodTimers[(int)FoodCategory.Vegetable] > 0) {
			Player.statLifeMax2 += 20 * FoodLevels[(int)FoodCategory.Vegetable];
		}
		if (FoodTimers[(int)FoodCategory.Sweet] > 0) {
			Player.moveSpeed += 0.2f * FoodLevels[(int)FoodCategory.Sweet];
		}
		if (FoodTimers[(int)FoodCategory.Alcohol] > 0) {
			Player.statDefense -= 5 * FoodLevels[(int)FoodCategory.Alcohol];
			Player.GetDamage(DamageClass.Generic) += 0.15f * FoodLevels[(int)FoodCategory.Alcohol];
			Player.GetAttackSpeed(DamageClass.Generic) += 0.1f * FoodLevels[(int)FoodCategory.Alcohol];
		}
	}
}
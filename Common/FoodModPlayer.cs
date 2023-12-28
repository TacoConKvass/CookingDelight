namespace CookingDelight.Common;

public class FoodModPlayer : ModPlayer
{
	// Immunity to vanilla food related buffs / debuffs
	public override void PostUpdateMiscEffects() {
		Player.buffImmune[BuffID.WellFed] = true;
		Player.buffImmune[BuffID.WellFed2] = true;
		Player.buffImmune[BuffID.WellFed3] = true;
		Player.buffImmune[BuffID.Tipsy] = true;
		Player.buffImmune[BuffID.NeutralHunger] = true;
		Player.buffImmune[BuffID.Hunger] = true;
		Player.buffImmune[BuffID.Starving] = true;
		base.PostUpdateMiscEffects();
	}
}
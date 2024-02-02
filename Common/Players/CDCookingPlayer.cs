using CookingDelight.Common.Systems;
using Microsoft.Xna.Framework;

namespace CookingDelight.Common.Players;

public class CDCookingPlayer : ModPlayer 
{
	public Vector2? CurrentCrockpotPosition;

	public override void PostUpdate() {
		if (CurrentCrockpotPosition != null) {
			if (Main.LocalPlayer.position.Distance((Vector2)CurrentCrockpotPosition) > 160f) {
				ModContent.GetInstance<UISystem>().HideCookingUI();
			}
		}
	}
}
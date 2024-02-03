using CookingDelight.Common.Systems;
using CookingDelight.Common.UI;
using Microsoft.Xna.Framework;

namespace CookingDelight.Common.Players;

public class CDCookingPlayer : ModPlayer 
{
	public Vector2? CurrentCrockpotPosition;

	public override void PostUpdate() {
		if (CurrentCrockpotPosition != null) {
			if (ModContent.GetInstance<UISystem>().userInterface.CurrentState == null) {
				ModContent.GetInstance<UISystem>().ShowCookingUI();
			}

			if (Main.LocalPlayer.position.Distance((Vector2)CurrentCrockpotPosition) > 320f) {
				ModContent.GetInstance<UISystem>().HideCookingUI();
				CurrentCrockpotPosition = null;
			}
		} else {
			if (ModContent.GetInstance<UISystem>().userInterface.CurrentState is CookingUI) {
				ModContent.GetInstance<UISystem>().HideCookingUI();
			}
		}
	}
}
using CookingDelight.Common.Systems;
using CookingDelight.Common.UI;

namespace CookingDelight.Common.Players;

public class CDCookingPlayer : ModPlayer 
{
	public override void OnEnterWorld() {
		if (Main.dedServ) {
			return;
		}
		
		ModContent.GetInstance<CookingUISystem>().HideCookingUI();
		ModContent.GetInstance<CookingUISystem>().CurrentCrockpotPosition = null;
	}
}
using CookingDelight.Common.Players;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace CookingDelight.Common.UI;

public class CookingUI : UIState
{
	public UIPanel panel;

	public override void OnInitialize() {
		panel = new UIPanel();
		panel.Width.Set(300, 0);
		panel.Height.Set(300, 0);
		panel.Left.Set(600, 0);
		panel.Top.Set(350, 0);

		Append(panel);
	}

	public override void Update(GameTime gameTime) {
		Vector2 activeCrockpotPosition = (Vector2)Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition;
		activeCrockpotPosition = activeCrockpotPosition.ToScreenPosition();
		panel.Left.Set(activeCrockpotPosition.X - 142, 0f);
		panel.Top.Set(activeCrockpotPosition.Y - 400, 0f);
		base.Update(gameTime);
	}
}
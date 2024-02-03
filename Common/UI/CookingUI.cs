using CookingDelight.Common.Players;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace CookingDelight.Common.UI;

public class CookingUI : UIState
{
	public UIPanel panel;
	public List<ItemSlotWrapper> ingredientSlots;

	public override void OnInitialize() {
		panel = new UIPanel();
		panel.Width.Set(300, 0);
		panel.Height.Set(300, 0);
		panel.Left.Set(600, 0);
		panel.Top.Set(350, 0);

		ingredientSlots = new List<ItemSlotWrapper>() {};

		ingredientSlots.Add(new ItemSlotWrapper());
		ingredientSlots[0].Left.Set(114, 0);
		ingredientSlots[0].Top.Set(0, 0);

		ingredientSlots.Add(new ItemSlotWrapper());
		ingredientSlots[1].Left.Set(114, 0);
		ingredientSlots[1].Top.Set(226, 0);

		ingredientSlots.Add(new ItemSlotWrapper());
		ingredientSlots[2].Left.Set(0, 0);
		ingredientSlots[2].Top.Set(114, 0);

		ingredientSlots.Add(new ItemSlotWrapper());
		ingredientSlots[3].Left.Set(226, 0);
		ingredientSlots[3].Top.Set(114, 0);

		ingredientSlots.Add(new ItemSlotWrapper());
		ingredientSlots[4].Left.Set(226, 0);
		ingredientSlots[4].Top.Set(114, 0);

		for (int index = 0; index < 5; index++) {
			panel.Append(ingredientSlots[index]);
		}
		
		Append(panel);
	}

	public override void Update(GameTime gameTime) {
		base.Update(gameTime);
		Vector2 activeCrockpotPosition = (Vector2)Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition;
		activeCrockpotPosition = activeCrockpotPosition.ToScreenPosition();
		panel.Left.Set(activeCrockpotPosition.X - 142, 0f);
		panel.Top.Set(activeCrockpotPosition.Y - 400, 0f);
	}
}
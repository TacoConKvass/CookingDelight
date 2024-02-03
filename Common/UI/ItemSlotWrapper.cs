using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.UI;

namespace CookingDelight.Common.UI;

public class ItemSlotWrapper : UIElement
{
	internal Item Item;
	public readonly int Context;
	public readonly float Scale;
	internal Func<Item, bool> ValidItemFunc;

	public ItemSlotWrapper(int context = ItemSlot.Context.BankItem, float scale = 1f) {
		Context = context;
		Scale = scale;
		Item = new Item();
		Item.SetDefaults(0);

		Width.Set(TextureAssets.InventoryBack9.Value.Width * scale, 0f);
		Height.Set(TextureAssets.InventoryBack9.Value.Height * scale, 0f);
	}

	protected override void DrawSelf(SpriteBatch spriteBatch) {
		float oldScale = Main.inventoryScale;
		Main.inventoryScale = Scale;
		Rectangle rectangle = GetDimensions().ToRectangle();

		if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface) {
			Main.LocalPlayer.mouseInterface = true;
			if (ValidItemFunc == null || ValidItemFunc(Main.mouseItem)) {
				// Handle handles all the click and hover actions based on the context.
				ItemSlot.Handle(ref Item, Context);
			}
		}
		// Draw draws the slot itself and Item. Depending on context, the color will change, as will drawing other things like stack counts.
		ItemSlot.Draw(spriteBatch, ref Item, Context, rectangle.TopLeft());
		Main.inventoryScale = oldScale;
	}
}
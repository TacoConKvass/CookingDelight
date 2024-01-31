namespace CookingDelight.Content.Tiles;

public class CrockPotTE : ModTileEntity {
	public override bool IsTileValidForEntity(int x, int y) {
		throw new NotImplementedException();
	}

	public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate) {
		return base.Hook_AfterPlacement(i, j, type, style, direction, alternate);
	}
}
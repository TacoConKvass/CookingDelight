namespace CookingDelight.Content.Tiles;

public class CrockpotTE : ModTileEntity {
	public override bool IsTileValidForEntity(int x, int y) {
		Tile tile = Main.tile[x, y];
		return tile.HasTile && tile.TileType == ModContent.TileType<Crockpot>() && tile.TileFrameX == 0 && tile.TileFrameY == 0;
	}

	public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate) {
		// If in multiplayer, tell the server to place the tile entity and DO NOT place it yourself. That would mismatch IDs.
		// Also tell the server that you placed the 2x2 tiles that make up the Crock Pot.
		if (Main.netMode == NetmodeID.MultiplayerClient) {
			NetMessage.SendTileSquare(Main.myPlayer, i, j, Crockpot.Width, Crockpot.Height);
			NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i, j, Type);
			return -1;
		}

		// If in single player, just place the tile entity, no problems.
		int id = Place(i, j);
		return id;
	}

	public override void OnNetPlace() => NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, ID, Position.X, Position.Y);

	public override void OnKill() {
		Main.NewText("AHHHhhhh...");
		base.OnKill();
	}
}
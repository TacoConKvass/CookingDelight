using CookingDelight.Common.Players;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Localization;
using Terraria.ObjectData;

namespace CookingDelight.Content.Tiles;

public class Crockpot : ModTile
{
	public static int Width = 2;
	public static int Height = 2;

	public override void SetStaticDefaults() {
		Main.tileFrameImportant[Type] = true;
		Main.tileWaterDeath[Type] = false;
		Main.tileLavaDeath[Type] = false;

		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.Origin = new Point16(1, 1);
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.addTile(Type);

		AddMapEntry(new Color(240, 20, 10), Language.GetText("Mods.CookingDelight.Tiles.CrockPot.DisplayName"));
	}

	public override bool CanExplode(int i, int j) => false;

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

	public override bool RightClick(int i, int j) {
		Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition = Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition == null ? new Point16(i, j).ToWorldCoordinates() : null;
		return true;
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY) {
		Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition = null;
	}
}
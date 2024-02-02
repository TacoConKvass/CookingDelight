using CookingDelight.Common.Players;
using Humanizer;
using Microsoft.Xna.Framework;
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
		TileObjectData.newTile.LavaDeath = false;

		ModTileEntity te_crockpot = ModContent.GetInstance<CrockpotTE>();
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(te_crockpot.Hook_AfterPlacement, -1, 0, true);

		TileObjectData.addTile(Type);
		AddMapEntry(new Color(240, 20, 10), Language.GetText("Mods.CookingDelight.Tiles.CrockPot.DisplayName"));
	}

	public override bool CanExplode(int i, int j) => false;

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

	public override void KillMultiTile(int i, int j, int frameX, int frameY) {
		ModContent.GetInstance<CrockpotTE>().Kill(i, j);
		base.KillMultiTile(i, j, frameX, frameY);
	}

	public override bool RightClick(int i, int j) {
		// There must be a better way
		bool exists = TileEntity.ByPosition.TryGetValue(new Point16(i, j), out TileEntity te);
		if (!exists) {
			exists = TileEntity.ByPosition.TryGetValue(new Point16(i - 1, j), out TileEntity t2);
			te = t2;
		}
		if (!exists) {
			exists = TileEntity.ByPosition.TryGetValue(new Point16(i, j - 1), out TileEntity t3);
			te = t3;
		}
		if (!exists) {
			exists = TileEntity.ByPosition.TryGetValue(new Point16(i-1, j - 1), out TileEntity t4);
			te = t4;
		}

		if (exists) {
			Main.LocalPlayer.GetModPlayer<CDCookingPlayer>().CurrentCrockpotPosition = te.Position.ToWorldCoordinates();
		}
		return true;
	}
}
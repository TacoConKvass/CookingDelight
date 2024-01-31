using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Localization;
using Terraria.ObjectData;

namespace CookingDelight.Content.Tiles;

public class CrockPot : ModTile {
	public override void SetStaticDefaults() {
		Main.tileFrameImportant[Type] = true;
		Main.tileWaterDeath[Type] = false;
		Main.tileLavaDeath[Type] = false;
			
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.Origin = new Point16(1, 1);
		TileObjectData.newTile.LavaDeath = false;
		
		ModTileEntity te_crockpot = ModContent.GetInstance<CrockPotTE>();
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(te_crockpot.Hook_AfterPlacement, -1, 0, true);

		TileObjectData.addTile(Type);
		AddMapEntry(new Color(240, 20, 10), Language.GetText("Mods.CookingDelight.Tiles.CrockPot.DisplayName"));
	}

	public override bool CanExplode(int i, int j) => false;

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;
}
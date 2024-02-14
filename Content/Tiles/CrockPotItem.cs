using Microsoft.Xna.Framework.Graphics;

namespace CookingDelight.Content.Tiles;

public class CrockpotItem : ModItem
{
	public override void SetDefaults() {
		Item.DefaultToPlaceableTile(ModContent.TileType<Crockpot>(), 0);

		Item.width = 30;
		Item.height = 40;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.buyPrice(silver: 20);
	}

	public override string Texture => "CookingDelight/Content/Tiles/CrockpotItem";
}
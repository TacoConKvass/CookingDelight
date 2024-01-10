using CookingDelight.Common.UI;
using Microsoft.Xna.Framework;	
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace CookingDelight.Common.Systems;

public class UIManagementSystem : ModSystem
{
	public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
	{
		int buffDisplayIndex = layers.FindIndex(layer => layer.Name == "Vanilla: Resource Bars");
		if (buffDisplayIndex != -1)
		{
			layers.Insert(buffDisplayIndex, new LegacyGameInterfaceLayer("Food Buff UI", delegate ()
			{
				FoodBuffDisplayUI.Draw(Main.spriteBatch);
				return true;
			}, InterfaceScaleType.UI));
		}
	}
}
using CookingDelight.Common.UI;
using Terraria.UI;

namespace CookingDelight.Common.Systems;

public class CookingUISystem : ModSystem
{
	public Vector2? CurrentCrockpotPosition;

	public UserInterface userInterface;
	public CookingUI cookingUI;

	private GameTime lastUpdateUiGameTime;

	public override void PostUpdatePlayers() {
		if (CurrentCrockpotPosition != null) {
			if (userInterface.CurrentState == null) {
				ShowCookingUI();
				Main.NewText($"UI is now shown; CurrentCrockpotPosition: {CurrentCrockpotPosition}; Player position: {Main.LocalPlayer.Center}");
				return;
			}

			if (Main.LocalPlayer.Center.Distance((Vector2)CurrentCrockpotPosition) > 320f) {
				HideCookingUI();
				CurrentCrockpotPosition = null;
				Main.NewText("UI is now hidden");
			}
		}
		else if (userInterface != null) {
			if (userInterface.CurrentState is CookingUI) {
				HideCookingUI();
			}
		}
	}

	public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
		int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
		if (mouseTextIndex != -1) {
			layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
				"CookingDelight : Cooking UI",
				delegate {
					if (lastUpdateUiGameTime != null && userInterface?.CurrentState != null) {
						userInterface.Draw(Main.spriteBatch, lastUpdateUiGameTime);
					}
					return true;
				},
				InterfaceScaleType.UI
			));
		}
	}

	public override void UpdateUI(GameTime gameTime) {
		lastUpdateUiGameTime = gameTime;
		if (userInterface?.CurrentState != null) {
			userInterface.Update(gameTime);
		}
	}

	public override void Load() {
		if (Main.dedServ) {
			return;
		}

		userInterface = new UserInterface();
		cookingUI = new CookingUI();
		cookingUI.Activate();
	}
	public override void Unload() {
		cookingUI = null;
	}

	public void ShowCookingUI() {
		userInterface?.SetState(cookingUI);
	}

	public void HideCookingUI() {
		userInterface?.SetState(null);
	}
}
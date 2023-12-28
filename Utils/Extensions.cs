namespace CookingDelight.Utils;

public static class Extensions
{
	public static int Seconds(this int x, int updatesPerTick = 1) {
		return x * updatesPerTick * 60;
	}
}
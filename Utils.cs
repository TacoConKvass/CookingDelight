namespace CookingDelight;

public static class Utils 
{
	public static List<int> Sorted(this List<int> list) {
		list.Sort();
		return list;
	}

	public static int Seconds(this int time) {
		return (int)time * 60;
	}

	public static int Minutes(this int time) {
		return time * 3600;
	}

}
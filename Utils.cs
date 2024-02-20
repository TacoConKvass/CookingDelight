namespace CookingDelight;

public static class Utils 
{
	/// <summary>
	/// </summary>
	/// <param name="list">The list you want to sort</param>
	/// <returns>A sorted list.</returns>
	public static List<T> Sorted<T>(this List<T> list) {
		list.Sort();
		return list;
	}

	/// <summary>
	/// </summary>
	/// <param name="list">The list you want to join</param>
	/// <param name="separator">The set of characters you want to insert in between list elements</param>
	/// <returns>A <see langword="string"/> joining all elements in the list.</returns>
	public static string Join<T>(this List<T> list, string separator = " ") {
		return string.Join(separator, list);
	}

	public static int Seconds(this int time) {
		return (int)time * 60;
	}

	public static int Minutes(this int time) {
		return time * 3600;
	}

}
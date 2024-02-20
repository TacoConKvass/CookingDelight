using System.Linq;

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

	public static int AmountOf<T>(this List<T> list, T searchedItem) {
		return list.Where(x => x.Equals(searchedItem)).Count();
	}

	public static int Seconds(this int time) {
		return (int)time * 60;
	}

	public static int Minutes(this int time) {
		return time * 3600;
	}
}

// Taken from https://www.codeproject.com/Questions/5162240/Order-a-list-of-list-in-Csharp
public sealed class ListComparer<T> : IComparer<IReadOnlyList<T>> where T : IComparable
{
	public int Compare(IReadOnlyList<T> left, IReadOnlyList<T> right) {
		if (left is null) return right is null ? 0 : -1;
		if (right is null) return 1;

		var innerComparer = Comparer<T>.Default;
		int count = Math.Min(left.Count, right.Count);
		for (int index = 0; index < count; index++) {
			int result = innerComparer.Compare(left[index], right[index]);
			if (result != 0) return result;
		}

		return left.Count.CompareTo(right.Count);
	}
}
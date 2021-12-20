namespace Utilities;

public static class IEnumerableExtensions {
    public static IEnumerable<T> Replicate<T>(this T toReplicate, uint times) =>
        Enumerable.Range(0, (int)times)
        .Select(_ => toReplicate);
}

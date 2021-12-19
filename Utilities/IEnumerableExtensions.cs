namespace Utilities;

public static class IEnumerableExtensions {
    public static IEnumerable<T> Replicate<T>(this IEnumerable<T> toReplicate, uint times) =>
        Enumerable.Range(0, (int)times)
        .SelectMany(_ => toReplicate);

    public static IEnumerable<T> Replicate<T>(this T toReplicate, uint times) =>
        Enumerable.Range(0, (int)times)
        .Select(_ => toReplicate);
}

public static class PipeExtensions {
    public static TOut Pipe<TIn, TOut>(this TIn toPipe, Func<TIn, TOut> func) =>
        func(toPipe);
    public static void Pipe<T>(this T toPipe, Action<T> func) =>
        func(toPipe);
}
namespace Utilities;

public static class PipeExtensions {
    public static TOut Pipe<TIn, TOut>(this TIn toPipe, Func<TIn, TOut> func) =>
        func(toPipe);

    public static void Pipe<T>(this T toPipe, Action<T> func) =>
        func(toPipe);
}
namespace HTTPServer.Formatters.Logger
{
    public interface ILoggerFormattable
    {
        int Counter { get; }

        string Source { get; }

        string Caller { get; }
    }
}
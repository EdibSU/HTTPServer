namespace HTTPServer.Formatters.Logger
{
    public interface ILoggerFormatter : IFormatter<string>
    {
        ILoggerFormatter Init(ILoggerFormattable formattable);
    }
}
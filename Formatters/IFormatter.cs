namespace HTTPServer.Formatters
{
	public interface IFormatter<T>
	{
		T Format(T data);
	}
}
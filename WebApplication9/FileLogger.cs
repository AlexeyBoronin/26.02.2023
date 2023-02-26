namespace WebApplication9
{
    public class FileLogger:ILogger,IDisposable
    {
        string filePath1;
        static object _lock=new object();
        public FileLogger(string path)
        {
            filePath1=path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }
        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel1)
        {
            //return logLevel==LogLevel.Trace;
            return true;
        }
        public void Log<TState>(LogLevel logLevel1,EventId eventId1, TState state,Exception? exception1,
            Func<TState, Exception?, string> formatter1)
        {
            lock(_lock) 
            {
                File.AppendAllText(filePath1, formatter1(state,exception1)+Environment.NewLine);
            }
        }
    }
}

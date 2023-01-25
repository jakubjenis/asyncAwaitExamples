using AsyncAwaitBestPractices;

namespace Tasks;

public class AsyncVoidAvoidedBySafeFireAndForget
{
    public AsyncVoidAvoidedBySafeFireAndForget()
    {
        ExecuteRefresh().SafeFireAndForget((e) =>
        {
            Console.WriteLine("Handled gracefully");
        });
    }
 
    private async Task ExecuteRefresh()
    {
        await Task.Delay(1);
        throw new Exception("Async void has thrown exception");
    }
}
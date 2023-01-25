namespace Tasks;

public class AsyncVoidIncorrect
{
    public AsyncVoidIncorrect()
    {
        // Handling exception this way is impossible
        // By the time it is thrown, we are out of the try catch block
        try
        {
            ExecuteRefreshAsyncVoidWrapper();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception handled gracefully");
        }
    }
    
    private async void ExecuteRefreshAsyncVoidWrapper()
    {
        await ExecuteRefresh();
    }

    private async Task ExecuteRefresh()
    {
        await Task.Delay(1);
        throw new Exception("Async void has thrown exception");
    }
}
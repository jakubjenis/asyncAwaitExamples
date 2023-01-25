namespace Tasks;

public class ContinuationSyncOverAsyncDemo
{
    public async Task<int> MethodA()
    {
        //MoveNext
        Console.WriteLine($"MethodA before calling MethodB running in Thread: {Environment.CurrentManagedThreadId}");
        var result = MethodB().Result; 
        
        Console.WriteLine($"MethodA after await running in Thread: {Environment.CurrentManagedThreadId}");
        return result;
    }
    
    public async Task<int> MethodB()
    {
        Console.WriteLine($"MethodC before await running in Thread: {Environment.CurrentManagedThreadId}");
        await Task.Delay(100);
        
        Console.WriteLine("Task delay 100 awaited");
        Console.WriteLine($"MethodC after await running in Thread: {Environment.CurrentManagedThreadId}");
        return 1;
    }
}
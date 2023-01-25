namespace Tasks;

public class NestedAwaitsTaskResult
{
    public async Task<int> MethodA()
    {
        Console.WriteLine($"MethodA before await running in Thread: {Environment.CurrentManagedThreadId}");
        var result = await MethodB();
        Console.WriteLine($"MethodA after await running in Thread: {Environment.CurrentManagedThreadId}");
        return result;
    }
    
    public async Task<int> MethodB()
    {
        Console.WriteLine($"MethodB before await running in Thread: {Environment.CurrentManagedThreadId}");
        var result = await MethodC();
        Console.WriteLine($"MethodB before await running in Thread: {Environment.CurrentManagedThreadId}");
        return result;
    }
    
    public async Task<int> MethodC()
    {
        Console.WriteLine($"MethodC before await running in Thread: {Environment.CurrentManagedThreadId}");
        await Task.Yield();
        Console.WriteLine($"MethodC before await running in Thread: {Environment.CurrentManagedThreadId}");
        return 1;
    }
}
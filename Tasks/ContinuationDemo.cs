namespace Tasks;

//MethodA
//1) Creates State machine
//2) Starts State Machine - first call to MoveNext of MethodA
//3) MethodA calls MethodB
// this.<task>5__1 = this.<>4__this.MethodB()

//MethodB
//1) Creates State machine
//2) Starts State Machine - first call to MoveNext of MethodB
//3) MethodB calls Task.Delay
        
//Task.Delay
//1) Creates Delay task
//2) Returns Delay task
        
//MethodB
//Calls awaiter on Delay task
//Awaiter is not completed, schedule continuation and return
        
//MethodA
//We don't await Task right away, so method can continue
//Console.WriteLine("MethodA after calling MethodB before await");
//GetAwaiter of MethodB task     
//Awaiter is not completed, schedule continuation and return

//Task.Delay timer expires

//MethodB
//MoveNext is called - how? who calls it?
//calls GetResult on delay awaiter
//calls SetResult on its state machine

//MethodA
//MoveNext is called - how? who calls it?
//calls GetResult on MethodA awaiter
//calls SetResult on its state machine

public class ContinuationDemo
{
    public async Task<int> MethodA()
    {
        //IL
        // public Task<int> MethodA()
        // {
        //     ContinuationDemo.<MethodA>d__0 stateMachine = new ContinuationDemo.<MethodA>d__0();
        //     stateMachine.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
        //     stateMachine.<>4__this = this;
        //     stateMachine.<>1__state = -1;
        //     stateMachine.<>t__builder.Start<ContinuationDemo.<MethodA>d__0>(ref stateMachine);
        //     return stateMachine.<>t__builder.Task;
        // }
        
        //MoveNext
        Console.WriteLine($"MethodA before calling MethodB running in Thread: {Environment.CurrentManagedThreadId}");
        var task = MethodB(); //this.<task>5__1 = this.<>4__this.MethodB();
        Console.WriteLine("MethodA after calling MethodB before await");
        var result = await task; //awaiter = this.<task>5__1.GetAwaiter();
        //if(awaiter.IsCompleted)../
        
        Console.WriteLine($"MethodA after await running in Thread: {Environment.CurrentManagedThreadId}");
        return result;
    }
    
    public async Task<int> MethodB()
    {
        //IL
        //public Task<int> MethodB()
        //{
        //     ContinuationDemo.<MethodB>d__1 stateMachine = new ContinuationDemo.<MethodB>d__1();
        //     stateMachine.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
        //     stateMachine.<>4__this = this;
        //     stateMachine.<>1__state = -1;
        //     stateMachine.<>t__builder.Start<ContinuationDemo.<MethodB>d__1>(ref stateMachine);
        //     return stateMachine.<>t__builder.Task;
        //}
        
        Console.WriteLine($"MethodC before await running in Thread: {Environment.CurrentManagedThreadId}");
        await Task.Delay(100); //awaiter = Task.Delay(100).GetAwaiter();
        //if(awaiter.IsCompleted)
        
        Console.WriteLine("Task delay 100 awaited");
        Console.WriteLine($"MethodC after await running in Thread: {Environment.CurrentManagedThreadId}");
        return 1;
    }
}
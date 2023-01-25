// See https://aka.ms/new-console-template for more information

using Tasks;

var action = (object obj) =>
{
    Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, obj, Environment.CurrentManagedThreadId);
};

//Create task by calling constructor
//Can create Task without starting it - otherwise other methods are preferred
// var task = new Task(action, "alpha");
// task.Start();
// task.Wait();
//
// //Create task by Task.Factory.StartNew
// var task2 = Task.Factory.StartNew(action, "beta");
// task2.Wait();
//
// //Create task by Task.Run
// var taskData = "delta";
// var task3 = Task.Run(() =>
// {
//     Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, taskData, Environment.CurrentManagedThreadId);
//     return 2;
// });
// task3.Wait();
//
//
// //difference?
// task3.Wait();
// task3.GetAwaiter();
//
// //difference?
// var result1 = task3.Result;
// var result2 = task3.GetAwaiter().GetResult();
//
// Console.WriteLine("Hello, World!");

//1)
//Running and awaiting MethodA, MethodB, MethodC does not cause any thread switch
//Task.Result is in completed state, so state machine never schedules continuation

//await new NestedAwaitsTaskResult().MethodA();

//2)
//Running and awaiting MethodA, MethodB, MethodC causes thread switch on Task.Delay
//Task.Delay is not in completed state, so state machine schedules continuation
//In Console application this is scheduled to any thread - no SynchronizationContext
//The same would happen with Task.Yield

//await new NestedAwaitsTaskDelay().MethodA();

//3)
//await new ContinuationDemo().MethodA();

//3B)
//Sync over async
//Thread 1 is blocked while another Thread completes MethodB
await new ContinuationSyncOverAsyncDemo().MethodA();


//4) Async void
//Async void method is called in the constructor and throw an exception
//Try catch around the async method call does not help without await

//new AsyncVoidIncorrect();

//5)
//Async void correctly handling exception

//new AsyncVoidCorrect();

//6)
//SafeFireAndForget
//new AsyncVoidAvoidedBySafeFireAndForget();

Console.ReadKey();
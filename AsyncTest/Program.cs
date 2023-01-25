var cts = new CancellationTokenSource();
var longTask = LongTask(cts.Token);
// while (!longTask.IsCompleted)
// {
//     Console.Write(".");
//     Thread.Sleep(100);
// }
Console.WriteLine($"initialStatus: {longTask.Status}");
cts.CancelAfter(TimeSpan.FromSeconds(1));

try
{
    await longTask;
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine($"finalStatus: {longTask.Status}");

async Task LongTask(CancellationToken token)
{
    await Task.Delay(5000, token);
    Console.WriteLine("Long task done");
}
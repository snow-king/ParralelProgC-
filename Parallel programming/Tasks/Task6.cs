namespace Parallel_programming.Tasks;

public class Task6 : AbstractTask
{
    public Task6() : base("Task6",
        "Поиск минимального значения последовательности")
    {
    }
	
    protected override void ExecutionWithoutThread()
    {
        base.ExecutionWithoutThread();
		
        TimeExecution.Start();
        Console.WriteLine("Минимальное число: {0}", 
            TaskResult.Results = Array!.Min().ToString());
        TimeExecution.Stop();
		
        WriteTimeResult();
    }
	
    protected override void ExecutionWithThread()
    {
        base.ExecutionWithThread();
		
        TimeExecution.Start();
        StartExecutionThread();
        for (var i = 0; i < CountThreads; i++)
        {
            Threads[i].Join();
        }       
        var result = ThreadReturns.Min();
        TimeExecution.Stop();
		
        Console.WriteLine("Минимальное число: {0}", 
            TaskResult.Results = result.ToString());
        WriteTimeResult();
		
    }
	
    protected override long CalculateThreadFunction(int begin, int end) 
    {
        return Array![begin..(end)].Min();;
    }
	
}
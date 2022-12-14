namespace Parallel_programming.Tasks;

public class Task5 : AbstractTask
{
    public Task5() : base("Task5",
        "Поиск максимального значения последовательности")
    {
    }
	
    protected override void ExecutionWithoutThread()
    {
        base.ExecutionWithoutThread();
		
        TimeExecution.Start();
        Console.WriteLine("Максимальное число: {0}", 
            TaskResult.Results = Array!.Max().ToString());
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
        var result = ThreadReturns.Max();
        TimeExecution.Stop();
		
        Console.WriteLine("Маскимальное число: {0}", 
            TaskResult.Results = result.ToString());
        WriteTimeResult();
		
    }
	
    protected override long CalculateThreadFunction(int begin, int end) 
    {
        return  Array![begin..(end)].Max();
    }
	
}
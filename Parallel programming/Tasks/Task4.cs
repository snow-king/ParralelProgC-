namespace Parallel_programming.Tasks;

public class Task4 : AbstractTask
{
    public Task4() : base(
        "Task4",
        "Вычисление произведения последовательности чисел")
    {
    }
	
    protected override void ExecutionWithoutThread()
    {
        base.ExecutionWithoutThread();
		
        TimeExecution.Start();
        Console.WriteLine("Произведение чисел: {0}", 
            TaskResult.Results = Array.Aggregate((x, y) => x * y).ToString());
        TimeExecution.Stop();
		
        WriteTimeResult();
    }
	
    protected override void ExecutionWithThread()
    {
        base.ExecutionWithThread();
		
        TimeExecution.Start();
        StartExecutionThread();
        long result = 1;
        for (var i = 0; i < CountThreads; i++)
        {
            Threads[i].Join();
            result *= ThreadReturns[i];
        }      
        TimeExecution.Stop();
		
        Console.WriteLine("Произведение чисел: {0}", 
            TaskResult.Results = result.ToString());
        WriteTimeResult();
		
    }
	
    protected override long CalculateThreadFunction(int begin, int end) 
    {
        return Array[begin..(end)]!.Aggregate((x, y) => x * y);
    }
	
}
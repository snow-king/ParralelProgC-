namespace Parallel_programming.Tasks;

public class Task10 : AbstractTask
{
    public Task10() : base("Task10",
        "Вычисление суммы чётных элементов последовательности")
    {
    }
	
    protected override void ExecutionWithoutThread()
    {
        base.ExecutionWithoutThread();
        var bigArray = System.Array.ConvertAll<int, long>(Array,
            i => (long)i);;
        TimeExecution.Start();
        var sum = bigArray!.Where(element => element % 2 == 0).Sum();
        TimeExecution.Stop();
		
        Console.WriteLine("Сумма четных чисел: {0}",
            TaskResult.Results = sum.ToString());
        WriteTimeResult();
    }
	
    protected override void ExecutionWithThread()
    {
        base.ExecutionWithThread();
		
        TimeExecution.Start();
        StartExecutionThread();
        long result = 0;
        for (var i = 0; i < CountThreads; i++)
        {
            Threads[i].Join(); 
            result += ThreadReturns[i];
        } 		
        TimeExecution.Stop();
		
        Console.WriteLine("Сумма четных чисел: {0}",
            TaskResult.Results = result.ToString());
        WriteTimeResult();
		
    }
	
    protected override long CalculateThreadFunction(int begin, int end) 
    {
        var bigArray = System.Array.ConvertAll<int, long>(Array[begin..(end)],
            i => (long)i);;
        var sum = bigArray!.Where(element => element % 2 == 0).Sum();
		
        return sum;
    }
	
}
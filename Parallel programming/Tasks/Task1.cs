namespace Parallel_programming.Tasks;

public class Task1 : AbstractTask
{
    /// <summary>
    /// Последовательность чисел С.
    /// </summary>
    private int[]? _arrayC;
	
    public Task1()
        : base("Task1",
            "Совпадают ли поэлементно массивы А и С")
    {
      
    }
	
    protected override void ReadInputData()
    {
        base.ReadInputData();
        _arrayC = new int[CountElements];
        _arrayC = InitialArrayRandomData();
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
		
        Console.WriteLine("Количество совпадающих элементов: {0}", 
            TaskResult.Results = result.ToString());
        WriteTimeResult();
		
    }
	
    protected override long CalculateThreadFunction(int begin, int end) 
    {
        var countEqualElements = 0;
        for (var i = begin; i < end; i++)
        {
            if (Array[i] == _arrayC![i])
            {
                countEqualElements++;
            }
			
        }
		
        return countEqualElements;
    }
	
    protected override void ExecutionWithoutThread()
    {
        base.ExecutionWithoutThread();
        var countEqualElements = 0;
		
        TimeExecution.Start();
        for (var i = 0; i < CountElements; i++)
        {
            if (Array[i] == _arrayC![i])
            {
                countEqualElements++;
            }
			
        }   
        TimeExecution.Stop();
		
        Console.WriteLine("Количество совпадающих элементов: {0}", 
            TaskResult.Results = countEqualElements.ToString());
        WriteTimeResult();
    }
}
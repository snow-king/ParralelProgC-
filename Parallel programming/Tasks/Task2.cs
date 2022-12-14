namespace Parallel_programming.Tasks;

public class Task2 : AbstractTask
{
    /// <summary>
    /// Количество пар кодирующих чисел.
    /// </summary>
    private int _n;
	
    /// <summary>
    /// Массив кодирующих чисел a.
    /// </summary>
    private int[]? _arrayA;
	
    /// <summary>
    /// Массив кодирующих чисел b.
    /// </summary>
    private int[]? _arrayB;
	
    /// <summary>
    /// Массив для хранения последовательности чисел С.
    /// </summary>
    private int[]? _arrayС;
	
    public Task2() : base("Task2","Кодировка последовательности C")
    {
    }
	
    protected override void ReadInputData()
    {
        base.ReadInputData();
		
        _n = ReadDigitFromConsole("Введите количество пар кодирующих чисел: ");
        _arrayA = InitialEncodingNumbersRandomData();
        _arrayB = InitialEncodingNumbersRandomData();
	}
	
    /// <summary>
    /// Инициализация массива случайными неповторяющимися числами.
    /// </summary>
    /// <returns> Массив, заполненный случайными числами.</returns>
    private int[]? InitialEncodingNumbersRandomData()
    {
        var arrayTemp = new int[_n];
        int temp;
        Random random;
        for (var i = 0; i < _n; i++)
        {
            random = new Random();
            temp = random.Next();
            while (arrayTemp.Contains(temp)) temp = random.Next();
            arrayTemp[i] = temp;
		}
		
        return arrayTemp;
	}
	
	protected override void ExecutionWithoutThread()
    {
        base.ExecutionWithoutThread();
		_arrayС = Array!.ToArray();
        var countEncodedElements = 0;
		
        TimeExecution.Start();
		for (var i = 0; i < CountElements; i++)
        {
            for (var j = 0; j < _n; j++)
            {
	            if (Array![i] != _arrayA![j]) continue;
	            Array[i] = _arrayB![j];
	            countEncodedElements++;

            }
			
		}   
		TimeExecution.Stop();
		
		Console.WriteLine("Количество закодированных элементов: {0}", 
		TaskResult.Results = countEncodedElements.ToString());
		WriteTimeResult();		
	}
	
	protected override void ExecutionWithThread()
	{
        base.ExecutionWithThread();
        Array = _arrayС!.ToArray();
		
        TimeExecution.Start();
		StartExecutionThread();
		long result = 0;
		for (var i = 0; i < CountThreads; i++)
        {
			Threads[i].Join(); 
			result += ThreadReturns[i];
		}
		TimeExecution.Stop();
		
		Console.WriteLine("Количество закодированных элементов: {0}", 
		TaskResult.Results = result.ToString());
		WriteTimeResult();	
	} 
	
	protected override long CalculateThreadFunction(int begin, int end) 
	{
		var countEncodedElements = 0;
		for (var i = begin; i < end; i++)
        {
			for (var j = 0; j < _n; j++)
			{
				if (Array[i] != _arrayA[j]) continue;
				Array[i] = _arrayB[j];
				countEncodedElements++;

			}
			
		}
		
		return countEncodedElements;
	}
 	
}
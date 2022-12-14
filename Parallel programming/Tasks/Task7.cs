namespace Parallel_programming.Tasks;

public class Task7 : AbstractTask

{
    /// <summary>
    /// Список простых чисел.
    /// </summary>
    private int _primeNumbers;
	
    public Task7() : base("Task7",
        "Нахождение в последовательности всех простых чисел")
    {
        _primeNumbers = 0;
    }
	
    protected override void ExecutionWithoutThread()
    {
        base.ExecutionWithoutThread();
        TimeExecution.Start();
        _primeNumbers = Array.Count(element => IsPrimeNumber(element));
        // foreach (var element in Array)
        // {
        //     if (IsPrimeNumber(element))
        //     {
        //         _primeNumbers.Add(element);
        //     }
			     //
        // }
        TimeExecution.Stop();
		
        Console.WriteLine("Количество простых чисел: {0}",
            TaskResult.Results = _primeNumbers.ToString());
        WriteTimeResult();
    }
	
    /// <summary>
    /// Выявление, является ли число простым.
    /// </summary>
    private static bool IsPrimeNumber(long x)
    {
        var random = new Random();
        if(x == 2)
            return true;
        for(var i=0;i<100;i++){
            var a = (random.Next() % (x - 2)) + 2;
            if (Gcd(a, x) != 1)
                return false;			
            if( Pows(a, x-1, x) != 1)		
                return false;			
        }
        return true;
    }

    private static long Gcd(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }

    private static long Mul(long a, long b, long m)
    {
        if(b==1)
            return a;
        if (b % 2 != 0) return (Mul(a, b - 1, m) + a) % m;
        var t = Mul(a, b/2, m);
        return (2 * t) % m;
    }

    private static long Pows(long a, long b, long m)
    {
        if(b==0)
            return 1;
        if (b % 2 != 0) return (Mul(Pows(a, b - 1, m), a, m)) % m;
        var t = Pows(a, b/2, m);
        return Mul(t , t, m) % m;
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
		
        Console.WriteLine("Количество простых чисел: {0}",
            TaskResult.Results = result.ToString());
        WriteTimeResult();
		
    }
	
    protected override long CalculateThreadFunction(int begin, int end) 
    {
        return Array[begin..(end)].Count(element => IsPrimeNumber(element));
    }
    
}
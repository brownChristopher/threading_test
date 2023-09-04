//Testing multi threading with .Net 6

using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Begin\n");

        Console.WriteLine("This is a multithread test application to check performance time.\n");

        Stopwatch stopWatch = new();
        long time = 0;
        Thread main = Thread.CurrentThread;

        main.Name = "Main Thread";

        Console.WriteLine("Looping 1 000 000 000 times in a nested loop, 2 times\n");

        stopWatch.Start();
        Loop1();
        Loop1();
        stopWatch.Stop();

        time = stopWatch.ElapsedMilliseconds;

        Console.WriteLine("Single thread time : " + time + " (Thread actif : " + Thread.CurrentThread.Name + ")\n");

        stopWatch.Restart();
        Thread t1 = new(Loop1)
        {
            Name = "Thread 1"
        };
        Thread t2 = new(Loop1)
        {
            Name = "Thread 2"
        };

        t1.Start();
        t2.Start();

        while (t1.IsAlive == true || t2.IsAlive == true)
        {
            //waiting
        };

        stopWatch.Stop();

        time = stopWatch.ElapsedMilliseconds;

        Console.WriteLine("Multi thread time : " + time + " (Thread actif : " + Thread.CurrentThread.Name + ")\n");


        Console.WriteLine("End");
        Console.Read();
       
    }

    static void Loop1()
    {
        int result = 0;
        for (int i = 0; i < 250000000; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result++;
            }
            
        };

        Console.WriteLine("Result from Loop1 :" + result + " (Thread actif : " + Thread.CurrentThread.Name + ")");
    }
}
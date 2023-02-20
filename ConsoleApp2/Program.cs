

/* Resources Used
 * https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-7.0
 * 
 * 
 * 
 * 
 * 
 * 
 */

/* 
 Write a C# class to execute a number of pieces of work (actions) in the background (i.e. without blocking the program’s execution):

-               The actions must be executed sequentially – one at a time;

-               The actions must be executed in the order that they were added to the class;

-               The actions are not necessarily added all at the same time;

-               The actions are not necessarily all executed on the same thread;

*/



static void ThreadProc1()
{
    // 5000 to show it is running one after the other
    for (int i = 0; i < 5000; i++)
    {
        Console.WriteLine("Thread1Proc {0}", i);
    }
    // Get the current Thread and show the ID
    var th = Thread.CurrentThread;
    Console.WriteLine("Managed Thread #{0}", th.ManagedThreadId);
}


static void ThreadProc2()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Thread2Proc {0}", i);
    }
    var th = Thread.CurrentThread;
    Console.WriteLine("Managed Thread #{0}", th.ManagedThreadId);
}

// Create the new threads
Thread t1 = new Thread(new ThreadStart(ThreadProc1));
Thread t2 = new Thread(new ThreadStart(ThreadProc2));
Thread t3 = new Thread(new ThreadStart(ThreadProc2));
Thread t4 = new Thread(new ThreadStart(ThreadProc2));
Thread t5 = new Thread(new ThreadStart(ThreadProc2));


// Use Join to wait until the current thread has finished the task then start the next one.

t1.Start();
t1.Join();

// Wait 10 seconds (can be replaced with any time)
Thread.Sleep(10000);

t2.Start();
t2.Join();

t3.Start();
t3.Join();

t4.Start();
t4.Join();

t5.Start();

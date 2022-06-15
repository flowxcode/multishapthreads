// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, ts!");

var ids = new[] { "1", "2", "3" };

var manualResetEventSlim = new ManualResetEventSlim();

Thread[] threads = new Thread[3];

for (int i = 0; i < 3; i++)
{
    threads[i] = new Thread((obj) =>
    {
        Console.WriteLine(string.Format("thread {0} strated", obj as string));
        manualResetEventSlim.Wait();
        Console.WriteLine("thread {0} work in progress", obj as string);
    });

}

foreach (var t in threads)
{
    t.Start();
}


Console.WriteLine("wait");
Console.ReadKey();

manualResetEventSlim.Set();

Console.WriteLine("wait2");
Console.ReadKey();

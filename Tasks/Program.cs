using System;
using System.Threading;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Group<TestClass> group = new();
            TestClass o1 = new();
            TestClass o2 = new();
            TestClass o3 = new();
            group.Add(o1);
            group.Add(o2);
            group.Add(o3);
            group.Cast((i)=>
            {
                Console.WriteLine(i.ToString());
            });
            foreach(var i in group)
            {
                Console.WriteLine(i);
            }
            group.Clear();
            group.Cast((i)=> { Console.WriteLine("nmsl"); });
            //-------------------------------------

            CountDownTaskManager countDownTask = new(0.1f);
            countDownTask.AddTask(()=> { Console.WriteLine("cnmb"); });
            countDownTask.ClearAll();
            countDownTask.AddTask(() => { Console.WriteLine("ccnmb"); });
            Thread.Sleep(100000);


        }
    }
}

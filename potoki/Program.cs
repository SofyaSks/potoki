using static System.Console;
using System.Threading;

// 1

/*Thread th = Thread.CurrentThread;
th.Name = "Thread main";
WriteLine(th.Name);
WriteLine(th.IsAlive);
WriteLine(th.Priority);
WriteLine(th.ThreadState);*/


// 4
public class Param_
{
    public int x;
    public double y;
}

// 5
public class Counterr
{
    public int x;
    public double y;
    public Counterr(int x_, double y_)
    {
        x = x_;
        y = y_;
    }

    public void count_() // только object 
    {

        for (int i = 1; i <= 10; i++)
        {

            WriteLine($"Second thread:{i} {x * y * i}");
            Thread.Sleep(500);
        }
    }
}
class Program
{
    // 2
    /*public static void count_()
    {
        for (int i = 1; i <= 10; i++)
        {
            WriteLine($"Secong thread:{i }");
            Thread.Sleep(500);
        }
    }*/

    // 3 - передача параметров в поток
    /*public static void count_(object num) // только object 
    {
        for (int i = 1; i <= 10; i++)
        {
            int num_ = (int)num;
            WriteLine($"Second thread:{i} {num}");
            Thread.Sleep(500);
        }
    }*/

    // 4
    public static void count_(object num) // только object 
    {
        Param_ p1 = (Param_)num;
        for (int i = 1; i <= 10; i++)
        {
           
            WriteLine($"Second thread:{i} {p1.x*p1.y*i}");
            Thread.Sleep(500);
        }
    }

    static void Main(string[] args)
    {
        //2 
        /*Thread th1 = new Thread(new ThreadStart(count_));
        th1.Start();
        for (int i = 1; i <= 10; i++)
        {
            WriteLine($"Main thread:{i }");
            Thread.Sleep(300);
        }
        WriteLine("Ok");*/
        //ReadLine();

        // 3
        /*int x = 10;
        Thread th2 = new Thread(new ParameterizedThreadStart(count_));
        th2.Start(x);
        for (int i = 1; i <= 10; i++)
        {
            WriteLine($"Main thread:{i }");
            Thread.Sleep(300);
        }
        WriteLine("Ok");*/

        // 4
        /* Param_ p = new Param_();
         p.x = 2;
         p.y = 2.5;
         Thread th2 = new Thread(new ParameterizedThreadStart(count_));
         th2.Start(p); // небезопасный тип (можем передать любой тип так как это обджект)
         for (int i = 1; i <= 10; i++)
         {
             WriteLine($"Main thread:{i }");
             Thread.Sleep(300);
         }
         WriteLine("Ok");*/


        //5 

        Counterr p = new Counterr(2,3.5);
        
        Thread th2 = new Thread(new ThreadStart(p.count_));
        th2.Start(p); // небезопасный тип (можем передать любой тип так как это обджект)
        for (int i = 1; i <= 10; i++)
        {
            WriteLine($"Main thread:{i }");
            Thread.Sleep(300);
        }
        WriteLine("Ok");
    }
}

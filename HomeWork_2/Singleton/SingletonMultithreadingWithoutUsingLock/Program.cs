/* Потокобезопасная реализация без использования lock

    *  При применении паттерна синглтон в многопоточным программах мы можем столкнуться 
       с проблемой, которую можно описать следующим образом:
*/

using OperatingSystemLib.Classes;

namespace SingletonMultithreadingWithoutUsingLock;

class Program
{
    static void Main(string[] args)
    {
        (new Thread(() =>
        {
            ComputerWithoutUsingLock singleton1 = ComputerWithoutUsingLock.GetInstance();
            Console.WriteLine(singleton1.Date);
        })).Start();

        ComputerWithoutUsingLock singleton2 = ComputerWithoutUsingLock.GetInstance();
        Console.WriteLine(singleton2.Date);
    }
}
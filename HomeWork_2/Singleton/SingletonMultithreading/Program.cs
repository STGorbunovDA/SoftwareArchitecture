/* Синглтон и многопоточность

    *  При применении паттерна синглтон в многопоточным программах мы можем столкнуться 
       с проблемой, которую можно описать следующим образом:
*/

using OperatingSystemLib.Classes;
namespace SingletonMultithreading;

class Program
{
    static void Main(string[] args)
    {
        (new Thread(() =>
        {
            Computer comp2 = new Computer();
            comp2.OS = OS.getInstance("Windows 10");
            Console.WriteLine(comp2.OS.Name);

        })).Start();

        Computer comp = new Computer();
        comp.Launch("Windows 8.1");
        Console.WriteLine(comp.OS.Name);
        Console.ReadLine();
    }
}
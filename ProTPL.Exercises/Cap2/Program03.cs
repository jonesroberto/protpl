using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTPL.Exercises.Cap2
{
    public class Program03
    {
        //Example Listing 03
        public static void Listing03()
        {
            //usando uma Action delegate e um metodo nomeado
            Task task1 = new Task(new Action<object>(PrintMessage), "First Task");

            //usando um delegate anonimo
            Task task2 = new Task(delegate (object obj) { PrintMessage(obj); }, "Second Task");

            //usando lambda expression e um metodo nomeado
            //lambda não precisa de parametros
            //nesse caso eu usei apenas um parametro
            Task task3 = new Task((obj) => PrintMessage(obj), "Thrid Task");

            //usando uma lambda expression e um metodo anonimo
            Task task4 = new Task((obj) =>
            {
                Console.WriteLine($"Message {obj}");
            }, "Fourth Task");

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            Console.WriteLine("Main method complete. Press any key to finish!");
            Console.ReadKey();
        }

        private static void PrintMessage(object message)
        {
            Console.WriteLine($"Message {message}");
        }
    }
}

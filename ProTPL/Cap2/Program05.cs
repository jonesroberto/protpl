using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTPL.Cap2
{
    public class Program05
    {
        //Example Listing 05
        public static void Listing05()
        {
            Task<int> task1 = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                }
                return sum;
            });

            task1.Start();

            Console.WriteLine($"Result 1 {task1.Result}");

            Task<int> task2 = new Task<int>(obj =>
            {
                int sum = 0;
                int max = (int)obj;

                for (int i = 0; i < max; i++)
                {
                    sum += i;
                }

                return sum;
            }, 100);

            task2.Start();

            Console.WriteLine($"Result 2 {task2.Result}");

            Console.WriteLine("Main method complete . Press enter to finish");
            Console.ReadKey();

            //A leitura da propriedade Result aguarda até que a task1 que foi criada tenha 
            //sido concluída, isso significa que a task2 não será iniciada até que a task1 tenha sido concluída,
            //porque chamamo a Propriedade "Result" na primeira Task antes de criar e iniciar a segunda Task.
            //Podemos criar e iniciar uma nova Task usando o Task.Factory.StartNew (método estático)
            //Task.Factory também inclui o método StartNew<T> , que criará e iniciará uma Task<T> em um único passo
        }
    }
}

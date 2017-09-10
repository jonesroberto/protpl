using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProTPL.Exercises.Cap2
{
    public class Program12
    {
        //Example Listing 12

        public static void Listing12()
        {
            //DETERMINANDO SE UM TAREFA JÁ FOI CANCELADA
            /* Você pode verificar se uma tarefa já foi cancelada utilizando a propriedade IsCancelled, que retornar um booleano,
             * true se a tarefa foi cancelada e false se ainda continua sendo executada... */

            CancellationTokenSource tokenSource1 = new CancellationTokenSource();
            CancellationToken token1 = tokenSource1.Token;

            Task task1 = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token1.ThrowIfCancellationRequested();
                    Console.WriteLine("Task 1 - internal value {0}", i);
                }
            }, token1);

            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationToken token2 = tokenSource2.Token;

            Task task2 = new Task(() => {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token2.ThrowIfCancellationRequested();
                    Console.WriteLine("Task 2 - internal value {0}", i);
                }
            }, token2);

            task1.Start();
            task2.Start();

            tokenSource2.Cancel();

            Console.WriteLine("task1 foi cancelada? {0}", task1.IsCanceled);
            Console.WriteLine("task2 foi cancelada? {0}", task2.IsCanceled);
            Console.ReadLine();

            Console.WriteLine("o Programa foi finalizado, Pressione enter para fechar!");
            Console.ReadLine();

        }

    }
}

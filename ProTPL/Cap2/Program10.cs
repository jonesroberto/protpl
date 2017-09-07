using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProTPL.Cap2
{
    public class Program10
    {
        //Example Listing 10

        public static void Listing10()
        {
            // CANCELANDO VÁRIAS TAREFAS
            /* Você pode criar um único token ao criar Tasks e cancelar todas elas com uma única chamada 
               para o método CancellationTokenSource.Cancel(). o Exercício Cap2-10 mostra isso em ação.. */

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task task1 = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("Task 1 internal value {0}", i);
                }
            },token);

            Task task2 = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("Task 2 internal value {0}", i);
                }
            }, token);

            Console.WriteLine("Pressione enter para iniciar as Tasks");
            Console.WriteLine("Pressione enter novamente para cancelar as Tasks");
            Console.ReadLine();

            task1.Start();
            task2.Start();

            Console.ReadLine();

            Console.WriteLine("Cancelar Tasks");
            tokenSource.Cancel();

            Console.WriteLine("Programa finalizado, Pressione enter para encerrar");
            Console.ReadLine();

        }
    }
}

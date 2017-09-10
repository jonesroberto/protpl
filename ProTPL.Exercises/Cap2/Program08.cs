using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProTPL.Exercises.Cap2
{
    public class Program08
    {
        //Example Listing 08
        /* Explanation
            O exercício 2-8 é muito semelhante ao 2-7, com a adição do delegate de cancelamento 
            registrado usando o método Register() da classe CancelledToken , que é mostrado no código em 
            negrito no listagem. O método Register() leva uma instância de Action ou Action<object> . 
            Este último permite-lhe forneça um objeto estatal ao seu delegate da mesma maneira que você 
            faria quando passasse o estado para uma Task delegate. Quando a tarefa é cancelada, a ação 
            que você especificou é executada. No caso do exercício 2-8, isto é para imprimir uma mensagem simples.
        */

        public static void Listing08()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task task = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task Cancel detected");
                        throw new OperationCanceledException(token);
                    }
                    else
                    {
                        Console.WriteLine($"Int value {i}");
                    }
                }

            }, token);

            //create a cancellation token delegate
            token.Register(() =>
            {
                Console.WriteLine(">>>>>> Delegate Invoked");
            });

            Console.WriteLine("Press enter to start task");
            Console.WriteLine("Press enter again to cancel task");
            Console.ReadLine();

            task.Start();

            Console.ReadLine();

            Console.WriteLine("Cancelling Task");
            tokenSource.Cancel();

            Console.WriteLine("Main method complete. Press enter to finish");
            Console.ReadLine();
        }
    }
}

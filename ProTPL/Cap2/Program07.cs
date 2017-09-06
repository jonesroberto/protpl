using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProTPL.Cap2
{
    public class Program07
    {
        //Example Listing 07

        public static void Listing07()
        {
            //create cancellation token source
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            //create the cancellationToken
            CancellationToken token = tokenSource.Token;

            Task task = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task cancel detected");
                        throw new OperationCanceledException(token);
                    }
                    else
                    {
                        Console.WriteLine($"Int Value {i}");
                    }
                }
            }, token);

            //wait for input before we start the task
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

        /*  Explanation 
         *  
         Muitos corpos de tarefas contêm loops para processar dados iterativamente. 
         Você pode usar as iterações de loop para verificar sesua tarefa foi cancelada
         através da votação da propriedade IsCancellationRequested do CancelamentoTokenclasse.
         Se o imóvel retornar verdadeiro , você precisa sair do loop e liberar os recursos
         que você ésegurando (conexões de rede, contêineres de transações, etc.)
         Você também deve lançar uma instância de System.Threading.OperationCanceledException
         em sua tarefacorpo; É assim que você reconhece o cancelamento, e se você esquecer,
         o status de sua tarefa não serádefinido corretamente. O seguinte fragmento de 
         código mostra a anatomia básica de um loop de corpo da tarefa que buscacancelamento
         */
    }
}

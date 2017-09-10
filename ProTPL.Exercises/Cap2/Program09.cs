using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProTPL.Exercises.Cap2
{
    public class Program09
    {
        //Example Listing 09

        public static void Listing09()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            CancellationToken token = tokenSource.Token;

            Task task1 = new Task(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("");
                        throw new OperationCanceledException(token);
                    }
                    else
                    {
                        Console.WriteLine($"int value {i}");
                    }
                }
            }, token);

            Task task2 = new Task(() =>
            {
                //wait on handle
                token.WaitHandle.WaitOne();
                //mensagem de despedida
                Console.WriteLine(">>>>>>> Wait handle released");
            });

            //aguardando pela tecla para começar a trabalhar
            Console.WriteLine("Press enter to start Task");
            Console.WriteLine("Press enter again to cancel Task");
            Console.ReadLine();

            task1.Start();
            task2.Start();

            //lendo a linha do console
            Console.ReadLine();

            //cancelando a Task
            Console.WriteLine("Cancelling Task");
            tokenSource.Cancel();

            //aguardando pelo input do teclado para sair
            Console.WriteLine("Programa executado. Pressione enter para finalizar");
            Console.ReadLine();


        }

        /* 
         A terceira maneira de monitorar o cancelamento de tarefas é chamar o método WaitOne() 
         da propriedade CancelamentoToken.WaitHandle. Saberemos mais sobre wait em outros exercícios
         mais tarde, mas por enquanto basta saber que existe, quando você chama o método
         WaitOne(), ele bloqueia até que o método Cancel() seja chamado no CancellationTokenSource 
         que foi usado para criar o token cuja espera lidar com você está usando. Nesse exercício 2-9 
         tentei demonstrar, o uso de handle de monitoramento de cancelamento. Duas tarefas são criadas,
         uma das quais (task2) chama o método WaitOne(), que bloqueia até a primeira Tarefa ser cancelada

         * */
    }
}

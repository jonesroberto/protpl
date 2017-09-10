using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProTPL.Exercises.Cap2
{
    public class Program11
    {
        //Example Listing 11

        public static void Listing11()
        {
            //CRIANDO UM TOKE DE CANCELAMENTO COMPOSTO
            /*
                Você pode criar um token que é composto por vários CancellationTokenSource que serão cancelados
                se algum token subjacente for cancelado. Você faz isso chamando o método CancellationTokenSource.CreateLinkedTokenSource()
                e passando o CancellationToken que você deseja vincular, o resultado é um novo CancellationToken que você pode usar normalmente.
                Esse exercício demonstra como criar e usar um token de cancelamento composto
             */

            CancellationTokenSource tokenSource1 = new CancellationTokenSource();
            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationTokenSource tokenSource3 = new CancellationTokenSource();

            CancellationTokenSource compositoSource = CancellationTokenSource.CreateLinkedTokenSource(tokenSource1.Token, tokenSource2.Token, tokenSource3.Token);

            Task task1 = new Task(() => 
            {
                //aguarda até que o token seja cancelado
                compositoSource.Token.WaitHandle.WaitOne();
                // lança uma exceção de cancelamento
                throw new OperationCanceledException(compositoSource.Token);
            },compositoSource.Token);

            task1.Start();

            tokenSource2.Cancel();

            Console.WriteLine("O programa terminou, Pressione enter para finalizar!");
            Console.ReadLine();
        }

    }
}

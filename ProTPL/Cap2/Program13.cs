using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProTPL.Cap2
{
    public class Program13
    {
        //Example Listing 13

        public static void Listing13()
        {
            // Usando o wait para executar o próximo passo das tarefas

            /*
                A melhor maneira de colocar uma tarefa para aguardar é utilizando um controle de espera,
                do CancellationToken, que vimos nos exercícios anteriores. Criaremos uma instância do 
                CancellationTokenSource, e iremos ler a propriedade Token para obter a instância do CancellationToken,
                Use a propriedade WaitHandle e chame o método WaitOne(). Anteriormente utilizamos esse método sem parametros,
                porém ele tem outras sobrecargas que permitem passar um tempo de espera essas sobrecargas podem receber um
                Int32 ou um TimeSpan. Quando você especifica um período de tempo, o método WaitOne() colocará a Task em espera
                pelo período que passarmos por parametro.

             */

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task task1 = new Task(() => {
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    bool cancelled = token.WaitHandle.WaitOne(1000);
                    Console.WriteLine($"task1 - int value {i}.Cancelled? {cancelled}");

                    if (cancelled)
                        throw new OperationCanceledException(token);
                }
            },token);

            task1.Start();

            Console.WriteLine("Pressione enter para cancelar a tarefa");
            Console.ReadLine();

            tokenSource.Cancel();

            Console.WriteLine("O programa foi finalizado, Pressione enter para finalizar");
            Console.ReadLine();

            /* A Listagem 2-13 cria uma tarefa que imprime uma mensagem e, em seguida, espera por 10 segundos usando o método WaitOne(). 
             * Se você executar o código, as mensagens serão impressas até que você toque a tecla enter, nesse ponto o CancellationToken
             * será cancelado, fazendo com que a Task volte a ativar. Lembre-se, o método WaitOne() aguardará até que o tempo especificado
             * tenha decorrido ou o token tenha sido cancelado, o que ocorrer primeiro. O método CancellationToken.WaitHandle.WaitOne() 
             * retorna verdadeiro se o token tiver sido cancelado e falso se o tempo decorrido, fazendo com que a tarefa tenha despertado
             * porque o tempo especificado expirou. Prefiro essa técnica para colocar as tarefas a dormir por causa da resposta imediata 
             * a o tokenbeing foi cancelado. Você verá em um momento que esta é uma melhoria em relação ao modelo de threading clássico
             */

        }

    }
}

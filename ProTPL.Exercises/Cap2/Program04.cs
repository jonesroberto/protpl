using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTPL.Exercises.Cap2
{
    public class Program04
    {
        //Example Listing 04
        public static void Listing04()
        {
            string[] messages = { "First Task", "Second Task", "Thrid Task", "Fourth Task" };

            foreach (var item in messages)
            {
                Task task = new Task(obj => PrintMessage((string)obj), item);
                task.Start();
            }

            Console.WriteLine("Main method complete. Press any key to finish!");
            Console.ReadKey();
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine($"Message {message}");
        }

        //Observe que lançamos explicitamente os dados de estado em uma string para que 
        //possamos chamar o método PrintMessage() na expressão lambda na Listagem04. 
        //A única maneira de passar do estado para um construtor de tarefas está 
        //usando Action<object> , então você deve converter ou lançar explicitamente se 
        //precisar acessar os membros de um determinadotipo.A execução do código na 
        //Listagem 04, produz os seguintes resultados:

        //Retorno do foreach
        //Método principal completo.
        //Pressione Enter para terminar.
        //Mensagem: segunda tarefa
        //Mensagem: quarta tarefa 
        //Mensagem: Primeira tarefa
        //Mensagem: terceira tarefa
        // a ordem de retorno pode alterar de acordo com a execução,
        //o agendador de tarefa irá iniciar a task de acordo com o proceso interno dele.
    }
}

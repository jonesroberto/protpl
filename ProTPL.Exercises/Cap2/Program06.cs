using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTPL.Exercises.Cap2
{
    public class Program06
    {
        //Example Listing 06
        public static void Listing06()
        {
            Task<int> task1 = Task.Factory.StartNew<int>(() =>
            {
                int sum = 0;

                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                }
                return sum;
            });
        }

        //O método Task.Factory.StartNew inicializa a task imediatamente quando é chamado
        //removendo assim a necessidade de precisar executar task1.Start();
        // ele ainda aceita o tipo de retorno por parametro Task.Factory.StartNew<int> no nosso caso.
    }
}

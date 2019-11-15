using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sequence(8));
            Console.ReadKey();
        }
        static String Sequence(int N)
        {
            String result = N.ToString();
            if(N > 1)
            {
                result = Sequence(N - 1) + ","+  result;
            }
            else
            {
                result = 1.ToString();
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            _ArrayList _ArrayList = new _ArrayList(5);
            _ArrayList.Add(25);
            _ArrayList.Add("Barev");
            _ArrayList.Add('A');
            foreach (var item in _ArrayList)
            {
                Console.WriteLine(item);
            }

        }
    }
}

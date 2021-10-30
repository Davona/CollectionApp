using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp
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
            _Dictionary<string, int> dictionary = new _Dictionary<string, int>(5);
            dictionary.Add("Bar", 2);
            dictionary.Add("Bare", 5);
            dictionary.Add("Barv", 26);

            bool IsContain = dictionary.TryGetValue("Barv", out int value);
            Console.WriteLine(IsContain);
            Console.WriteLine(value);

            SortedList<int, string> dayOfWeek = new SortedList<int, string>();
            dayOfWeek.Add(3, "Wednesday");
            dayOfWeek.Add(5, "Friday");
            dayOfWeek.Add(7, "Sunday");
            dayOfWeek.Add(1, "Monday");
            dayOfWeek.Add(2, "Tuesday");
            dayOfWeek.Add(4, "Thursday");
            dayOfWeek.Add(6, "Saturday");
            foreach (KeyValuePair<int, string> pair in dayOfWeek)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
            Console.WriteLine("The key 1 contain in the SortedList:" + dayOfWeek.ContainsKey(1));
            Console.WriteLine("The key 5 contain in the SortedList:" + dayOfWeek.ContainsKey(5));
            Console.WriteLine("The key 10 contain in the SortedList:" + dayOfWeek.ContainsKey(10));
            Console.WriteLine("The key 50 contain in the SortedList:" + dayOfWeek.ContainsKey(50));
            Console.WriteLine();
            Console.WriteLine("The value Sunday contain in the SortedList:" + dayOfWeek.ContainsValue("Sunday"));
            Console.WriteLine("The value Friday contain in the SortedList:" + dayOfWeek.ContainsValue("Friday"));
            Console.WriteLine("The value May contain in the SortedList:" + dayOfWeek.ContainsValue("May"));
            Console.WriteLine("The value Wednesday contain in the SortedList:" + dayOfWeek.ContainsValue("Wednesday"));

            Stack<int> numbers = new Stack<int>();
            numbers.Push(5);
            numbers.Push(4);
            numbers.Push(3);
            numbers.Push(2);
            numbers.Push(1);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("Number of elements in Stack: {0}", numbers.Count);

            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop() + ",");
            }
            Console.WriteLine();
            Console.WriteLine("Number of elements in Stack: {0}", numbers.Count);

            Queue<char> letters = new Queue<char>();
            letters.Enqueue('H');
            letters.Enqueue('e');
            letters.Enqueue('l');
            letters.Enqueue('l');
            letters.Enqueue('o');
            foreach (var item in letters)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            if (letters.Count > 0)
            {
                Console.WriteLine(letters.Peek());
                Console.WriteLine(letters.Peek());
            }
            Console.WriteLine("The value H contain in the Queue:" + letters.Contains('H'));
            Console.WriteLine("The value a contain in the Queue:" + letters.Contains('a'));

            Hashtable romansNumbers = new Hashtable();

            romansNumbers.Add("I", 1);
            romansNumbers.Add("II", 2);
            romansNumbers.Add("III", 3);
            romansNumbers.Add("V", 5);
            romansNumbers.Add("X", 10);
            romansNumbers.Add("L", 50);
            romansNumbers.Add("C", 100);
            romansNumbers.Add("D", 500);
            romansNumbers.Add("M", 1000);

            foreach (DictionaryEntry item in romansNumbers)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            romansNumbers.Remove("II");
            romansNumbers.Remove("III");
            romansNumbers.Remove("M");

            Console.WriteLine("Key and Value pairs :");

            foreach (DictionaryEntry item in romansNumbers)
            {
                Console.WriteLine("{0} : {1} ", item.Key, item.Value);
            }

            Console.WriteLine("Total number of elements present" + " in my_hashtable:{0}", romansNumbers.Count);

            romansNumbers.Clear();

            Console.WriteLine("Total number of elements present in" + " my_hashtable:{0}", romansNumbers.Count);

        }
    }
}



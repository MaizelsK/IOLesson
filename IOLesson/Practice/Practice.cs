using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IOLesson
{
    public class Practice
    {
        static public void Task1()
        {
            char[] symbols = new char[256];
            for (int i = 0; i < 256; i++)
                symbols[i] = (char)(i);

            //foreach (var sym in symbols)
            //    Console.WriteLine(sym);

            byte[] array;
            using (FileStream stream = new FileStream("Practice1.txt", FileMode.OpenOrCreate))
            {
                array = new byte[stream.Length];

                stream.Read(array, 0, array.Length);
            }

            foreach (var symbol in symbols)
            {
                int count = 0;
                foreach (var sym in array)
                {
                    if (symbol.Equals((char)sym))
                        count++;
                }
                Console.WriteLine(symbol + " - " + count);
            }

            Console.ReadLine();
        }

        static public void Task2()
        {
            using (StreamWriter writer = new StreamWriter("Practice2.txt"))
            {
                writer.WriteLine("Kirill");
                writer.WriteLine("Maizels");
                writer.WriteLine(20);
            }
        }
    }
}
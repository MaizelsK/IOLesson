using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOLesson
{
    public class Homework
    {
        static public void Task1()
        {
            byte[] array;

            using (FileStream stream = new FileStream("Homework1.txt", FileMode.Open))
            {
                array = new byte[stream.Length];

                stream.Read(array, 0, array.Length);
            }

            using (FileStream stream = new FileStream("Homework1.txt", FileMode.Append))
            {
                stream.Write(array, 0, array.Length);
            }
        }

        static public void Task2()
        {
            byte[] array;
            int result = 0;

            using (FileStream stream = new FileStream("INPUT.txt", FileMode.OpenOrCreate))
            {
                array = new byte[stream.Length];

                stream.Read(array, 0, array.Length);

                string text = Encoding.UTF8.GetString(array);

                string[] numbers = text.Split(' ');

                foreach (var number in numbers)
                    result += int.Parse(number);
            }

            using (StreamWriter stream = new StreamWriter("OUTPUT.txt"))
            {
                stream.Write(result);
            }
        }
    }
}

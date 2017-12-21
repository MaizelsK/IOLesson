using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var drives = DriveInfo.GetDrives();


            Directory.CreateDirectory(@"C:\name_off_folder");
            if (Directory.Exists(@"C:\name_off_folder"))
            {
                var directories = Directory.EnumerateDirectories(@"C:\");

                File.Create(@"C:\name_off_folder\name_of_file.txt");

                FileInfo fileInfo = new FileInfo(@"C:\name_off_folder\name_of_file.txt");
                //fileInfo.OpenRead();

                foreach (var dir in directories)
                {
                    Console.WriteLine(dir);
                }
                Console.ReadLine();
            }
        }

        static void FileIO()
        {
            // Создадим приемник
            File.Create(@"C:\name_off_folder\receiver");

            // FileStream - для байтов, 
            //StreamReader /StreamWriter - для текста, 
            //BinaryReader /BinaryWriter - .bin

            // Создадим источник
            //File.Create(@"C:\name_off_folder\source");

            using (FileStream stream = new FileStream(@"C:\name_off_folder\source", FileMode.OpenOrCreate))
            {
                string text = "Мама мыла рану";
                byte[] array = Encoding.UTF32.GetBytes(text);
                stream.Write(array, 0, array.Length);
            }

            using (FileStream stream = new FileStream(@"C:\name_off_folder\source", FileMode.OpenOrCreate))
            {
                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);

                string text = Encoding.UTF32.GetString(array);
            }

            using (StreamReader reader = new StreamReader(@"C:\name_off_folder\name_of_file.txt"))
            {
                string text = reader.ReadToEnd();
            }

            using (StreamWriter writer = new StreamWriter(@"C:\name_off_folder\name_of_file.txt"))
            {
                string text = "some text";
                writer.WriteLine(text);
            }

            using (BinaryReader reader = new BinaryReader(File.Create(@"C:\name_off_folder\name_of_file.bin")))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                string sex = reader.ReadString();

                var anonim = new { Name = name, Age = age, Sex = sex };
            }
        }
    }
}

using System;
using System.IO;

namespace FileLocker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the file you would like to open exclusively.");
            var filename = Console.ReadLine();

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                Console.WriteLine("Bad file name");
                return;
            }

            try
            {
                using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    Console.WriteLine("File Locked");
                    Console.WriteLine("Press any key to unlock");
                    Console.ReadKey();
                    Console.WriteLine("File unlocked. Exiting");
                    stream.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}

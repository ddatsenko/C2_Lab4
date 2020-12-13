using System;
using System.IO;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1;
            string line2;
            int line1_number, line2_number;
            int product = new Int32();
            long sum = 0;
            int corrfiles = 0;
            for (int i = 10; i < 30; i++)
            {
                string path = @"C:\Users\Денис\Desktop\Uni\ООП\Lab4\txt\" + i + ".txt";
                try
                {
                    StreamReader f = new StreamReader(path);
                    line1 = f.ReadLine();
                    line1_number = Convert.ToInt32(line1);
                    line2 = f.ReadLine();
                    line2_number = Convert.ToInt32(line2);
                    checked
                    {
                        product = line1_number * line2_number;
                    }
                    Console.WriteLine("Product of numbers in the file named " + i + ".txt" + " equals: " + product);
                    sum += product;
                    corrfiles++;
                    f.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    using (StreamWriter no_file = new StreamWriter(@"C:\Users\Денис\Desktop\Uni\ООП\Lab4\txt\no_file.txt", true, System.Text.Encoding.Default))
                    {
                        no_file.WriteLine(i + ".txt");
                    }
                }
                catch (System.FormatException)
                {
                    using (StreamWriter bad_data = new StreamWriter(@"C:\Users\Денис\Desktop\Uni\ООП\Lab4\txt\bad_data.txt", true, System.Text.Encoding.Default))
                    {
                        bad_data.WriteLine(i + ".txt");
                    }
                }
                catch (System.OverflowException)
                {
                    using (StreamWriter overflow = new StreamWriter(@"C:\Users\Денис\Desktop\Uni\ООП\Lab4\txt\overflow.txt", true, System.Text.Encoding.Default))
                    {
                        overflow.WriteLine(i + ".txt");
                    }
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Немає доступу до файлу. Можливо його вже було створено");
                    break;
                }
            }
            Console.WriteLine("Correct files: {0}. Arithmetic mean of products of two numbers in each of those files equals to {1}", corrfiles, sum / (double)corrfiles);
            Console.ReadKey();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        public enum Gender { Male, Female };
        public struct thing
        {
            public int age;
            public string name;
            public Gender gender;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("         Patient Records");
            List<thing> thing2 = new List<thing>();
            string inp;
            int count = 0, count2;
            bool input = false;
            StreamWriter outputfile;
            outputfile = new StreamWriter("test.txt");
            do
            {
                Console.WriteLine("a. Add" + "\nd. Display" + "\ns. Stats" + "\nss. Save" + "\nq. Quit"+"\nl. Load");
                inp = Console.ReadLine();
                if (inp == "a")
                {
                    addInfo(ref thing2, ref count);
                }
                else if (inp == "d")
                {
                    count2 = count - 1;
                    displayInfo(ref thing2, count);
                }
                else if (inp == "s")
                {

                    stats(ref thing2, count);
                }
                else if (inp == "q")
                {
                    input = true;
                }
                else if (inp == "ss")
                {
                    Console.WriteLine("Input file name: ");
                    string butt = Console.ReadLine();

                    save(ref thing2, count, outputfile, ref butt);
                }
                else if (inp == "l") {
                    GetFile("Enter filename");

                }
            } while (!input);

        }
        static void addInfo(ref List<thing> thing2, ref int count)
        {

            int ag;
            string na, gen;
            bool input = false, input2 = false;
            var cd = new thing();
            do
            {
                Console.WriteLine("Enter the patient age: ");
                input = int.TryParse(Console.ReadLine(), out ag);
                cd.age = ag;

            }
            while (!input);
            Console.WriteLine("Enter the patient name: ");
            na = Console.ReadLine();
            cd.name = na;

            do
            {

                Console.WriteLine("Enter the patient sex male/female: ");
                gen = Console.ReadLine();
                if (gen == "male" || gen == "Male" || gen == "m" || gen == "M")
                {
                    cd.gender = Gender.Male;

                    input2 = true;
                }
                else if (gen == "female" || gen == "Female" || gen == "f" || gen == "F")
                {
                    cd.gender = Gender.Female;

                    input2 = true;
                }
            } while (!input2);
            count++;
            thing2.Add(cd);
        }
        static void displayInfo(ref List<thing> thing2, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Patient: {0}", thing2[i].name);
                Console.WriteLine("Patient age: {0}", thing2[i].age);
                Console.WriteLine("Patient gender: {0}", thing2[i].gender);
            }
        }
        static void stats(ref List<thing> thing2, int count)
        {
            int[] arr = thing2.Select(item => item.age).ToArray();
            thing[] thing3 = thing2.ToArray();
            int index = Array.IndexOf(arr, arr.Max());
            Console.WriteLine("Patient: {0}", thing2[index].name);
            Console.WriteLine("Patient age: {0}", thing2[index].age);
            Console.WriteLine("Patient gender: {0}", thing2[index].gender);
            int male = 0, female = 0;
            for (int i = 0; i < count; i++)
            {
                int w = (int)thing3[i].gender;
                if (w == 0)
                {
                    male++;
                }
                else if (w == 1)
                {
                    female++;
                }
            }
            Console.WriteLine("There are {0} males and {1} females: ", male, female);
        }
        static void save(ref List<thing> thing2, int count, StreamWriter input, ref string thing3)
        {
            Console.WriteLine("Input file name: ");
            thing3 = Console.ReadLine();
            try
            {

                input = new StreamWriter(thing3);
                try
                {
                    input.WriteLine("{0}, {1}, {2}", thing2[count - 1].name, thing2[count - 1].age, thing2[count - 1].gender);

                    try
                    {
                        input.Close();
                    }
                    catch (Exception eClose)
                    {
                        Console.WriteLine("A error closing Test.txt occurred.");
                        Console.WriteLine("The error was: {0}", eClose.Message);
                    }
                }
                catch (Exception eWrite)
                {
                    Console.WriteLine("A error writing to Test.txt occurred.");
                    Console.WriteLine("The error was: {0}", eWrite.Message);
                }
            }
            catch (Exception eOpen)
            {
                Console.WriteLine("A error opening Test.txt occurred.");
                Console.WriteLine("The error was: {0}", eOpen.Message);
            }
        }
        static void GetFile(string thing)
        {
            try
            {
                StreamReader srInFile;
                srInFile = new StreamReader(thing);
                int iInput;
             
                try
                {
                    while ((iInput = srInFile.Read()) != -1)
                        Console.Write((char)iInput);

                    try
                    {
                        srInFile.Close();
                    }
                    catch (Exception eClose)
                    {
                        Console.WriteLine("Error reading file: {0}", eClose.Message);
                    }
                }
                catch (IOException eRead)
                {
                    Console.WriteLine("Error reading file: {0}", eRead.Message);
                }
            }
            catch (Exception eOpen)
            {
                Console.WriteLine("Error opening file: {0}", eOpen.Message);
            }

        }
    }
}





using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    //class Person to save detail of each list
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personlist = new List<Person>();
            //File is located in bin/Debug
            try
            {
                StreamReader sr = new StreamReader("unsorted-names-list.txt");
                while (!sr.EndOfStream)
                {
                    Person personobj = new Person();
                    string data = sr.ReadLine();
                    Console.WriteLine();
                    string[] names = data.ToString().Trim().Split(new char[]{' '}, 2);
                    //check whether the name has a given name
                    if (names.Length == 1) 
                    {
                        personobj.FirstName = "";
                        personobj.LastName = names[0];
                    }
                    else
                    {
                        personobj.FirstName = names[0];
                        personobj.LastName = names[1];
                    }
                    personlist.Add(personobj);

                }
                sr.Close();
                //sort list based on first name then by given name
                var sortedlist = personlist.OrderBy(p => p.FirstName).ThenBy(p1 => p1.LastName);
                StreamWriter sw = new StreamWriter("sorted-names-list.txt");
                Console.WriteLine();
                //write the sorted list on text and screen
                foreach (Person p in sortedlist)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName);
                    sw.WriteLine(p.FirstName + " " + p.LastName);
                }
                sw.Close();
                Console.ReadLine();
            }
            //If file does not exist, throw file not found exception, as no point in continuing
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            
        }
    }
}

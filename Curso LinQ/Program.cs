using ExampleLinq.Data;
using ExampleLinq.XML;
using LinqExample;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExampleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageXML.XMLExample();
        }

        static void LinqToEntity()
        {
            //using (var context = new Context())
            //{
            //    PersonEntity person = new PersonEntity()
            //    {
            //        FiscalDoc = "A0000000B",
            //        Name = "Antonio",
            //        SurName = "Zambrano",
            //        Age = 32
            //    };

            //    context.Persons.Add(person);

            //    context.SaveChanges();

            //    var javier = context.Persons.Where(c => c.FiscalDoc == "A0000000A").FirstOrDefault();

            //    var nullPerson = context.Persons.Where(c => c.FiscalDoc == "A0000000B").DefaultIfEmpty(new PersonEntity());

            //}

            using (var context = new Context())
            {
                var query = context.Persons.Where(c => c.FiscalDoc == "A0000000A").Select(c => c.Name).ToList();
            }
        }

        static void Agregacion()
        { 
            List<Person> person = new List<Person>()
            {
               new Person() { Name = "Javier", Age = 29 },
                new Person() { Name = "Julian", Age = 54 },
                new Person() { Name = "Rosa", Age = 18 }
            };

            var sum = person.Sum(p => p.Age);

            var ave = person.Average(p => p.Age);

            Console.WriteLine("Sum:" + sum);

            Console.WriteLine("ave:" + ave);

            Console.ReadLine();


            person.First();
            person.Last();
            person.ElementAt(2);

            //Average()
            //Coun()
            //LongCount()
            //Max()
            //Min()
            //Sum()
        }

        static void Agrupacion()
        {
            List<Child> childrens = new List<Child>()
                   {
                       new Child() { Name = "Antonio", Parent = "Javier" },
                       new Child() { Name = "Samuel", Parent = "Rosa" },
                       new Child() { Name = "Noa", Parent = "Javier" },
                       new Child() { Name = "Izan", Parent = "Rosa" },
                       new Child() { Name = "Maria", Parent = "Julian" },
                   };

            var groupBy = childrens.GroupBy(c => c.Parent);

            Console.WriteLine("Join");
            foreach (var result in groupBy)
            {
                Console.WriteLine(result.Key + "-" + result.Count());
            }



            Console.ReadLine();
        }

        static void Combinacion()
        {
            List<Person> person = new List<Person>()
            {
               new Person() { Name = "Javier", Age = 29 },
                new Person() { Name = "Julian", Age = 54 },
                new Person() { Name = "Rosa", Age = 18 }
            };

            List<Child> childrens = new List<Child>()
                   {
                       new Child() { Name = "Antonio", Parent = "Javier" },
                       new Child() { Name = "Noa", Parent = "Javier" },
                       new Child() { Name = "Izan", Parent = "Rosa" }
                   };

            var childParentList = person.Join(childrens, p => p.Name, c => c.Parent, (p, c) => new { NameParent = p.Name, ChildName = c.Name });

            Console.WriteLine("Join");
            foreach (var result in childParentList)
            {
                Console.WriteLine(result.NameParent + "-" + result.ChildName);
            }

            Console.ReadLine();
        }

        static void Particionado()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Take
            var take = numbers.Take(2);

            //TakeWhile
            var takeWhile = numbers.TakeWhile(n => n < 4);

            Console.WriteLine("Take");
            foreach (var result in take)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();

            Console.WriteLine("TakeWhile");
            foreach (var result in takeWhile)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();

            //Skip
            var skip = numbers.Skip(2).Take(2);
            Console.WriteLine("Skip");
            foreach (var result in skip)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

        static void Proyeccion()
        {
            List<Person> person = new List<Person>()
            {
               new Person() 
               { 
                   Name = "Javier", 
                   Age = 29, 
                   Childrens = new List<Child>() 
                   { 
                       new Child() { Name = "Antonio"},
                       new Child() { Name = "Noa"},
                       new Child() { Name = "Izan"}
                   } 
               },
                new Person() { Name = "Julian", Age = 54, Childrens = new List<Child>()  },
                new Person() { Name = "Rosa", Age = 18, Childrens = new List<Child>()  }
            };


            var select = person.Select(p => p.Name);

            Console.WriteLine("Select Name");
            foreach (var result in select)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();

            var selecChild = person.Select(p => p.Childrens).SelectMany(c => c);

            Console.WriteLine("Select Child");
            foreach (var result in selecChild)
            {
                Console.WriteLine(result.Name);
            }

            Console.ReadLine();
        }

        static void Cuantificacion()
        {
            List<Person> person = new List<Person>()
            {
               new Person() { Name = "Javier", Age = 29 },
                new Person() { Name = "Julian", Age = 54 },
                new Person() { Name = "Rosa", Age = 18 }
            };

            //Any
            var any = person.Any(p => p.Age > 20);
            Console.WriteLine("Any:" + any);

            //All
            var all = person.All(p => p.Age > 10);
            Console.WriteLine("All:" + all);

            //Contains
            var contain = person.Contains(new Person() { Name = "Javier", Age = 29 }, new PersonCompare());
            Console.WriteLine("Contains:" + contain);

            Console.ReadLine();
        }

        static void Conjunto()
        {
            //List<Person> person = new List<Person>()
            //{
            //    new Person() { Name = "Javier", Age = 29 },
            //    new Person() { Name = "Julian", Age = 54 },
            //    new Person() { Name = "Rosa", Age = 18 },
            //    new Person() { Name = "Julian", Age = 54 }
            //};

            //var distinct = person.Distinct(new PersonCompare());

            //Console.WriteLine("Distinct");
            //foreach (var result in distinct)
            //{
            //    Console.WriteLine(result.Name + result.Age);
            //}

            //Console.ReadLine();
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };

            //Distinct
            var distinct = numbers.Distinct();

            Console.WriteLine("Distinct");
            foreach (var result in distinct)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();

            //Except
            List<int> numbersExcept = new List<int>() { 0, 1, 2 };

            var except = numbers.Except(numbersExcept);

            Console.WriteLine("Except");
            foreach (var result in except)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();

            //Union
            List<int> numbersUnion = new List<int>() { 10, 11, 12 };

            var union = numbers.Union(numbersUnion);

            Console.WriteLine("Union");
            foreach (var result in union)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();

        }

        static void Ordenacion()
        {
            List<Person> person = new List<Person>() 
            { 
                new Person() { Name = "Javier", Age = 29 },
                new Person() { Name = "Julian", Age = 54 },
                new Person() { Name = "Rosa", Age = 18 },
            };

            var order = person.OrderBy(p => p.Age);

            var orderDesc = person.OrderByDescending(p => p.Age);

            Console.WriteLine("Order");
            foreach (var result in order)
            {
                Console.WriteLine(result.Name + result.Age);
            }

            Console.WriteLine("OrderDesc");
            foreach (var result in orderDesc)
            {
                Console.WriteLine(result.Name + result.Age);
            }

            Console.ReadLine();
        }

        static void Init()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<int> filterNumbers = new List<int>();

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    filterNumbers.Add(num);
                }
            }

            Console.WriteLine("Foreach");
            foreach (var result in filterNumbers)
            {
                Console.WriteLine(result);
            }

            // Síntaxis de Consulta
            var query = from num in numbers
                        where num % 2 == 0
                        select num;

            Console.WriteLine("LINQ - Sintaxis de Consulta");
            foreach (var result in query)
            {
                Console.WriteLine(result);
            }

            // Síntaxis de Método
            var lambda = numbers.Where(num => num % 2 == 0);

            Console.WriteLine("LINQ - Sintaxis de Método");
            foreach (var result in query)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
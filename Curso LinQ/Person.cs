using System.Collections.Generic;

namespace LinqExample
{
    public class Person
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public int Age { get; set; }

        public List<Child> Childrens { get; set; }
    }

    public class Child
    {
        public string Name { get; set; }

        public string Parent { get; set; }
    }

    public class PersonCompare : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Name == y.Name && x.SurName == y.SurName && x.Age == y.Age;
        }

        public int GetHashCode(Person person)
        {
            if (ReferenceEquals(person, null)) return 0;

            int hashName = person.Name.GetHashCode();

            int hashSurName = string.IsNullOrEmpty(person.SurName) ? 0 : person.SurName.GetHashCode();

            int hasAge = person.Age.GetHashCode();

            return hashName ^ hashSurName ^ hasAge;
        }
    }
}

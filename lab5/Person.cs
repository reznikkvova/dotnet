using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Person
    {
        private readonly string _name;
        private readonly string _surname;
        private DateTime _dateOfBirth;

        public string Name => _name;
        public string Surname => _surname;
        public DateTime DateOfBirth => _dateOfBirth;

        public int YearOfBirth
        {
            set => _dateOfBirth = new DateTime(value, _dateOfBirth.Month, _dateOfBirth.Day);
            get => _dateOfBirth.Year;
        }



        public Person DeepCopy()
        {
            return new Person(Name, Surname, new DateTime(DateOfBirth.Year, DateOfBirth.Month, DateOfBirth.Day));
        }


        public Person(string name, string surname, DateTime dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
        }

        public Person()
        {
            _name = "";
            _surname = "";

            _dateOfBirth = new DateTime(1, 1, 1);
        }


        public override bool Equals(object obj)
        {
            if (null == obj || !(GetType() == obj.GetType()))
            {
                return false;
            }

            return ToString() == ((Person)obj).ToString();
        }


        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(Person obj1, Person obj2)
        {
            if (null == obj1 && null == obj2)
            {
                return true;
            }
            if (null == obj1 || null == obj2)
            {
                return false;
            }

            return obj1.ToString() == obj2.ToString();
        }

        public static bool operator !=(Person obj1, Person obj2)
        {
            return !(obj1 == obj2);
        }


        public override string ToString()
        {
            return $"{ToShortString()}, {DateOfBirth:yyyy/MM/dd}";
        }

        public virtual string ToShortString()
        {
            return $"{Name} {Surname}";
        }
    }
}

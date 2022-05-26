using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Team : INameAndCopy
    {
        public string name { get; set; }

        protected string _nameOfOrganization;

        protected int _registrationNumber;

        public int RegistrationNumber
        {
            get => _registrationNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Реєстраційний номер має бути більше нуля");
                }

                _registrationNumber = value;
            }
        }


        public string NameOfOrganization { get; }

        public Team(string nameOfOrganizationm, int registrationNumber)
        {
            _nameOfOrganization = nameOfOrganizationm;
            _registrationNumber = registrationNumber;
        }

        public Team()
        {
            _nameOfOrganization = "";
            _registrationNumber = -1;
        }


        public virtual object DeepCopy()
        {
            return new Team(_nameOfOrganization, _registrationNumber);
        }

        public override bool Equals(object obj)
        {
            if (null == obj || !(GetType() == obj.GetType()))
            {
                return false;
            }

            return ToString() == ((Team)obj).ToString();
        }


        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        public static bool operator ==(Team obj1, Team obj2)
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

        public static bool operator !=(Team obj1, Team obj2)
        {
            return !(obj1 == obj2);
        }

        public override string ToString()
        {
            return $"{_nameOfOrganization}, {_registrationNumber}";
        }
    }
}

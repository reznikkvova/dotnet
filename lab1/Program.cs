using System;
using System.Linq;


namespace Lab1
{
    class Person
    {
        private string _name;
        private string _surname;
        private DateTime _dateOfBirth;

        public string Name => _name;
        public string Surname => _surname;
        public DateTime DateOfBirth => _dateOfBirth;

        public int YearOfBirth
        {
            set => _dateOfBirth = new DateTime(value, _dateOfBirth.Month, _dateOfBirth.Day);
            get => _dateOfBirth.Year;
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

           _dateOfBirth = new DateTime(1,1,1);
       }

       public override string ToString()
       {
           return $"{ToShortString()}, {DateOfBirth.ToString("yyyy/MM/dd")}";
       }

       public virtual string ToShortString()
       {
           return $"{Name} {Surname}";
       }
    }



    internal class Program
    {

        enum TimeFrame
        {
            Year,
            TwoYears,
            Long
        }

        class Paper
        {
            public string _name;
            public Person _author;
            public DateTime _publishDate;

            public Paper(string name, Person author, DateTime publishDate)
            {
                _name = name;
                _author = author;
                _publishDate = publishDate;
            }

            public Paper()
            {
                _author = new Person();
                _name = "";
                _publishDate = new DateTime(1, 1, 1);
            }

            public override string ToString()
            {
                return $"Name: {_name}, Author: {_author}, Publish date: {_publishDate.ToString("yyyy/MM/dd")}";
            }
        }

        class ResearchTeam
        {

            private string _topic;
            private string _nameOfOrganization;
            private int    _registrationNumber;
            private TimeFrame _duration;
            private Paper[] _papers;

            public ResearchTeam()
            {
                _topic = "";
                _nameOfOrganization = "";
                _registrationNumber = -1;
                _duration = TimeFrame.Long;
            }

            public ResearchTeam(
                string topic,
                string nameOfOrganization,
                int registrationNumber,
                TimeFrame duration
            )
            {
                _topic = topic;
                _nameOfOrganization = nameOfOrganization;
                _registrationNumber = registrationNumber;
                _duration = duration;
            }



            public string Topic
            {
                get => _topic;
                set => _topic = value;
            }

            public string NameOfOrganization
            {
                get => _nameOfOrganization;
                set => _nameOfOrganization = value;
            }

            public int RegistrationNumber
            {
                get => _registrationNumber;
                set => _registrationNumber = value;
            }

            public TimeFrame Duration
            {
                get => _duration;
                set => _duration = value;
            }

            public Paper[] Papers
            {
                get => _papers;
            }


            public Paper Paper
            {
                get => Papers.Length == 0 ? null : Papers.OrderByDescending(p => p._publishDate).ToArray().First();
            }

            public bool this[TimeFrame timeFrame]
            {
                get => Duration == timeFrame;
            }

            public void AddPapers(Paper[] newPapers)
            {
                _papers = null == _papers ? newPapers : _papers.ToList().Concat(newPapers.ToList()).ToArray();
            }

            public override string ToString()
            {

                return null == Papers
                    ? $"{ToShortString()}"
                    : $"{ToShortString()}, \nPapers: \n" + string.Join("\n", Papers.ToList());
            }


            public virtual string ToShortString()
            {
                return $"Topic: {_topic}, NameOfOrganization: {_nameOfOrganization}, RegistrationNumber: {_registrationNumber}, Duration: {_duration}";
            }

        }






        public static void Main(string[] args)
        {
            var researchTeam = new ResearchTeam();
            Console.WriteLine($"{researchTeam.ToShortString()} \n");

            Console.WriteLine($"Duration Long: {researchTeam[TimeFrame.Long]}");
            Console.WriteLine($"Duration TwoYears: {researchTeam[TimeFrame.TwoYears]}");
            Console.WriteLine($"Duration Year: {researchTeam[TimeFrame.Year]} \n");

            researchTeam.Topic = "Topic";
            researchTeam.NameOfOrganization = "Super Org";
            researchTeam.RegistrationNumber = 1;
            researchTeam.Duration = TimeFrame.Year;
            Console.WriteLine(researchTeam);


            Paper[] papers =
            {
                new Paper("Name1", new Person("Person1", "Person1", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
                new Paper("Name2", new Person("Person2", "Person2", new DateTime(1997,1,1)), new DateTime(2021,1,1)),
                new Paper("Name3", new Person("Person3", "Person3", new DateTime(1993,1,1)), new DateTime(2022,4,1)),
            };

            researchTeam.AddPapers(papers);

            Console.WriteLine(researchTeam);
            Console.WriteLine($"Last published: {researchTeam.Paper}");
        }
    }
}
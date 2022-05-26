using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace Lab2
{


    internal class Program
    {


        interface INameAndCopy
        {
            string name { get; set; }

            object DeepCopy();

        }


       class Team : INameAndCopy
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

                return ToString() == ((Team) obj).ToString();
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
                if(null == obj1 || null == obj2)
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


        class Person
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

                _dateOfBirth = new DateTime(1,1,1);
            }


            public override bool Equals(object obj)
            {
                if (null == obj || !(GetType() == obj.GetType()))
                {
                    return false;
                }

                return ToString() == ((Person) obj).ToString();
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
                if(null == obj1 || null == obj2)
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



            public virtual Paper DeepCopy()
            {
                return new Paper(_name, _author.DeepCopy(), new DateTime(_publishDate.Year, _publishDate.Month, _publishDate.Day));
            }


            public override string ToString()
            {
                return $"Name: {_name}, Author: {_author}, Publish date: {_publishDate.ToString("yyyy/MM/dd")}";
            }
        }

        class ResearchTeam : Team
        {

            private string _topic;

            private TimeFrame _duration;
           // private Paper[] _papers;

          private ArrayList _papers;

          private ArrayList _participants;
          public string name { get; set; }


          public ArrayList Participants { get; }

          public Team Team
          {
              get
              {
                  return Participants?.Cast<Team>().FirstOrDefault(t => ToString() == t.ToString());
              }
          }



          public IEnumerable<Person> GetPersonWithoutPaper()
          {
              foreach (Person person in Participants)
              {
                  var exists = false;
                  foreach (Paper paper in Papers)
                  {
                      if (paper._author == person)
                      {
                          exists = true;
                      }

                      if (!exists)
                      {
                          yield return person;
                      }

                  }
              }
          }


          public IEnumerable GetLastPapers(int diff)
          {
              var currentYear = DateTime.Now.Year;

              foreach (Paper p in Papers)
              {
                  if ((currentYear - p._publishDate.Year) <= diff)
                  {
                      yield return p;
                  }

              }
          }

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

            public ResearchTeam DeepCopy()
            {
                var rt = new ResearchTeam(Topic, NameOfOrganization, RegistrationNumber, Duration);
                if (Papers != null)
                {
                    var clonePapers = new Paper[] { };
                    var ind = 0;

                    foreach (Paper p in Papers)
                    {
                        clonePapers[ind] = p.DeepCopy();
                        ind++;
                    }

                    rt.AddPapers(clonePapers);
                }

                return rt;
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

            public ArrayList Papers
            {
                get => _papers;
            }


            public Paper Paper
            {
                get
                {
                    if (_papers.Count == 0)
                    {
                        return null;
                    }

                    var comp = new Paper();

                    foreach (Paper p in _papers)
                    {
                        if (comp._publishDate < p._publishDate)
                        {
                            comp = p;
                        }
                    }

                    return comp;
                }
            }

            public bool this[TimeFrame timeFrame]
            {
                get => Duration == timeFrame;
            }

            public void AddPapers(Paper[] newPapers)
            {

                if (null == _papers)
                {
                    _papers = new ArrayList();
                }


                foreach (var t in newPapers)
                {
                    _papers.Add(t);
                }
            }

            public override string ToString()
            {

                return null == Papers
                    ? $"{ToShortString()}"
                    : $"{ToShortString()}, \nPapers: \n" + string.Join("\n", Papers);
            }


            public virtual string ToShortString()
            {
                return $"Topic: {_topic}, NameOfOrganization: {_nameOfOrganization}, RegistrationNumber: {_registrationNumber}, Duration: {_duration}";
            }

        }






        public static void Main(string[] args)
        {
            var team1 = new Team("Team1", 1);
            var team2 = new Team("Team1", 1);
            Console.WriteLine($"hash team 1: {team1.GetHashCode()}");
            Console.WriteLine($"hash team 2: {team2.GetHashCode()}");



            try
            {
                team1.RegistrationNumber = -10000000;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            var researchTeam = new ResearchTeam("Topic1", "Org", 111, Program.TimeFrame.Long);
            Console.WriteLine("Team: " + researchTeam.Team);

            var researchTeamClone = researchTeam.DeepCopy();

            researchTeamClone.name = "Copy";

            Console.WriteLine($"origin name: {researchTeam.name}, clone name: {researchTeamClone.name}");



            Console.WriteLine("Учасники без публікацій");
            foreach (var person in researchTeam.GetPersonWithoutPaper())
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Всі публікації за два роки");
            foreach (var paper in researchTeam.GetLastPapers(2))
            {
                Console.WriteLine(paper);
            }



        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab5
{
    public class ResearchTeam : Team, IComparer<ResearchTeam>
    {

        private string _topic;

        private TimeFrame _duration;

        private Team _team;

        private List<Paper> _papers;

        private List<Person> _participants;
        public string name { get; set; }

        public List<Person> Participants
        {
            get => _participants;
            set => _participants = value;
        }

        public Team Team
        {
            get => _team;
            set => _team = value;
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
                }

                if (!exists)
                {
                    yield return person;
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
            _participants = new List<Person>();
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
            _participants = new List<Person>();
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

        public List<Paper> Papers
        {
            get => _papers;
            set => _papers = value;
        }

        public void AddPapers(Paper[] newPapers)
        {

            if (null == _papers)
            {
                _papers = new List<Paper>();
            }


            foreach (var t in newPapers)
            {
                _papers.Add(t);
            }
        }

        public bool this[TimeFrame timeFrame]
        {
            get => Duration == timeFrame;
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

        public int Compare(ResearchTeam a, ResearchTeam b)
        {
            return a._topic.CompareTo(b._topic);
        }

        public ResearchTeam DeepCopy()
        {

            using (MemoryStream memory = new MemoryStream())
            {
                XmlSerializer XML = new XmlSerializer(typeof(ResearchTeam));
                XML.Serialize(memory, this);
                memory.Seek(0, SeekOrigin.Begin);
                ResearchTeam team = (ResearchTeam)XML.Deserialize(memory);
                return team;
            }

        }
        public bool Save(string filename)
        {

            try
            {
                if (!File.Exists(filename)) { Console.WriteLine("файл було створено"); }
                using (FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(ResearchTeam));
                    XML.Serialize(fileStream, this);
                }
                Console.WriteLine("Серіалізація відбулася успішно");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка при запису об'єкта у файл\n{e}\n");
                return false;
            }

        }

        public bool Load(string filename)
        {
            try
            {
                if (!File.Exists(filename)) { Console.WriteLine("Вказаного файлу не існує"); }
                using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(ResearchTeam));

                    var team = (ResearchTeam)XML.Deserialize(fileStream);
                    Participants = team.Participants; 
                    Topic = team.Topic;
                    NameOfOrganization = team.NameOfOrganization;
                    RegistrationNumber = team.RegistrationNumber;
                    Duration = team.Duration;
                    Papers = team.Papers;
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка при десеріалізації\n{e}\n");
                return false;
            }
        }

        public static bool Save(string filename, ResearchTeam team)
        {
            return team.Save(filename);
        }

        public static bool Load(string filename, ResearchTeam team)
        {
            return team.Load(filename);
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Введіть назву публікації, ім'я прізвище та дату народження автора статті, дату публікації формату yyyy-mm-dd.\nВ якості розділювачів використовуйте символ ','");
            string[] information = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string name = information[0];
                Person person = new Person(information[1], information[2], DateTime.Parse(information[3]));
                AddPapers(new Paper[] { new Paper(name, person, DateTime.Parse(information[4])) });
                Console.WriteLine("Додано успішно");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Увага! Допущені помилки при введені\n{e}\n");
                return false;
            }
        }


    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class ResearchTeam : Team
    {

        private string _topic;

        private TimeFrame _duration;
        // private Paper[] _papers;

        private ArrayList _papers;

        private ArrayList _participants;
        public string name { get; set; }


        public ArrayList Participants 
        {
            get => _participants;
            set => _participants = value;
        }

        public Team Team
        {
            get
            {
                return new Team(NameOfOrganization, RegistrationNumber);
            }
            init
            {
                NameOfOrganization = value.NameOfOrganization;
                RegistrationNumber = value.RegistrationNumber;
                name = value.name;
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

        public override ResearchTeam DeepCopy()
        {
            var rt = new ResearchTeam(Topic, NameOfOrganization, RegistrationNumber, Duration);
            if (Papers != null)
            {
                var clonePapers = new List<Paper>();
                foreach (Paper p in Papers)
                {
                    clonePapers.Add(p.DeepCopy());
                }

                rt.AddPapers(clonePapers.ToArray());
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
}

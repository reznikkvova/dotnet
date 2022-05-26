using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class ResearchTeamCollection
    {
        private List<ResearchTeam>? _researchTeams;

        public void AddDefaults()
        {
            if (_researchTeams == null)
            {
                _researchTeams = new List<ResearchTeam>();
            }

            var test = new ResearchTeam("Test", "Test", 12345, TimeFrame.Year);
            test.Participants = new List<Person>
            {
                new Person("Person1", "Person1",new DateTime(1999,1,1)),
                new Person("Person2", "Person2", new DateTime(1997,1,1))
            };
            Paper[] papers =
            {
                new Paper("Name1", new Person("Person1", "Person1", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
            };
            test.AddPapers(papers);

            var test2 = new ResearchTeam("Test1", "Test1", 1111, TimeFrame.TwoYears);
            test2.Participants = new List<Person>
            {
                new Person("Person1", "Person1",new DateTime(1999,1,1))
            };
            Paper[] papers2 =
            {
                new Paper("Name1", new Person("Person1", "Person1", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
            };
            test2.AddPapers(papers2);

            _researchTeams.Add(test);
            _researchTeams.Add(test2);
        }

        public void AddResearchTeams(ResearchTeam[] researchTeams)
        {
            if (_researchTeams == null)
            {
                _researchTeams = new List<ResearchTeam>();
            }

           foreach(var rt in researchTeams)
            {
                _researchTeams.Add(rt);
            }
        }

        public override string ToString()
        {
            if (_researchTeams != null)
            {
                StringBuilder res = new StringBuilder();
                foreach (ResearchTeam rt in _researchTeams)
                {
                    res.Append(rt.ToShortString());
                    if (rt.Participants != null)
                    {
                        foreach (Person person in rt.Participants)
                        {
                            res.Append(person);
                        }
                    }

                    res.Append("\nPapers:\n");

                    if (rt.Papers != null)
                    {
                        foreach (Paper paper in rt.Papers)
                        {
                            res.Append(paper);
                        }
                    }

                    res.Append("\n");
                }

                return $"Info about all:\n{res}";
            }

            else
            {
                return "List is empty";
            }
        }

        public string ToShortString()
        {
            StringBuilder res = new StringBuilder();

            if (_researchTeams != null && _researchTeams.Count != 0)
            {
                foreach (ResearchTeam rt in _researchTeams)
                {
                    res.Append(rt.ToShortString());
                    if (rt.Participants == null)
                    {
                        res.Append("Number participants: 0\n");
                    }
                    else
                    {
                        res.Append($"Number participants: {rt.Participants.Count}\n");
                    }

                    if (rt.Papers == null)
                    {
                        res.Append("Number papers: 0\n");
                    }
                    else
                    {
                        res.Append($"Number papers: {rt.Papers.Count}\n");
                    }

                }

                return $"Info about teams: {res}";
            }
            else
            {
                return "List is null";
            }
        }

        public void SortByNumber()
        {
            if (_researchTeams != null)
            {
                _researchTeams.Sort();
            }
        }

        public void SortByTopic()
        {
            if (_researchTeams != null)
            {
                _researchTeams.Sort(new ResearchTeam());
            }
        }

        public void SortByPaper()
        {
            if (_researchTeams != null)
            {
                _researchTeams.Sort(new ResearchTeamComparer());
            }
        }

        public double MinRegistrationNumber
        {
            get
            {
                if (_researchTeams == null || _researchTeams.Count == 0)
                {
                    return 0;
                }

                else
                {
                    return _researchTeams.Min(x => x.RegistrationNumber);

                }
            }
        }

        public IEnumerable<ResearchTeam> DurationTwoYears
        {
            get
            {
                if (_researchTeams == null || _researchTeams.Count == 0)
                {
                    return Enumerable.Empty<ResearchTeam>();
                }
                return _researchTeams.Where(x => x.Duration == TimeFrame.TwoYears);

            }
        }

        public List<ResearchTeam> NGroup(int value)
        {
            if (_researchTeams == null || _researchTeams.Count == 0)
            {
                return Enumerable.Empty<ResearchTeam>().ToList();
            }

            return _researchTeams.GroupBy(stud => stud.Participants).FirstOrDefault(x => x.Key.Count == value).ToList(); 
        }
    }
}

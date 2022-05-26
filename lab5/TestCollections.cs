using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab5
{
    public class TestCollections
    {
        private List<Team> _teams;
        private List<string> _strings;
        private Dictionary<Team, ResearchTeam> _teamResearchTeam;
        private Dictionary<string, ResearchTeam> _stringResearchTeam;

        public TestCollections(int count)
        {

            if (_teams == null) { _teams = new List<Team>(); }
            if (_strings == null) { _strings = new List<string>(); }
            if (_teamResearchTeam == null) { _teamResearchTeam = new Dictionary<Team, ResearchTeam>(); }
            if (_stringResearchTeam == null) { _stringResearchTeam = new Dictionary<string, ResearchTeam>(); }

            for (int i = 1; i <= count; i++)
            {

                Team team = GenerateResearchTeam(i).Team;
                ResearchTeam researchTeam = GenerateResearchTeam(i);
                _teams.Add(team);
                _strings.Add(team.ToString());
                _teamResearchTeam.Add(team, researchTeam);
                _stringResearchTeam.Add(team.ToString(), researchTeam);
            }
        }

        public static ResearchTeam GenerateResearchTeam(int i)
        {
            return new ResearchTeam("Test " + i, "Name" + i, i, TimeFrame.Year);
        }

        public void TimeFinding(int count)
        {
            int start, end;
            Team person = GenerateResearchTeam(0).Team;
            ResearchTeam student = GenerateResearchTeam(0);
            WriteLine("\n\n--------------First element---------------\n");

            WriteLine("--------Time in List<Team>----------------\n");
            start = Environment.TickCount;
            _teams.Contains(person);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in List<string>---------------\n");
            start = Environment.TickCount;
            _strings.Contains(person.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsKey(person);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<string,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _stringResearchTeam.ContainsKey(person.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by value---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsValue(student);
            end = Environment.TickCount;
            WriteLine(end - start);



            WriteLine("\n\n--------------Central element-----------------\n");

            Team person1 = GenerateResearchTeam(count / 2).Team;
            ResearchTeam student1 = GenerateResearchTeam(count / 2);
            WriteLine("--------Time in List<Team>----------------\n");
            start = Environment.TickCount;
            _teams.Contains(person1);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in List<string>---------------\n");
            start = Environment.TickCount;
            _strings.Contains(person1.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsKey(person1);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<string,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _stringResearchTeam.ContainsKey(person1.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by value---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsValue(student1);
            end = Environment.TickCount;
            WriteLine(end - start);



            WriteLine("\n\n--------------Last element-----------------\n");

            Team person2 = GenerateResearchTeam(count - 1).Team;
            ResearchTeam student2 = GenerateResearchTeam(count - 1);
            WriteLine("--------Time in List<Team>----------------\n");
            start = Environment.TickCount;
            _teams.Contains(person2);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in List<string>---------------\n");
            start = Environment.TickCount;
            _strings.Contains(person2.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsKey(person2);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<string,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _stringResearchTeam.ContainsKey(person2.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by value---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsValue(student2);
            end = Environment.TickCount;
            WriteLine(end - start);




            WriteLine("\n\n--------------Element which isn't a collection-----------------\n");

            Team person3 = GenerateResearchTeam(count).Team;
            ResearchTeam student3 = GenerateResearchTeam(count);
            WriteLine("--------Time in List<Team>----------------\n");
            start = Environment.TickCount;
            _teams.Contains(person3);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in List<string>---------------\n");
            start = Environment.TickCount;
            _strings.Contains(person3.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsKey(person3);
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<string,ResearchTeam> by key---------------\n");
            start = Environment.TickCount;
            _stringResearchTeam.ContainsKey(person3.ToString());
            end = Environment.TickCount;
            WriteLine(end - start);

            WriteLine("--------Time in Dictionary<Team,ResearchTeam> by value---------------\n");
            start = Environment.TickCount;
            _teamResearchTeam.ContainsValue(student3);
            end = Environment.TickCount;
            WriteLine(end - start);
        }

    }
}

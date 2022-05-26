using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lab4
{


    internal class Program
    {

        public static void Main(string[] args)
        {
            ResearchTeamCollection collection1 = new ResearchTeamCollection("test1");
            ResearchTeamCollection collection2 = new ResearchTeamCollection("test2");


            TeamJournal journal1 = new TeamJournal();
            TeamJournal journal2 = new TeamJournal();

            collection1.ResearchTeamInserted += journal1.ResearchTeamInserted;
            collection1.ResearchTeamAdded += journal1.ResearchTeamAdded;


            collection1.ResearchTeamInserted += journal2.ResearchTeamInserted;
            collection1.ResearchTeamAdded += journal2.ResearchTeamAdded;
            collection2.ResearchTeamInserted += journal2.ResearchTeamInserted;
            collection2.ResearchTeamAdded += journal2.ResearchTeamAdded;

            collection1.AddDefaults();
            var test = new ResearchTeam("Test3", "Test3", 2222, TimeFrame.TwoYears);
            test.Participants = new List<Person>
            {
                new Person("Person1", "Person1",new DateTime(1999,1,1))
            };
            Paper[] papers2 =
            {
                new Paper("Name1", new Person("Person1", "Person1", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
            };
            test.AddPapers(papers2);

            collection1.AddResearchTeams(new ResearchTeam[]
            {
                test
            });

            var test2 = new ResearchTeam("Test4", "Test4", 2222, TimeFrame.TwoYears);
            test2.Participants = new List<Person>
            {
                new Person("Person1", "Person1",new DateTime(1999,1,1))
            };
            Paper[] papers3 =
            {
                new Paper("Name1", new Person("Person1", "Person1", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
            };
            test2.AddPapers(papers3);
            collection1.InsertAt(2, test2);
            collection1.InsertAt(20, test2);



            collection2.AddDefaults();
            var testS = new ResearchTeam("Test3S", "Test3S", 22221, TimeFrame.TwoYears);
            testS.Participants = new List<Person>
            {
                new Person("Person1S", "Person1S",new DateTime(1999,1,1))
            };
            Paper[] papers2S =
            {
                new Paper("Name1S", new Person("Person1S", "Person1S", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
            };
            testS.AddPapers(papers2S);

            collection2.AddResearchTeams(new ResearchTeam[]
            {
                test
            });

            var test2S = new ResearchTeam("Test4S", "Test4S", 22222, TimeFrame.TwoYears);
            test2S.Participants = new List<Person>
            {
                new Person("Person1S", "Person1S",new DateTime(1999,1,1))
            };
            Paper[] papers3S =
            {
                new Paper("Name1S", new Person("Person1S", "Person1S", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
            };
            test2S.AddPapers(papers3);
            collection2.InsertAt(2, test2S);
            collection2.InsertAt(20, test2S);

            WriteLine($"Team Journal 1\n\n{journal1}");
            WriteLine($"Team Journal 2\n\n{journal2}");


        }
    }
}
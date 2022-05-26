using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lab3
{


    internal class Program
    {

        public static void Main(string[] args)
        {
            //1)
            WriteLine("1)------------------------------------");
            ResearchTeamCollection rtCollection = new ResearchTeamCollection();
            rtCollection.AddDefaults();

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

            rtCollection.AddResearchTeams(new ResearchTeam[]
            {
                test
            });
            WriteLine(rtCollection);
            WriteLine("----------------------------------------\n");


            //2)
            WriteLine("2)------------------------------------");

            WriteLine("--Sort by number--\n");
            rtCollection.SortByNumber();
            WriteLine(rtCollection);
            WriteLine("--Sort by topic--\n");
            rtCollection.SortByTopic();
            WriteLine(rtCollection);
            WriteLine("--Sort by paper--\n");
            rtCollection.SortByPaper();
            WriteLine(rtCollection.ToShortString());
            WriteLine("----------------------------------------\n");

            //3)
            WriteLine("3)------------------------------------");
            WriteLine("--Min number--");
            WriteLine(rtCollection.MinRegistrationNumber);
            WriteLine("--Duration Two Years--");
            foreach (ResearchTeam rt in rtCollection.DurationTwoYears)
            {
                WriteLine(rt);
            }
            WriteLine("--Group papers--");
            foreach (ResearchTeam rt in rtCollection.NGroup(2))
            {
                WriteLine(rt);
            }
            WriteLine("----------------------------------------\n");

            //4)
            WriteLine("4)------------------------------------");
            TestCollections testCollection = new TestCollections(1000000);
            testCollection.TimeFinding(1000000);
            WriteLine("----------------------------------------\n");

        }
    }
}
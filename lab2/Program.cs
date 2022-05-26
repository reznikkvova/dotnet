using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace Lab2
{
  
    
    internal class Program
    {
        
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

            var researchTeam = new ResearchTeam("Topic1", "Org", 111, TimeFrame.Long);
            researchTeam.Participants = new ArrayList
            {
                new Person("Person1", "Person1",new DateTime(1999,1,1)),
                new Person("Person2", "Person2", new DateTime(1997,1,1)),
                new Person("Person3", "Person3", new DateTime(1993,1,1)),
                new Person("Person4", "Person4", new DateTime(1993,1,1))
            };
            Paper[] papers =
            {
                new Paper("Name1", new Person("Person1", "Person1", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
                new Paper("Name2", new Person("Person2", "Person2", new DateTime(1997,1,1)), new DateTime(2021,1,1)),
                new Paper("Name3", new Person("Person3", "Person3", new DateTime(1993,1,1)), new DateTime(2022,4,1)),
            };

            researchTeam.AddPapers(papers);

            Console.WriteLine("researchTeam: " + researchTeam);

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
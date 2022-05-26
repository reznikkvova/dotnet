using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lab5
{


    public class Program
    {

        public static void Main(string[] args)
        {

            //1)
            ResearchTeam team = new ResearchTeam("test", "test", 111, TimeFrame.TwoYears);
            team.Participants = new List<Person>
            {
                new Person("Person1", "Person1",new DateTime(1999,1,1))
            };
            Paper[] papers2 =
            {
                new Paper("Name1", new Person("Person1", "Person1", new DateTime(1999,1,1)), new DateTime(2022,7,1)),
            };
            team.AddPapers(papers2);

            WriteLine(team.DeepCopy());
            //2-3)
            WriteLine("Введіть назву файлу, в який ви хочете записати дані про об'єкт:");
            team.Save(ReadLine());
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            ResearchTeam team2 = new ResearchTeam();
            team2.Load(ReadLine());
            WriteLine(team2);

            //4)
            team.AddFromConsole();
            WriteLine("Введіть назву файлу, в який ви хочете записати дані про об'єкт:");
            team.Save(ReadLine());
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            team.Load(ReadLine());


            //5)
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            ResearchTeam.Load(ReadLine(), team);
            team.AddFromConsole();
            WriteLine("Введіть назву файлу, в який ви хочете записати дані про об'єкт:");
            ResearchTeam.Save(ReadLine(), team);
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            ResearchTeam.Load(ReadLine(), team);
        }
    }
}
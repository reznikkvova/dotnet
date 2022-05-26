using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6 {
    internal class Program {
        static void Main(string[] args) {
            ConsoleKey consoleKey;
            DateTime now = DateTime.Now;
            if (now.DayOfWeek != DayOfWeek.Sunday) {
                Console.WriteLine("Ім'я дівчини: ");
                string nameGirl = Console.ReadLine();
                Console.WriteLine("По-батькові дівчини: ");
                string lastnameGirl = Console.ReadLine();

                Console.WriteLine("Ім'я хлопця: ");
                string nameBoy = Console.ReadLine();
                Console.WriteLine("По-батькові хлопця: ");
                string lastnameBoy = Console.ReadLine();

                Human[] humans ={ new Student(nameBoy, lastnameBoy), new Botan(nameBoy, lastnameBoy), new Girl(nameGirl, lastnameGirl), new PrettyGirl(nameGirl, lastnameGirl), new SmartGirl(nameGirl, lastnameGirl) };
                do {
                    Random random = new Random();
                    var IdxFirst = random.Next(humans.Length);
                    var IdxSecond = random.Next(humans.Length);
                    Console.WriteLine($"\nПерша людина: {humans[IdxFirst].GetType().GetProperty("Name").GetValue(humans[IdxFirst])}\n");
                    Console.WriteLine($"Друга людина: {humans[IdxSecond].GetType().GetProperty("Name").GetValue(humans[IdxSecond])}\n");
                    if(Human.CheckCouple(humans[IdxFirst], humans[IdxSecond])){
                        Console.WriteLine("Стать співпадає");
                    } else {
                        IHasName child = Human.Couple(humans[IdxFirst], humans[IdxSecond]);
                        if (child != null) {
                            Console.WriteLine($"\nІм'я: {child.GetType().GetProperty("Name")?.GetValue(child)}");
                            Console.WriteLine($"Прізвище: {child.GetType().GetProperty(nameof(Human.Lastname))?.GetValue(child)}");
                            Console.WriteLine($"Child Type: {child}");
                        }
                    }
                    consoleKey = Console.ReadKey(false).Key;
                } while (consoleKey != ConsoleKey.F10 && consoleKey.ToString() != "q");
            } else {
                Console.WriteLine("неділя");
            }
        }
    }
}

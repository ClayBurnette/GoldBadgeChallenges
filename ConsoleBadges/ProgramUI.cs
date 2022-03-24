using RepoBadges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBadges
{
    public class ProgramUI
    {
        private readonly Repository _repo = new Repository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Insurance Badging System\n" +
                    "\n" +
                    "Hello Security Admin, What Would You Like To Do?\n" + "\n" +
                    "1. Add A Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid Number.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void AddBadge()
        {
            Badges content = new Badges
            {
                DoorAccess = new List<string>()
            };
            Console.Clear();
            Console.WriteLine("Adding A New Badge\n" + "\n" + "Enter The New Badge Number:\n ");
            content.BadgeID = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine($"Adding A New Badge\n" + "\n" +  $"Badge ID: {content.BadgeID}\n");

            Console.WriteLine($"Enter A Door That Badge #{content.BadgeID} Will Need Access To: \n");
            content.DoorAccess.Add(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Door Successfully Added To Badge #{content.BadgeID}." + "\n");

            bool yes = true;
            while (yes)
            {
                Console.WriteLine("\n" + $"Need To Allow Access To Another Door For Badge #{content.BadgeID}(y/n)?" + "\n");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "y":
                        Console.WriteLine("\n"+ $"Enter A Door That Badge #{content.BadgeID} Will Need Access To: \n ");
                        content.DoorAccess.Add(Console.ReadLine());
                        break;
                    case "n":
                        yes = false;
                        break;
                }
            }
            _repo.AddBadge(content);

            Console.WriteLine("\n" + $"Badge #{content.BadgeID} Created Successfully.");
            Console.WriteLine("\nPress ENTER To Return To The Main Menu.");
            Console.ReadKey();
        }
        public void UpdateBadge()
        {
            Badges content = new Badges
            {
                DoorAccess = new List<string>()
            };

            Console.Clear();
            Console.WriteLine("What Is The Badge Number That Needs Updating? \n");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"What Would You Like To Do With Badge #{content.BadgeID}\n" +
                $"\n" +
                $"1. Remove A Door\n" +
                $"2. Add A Door\n" +
                $"3. Return to menu\n");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    //Add a door
                    RemoveDoorFromEdit(content.BadgeID);
                    break;
                case "2":
                    //Remove a door
                    AddDoorToEdit(content.BadgeID);
                    break;
                case "3":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please Enter A Valid Number.");
                    Console.ReadKey();
                    break;
            }
        }
        public void RemoveDoorFromEdit(int badgeid)
        {
            Console.WriteLine("\n" + $"Which Door Would You Like To Remove?" + "\n");
            string door = Console.ReadLine();
            _repo.RemoveAccess(badgeid, door);

            Console.WriteLine("\n" + "Door Access Has Been Removed." + "\n");
            Console.WriteLine("\n" + "Press ENTER to continue.");
            Console.ReadKey();
        }
        public void AddDoorToEdit(int badgeid)
        {
            Console.WriteLine("\n" + "Which Door Would You Like To Add?" + "\n");
            string door = Console.ReadLine();
            _repo.GiveAccess(badgeid, door);

            Console.WriteLine("\n" + "Door Access Has Been Added." + "\n");
            Console.WriteLine("\n" + "Press ENTER to continue.");
            Console.ReadKey();
        }
        public void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> BadgeList = _repo.GetDictonary();

            Console.WriteLine("=============");
            foreach (KeyValuePair<int, List<string>> badge in BadgeList)
            {
                Console.WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine("=============");
            }
            Console.WriteLine("\nPress ENTER To Return To The Main Menu.");
            Console.ReadLine();
        }
        public void SeedContent()
        {
            Badges badgeOne = new Badges(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badges badgeTwo = new Badges(32345, new List<string> { "A4", "A5" });

            _repo.AddBadge(badgeOne);
            _repo.AddBadge(badgeTwo);
        }
    }
}
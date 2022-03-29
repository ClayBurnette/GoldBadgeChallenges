using Outings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Outings
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private readonly Repository _outingsRepo = new Repository();
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Company Outings\n" +
                    "1. Display A List Of All Outings\n" +
                    "2. Add Individual Outings To A List\n" +
                    "3. Total Cost Of Outings\n" +
                    "4. Total Cost Of Outings Per Event\n" +
                    "5. Exit\n");
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗ ");
                    Console.WriteLine("██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗");
                    Console.WriteLine("█████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║");
                    Console.WriteLine("██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║");
                    Console.WriteLine("██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝");
                    Console.WriteLine("╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝ ");
                    Console.ResetColor();
                }
                string userInput = Console.ReadLine();
                switch (userInput)
                {   
                    case "1":
                        ListAllOutings();
                        break;
                    case "2":
                        AddIndividualOutings();
                        break;
                    case "3":
                        CalculateTotalCosts();
                        break;
                    case "4":
                        CalculateTotalCostsPerType();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                }
            }
        }
        public void ListAllOutings()
        {
            Console.Clear();
            List<Outings> outingsList = _outingsRepo.ListOutings();
            foreach (Outings content in outingsList)
            {
                Console.WriteLine($"{content.Type} {content.DateOfEvent} {content.People} {content.CostPerPerson} {content.CostOfEvent}");
            }
            Console.WriteLine("Press ENTER Key To Continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public void AddIndividualOutings()
        {
            Outings content = new Outings();

            Console.Clear();
            Console.WriteLine("(Type) (DateOfEvent) (People) (CostPerPerson) (CostOfEvent)");
            Console.WriteLine("Select The Type Of Event.\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");

            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    content.Type = TypeOfEvent.Golf;
                    break;
                case "2":
                    content.Type = TypeOfEvent.Bowling;
                    break;
                case "3":
                    content.Type = TypeOfEvent.AmusementPark;
                    break;
                case "4":
                    content.Type = TypeOfEvent.Concert;
                    break;
                default:
                    Console.WriteLine("Please Enter A Valid Response");
                    break;
            }
            Console.Clear();
            Console.WriteLine($"({content.Type}) (DateOfEvent) (People) (CostPerPerson) (CostOfEvent)");

            Console.WriteLine("Enter The Date Of The Event.\n");
            content.DateOfEvent = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.Type}) ({content.DateOfEvent}) (People) (CostPerPerson) (CostOfEvent)");

            Console.WriteLine("Enter How Many People Are Going?\n");
            content.People = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.Type}) ({content.DateOfEvent}) ({content.People}) (CostPerPerson) (CostOfEvent)");

            Console.WriteLine("How Much Does Each Person Cost?\n");
            content.CostPerPerson = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.Type}) ({content.DateOfEvent}) ({content.People}) ({content.CostPerPerson}) (CostOfEvent)");

            Console.WriteLine("What Is The Cost Of The Event?\n");
            content.CostOfEvent = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Here Is How Your Event Looks\n");

            Console.WriteLine($"({content.Type}\n) ({content.DateOfEvent}\n) ({content.People}\n) (${content.CostPerPerson}\n) (${content.CostOfEvent}\n)");

            Console.WriteLine("Press ENTER To Add The Event To The List.");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Event Has Been Added.");
            Console.WriteLine("Press ENTER To Continue.");
            Console.ReadLine();

            _outingsRepo.AddOutings(content);
        }
        public void CalculateTotalCosts()
        {
            Console.Clear();
            decimal totalCost = _outingsRepo.TotalOutingCosts();
            Console.WriteLine($"The Total Cost For All The Outings Is: ${totalCost}.");
            Console.WriteLine("Press ENTER To Continue.");
            Console.ReadLine();
        }
        public void CalculateTotalCostsPerType()
        {
            Console.Clear();
            Console.WriteLine("1) Golf\n" +
                "2) Bowling\n" +
                "3) Amusement Park\n" +
                "4) Concert");
            TypeOfEvent type = TypeOfEvent.Golf;
            decimal totalCostPerEvent = _outingsRepo.TotalOutingCostsPerType(type);
            switch (Console.ReadLine())
            {
                case "1":
                    type = TypeOfEvent.Golf;
                    Console.WriteLine($"Total Cost For Golf Events ${totalCostPerEvent}");
                    Console.ReadLine();
                    break;
                case "2":
                    type = TypeOfEvent.Bowling;
                    Console.WriteLine($"Total Cost For Bowling Events ${totalCostPerEvent}");
                    Console.ReadLine();
                    break;
                case "3":
                    type = TypeOfEvent.AmusementPark;
                    Console.WriteLine($"Total Cost For Amusement Park Events ${totalCostPerEvent}");
                    Console.ReadLine();
                    break;
                case "4":
                    type = TypeOfEvent.Concert;
                    Console.WriteLine($"Total Cost For Concert Events ${totalCostPerEvent}");
                    Console.ReadLine();
                    break;
            }
        }
        public void SeedContent()
        {
            Outings bowlingEvent = new Outings(TypeOfEvent.Bowling, DateTime.Parse("06/15/1993"), 25, 20, 3000.00m);
            Outings golfEvent = new Outings(TypeOfEvent.Golf, DateTime.Parse("06/14/1993"), 15, 40, 2000.00m);

            _outingsRepo.AddOutings(bowlingEvent);
            _outingsRepo.AddOutings(golfEvent);
        }
    }
}
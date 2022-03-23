using RepoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClaims
{
    public class ProgramUI
    {
        private readonly Repository _repo = new Repository();
        public Repository Repo => _repo;
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
                Console.WriteLine("Komodo Claims Department\n" + "\n" +
                    "1. See All Claims\n" +
                    "2. Take Care Of The Next Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        // Take next claim
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        // List all claims
                        break;
                    case "3":
                        EnterNewClaim();
                        // Add a new claim
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }
        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> claimList = Repo.GetList();

            Console.WriteLine("ClaimID\tType\tDescription    \t\tAmount\t\tDateOfAccident\tDateOfClaim\tIsValid\n");
            foreach (Claims content in claimList)
            {
                Console.WriteLine($"{content.ClaimID} \t{content.Type} \t{content.Description} \t${content.Amount} \t\t{content.DateOfAccident.ToShortDateString()} \t{content.DateOfClaim.ToShortDateString()} \t{content.IsValid}\n");
            }
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadKey();
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here Are The Details For The Next Claim To Be Handled: \n");

            Queue<Claims> newList = Repo.GetList();
            Claims nextClaim = newList.Peek();

            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.Type}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.Amount}\n" +
                $"DateOfAccident: {nextClaim.DateOfAccident.ToShortDateString()}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"Do You Want To Deal With This Claim Now (y/n)?");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    newList.Dequeue();
                    Console.WriteLine("\n" + "You Have Successfully Taken The Claim." + " \n" + " \n" + "Press ENTER to continue.");
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please Enter Either y Or n");
                    break;
            }
            Console.ReadLine();
        }
        public void EnterNewClaim()
        {
            Claims content = new Claims();

            Console.Clear();
            Console.WriteLine($"(ClaimID) (Type) (Description) (Amount Of Damage) (Date Of Accident) (Date Of Claim) (IsValid)\n");

            Console.WriteLine("Enter The Claim ID: ");
            content.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) (Type) (Description) (Amount Of Damage) (Date Of Accident) (Date Of Claim) (IsValid)\n");

            Console.WriteLine("Enter The Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    content.Type = TypeOfClaim.Car;
                    break;
                case "2":
                    content.Type = TypeOfClaim.Home;
                    break;
                case "3":
                    content.Type = TypeOfClaim.Theft;
                    break;
                default:
                    Console.WriteLine("Please Enter A Correct Type Of Claim Number");
                    break;
            }
            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.Type}) (Description) (Amount Of Damage) (Date Of Accident) (Date Of Claim) (IsValid)\n");

            Console.WriteLine("Enter A Claim Description: ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.Type}) ({content.Description}) (Amount Of Damage) (Date Of Accident) (Date Of Claim) (IsValid)\n");

            Console.WriteLine("Amount Of Damage:");
            content.Amount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.Type}) ({content.Description}) (${content.Amount}) (Date Of Accident) (Date Of Claim) (IsValid)\n");

            Console.WriteLine("Date Of Accident: ");
            content.DateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.Type}) ({content.Description}) (${content.Amount}) ({content.DateOfAccident}) (Date Of Claim) (IsValid)\n");

            Console.WriteLine("Date Of Claim: ");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Repo.IsValid(content);

            Console.Clear();
            Console.WriteLine($"Would You Like To Add This Claim To The Queue?: \n" +
                $"\n" +
                $"ClaimID: {content.ClaimID}\n" +
                $"Type: {content.Type}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: ${content.Amount}\n" +
                $"DateOfAccident: {content.DateOfAccident}\n" +
                $"DateOfClaim: {content.DateOfClaim}\n" +
                $"IsValid: {content.IsValid}\n" +
                $"\n" +
                $"Press ENTER To Confirm The Entry.");
            Console.ReadKey();

            Repo.AddClaim(content);
            Console.Clear();
            Console.WriteLine("Claim Has Been Added To The Queue\n" + "\n" + "Press Enter To Return To The Menu.");
            Console.ReadKey();
        }
        public void SeedContent()
        {
            Claims claimOne = new Claims(1, TypeOfClaim.Car, "Car Accident On 465.", 400, DateTime.Parse("04/25/2018"), DateTime.Parse("04/27/2018"), true);
            Claims claimTwo = new Claims(2, TypeOfClaim.Home, "House Fire In Kitchen.", 4000, DateTime.Parse("04/11/2018"), DateTime.Parse("04/12/2018"), true);
            Claims claimThree = new Claims(3, TypeOfClaim.Theft, "Stolen Pancakes.", 4.00m, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"), false);

            Repo.AddClaim(claimOne);
            Repo.AddClaim(claimTwo);
            Repo.AddClaim(claimThree);
        }
    }
}
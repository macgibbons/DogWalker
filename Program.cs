using System;
using DogWalker.Data;
using DogWalker.Models;
using System.Collections.Generic;

namespace DogWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            WalkerRepository walkerRepo = new WalkerRepository();
            NeighborhoodRepository neighborhoodRepo = new NeighborhoodRepository();
            OwnerRepository ownerRepo = new OwnerRepository();

            Console.WriteLine("Getting All Walkers:");
            Console.WriteLine();

            List<Walker> allWalkers = walkerRepo.GetAllWalkers();


            foreach (Walker walker in allWalkers)
            {
                Console.WriteLine($"{walker.Id}.) {walker.Name} Walks dogs in  {walker.Neighborhood.Name}.");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("Show Walkers in specific neighborhood");
            Console.WriteLine();

            List<Neighborhood> allNeighborhoods = neighborhoodRepo.GetAllNeighborhoods();
            foreach (var n in allNeighborhoods)
            {
                Console.WriteLine($"{n.Id} {n.Name}");
            }

            var userInput = int.Parse(Console.ReadLine());
            Walker singleWalker = walkerRepo.GetWalkerByNeighborhood(userInput);

            Console.WriteLine($"---- Dog walkers in {singleWalker.Neighborhood.Name} ----");
            Console.WriteLine($"{singleWalker.Id}.) {singleWalker.Name} ");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("---- Add a new Walker ----");
            Console.WriteLine();
            Console.WriteLine("What is their name?");
            var NewWalkerName = Console.ReadLine();
            Console.WriteLine($"What neighborhood does {NewWalkerName} work in?");
            foreach (var n in allNeighborhoods)
            {
                Console.WriteLine($"{n.Id} {n.Name}");
            }

            var NewWalkerNeighborhoodId = int.Parse(Console.ReadLine());
            Walker NewWalker = new Walker
            {
                Name = NewWalkerName,
                NeighborhoodId = NewWalkerNeighborhoodId
            };

            walkerRepo.AddWalker(NewWalker);

            Console.WriteLine($"{NewWalker.Name} has been added!");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("----Showing all Owners----");
            List<OWNER> allOwners =ownerRepo.GetAlOwners();

            foreach (var o in allOwners)
            {
                Console.WriteLine("----------------");
                Console.WriteLine($"{o.Name} lives in {o.Neighborhood.Name}");
                Console.WriteLine($"{o.Address}");
                Console.WriteLine($"{o.Phone}");
                Console.WriteLine();
            }

            Console.WriteLine("---- Add a new Owner ----");
            Console.WriteLine();
            Console.WriteLine("What is their name?");
            var newOwnerName = Console.ReadLine();
            Console.WriteLine($"What is {newOwnerName}'s phone number?");
            var newOwnerPhone = Console.ReadLine();
            Console.WriteLine($"What is {newOwnerName}'s Address?");
            var newOwnerAddress = Console.ReadLine();
            Console.WriteLine($"What neighborhood does {newOwnerName} live in?");
            foreach (var n in allNeighborhoods)
            {
                Console.WriteLine($"{n.Id} {n.Name}");
            }

            var NewOwnerNeighborhoodId = int.Parse(Console.ReadLine());
            OWNER NewOwner = new OWNER
            {
                Name = newOwnerName,
                Phone = newOwnerPhone, 
                Address = newOwnerAddress,
                NeighborhoodId = NewOwnerNeighborhoodId
            };

            ownerRepo.AddOwner(NewOwner);


            Console.WriteLine($"{NewOwner.Name} has been added!");

            Console.ReadLine();
            Console.Clear();

        }
    }
}

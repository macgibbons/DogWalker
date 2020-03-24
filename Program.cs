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
        }
    }
}

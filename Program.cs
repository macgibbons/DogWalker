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

            Console.WriteLine("Getting All Walkers:");
            Console.WriteLine();

            List<Walker> allWalkers = walkerRepo.GetAllWalkers();
            

            foreach (Walker walker in allWalkers)
            {
                Console.WriteLine($"{walker.Id}.) {walker.Name} Walks dogs in  {walker.Neighborhood.Name}.");
            }
        }
    }
}

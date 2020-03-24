using System;
using System.Collections.Generic;
using System.Text;

namespace DogWalker.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public String Breed { get; set; }
        public string Notes { get; set; }
        public OWNER Owner { get; set; }
    }
}

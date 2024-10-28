using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis.KYH
{
    public class Medborgare : Person
    {
        public Medborgare(int x, int y) : base(x, y)
        {
            
            Inventory.Add("Nycklar");
            Inventory.Add("Mobiltelefon");
            Inventory.Add("Pengar");
            Inventory.Add("Klocka");
        }
        public override void Interact(Person other)
        {
            // Inga specifika interaktioner med andra medborgare eller poliser
        }
    }
}

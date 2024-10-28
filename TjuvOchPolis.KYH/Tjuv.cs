using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis.KYH
{
    public class Tjuv : Person
    {
        public Tjuv(int x, int y) : base(x, y)
        {
        }
        public override void Interact(Person other)
        {
            if (other is Medborgare medborgare && medborgare.Inventory.Count > 0)
            {
                Random rnd = new Random();
                int itemIndex = rnd.Next(medborgare.Inventory.Count);
                string stulenSak = medborgare.Inventory[itemIndex];
                medborgare.Inventory.RemoveAt(itemIndex);
                Inventory.Add(stulenSak);
                Stad.robbedCitizens++;
                Console.WriteLine("Tjuv rånar medborgare och tar: " + stulenSak);
                Thread.Sleep(2000); 
            }
        }
    }
}

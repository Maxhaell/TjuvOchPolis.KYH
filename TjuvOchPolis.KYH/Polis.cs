using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis.KYH
{
    public class Polis : Person
    {
        private Prison prison;
        public Polis(int x, int y, Prison prison) : base(x, y)
        {
            this.prison = prison;
        }
        public override void Interact(Person other)
        {
            if (other is Tjuv tjuv)
            {
                Inventory.AddRange(tjuv.Inventory); // Polisen tar alla tjuvens saker
                tjuv.Inventory.Clear();
                if (prison.AddThief(tjuv)) // flytta tjuven till fängelset
                {
                    Stad.arrestedThieves++;
                    Console.WriteLine("Polis tar tjuv och flyttar hen till fängelset!");
                }
                else
                {
                    Console.WriteLine("Fängelset är fullt, tjuven är fri!");
                }
                Thread.Sleep(2000); 
            }
        }
    }
}

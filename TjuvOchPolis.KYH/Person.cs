using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis.KYH
{
    public abstract class Person
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public Person(int x, int y)
        {
            X = x;
            Y = y;
            SetRandomDirection();
        }
        public void SetRandomDirection()
        {
            Random rnd = new Random();
            int direction = rnd.Next(6); 
            switch (direction)
                // Olika rikningar personerna kan göra sig i.
            {
                case 0: XDirection = -1; YDirection = 0; break; // Vänster
                case 1: XDirection = 1; YDirection = 0; break;  // Höger
                case 2: XDirection = 0; YDirection = -1; break; // Upp
                case 3: XDirection = 0; YDirection = 1; break;  // Ned
                case 4: XDirection = 1; YDirection = -1; break; // Diagonalt höger upp
                case 5: XDirection = -1; YDirection = -1; break; // Diagonalt vänster upp
            }
        }
        public void Move(int cityWidth, int cityHeight)
        {
            X = (X + XDirection + cityWidth) % cityWidth;
            Y = (Y + YDirection + cityHeight) % cityHeight;
        }
        public abstract void Interact(Person other);
    }
}


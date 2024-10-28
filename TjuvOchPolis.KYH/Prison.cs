using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis.KYH
{
    public class Prison
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private List<Tjuv> imprisonedThieves;

        public Prison(int width, int height)
        {
            Width = width;
            Height = height;
            imprisonedThieves = new List<Tjuv>();
        }

        public bool AddThief(Tjuv thief)
        {
            imprisonedThieves.Add(thief);
            // Placera tjuven på en slumpmässig position i fängelset
            Random rnd = new Random();
            thief.X = rnd.Next(1, Width - 1);  
            thief.Y = rnd.Next(1, Height - 1);  
            return true;
        }

        public void DrawPrison()
        {
            Console.SetCursorPosition(0, 26);
            Console.WriteLine("FÄNGELSE:");

            // Rita fängelset och dess fångar
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    bool hasThief = false;
                    foreach (var thief in imprisonedThieves)
                    {
                        if (thief.X == x && thief.Y == y)
                        {
                            Console.Write("T");
                            hasThief = true;
                            break;
                        }
                    }
                    if (!hasThief)
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            
            Console.WriteLine($"\nAntal rånade medborgare: {Stad.robbedCitizens}");
            Console.WriteLine($"Antal gripna tjuvar: {Stad.arrestedThieves}");

            // Låt fångarna röra sig
            foreach (var thief in imprisonedThieves)
            {
                // Beräkna ny position
                int newX = thief.X + thief.XDirection;
                int newY = thief.Y + thief.YDirection;

                // Om tjuven skulle gå utanför gränserna, studsa tillbaka och byt riktning
                if (newX <= 0 || newX >= Width - 1 || newY <= 0 || newY >= Height - 1)
                {
                    thief.SetRandomDirection();
                    // Säkerställ att tjuven stannar inom gränserna
                    thief.X = Math.Max(1, Math.Min(Width - 2, thief.X));
                    thief.Y = Math.Max(1, Math.Min(Height - 2, thief.Y));
                }
                else
                {
                    // Uppdatera position om den är säker
                    thief.X = newX;
                    thief.Y = newY;
                }
            }
        }
    }
}

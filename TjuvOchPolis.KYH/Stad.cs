using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis.KYH
{
    class Stad
    {
        public static int robbedCitizens = 0;
        public static int arrestedThieves = 0;
        private List<Person> personer;
        private Prison prison;
        private int cityWidth = 100;
        private int cityHeight = 25;
        private int prisonWidth = 25;
        private int prisonHeight = 6;
        private int antalPoliser = 10;
        private int antalTjuvar = 20;
        private int antalMedborgare = 30;

        public Stad()
        {
            personer = new List<Person>();
            prison = new Prison(prisonWidth, prisonHeight);
            InitializePersoner();
        }

        private void InitializePersoner()
        {
            Random rnd = new Random();

            // Skapa poliser
            for (int i = 0; i < antalPoliser; i++)
            {
                personer.Add(new Polis(rnd.Next(cityWidth), rnd.Next(cityHeight), prison));
            }

            // Skapa tjuvar
            for (int i = 0; i < antalTjuvar; i++)
            {
                personer.Add(new Tjuv(rnd.Next(cityWidth), rnd.Next(cityHeight)));
            }

            // Skapa medborgare
            for (int i = 0; i < antalMedborgare; i++)
            {
                personer.Add(new Medborgare(rnd.Next(cityWidth), rnd.Next(cityHeight)));
            }
        }

        public void Run()
        {
            while (true)
            {
                foreach (Person person in personer)
                {
                    person.Move(cityWidth, cityHeight);
                    // Kolla om personen möter någon annan
                    foreach (Person other in personer)
                    {
                        if (person != other && person.X == other.X && person.Y == other.Y)
                        {
                            person.Interact(other);
                        }
                    }
                }

                char[,] cityMap = new char[cityWidth, cityHeight];
                Console.Clear();
                foreach (Person person in personer)
                {
                    char symbol = ' ';
                    if (person is Polis) symbol = 'P';
                    if (person is Tjuv) symbol = 'T';
                    if (person is Medborgare) symbol = 'M';
                    cityMap[person.X, person.Y] = symbol;
                }
                for (int y = 0; y < cityHeight; y++)
                {
                    for (int x = 0; x < cityWidth; x++)
                    {
                        Console.Write(cityMap[x, y] == '\0' ? '.' : cityMap[x, y]);
                    }
                    Console.WriteLine();
                }
                prison.DrawPrison();
                Thread.Sleep(500);
            }
        }
    }
}

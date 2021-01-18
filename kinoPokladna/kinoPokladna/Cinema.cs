using System;
using System.Collections.Generic;
using System.Text;

namespace kinoPokladna
{
    class Cinema
    {
        private bool[,] spodPatro { get; set; } // Velikost spod patra
        private bool[,] celkovaVelikost { get; set; } // Celková velikost
        private int rada, sedadlo;
        private ConsoleKeyInfo input { get; set; }
        private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private bool v, b;
        public Cinema(int _pocetRadSpod, int _pocetSedadel, int _pocetRadBalk)
        {
            spodPatro = new bool[_pocetRadSpod, _pocetSedadel];
            celkovaVelikost = new bool[_pocetRadSpod + _pocetRadBalk, _pocetSedadel];
        }
        public void Main()
        {
            while (true)
            {
                PrintArray(celkovaVelikost);
                Movement();
            }
        }
        private void PrintArray(bool[,] array)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Pohyb mezi sedadly - šipky \nZměna stavu sedadla - mezerník \nVypsaní všech obsazených sedadel - V \nVypsaní shrnutí sedadel - B\n\n");
            if (b)
            {
                ListSeats();
                b = false;
            }
            else if (v)
            {
                ListStatistics();
                v = false;
            }
            else
            {
                Console.Write("          Spodní patro\n\n");
                for (int i = 1; i <= array.GetLength(1); i++)
                {
                    if (i < 11) Console.Write("  " + i);
                    else Console.Write(" " + i);
                }
                Console.WriteLine();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Console.Write(alphabet[i] + " ");
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j]) //True obsazeno
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else //False volno
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        if (i == rada && j == sedadlo)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("X");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }

                    if (i == spodPatro.GetLength(0) - 1)
                    {
                        Console.Write("\n\n          Balkón\n\n");
                    }
                    else
                    {
                        Console.Write("\n\n");
                    }
                }
            }
        }
        private void Movement()
        {
            var validInput = false;
            while (!validInput)
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.RightArrow && sedadlo < celkovaVelikost.GetLength(1) - 1)
                {
                    sedadlo += 1;
                    validInput = true;
                }
                else if (input.Key == ConsoleKey.LeftArrow && sedadlo > 0)
                {
                    sedadlo -= 1;
                    validInput = true;
                }
                else if (input.Key == ConsoleKey.DownArrow && rada < celkovaVelikost.GetLength(0) - 1)
                {
                    rada += 1;
                    validInput = true;
                }
                else if (input.Key == ConsoleKey.UpArrow && rada > 0)
                {
                    rada -= 1;
                    validInput = true;
                }
                else if (input.Key == ConsoleKey.Spacebar)
                {
                    ChangeSeatState();
                    validInput = true;
                }   
                else if (input.Key == ConsoleKey.B)
                {
                    b = true;
                    validInput = true;
                }     
                else if (input.Key == ConsoleKey.V)
                {
                    v = true;
                    validInput = true;
                }
            }
        }
        private void ChangeSeatState()
        {
            if (celkovaVelikost[rada, sedadlo]) celkovaVelikost[rada, sedadlo] = false;
            else celkovaVelikost[rada, sedadlo] = true;
        }
        private void ListSeats()
        {
            for (int i = 0; i < celkovaVelikost.GetLength(0); i++)
            {
                for (int j = 0; j < celkovaVelikost.GetLength(1); j++)
                {
                    if (celkovaVelikost[i, j])
                    {
                        Console.Write("Sedadlo " + alphabet[i] + (j + 1) + " obsazeno\n");
                    }
                }
            }
        }
        private void ListStatistics()
        {
            var pocetObsazen = 0;
            var pocetPrazdny = 0;
            for (int i = 0; i < celkovaVelikost.GetLength(0); i++)
            {
                for (int j = 0; j < celkovaVelikost.GetLength(1); j++)
                {
                    if (celkovaVelikost[i, j])
                    {
                        pocetObsazen++;
                    }
                    else
                    {
                        pocetPrazdny++;
                    }
                }
            }
            Console.Write(pocetObsazen + " obsazených sedadel\n" + pocetPrazdny + " volných sedadel");
        }
    }
}

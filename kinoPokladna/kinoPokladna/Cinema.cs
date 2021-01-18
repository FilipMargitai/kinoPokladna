using System;
using System.Collections.Generic;
using System.Text;

namespace kinoPokladna
{
    class Cinema
    {
        private bool[,] spodPatro { get; set; }
        private bool[,] balkon { get; set; }
        public Cinema(int _pocetRadSpod, int _pocetSedSpod, int _pocetRadBalk, int _pocetSedBalk)
        {
            spodPatro = new bool[_pocetRadSpod, _pocetSedSpod];
            balkon = new bool[_pocetRadBalk, _pocetSedBalk];
        }
        public void Main()
        {
            PrintArray(spodPatro);
        }
        private void PrintArray(bool[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
        private void Movement()
        {

        }
        private void ChangeSeatState()
        {

        }
        private void Reset()
        {

        }
        private void ListSeats()
        {

        }
    }
}

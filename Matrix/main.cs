﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Matrix;
using System.Threading.Tasks;

namespace Matrix
{
    class main

    {
        private const int SIZEMATRIX = 15;
        static void Main(string[] args)
        {
            int count = 0;
            Neo neo;
            Smith smith;
            smith = SmithFactory.createSmith(SIZEMATRIX);
            neo = NeoFactory.CreateNeo(SIZEMATRIX);
            Console.WriteLine(smith);
            Matrix matrix;
            matrix = MatrixFactory.createMatrix(SIZEMATRIX, smith, neo);
            Console.ReadKey();
            while (count < 30)
            {
                Utility.PrintMatrix(matrix.MatrixChar,smith);
                Utility.MoveGeneric(matrix, SIZEMATRIX);
                Console.WriteLine("Tiempo de simulacion: "+ count);
                Console.WriteLine("Enemigos Restantes: "+ matrix.Cola.Count);

                Thread.Sleep(1000);
                count++;

                if (count % 2 == 0)
                {
                    Console.WriteLine(neo.Chosen);
                    smith.MoveSmith((int)neo.Ubicacion.X, (int)neo.Ubicacion.Y, matrix);
                }
                if (count % 5 == 0) {
                    neo.mover(matrix, SIZEMATRIX);
                    neo.CreateEnemy(matrix);
                    Utility.PrintMatrix(matrix.MatrixChar, smith);
                    smith.History.Clear();
                    Console.WriteLine("Tiempo de simulacion: "+ count);
                    Console.WriteLine("Enemigos Restantes: "+ matrix.Cola.Count);

                }

            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}

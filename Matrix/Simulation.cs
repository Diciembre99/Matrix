using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Matrix;
using System.Threading.Tasks;

namespace Matrix
{
    class Simulation

    {
        private const int SIZEMATRIX = 15;
        static void Main()
        {
            int count = 0;
            Neo neo;
            Smith smith;
            smith = SmithFactory.createSmith(SIZEMATRIX);
            neo = NeoFactory.CreateNeo(SIZEMATRIX);
            Utility.Dibujo();
            Console.WriteLine("\n\nPresiona cualquier tecla para comenzar\n\n");
            Console.WriteLine(smith);
            Matrix matrix;
            matrix = MatrixFactory.createMatrix(SIZEMATRIX, smith, neo);
            Console.ReadKey();
            while (count < 20 && (matrix.Cont > 0 || matrix.Cola.Count > 0))
            {
                Utility.PrintMatrix(matrix,smith);
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
                    Utility.PrintMatrix(matrix, smith);
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Utility
    {
        /// <summary>
        /// Verifica si smith se movio en esa casilla
        /// </summary>
        /// <param name="smith"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool inHistory(Smith smith,int x, int y)
        {
            bool color = false;
            foreach (var h in smith.History)
            {
                if (h.X == x && h.Y==y)
                {
                    return true;
                    
                }
            }
            return color;
        }
        /// <summary>
        /// Muestra la matriz en pantalla
        /// </summary>
        /// <param name="matrix"></param>
        public static void PrintMatrix(Matrix matrix,Smith smith)
        {
            bool color = false;
            int cont = 0;

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            for (int i = 0; i < matrix.MatrixChar.Length; i++)
            {
                Console.Write("║");

                for (int j = 0; j < matrix.MatrixChar[i].Length; j++)
                {

                    if (matrix.MatrixChar[i][j] == null)
                    {
                        color = inHistory(smith,i,j);
                        if (color)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("[ ]\t");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[ ]\t");
                            Console.ResetColor();
                        }

                    }
                    else if (matrix.MatrixChar[i][j] is Smith)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("[S]\t");
                        Console.ResetColor();
                    }
                    else if (matrix.MatrixChar[i][j] is Neo)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[N]\t");
                        Console.ResetColor();
                    }
                    else
                    {
                        char ini = matrix.MatrixChar[i][j].Name[0];
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[{0}]\t",ini);
                        Console.ResetColor();
                        cont++;
                    }
                }
                Console.WriteLine("║");
            }
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
          
            Console.WriteLine("\n\n");
            Console.WriteLine("Enemigos en el campo: "+cont);
            matrix.Cont = cont;
        }
        /// <summary>
        /// Cambia la ubicacion de un personaje
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="character"></param>
        public static void ChangeLocation(int x, int y, Character character)
        {
            character.Ubicacion.X = x;
            character.Ubicacion.Y = y;
        }

        public static void MoveGeneric(Matrix matrix, int max)
        {
            GenericChar generico;
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j <max; j++)
                {
                    if (matrix.MatrixChar[i][j] is GenericChar)
                    {
                        generico = (GenericChar)matrix.MatrixChar[i][j];
                        generico.death(matrix);
                    }
                }
            }
        }

        public static void Dibujo()
        {
            Console.WriteLine("███████████████████████████████████████████████████████████████████████████████████████████████████████\r\n█░░░░░░██████████░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░░░███░░░░░░░░░░█░░░░░░░░██░░░░░░░░█\r\n█░░▄▀░░░░░░░░░░░░░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀░░█░░▄▀▄▀░░██░░▄▀▄▀░░█\r\n█░░▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░░░░░▄▀░░░░░░█░░▄▀░░░░░░░░▄▀░░███░░░░▄▀░░░░█░░░░▄▀░░██░░▄▀░░░░█\r\n█░░▄▀░░░░░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░█████░░▄▀░░█████░░▄▀░░████░░▄▀░░█████░░▄▀░░█████░░▄▀▄▀░░▄▀▄▀░░███\r\n█░░▄▀░░██░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░█████░░▄▀░░█████░░▄▀░░░░░░░░▄▀░░█████░░▄▀░░█████░░░░▄▀▄▀▄▀░░░░███\r\n█░░▄▀░░██░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█████░░▄▀░░█████░░▄▀▄▀▄▀▄▀▄▀▄▀░░█████░░▄▀░░███████░░▄▀▄▀▄▀░░█████\r\n█░░▄▀░░██░░░░░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░█████░░▄▀░░█████░░▄▀░░░░░░▄▀░░░░█████░░▄▀░░█████░░░░▄▀▄▀▄▀░░░░███\r\n█░░▄▀░░██████████░░▄▀░░█░░▄▀░░██░░▄▀░░█████░░▄▀░░█████░░▄▀░░██░░▄▀░░███████░░▄▀░░█████░░▄▀▄▀░░▄▀▄▀░░███\r\n█░░▄▀░░██████████░░▄▀░░█░░▄▀░░██░░▄▀░░█████░░▄▀░░█████░░▄▀░░██░░▄▀░░░░░░█░░░░▄▀░░░░█░░░░▄▀░░██░░▄▀░░░░█\r\n█░░▄▀░░██████████░░▄▀░░█░░▄▀░░██░░▄▀░░█████░░▄▀░░█████░░▄▀░░██░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀░░█░░▄▀▄▀░░██░░▄▀▄▀░░█\r\n█░░░░░░██████████░░░░░░█░░░░░░██░░░░░░█████░░░░░░█████░░░░░░██░░░░░░░░░░█░░░░░░░░░░█░░░░░░░░██░░░░░░░░█\r\n███████████████████████████████████████████████████████████████████████████████████████████████████████\r\n");
        }
    }
}


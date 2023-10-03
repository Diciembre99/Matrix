using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace Matrix
{
    public class Neo : Character
    {
        private bool chosen;

        public Neo(string name, Location location, int age) : base(name, location, age)
        {

        }

        public bool Chosen { get => chosen; set => chosen=value; }

        public void mover(Matrix matrix, int max)
        {
            Character? characterAux = null;
            int x = (int)this.Ubicacion.X;
            int y = (int)this.Ubicacion.Y;
            //Genero 2 numeros random a donde se movera
            int x1 = RandomNumber.GiveNumber(0, max);
            int y1 = RandomNumber.GiveNumber(0, max);
            //Verificamos que la casilla donde se movera NEO no este ocupada
            if (matrix.MatrixChar[x1][y1] != null)
            {
                characterAux = matrix.MatrixChar[x1][y1];
                characterAux.Ubicacion.X = x;
                characterAux.Ubicacion.Y = y;
                //En caso de que la casilla este ocupada almacenamos al personaje que la ocupa en una variable auxiliar
                matrix.MatrixChar[x][y] = characterAux;
            }
            else
            {
                //Colocamos a null para que no se duplique Neo
                matrix.MatrixChar[x][y] = null;
            }
            matrix.MatrixChar[x1][y1] = this;
            this.Ubicacion.X = x1;
            this.Ubicacion.Y = y1;

        }

        /// <summary>
        /// Es elegido
        /// </summary>
        /// <returns> Verdadero o falso</returns>
        public bool IsChosen()
        {
            //Definimos si Neo es o no el elegido 
            RandomNumber rng = new();
            //Numero aleatorio entre 0 y 1
            int probabilidad = RandomNumber.GiveNumber(0, 2);
            if (probabilidad == 1) return true;
            else return false;
        }
        /// <summary>
        /// Metodo para que Neo genere enemigos si es elegido o no
        /// </summary>
        /// <param name="matrix"></param>
        public void CreateEnemy(Matrix matrix)
        {
            this.chosen = IsChosen();
            //Si Neo es elegido generamos enemigos
            if (this.chosen)
            {
                GenerateEnemies(matrix);

            }
        }

        /// <summary>
        /// Creacion de enemigos
        /// </summary>
        /// <param name="matrix"></param>
        public void GenerateEnemies(Matrix matrix)
        {
            int x = (int)this.Ubicacion.X;
            int y = (int)this.Ubicacion.Y;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j<= 1; j++)
                {
                    try
                    {
                        //En caso de no haber personajes generamos mas
                        if (matrix.MatrixChar[x + i][y + j] is null)
                        {
                            //Con este calculo podemos colocar enemigos al rededor de neo, sabiendo al ubicacion actual de el
                            matrix.MatrixChar[x + i][y + j] = matrix.Cola[0];
                            //Cambiamos la ubicacion de NEO
                            Utility.ChangeLocation(x+i, y + j, matrix.Cola[0]);
                            matrix.Cola.RemoveAt(0);
                        }
                        //Excepciones que controlan si la lista se ha quedado sin personajes genericos y si el movimiento esta dentro del rango
                    }
                    catch (IndexOutOfRangeException) { }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
namespace Matrix
{
    class MatrixFactory

    {
        /// <summary>
        /// Clase que fabrica a matrix
        /// </summary>
        /// <param name="length"></param>
        /// <param name="smith"></param>
        /// <param name="neo"></param>
        /// <returns></returns>
        public static Matrix createMatrix(int length, Smith smith,Neo neo)
        {
            int x = 0; int y = 0;
            Matrix matrix = new(length, length);
            RandomNumber rng = new();
            List<GenericChar> characterList = new List<GenericChar>();
            
            for (int i = 0; i < 200; i++)
            {
                characterList.Add(GenericCharFactory.CreateGenericChar(length));
                //Verificamos si la ubicacion esta usada ya o aun no
                while (MatrixFactory.duplicate(characterList, x, y))
                {
                    x = RandomNumber.GiveNumber(0, length);
                    y = RandomNumber.GiveNumber(0, length);
                }
                characterList[i].Ubicacion.X = x;
                characterList[i].Ubicacion.Y = y;
            }
            matrix.Cola = characterList;
            //Agregamos 50 personajes genericos a la matriz
            for (int i = 0; i < 50; i++)
            {
                matrix.addMatrix();
            }

            //Agregamos a smith y a neo de forma independiente a la cola de enemigos genericos
            x = (int)smith.Ubicacion.X;
            y = (int)smith.Ubicacion.Y;
            matrix.MatrixChar[x][y] = smith;


            x = (int)neo.Ubicacion.X;
            y = (int)neo.Ubicacion.Y;
            matrix.MatrixChar[x][y] = neo;
            
            matrix.Cola = characterList;
            return matrix;
        }


        /// <summary>
        /// Clase que verifica si la lista deperonajes tiene una ubicacion duplicada
        /// </summary>
        /// <param name="characterList"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool duplicate(List<GenericChar> characterList, int x, int y)
        {
            //Recorre la lista buscando posibles personajes que coincida con la ubicacion generada aleatoria
            foreach (Character character in characterList)
            {
                if (character != null && character.Ubicacion.X == x && character.Ubicacion.Y == y) { return true; }
            }
            return false;
        }
    }
}

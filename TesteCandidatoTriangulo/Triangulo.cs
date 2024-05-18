using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int ResultadoTriangulo(string dadosTriangulo)
        {

            var triangulo = JsonConvert.DeserializeObject<int[][]>(dadosTriangulo);

            var array = new int[triangulo[triangulo.Length - 1].Length];
            for (int i = 0; i < triangulo[triangulo.Length - 1].Length; i++)
            {
                array[i] = triangulo[triangulo.Length - 1][i];
            }

            for (int i = triangulo.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangulo[i].Length; j++)
                {
                    array[j] = triangulo[i][j] + Math.Max(array[j], array[j + 1]);
                }
            }

            return array[0];
        }
    }
}

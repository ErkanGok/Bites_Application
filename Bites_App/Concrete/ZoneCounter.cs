using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erkan_GOK
{
    class ZoneCounter : ZoneCounterInterface
    {
        #region Tanımlamalar
        private MapInterface Map;
        #endregion   


        #region Fonksiyonlar
        //Init yerine constructor kullanılabilir.
        public void Init(MapInterface map)
        {
            Map = map;
        }      
        
        static bool isSafe(int[,] M, int row,int col, bool[,] visited , int width, int height) => 
            (row >= 0) && (row < width) && (col >= 0) && (col < height) && (M[row, col] == 1 && !visited[row, col]);
       
        static void DFS(int[,] M, int row,int col, bool[,] visited,int width, int height)
        {
            
            int[] rowNbr = new int[] { -1, -1, -1, 0,
                                        0, 1, 1, 1 };
            int[] colNbr = new int[] { -1, 0, 1, -1,
                                        1, -1, 0, 1 };
            
            visited[row, col] = true;
            
            for (int k = 0; k < 8; ++k)
                if (isSafe(M, row + rowNbr[k], col + colNbr[k], visited,width,height))
                    DFS(M, row + rowNbr[k], col + colNbr[k], visited,width,height);
        }
        
        static int countIslands(int[,] M, int width, int height)
        {
           
            bool[,] visited = new bool[width, height];
           
            int count = 0;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    if (M[i, j] == 1 && !visited[i, j])
                    {                        
                        DFS(M, i, j, visited,width,height);
                        ++count;
                    }

            return count;
        }

        public int Solve()
        {            
            Map.GetSize(out int width,out int height);  

            int[,] result = new int[width, height];
            
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (Map.IsBorder(i, j))
                        result[i, j] = 0; // --> 0 Border'a karşılık gelmektedir.
                    else
                        result[i, j] = 1; // --> 1 Bölgelere Karşılık gelmektedir.
                    
                }
                Console.WriteLine();
            }            
            return countIslands(result, width,height);
            
        }
        #endregion
    }
}



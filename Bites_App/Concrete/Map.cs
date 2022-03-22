using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erkan_GOK
{
    public class Map : MapInterface
    {
        #region Tanımlamalar
        private int _width;
        private int _height;        
        private List<Border> Borders = new List<Border>();
        #endregion

        #region Fonksiyonlar
        public void ClearBorder(int x, int y)
        {
            Border border = Borders.FirstOrDefault(b => b.XPoint == x && b.YPoint == y);
            if (border == null)
                throw new Exception("Bu verdiğiniz değerler bir sınır değildir.");
            Borders.Remove(border);            
        }

        public void GetSize(out int width, out int height)
        {
            width = _width;
            height = _height;
        }      

        public bool IsBorder(int x, int y) => Borders.Any(b => b.XPoint == x && b.YPoint == y);

        public void SetBorder(int x, int y)
        {
            if(x > _width)
                throw new Exception("Sınırların Dışında Bir Değer Girdiniz !");
            if (y > _height )
                throw new Exception("Sınırların Dışında Bir Değer Girdiniz !");
            if (x < 0 || y < 0)
                throw new Exception("Lütfen Pozitif Bir değer Girin !");
            if(!IsBorder(x,y))
                Borders.Add(new Border { XPoint = x, YPoint = y});
        }

        public void SetSize(in int width, in int height)
        {
            if (width < 0 || height < 0)                         
                throw new Exception("Lütfen Pozitif Bir değer Girin !");
                      
            _width = width;
            _height = height;
            
        }

        public void Show()
        {          
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (Borders.Any(b => b.XPoint == i && b.YPoint == j))
                        Console.Write(" ");
                    else
                        Console.Write("*");                   
                }
                Console.WriteLine();
            }
        }
#endregion
    }
}

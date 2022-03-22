using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erkan_GOK
{
    public class Program 
    {
       static void Main()
        {
            #region Tanımlamalar          

            int width = 6;
            int height = 10;
            var map = new Map();
            var _ZoneCounter = new ZoneCounter();
            #endregion

            try
            {
                #region Test Verisi 
                map.SetSize(width, height);
                map.SetBorder(0, 4);
                map.SetBorder(0, 5);
                map.SetBorder(1, 4);
                map.SetBorder(2, 4);
                map.SetBorder(4, 4);
                map.SetBorder(5, 4);
                map.SetBorder(2, 3);
                map.SetBorder(3, 0);
                map.SetBorder(3, 1);
                map.SetBorder(3, 2);
                map.SetBorder(3, 3);
                map.SetBorder(3, 4);
                map.SetBorder(3, 5);
                map.SetBorder(2, 5);
                map.SetBorder(3, 6);
                map.SetBorder(4, 7);
                map.SetBorder(4, 6);
                map.SetBorder(4, 8);
                map.SetBorder(4, 9);
                map.SetBorder(5, 9);
               

                //map.ClearBorder(3, 6);
                #endregion

                _ZoneCounter.Init(map);                
                Console.WriteLine(_ZoneCounter.Solve());
                map.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            Console.ReadLine();

        }       
    }



}

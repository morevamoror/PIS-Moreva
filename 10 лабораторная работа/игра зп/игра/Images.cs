using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace игра
{
    public class Images
    {
       

       
        public List<Image> list;
        

        public Images()
            {
            list = new List<Image>();
          
                 
        }


            public void Add(Image c)
            {
            list.Add(c);
         
            }
            
       
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace игра
{
   
        public class Picture : Images
        {
            
            public int Count
            {
                get { return list.Count; }
            }
             public  string[] cardList2=new string[20];
          
        int ii = 0;
        public int Get()
            {
                Random R = new Random();
                int NumOfCard = R.Next(Count - 1); //выдает рандомное целое число, максимум число карт
                Image c = list[NumOfCard];
            
                cardList2[ii]=(c.ToString(c));
                ii++;
            list.Remove(c);
           // MessageBox.Show(c.Nomer(c).ToString());
                return c.Nomer(c)+1;
            }

            public Picture()//при вызовы дек состовляется к
            {
              for(int i=0; i<20; i++){
                cardList2[i] = "";
                  }
            for (int i = 0; i < 34; i++)
                {
                Random r = new Random();

                    Add(new Image(i)); 
                }
            }
       
        }
    
}

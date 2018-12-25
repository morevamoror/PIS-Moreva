using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;


namespace игра
{
    public class Game
    {
        public  Picture p;
        public Player[] k;

        public Game(int kol, string[] name, int[] win, int [] idi)
        {
            p = new Picture();
            k = new Player[kol];
            for (int i = 0; i < kol; i++)
            {
                k[i] = new Player( name[i], win[i], idi[i]);
            }
        }


        

        public void CheckAnswers(string[] answers, Player pl)
        {
           
            for(int i=0; i<p.cardList2.Length; i++)
            {
             //   MessageBox.Show(p.cardList2[i]);
                for(int j=0; j<answers.Length; j++)
                {
                    if (p.cardList2[i].ToLower() == answers[j].ToLower())
                    {
                        pl.number_right_ansvers[i] = true;
                    }
                }
            }
            
            
        }
        public string FindWinner()
        {
            int max = 0;
            string winnerr = "";
            int[] winner = new int[k.Length];
            for(int i = 0; i < k.Length; i++)
            {
                winner[i] = 0;
            }
           for(int i=0; i < 20; i++)
            {
                for (int j = 0; j < k.Length; j++) {
                    if (k[j].number_right_ansvers[i])
                        winner[j]+=1;
                        
                    }
            }
            int pobeda = 0;
           for(int i=0; i< k.Length; i++)
            {
                if (winner[pobeda] < winner[i])
                    pobeda = i;
               // winnerr += k[i].Nameret(k[i]) + " набрал:" + winner[i]+"   ";
            }
            k[pobeda].WinUp(k[pobeda]);
            winnerr += " Победил:" + k[pobeda].Name + "   Общее число побед:" + k[pobeda].Win.ToString();
            return winnerr;
        }

    }
}

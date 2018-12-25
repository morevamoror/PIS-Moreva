using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace игра
{
   

    public class Player
        {   static string connectionString = @"Data Source=LAPTOP-O8RC8S5Q;Initial Catalog=Zapomni;Integrated Security=True";

            int ID;
            public string Name;
            public int Win;
            public bool[] number_right_ansvers = new bool[20];
            
            public Player( string name,int win,int idi)
            {
                this.ID = idi;
                this.Name = name;
                this.Win = win;
            for (int i = 0; i < 20; i++) number_right_ansvers[i] = false;
            }
        public string Nameret(Player k)
        {
            return k.Name.ToString();
        }
        public void WinUp(Player p)
        {
            p.Win++;
            Apdate(p);
        }
        public void Apdate(Player p)
        {
            try
            {
                string sqlExpression = "ScoreUpdate";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = p.Name
                    };
                    command.Parameters.Add(nameParam);
                    SqlParameter scoreParam = new SqlParameter
                    {
                        ParameterName = "@score",
                        Value = p.Win
                    };
                    command.Parameters.Add(scoreParam);


                    command.ExecuteScalar().ToString();

                }
           
            }
            catch { }
        }
        }

    
}

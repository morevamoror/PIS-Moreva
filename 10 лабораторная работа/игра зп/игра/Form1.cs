using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace игра
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  
        static string connectionString = @"Data Source=LAPTOP-O8RC8S5Q;Initial Catalog=Zapomni;Integrated Security=True";
      
        private static int AddUser(string name)
        {
            try
            {
                // название процедуры
                string sqlExpression = "AddUser";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    // указываем, что команда представляет хранимую процедуру
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // параметр для ввода имени
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = name
                    };
                    // добавляем параметр
                    command.Parameters.Add(nameParam);
                   

                    SqlParameter scoreParam = new SqlParameter
                    {
                        ParameterName = "@score",
                        Value = 0
                    };
                    command.Parameters.Add(scoreParam);


                   return Convert.ToInt32(command.ExecuteScalar().ToString());




            }
                // prow = true;
            }
            catch { return 0; }
        }

        private static int Prowuser(string name)
        {
            try
            {
                string sqlExpression = "Prowuser";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = name
                    };
                    command.Parameters.Add(nameParam);

                    return Convert.ToInt32(command.ExecuteScalar().ToString());

                }
                //prow = true;
            }
            catch { return 0; }

        }

        private static int ScoreReturn(string name)
        {
            try
            {
                string sqlExpression = "ScoreReturn";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = name
                    };
                    command.Parameters.Add(nameParam);

                    return Convert.ToInt32(command.ExecuteScalar().ToString());

                }
           
            }
            catch { return 0; }

        }














        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i<21; i++)
            this.Controls["pictureBox" + (i).ToString()].Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            for (int i = 0; i < 20; i++)
            {
                answers[i] = "";
            }
        }
        Button bn = new Button();
        public static int count_players;  //количество игроков
        int tp = 0;
       
        public Game g;
        Label player_name = new Label();
        
        Button bpod = new Button();

        private void button1_Click(object sender, EventArgs e)
        {
            count_players = Convert.ToInt16(numericUpDown1.Value);
            lb_count.Visible = false;
            numericUpDown1.Visible = false;
            button1.Visible = false;
            for (int i = 0; i < count_players; i++)
            {
                TextBox tx = new TextBox();
                tx.Name = "textbox" + (i + 1);
                tx.Location = new Point(100, 30 * i);
                tx.Size = new Size(100, 24);
                tx.Text = "Игрок" + (i + 1);
                this.Controls.Add(tx);

                Label lb = new Label();
                lb.Name = "label" + (i + 1);
                lb.Location = new Point(10, 30 * i);
                lb.Size = new Size(100, 24);
                lb.Text = "Игрок" + (i + 1);
                this.Controls.Add(lb);

            }

            bn.Name = "ButStart";
            bn.Location = new Point(10, 30 * count_players);
            bn.Size = new Size(190, 24);
            bn.Text = "Start";
            bn.Click += new EventHandler(ButStart_Click);
            this.Controls.Add(bn);
        }

        static int[] win = new int[0];
        int[] idi = new int[0];
        string[] names = new string[0];
        private void ButStart_Click(object sender, EventArgs e)
        {
           
        
           
            bn.Visible = false;
            Array.Resize(ref idi, count_players);
            for (int i = 0; i < count_players; i++) //считываем имена игроков 
            {
                int a = Prowuser(this.Controls["textbox" + (i + 1).ToString()].Text);
                if ( a> 0)
                {
                    Array.Resize(ref names, names.Length + 1);
                    Array.Resize(ref win, win.Length + 1);
                    win[i] = ScoreReturn(this.Controls["textbox" + (i + 1).ToString()].Text);
                    idi[i] = a;
                   
                    names[i] = this.Controls["textbox" + (i + 1).ToString()].Text;
                    this.Controls["textbox" + (i + 1).ToString()].Visible = false;
                    this.Controls["label" + (i + 1).ToString()].Visible = false;
                   // MessageBox.Show("{0}", names[i]+"   "+ win[i].ToString()+"    "+ idi[i].ToString());
                }
                else
                {
                    a = AddUser(this.Controls["textbox" + (i + 1).ToString()].Text);
                    Array.Resize(ref names, names.Length + 1);
                    Array.Resize(ref win, win.Length + 1);
                    win[i] = 0;
                    idi[i] = a;
                    names[i] = this.Controls["textbox" + (i + 1).ToString()].Text;
                    this.Controls["textbox" + (i + 1).ToString()].Visible = false;
                    this.Controls["label" + (i + 1).ToString()].Visible = false;
                  //  MessageBox.Show("{0}", names[i] + "   " + win[i].ToString() + "    " + idi[i].ToString());
                }

            }



            g = new Game(count_players,names, win,idi);
           
            for (int i = 0; i < 20; i++) //вывод иконок в пикчебоксы
            {

                Bitmap bitmap = new Bitmap(g.p.Get().ToString()+".png");
                this.Controls["pictureBox" + (i + 1).ToString()].BackgroundImage = bitmap;
                this.Controls["pictureBox" + (i + 1).ToString()].BackColor = Color.White;
                this.Controls["pictureBox" + (i + 1).ToString()].Visible = true;
            }


            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 7000; //180000;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                timer1.Stop();
            listBox1.Visible = true;
            listBox2.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            play();
               
            

        }

       
        public void play()
        {
            player_name.Name = g.k[tp].Nameret(g.k[tp]); // вывод имени игрока который сейчас отвечает
            player_name.Location = new Point(50, 5);
            player_name.Size = new Size(100, 24);
            //  player_name.Text = players[0].Name.ToString();
            this.Controls.Add(player_name);

          
            listBox1.Items.AddRange(g.p.list[0].Words());

           

            for (int j = 0; j < 20; j++)
            {
                this.Controls["pictureBox" + (j + 1).ToString()].Visible = false;
            }

           

        }
        int q=0;
        string[] answers = new string [20];


      
        public void play2(){
            button3.Visible = false;
            button4.Visible = true;
            player_name.Name = g.k[tp].Nameret(g.k[tp]); // вывод имени игрока который сейчас отвечает
            listBox1.Visible = true;
            listBox2.Visible = true;



            listBox1.Items.AddRange(g.p.list[0].Words());

           
            this.Size = new Size(500, 700);

            for (int j = 0; j < 20; j++)
            {
                this.Controls["pictureBox" + (j + 1).ToString()].Visible = false;
            }


            q = 0;
            for (int i = 0; i < 20; i++)
            {
                answers[i] = "";
            }
        }

  

        private void button2_Click(object sender, EventArgs e)
        {
          
            try
            {
                string str = listBox1.SelectedItem.ToString();
                listBox2.Items.Add(str); // добавляем выбранный пользователем предмет во второй листбокс  
                listBox1.Items.Remove(str);
                answers[q] = str; // записывем очередной ответ игрока
                q++; //счетчик добавленных ответов

                if (q >= 20) //игрок завершил выбор слов
                {
                   
                    g.CheckAnswers(answers, g.k[tp]); //узнаем число правильных отвтов у этого игрока
                                                      // MessageBox.Show(g.k[tp].Name);
                    for (int i = 0; i < 20; i++)
                    {

                        this.Controls["pictureBox" + (i + 1).ToString()].Visible = true;

                    }
                    for (int i = 0; i < 20; i++)
                    {
                        if (g.k[tp].number_right_ansvers[i] == true)
                        {
                            this.Controls["pictureBox" + (i + 1).ToString()].BackColor = Color.Green;
                        }
                        else this.Controls["pictureBox" + (i + 1).ToString()].BackColor = Color.Red;
                    }

                    listBox1.Visible = false;
                    listBox2.Visible = false;
                    button2.Visible = false;
                    button3.Visible = true;
                    button4.Visible = false;
                  

                    tp++; //ТЕКУЩИЙ ИГРОК
                    q = 0;
                    for (int i = 0; i < 20; i++)
                    {
                        answers[i] = "";
                    }

                }

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tp < count_players) //еще не все игроки ответили
            {

                player_name.Text = g.k[tp].Name.ToString();
                listBox1.Items.Clear();
                listBox2.Items.Clear();



                button2.Visible = true;
                for (int i = 0; i < 20; i++)
                {

                    this.Controls["pictureBox" + (i + 1).ToString()].Visible = false;

                }
                play2();
            }
            else 
            {
                button3.Visible = false;
                g.FindWinner();
                player_name.Text = "Игра завершена! " + g.FindWinner();
                player_name.Size = new Size(300, 24);
                listBox1.Visible = false;
                listBox2.Visible = false;
                bpod.Visible = false;
                for (int i = 0; i < 20; i++)
                {
                    this.Controls["pictureBox" + (i + 1).ToString()].Visible = false;

                }
                button5.Visible = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.CheckAnswers(answers, g.k[tp]); //узнаем число правильных отвтов у этого игрока
                                              // MessageBox.Show(g.k[tp].Name);
            for (int i = 0; i < 20; i++)
            {

                this.Controls["pictureBox" + (i + 1).ToString()].Visible = true;

            }
            for (int i = 0; i < 20; i++)
            {
                if (g.k[tp].number_right_ansvers[i] == true)
                {
                    this.Controls["pictureBox" + (i + 1).ToString()].BackColor = Color.Green;
                }
                else this.Controls["pictureBox" + (i + 1).ToString()].BackColor = Color.Red;
            }

            listBox1.Visible = false;
            listBox2.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;


            tp++; //ТЕКУЩИЙ ИГРОК
            q = 0;
            for (int i = 0; i < 20; i++)
            {
                answers[i] = "";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tp = 0;
            button4.Visible = false;
            button5.Visible = false;
            player_name.Text = names[tp];
            g = new Game(count_players, names, win, idi);

            for (int i = 0; i < 20; i++) //вывод иконок в пикчебоксы
            {

                Bitmap bitmap = new Bitmap(g.p.Get().ToString() + ".png");
                this.Controls["pictureBox" + (i + 1).ToString()].BackgroundImage = bitmap;
                this.Controls["pictureBox" + (i + 1).ToString()].BackColor = Color.White;
                this.Controls["pictureBox" + (i + 1).ToString()].Visible = true;
            }


            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 7000; //180000;
        }
    }
}

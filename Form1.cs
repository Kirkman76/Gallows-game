using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallows
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            words = new BaseOfWords();
            lettersPositions = new List<int>();
            playingWordNum = 0;
            unsuccessAttempts = 0;
            wordsCounter = 0;


        }

        BaseOfWords words;
        int playingWordNum;
        int unsuccessAttempts;
        int wordsCounter;
        List<int> lettersPositions;


        public void LoadWordOnScreen()
        {
            Graphics g = this.CreateGraphics();
            lettersPositions.Clear();
            button2.Visible = false;
            HatchStyle backStyle = new HatchStyle();
            backStyle = HatchStyle.Cross;
            HatchBrush backgrndBrush = new HatchBrush(backStyle, Color.CadetBlue, Color.White);
            g.FillRectangle(backgrndBrush, new Rectangle(0, 0, 862, 561));

            ClearKeyboard();

            string word = null;
            try
            {
                word = words.GetWords()[playingWordNum];
            }
            catch
            {
                return;
            }
            Random rand = new Random();
            int numOfLetters = Convert.ToInt32(word.Length * 0.3); // количество начально открываемых букв

            ////////// подготовка коллекции начально открытых букв
            for (int i = 0; i < numOfLetters; i++)
            {
                int tmpRand = rand.Next(0, word.Length);
                if (!lettersPositions.Contains(tmpRand))
                {
                    lettersPositions.Add(tmpRand);
                }
                // если буква встречается несколько раз
                if (word.Count(x => x == word[tmpRand]) > 1)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (word[j] == word[tmpRand] && !lettersPositions.Contains(j))
                        {
                            lettersPositions.Add(j);
                        }
                    }
                }
            }
            lettersPositions.Sort();
            ////////////

            int xCoord = 390;
            int yCoord = 300;
            SolidBrush backBrush = new SolidBrush(Color.Coral);
            SolidBrush txtBrush = new SolidBrush(Color.Black);

            for (int i = 0; i < word.Length; i++)
            {
                string forDraw = "--";

                if (lettersPositions.Any(x => x == i))
                {
                    forDraw = Convert.ToString(word[i]);
                }

                g.FillRectangle(backBrush, new Rectangle(xCoord, yCoord, 40, 40));
                g.DrawString(forDraw, new Font("Arial", 30), txtBrush, xCoord - 2, yCoord - 2);
                xCoord += 45;
            }
            backBrush.Dispose();
            txtBrush.Dispose();
            g.Dispose();

        }

        private void ClearKeyboard()
        {
            button1.BackColor = Color.MistyRose;
            button3.BackColor = Color.MistyRose;
            button4.BackColor = Color.MistyRose;
            button5.BackColor = Color.MistyRose;
            button6.BackColor = Color.MistyRose;
            button7.BackColor = Color.MistyRose;
            button8.BackColor = Color.MistyRose;
            button9.BackColor = Color.MistyRose;
            button10.BackColor = Color.MistyRose;
            button11.BackColor = Color.MistyRose;
            button12.BackColor = Color.MistyRose;
            button13.BackColor = Color.MistyRose;
            button14.BackColor = Color.MistyRose;
            button15.BackColor = Color.MistyRose;
            button16.BackColor = Color.MistyRose;
            button17.BackColor = Color.MistyRose;
            button18.BackColor = Color.MistyRose;
            button19.BackColor = Color.MistyRose;
            button20.BackColor = Color.MistyRose;
            button21.BackColor = Color.MistyRose;
            button22.BackColor = Color.MistyRose;
            button23.BackColor = Color.MistyRose;
            button24.BackColor = Color.MistyRose;
            button25.BackColor = Color.MistyRose;
            button26.BackColor = Color.MistyRose;
            button27.BackColor = Color.MistyRose;
            button28.BackColor = Color.MistyRose;
            button29.BackColor = Color.MistyRose;
            button30.BackColor = Color.MistyRose;
            button31.BackColor = Color.MistyRose;
            button32.BackColor = Color.MistyRose;
            button33.BackColor = Color.MistyRose;
            button34.BackColor = Color.MistyRose;
        }

        private void DrawGallows(int unsuccessAttempts)
        {
            Graphics g = this.CreateGraphics();
            Pen gallowPen = new Pen(Color.DarkOliveGreen, 15);
            Pen manPen = new Pen(Color.DimGray, 5);
            Pen ropePen = new Pen(Color.SandyBrown, 7);

            switch (unsuccessAttempts)
            {
                case 1:
                    g.DrawLine(gallowPen, 20, 500, 100, 500);
                    return;
                case 2:
                    g.DrawLine(gallowPen, 50, 500, 50, 70);

                    return;
                case 3:
                    g.DrawLine(gallowPen, 43, 70, 250, 70);
                    return;
                case 4:
                    g.DrawLine(ropePen, 200, 63, 200, 135);
                    return;
                case 5:
                    g.DrawEllipse(manPen, 170, 135, 60, 60);
                    return;
                case 6:
                    g.DrawEllipse(manPen, 162, 195, 80, 160);
                    return;
                case 7:
                    g.DrawLine(manPen, 178, 340, 150, 430);
                    return;
                case 8:
                    g.DrawLine(manPen, 222, 340, 250, 430);
                    return;
                case 9:
                    g.DrawLine(manPen, 173, 220, 130, 310);
                    return;
                case 10:
                    g.DrawLine(manPen, 230, 220, 270, 310);
                    return;
            }

            gallowPen.Dispose();
            manPen.Dispose();
            ropePen.Dispose();
            g.Dispose();
        }

        private void GameOver()
        {
            tableLayoutPanel1.Enabled = false;
            Graphics g = this.CreateGraphics();
            SolidBrush txtBrush = new SolidBrush(Color.Black);
            Font txtFont1 = new Font("Arial", 30);
            Font txtFont2 = new Font("Arial", 15);

            g.DrawString("Игра окончена", txtFont1, txtBrush, 300, 150);
            g.DrawString("Отгадано слов: " + wordsCounter, txtFont2, txtBrush, 300, 230);
        }

        private void NextWord()
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel1.Enabled = true;
            label1.Visible = false;
            Random wordChoose = new Random();
            playingWordNum = wordChoose.Next(0, words.GetWords().Count);
            try
            {
                LoadWordOnScreen();
            }
            catch
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string word = words.GetWords()[playingWordNum];
            Graphics g = this.CreateGraphics();
            SolidBrush backBrush = new SolidBrush(Color.Coral);
            SolidBrush txtBrush = new SolidBrush(Color.Black);
            int xCoord = 390;
            int yCoord = 300;

            int pos = 0;

            if (word.Contains(btn.Tag.ToString().ToLower()))
            {
                if (word.LastIndexOf(btn.Tag.ToString().ToLower()) == 0){
                    g.FillRectangle(backBrush, new Rectangle(xCoord + pos * 45, yCoord, 40, 40));
                    g.DrawString(btn.Tag.ToString().ToLower(), new Font("Arial", 30), txtBrush, xCoord - 2 + pos * 45, yCoord - 2);
                    if (!lettersPositions.Contains(word.LastIndexOf(btn.Tag.ToString().ToLower())))
                    {
                        lettersPositions.Add(word.LastIndexOf(btn.Tag.ToString().ToLower()));
                    }
                    
                }
                else
                {
                    for (; pos != word.LastIndexOf(btn.Tag.ToString().ToLower());)
                    {
                        pos = word.IndexOf(btn.Tag.ToString().ToLower(), pos + 1);
                        g.FillRectangle(backBrush, new Rectangle(xCoord + pos * 45, yCoord, 40, 40));
                        g.DrawString(btn.Tag.ToString().ToLower(), new Font("Arial", 30), txtBrush, xCoord - 2 + pos * 45, yCoord - 2);
                        if (!lettersPositions.Contains(pos))
                        {
                            lettersPositions.Add(pos);
                        }
                    }
                }

                btn.BackColor = Color.Aquamarine;
            }
            else
            {
                btn.BackColor = Color.IndianRed;
                unsuccessAttempts++;
                DrawGallows(unsuccessAttempts);
            }
            backBrush.Dispose();
            txtBrush.Dispose();
            g.Dispose();
            
            if (unsuccessAttempts == 10)
            {
                GameOver();
            }

            if (lettersPositions.Count == word.Length)
            {
                button2.Visible = true;
                wordsCounter++;
            }

        }

        

        private void НоваяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel1.Enabled = true;
            label1.Visible = false;
            lettersPositions.Clear();
            unsuccessAttempts = 0;
            wordsCounter = 0;
            Random wordChoose = new Random();
            playingWordNum = wordChoose.Next(0, words.GetWords().Count);
            try
            {
                LoadWordOnScreen();
            }
            catch
            {

            }
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            lettersPositions.Clear();
            NextWord();
            for (int i = 1; i <= unsuccessAttempts; i++)
            {
                DrawGallows(i);
            }
            button2.Visible = false;
        }
    }
}

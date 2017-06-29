using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace The_4096_Game
{
    public partial class Form1 : Form
    {
        private int[,] blocks = new int[5, 5];
        private int score, best;
        private Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            resetBoard();
            info.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\startup.png";
        }
        public void updatePic()
        {
            p1.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[0, 0] + ".png";
            p2.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[0, 1] + ".png";
            p3.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[0, 2] + ".png";
            p4.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[0, 3] + ".png";
            p5.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[0, 4] + ".png";
            p6.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[1, 0] + ".png";
            p7.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[1, 1] + ".png";
            p8.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[1, 2] + ".png";
            p9.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[1, 3] + ".png";
            p10.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[1, 4] + ".png";
            p11.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[2, 0] + ".png";
            p12.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[2, 1] + ".png";
            p13.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[2, 2] + ".png";
            p14.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[2, 3] + ".png";
            p15.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[2, 4] + ".png";
            p16.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[3, 0] + ".png";
            p17.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[3, 1] + ".png";
            p18.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[3, 2] + ".png";
            p19.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[3, 3] + ".png";
            p20.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[3, 4] + ".png";
            p21.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[4, 0] + ".png";
            p22.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[4, 1] + ".png";
            p23.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[4, 2] + ".png";
            p24.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[4, 3] + ".png";
            p25.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\" + blocks[4, 4] + ".png";
        }
        public void resetBoard()
        {
            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++)
                {
                    blocks[a, b] = 0;
                }
            updatePic();
            score = 0;
        }
        public void makeRandom2()
        {
            bool chk = false;
            int a, b, c;
            if (!isFull())
            {
                while (chk == false)
                {
                    a = rand.Next(5);
                    b = rand.Next(5);
                    c = rand.Next(100);
                    if (blocks[a, b] == 0)
                    {
                        if (c > 85)
                            blocks[a, b] = 4;
                        else
                            blocks[a, b] = 2;
                        chk = true;
                    }
                }
                updatePic();
            }
        }
        public bool isFull()
        {
            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++)
                {
                    if (blocks[a, b] == 0)
                        return false;
                }
            return true;
        }
        private void moveMe(object sender, KeyEventArgs e)
        {
                info.Visible = false;
            this.checkBoard();
            if (e.KeyCode == Keys.Up)
            {
                moveArrow(0);
            }
            if (e.KeyCode == Keys.Right)
            {
                moveArrow(3);
            }
            if (e.KeyCode == Keys.Down)
            {
                moveArrow(1);
            }
            if (e.KeyCode == Keys.Left)
            {
                moveArrow(2);
            }
            makeRandom2();
            updateLabel();
        }
        private void moveArrow(int p)
        {
            if (p == 0)
            {
                shiftUp();
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (i + 1 < 5)
                        {
                            if (blocks[i, j] == blocks[i + 1, j])
                            {
                                blocks[i, j] *= 2;
                                calScore(blocks[i, j]);
                                blocks[i + 1, j] = 0;
                            }
                        }
                    }
                shiftUp();
            }
            if (p == 1)
            {
                shiftDown();
                for (int i = 4; i >= 0; i--)
                    for (int j = 4; j >= 0; j--)
                    {
                        if (i - 1 >= 0)
                        {
                            if (blocks[i, j] == blocks[i - 1, j])
                            {
                                blocks[i, j] *= 2;
                                calScore(blocks[i, j]);
                                blocks[i - 1, j] = 0;
                            }
                        }
                    }
                shiftDown();
            }
            if (p == 2)
            {
                shiftLeft();
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (j + 1 < 5)
                        {
                            if (blocks[i, j] == blocks[i, j + 1])
                            {
                                blocks[i, j] *= 2;
                                calScore(blocks[i, j]);
                                blocks[i, j + 1] = 0;
                            }
                        }
                    }
                shiftLeft();
            }
            if (p == 3)
            {
                shiftRight();
                for (int i = 4; i >= 0; i--)
                    for (int j = 4; j >= 0; j--)
                    {
                        if (j - 1 >= 0)
                        {
                            if (blocks[i, j] == blocks[i, j - 1])
                            {
                                blocks[i, j] *= 2;
                                calScore(blocks[i, j]);
                                blocks[i, j - 1] = 0;
                            }
                        }
                    }
                shiftRight();
            }
        }
        private void shiftRight()
        {
            for (int i = 4; i >= 0; i--)
                for (int j = 4; j >= 0; j--)
                {
                    if (j - 1 >= 0)
                    {
                        if (blocks[i, j] == 0)
                        {
                            blocks[i, j] = blocks[i, j - 1];
                            blocks[i, j - 1] = 0;
                        }
                    }
                    if (j - 2 >= 0)
                    {
                        if (blocks[i, j - 1] == 0 && blocks[i, j] == 0)
                        {
                            blocks[i, j] = blocks[i, j - 2];
                            blocks[i, j - 2] = 0;
                        }
                    }
                    if (j - 3 >= 0)
                    {
                        if (blocks[i, j] == 0 && blocks[i, j - 1] == 0 && blocks[i, j - 2] == 0)
                        {
                            blocks[i, j] = blocks[i, j - 3];
                            blocks[i, j - 3] = 0;
                        }
                    }
                    if (j - 4 >= 0)
                    {
                        if (blocks[i, j] == 0 && blocks[i, j - 1] == 0 && blocks[i, j - 2] == 0 && blocks[i, j - 3] == 0)
                        {
                            blocks[i, j] = blocks[i, j - 4];
                            blocks[i, j - 4] = 0;
                        }
                    }
                }
        }
        private void shiftUp()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (i + 1 < 5)
                    {
                        if (blocks[i, j] == 0)
                        {
                            blocks[i, j] = blocks[i + 1, j];
                            blocks[i + 1, j] = 0;
                        }
                    }
                    if (i + 2 < 5)
                    {
                        if (blocks[i, j] == 0 && blocks[i + 1, j] == 0)
                        {
                            blocks[i, j] = blocks[i + 2, j];
                            blocks[i + 2, j] = 0;
                        }
                    }
                    if (i + 3 < 5)
                    {
                        if (blocks[i, j] == 0 && blocks[i + 1, j] == 0 && blocks[i + 2, j] == 0)
                        {
                            blocks[i, j] = blocks[i + 3, j];
                            blocks[i + 3, j] = 0;
                        }
                    }
                    if (i + 4 < 5)
                    {
                        if (blocks[i, j] == 0 && blocks[i + 1, j] == 0 && blocks[i + 2, j] == 0 && blocks[i + 3, j] == 0)
                        {
                            blocks[i, j] = blocks[i + 4, j];
                            blocks[i + 4, j] = 0;
                        }
                    }
                }
        }
        private void shiftDown()
        {
            for (int i = 4; i >= 0; i--)
                for (int j = 4; j >= 0; j--)
                {
                    if (i - 1 >= 0)
                    {
                        if (blocks[i, j] == 0)
                        {
                            blocks[i, j] = blocks[i - 1, j];
                            blocks[i - 1, j] = 0;
                        }
                    }
                    if (i - 2 >= 0)
                    {
                        if (blocks[i, j] == 0 && blocks[i - 1, j] == 0)
                        {
                            blocks[i, j] = blocks[i - 2, j];
                            blocks[i - 2, j] = 0;
                        }
                    }
                    if (i - 3 >= 0)
                    {
                        if (blocks[i, j] == 0 && blocks[i - 1, j] == 0 && blocks[i - 2, j] == 0)
                        {
                            blocks[i, j] = blocks[i - 3, j];
                            blocks[i - 3, j] = 0;
                        }
                    }
                    if (i - 4 >= 0)
                    {
                        if (blocks[i, j] == 0 && blocks[i - 1, j] == 0 && blocks[i - 2, j] == 0 && blocks[i - 3, j] == 0)
                        {
                            blocks[i, j] = blocks[i - 4, j];
                            blocks[i - 4, j] = 0;
                        }
                    }
                }

        }
        private void shiftLeft()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (j + 1 < 5)
                    {
                        if (blocks[i, j] == 0)
                        {
                            blocks[i, j] = blocks[i, j + 1];
                            blocks[i, j + 1] = 0;
                        }
                    }
                    if (j + 2 < 5)
                    {
                        if (blocks[i, j] == 0 && blocks[i, j + 1] == 0)
                        {
                            blocks[i, j] = blocks[i, j + 2];
                            blocks[i, j + 2] = 0;
                        }
                    }
                    if (j + 3 < 5)
                    {
                        if (blocks[i, j] == 0 && blocks[i, j + 1] == 0 && blocks[i, j + 2] == 0)
                        {
                            blocks[i, j] = blocks[i, j + 3];
                            blocks[i, j + 3] = 0;
                        }
                    }
                    if (j + 4 < 5)
                    {
                        if (blocks[i, j] == 0 && blocks[i, j + 1] == 0 && blocks[i, j + 2] == 0 && blocks[i, j + 3] == 0)
                        {
                            blocks[i, j] = blocks[i, j + 4];
                            blocks[i, j + 4] = 0;
                        }
                    }
                }

        }
        private void calScore(int p)
        {
            if (p == 2) score += 2;
            if (p == 4) score += 4;
            if (p == 8) score += 8;
            if (p == 16) score += 16;
            else if (p > 16) score += 64;

        }
        public void updateLabel()
        {
            scoreLabel.Text = "Score: " + score;
            if (score > best)
            {
                best = score;
                bestLabel.Text = "Best Score: " + best;
            }
        }
        private void checkWin()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (blocks[i, j] == 4096)
                    {
                        info.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\win.png";
                        info.Visible = true;
                        resetBoard();
                    }
                }
        }
        private void checkLose()
        {
            bool chk = false;
            if (isFull())
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (j + 1 < 5)
                        {
                            if (blocks[i, j] == blocks[i, j + 1])
                            {
                                chk = true;
                                break;
                            }
                        }
                        if (i + 1 < 5)
                        {
                            if (blocks[i, j] == blocks[i + 1, j])
                            {
                                chk = true;
                                break;
                            }
                        }

                    }
                if (!chk)
                {
                    info.ImageLocation = Directory.GetCurrentDirectory() + "\\img\\lose.png";
                    info.Visible = true;
                    resetBoard();
                }
            }
        }
        private void checkBoard()
        {
            this.checkLose();
            this.checkWin();
        }
    }
}


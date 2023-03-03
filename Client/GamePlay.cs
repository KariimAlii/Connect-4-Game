using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;


//=====================Game Play Logic====================//


namespace Client
{
    public partial class GameForm : Form
    {

        private void GamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            challenger = this.player.name;
            CheckScore(e.Location);

        }

        public void CheckScore(Point target)
        {
            col_num = Nrows - 1;
            row_num = (target.X / Size);
            adjustPlay(row_num, col_num, turn);
        }

        private void Horizontal_Vertical_Checker(int row, int col, int playerIdentifier)
        {

            //=====================Horizontal Checker====================//           
            for (int i = 0; i < Ncols - 3; i++)
            {
                if (Board[row, i] == playerIdentifier &&
                    Board[row, i + 1] == playerIdentifier &&
                    Board[row, i + 2] == playerIdentifier &&
                    Board[row, i + 3] == playerIdentifier)
                {
                    if (this.challenger == this.player.name) MessageBox.Show($"You Won !");
                    else MessageBox.Show($"You Lose !");
                }

            }
            //=====================Vertical Checker====================//
            for (int i = 0; i < Nrows - 3; i++)
            {
                if (Board[i, col] == playerIdentifier &&
                    Board[i + 1, col] == playerIdentifier &&
                    Board[i + 2, col] == playerIdentifier &&
                    Board[i + 3, col] == playerIdentifier)
                {

                    if (this.challenger == this.player.name) MessageBox.Show($"You Won !");
                    else MessageBox.Show($"You Lose !");
                    this.GamePanel.Enabled = false;
                }

            }


        }
        private void Diagonal_Checker(int row, int col, int playerIdentifier)
        {
            int r_row = row, l_row = row;
            int r_col = col, l_col = col;
            //=====================right diagonal check====================//
            while (r_row > 0 && r_col < Nrows - 1)
            {
                r_row--;
                r_col++;
            }
            //MessageBox.Show(row.ToString() + "," + col.ToString());
            for (int i = r_row, j = r_col; i < Nrows - 3 && (j > 3); i++, j--)
            {
                if (Board[i, j] == playerIdentifier &&
                    Board[i + 1, j - 1] == playerIdentifier &&
                    Board[i + 2, j - 2] == playerIdentifier &&
                    Board[i + 3, j - 3] == playerIdentifier)
                {

                    if (this.challenger == this.player.name) MessageBox.Show($"You Won !");
                    else MessageBox.Show($"You Lose !");
                    this.GamePanel.Enabled = false;
                }

            }

            //=====================left diagonal check====================//
            while (l_col > 0 && l_row > 0)
            {
                l_row--;
                l_col--;
            }
            //MessageBox.Show(l_row.ToString()+","+l_col.ToString());
            for (int i = l_row, j = l_col; i < Nrows - 3 && (j < Ncols - 3); i++, j++)
            {
                if (Board[i, j] == playerIdentifier &&
                    Board[i + 1, j + 1] == playerIdentifier &&
                    Board[i + 2, j + 2] == playerIdentifier &&
                    Board[i + 3, j + 3] == playerIdentifier)
                {

                    if (this.challenger == this.player.name) MessageBox.Show($"You Won !");
                    else MessageBox.Show($"You Lose !");
                    this.GamePanel.Enabled = false;
                }

            }


        }

        public void adjustPlay(int row_num, int col_num, int turn)
        {

            while (col_num >= 0 && Board[col_num, row_num] > 0)
            {
                col_num--;
            }

            if (col_num >= 0 && Board[col_num, row_num] == 0)
            {
                switch (turn)
                {

                    case 1:

                        DrawCircle(Player1Brush, points[col_num, row_num].X, points[col_num, row_num].Y, Size);
                        Board[col_num, row_num] = 1;
                        Horizontal_Vertical_Checker(col_num, row_num, 1);
                        Diagonal_Checker(col_num, row_num, 1);
                        break;
                    case 2:
                        DrawCircle(Player2Brush, points[col_num, row_num].X, points[col_num, row_num].Y, Size);
                        Board[col_num, row_num] = 2;
                        Horizontal_Vertical_Checker(col_num, row_num, 2);
                        Diagonal_Checker(col_num, row_num, 2);
                        break;

                }
            }








        }


    }
}

using System;
using System.Drawing;
using System.Windows.Forms;


// Game Play Logic


namespace Connect4Game
{
    public partial class GameForm : Form
    {

        private void GamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            CheckScore(e.Location);
        }

        public void CheckScore(Point target)
        {
            col_num = Nrows - 1;
            row_num = (target.X / Size);


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
                        turn = 2;
                        Horizontal_Vertical_Checker(col_num, row_num, 1);
                        Diagonal_Checker(col_num, row_num, 1);
                        break;
                    case 2:
                        DrawCircle(Player2Brush, points[col_num, row_num].X, points[col_num, row_num].Y, Size);
                        Board[col_num, row_num] = 2;
                        turn = 1;
                        Horizontal_Vertical_Checker(col_num, row_num, 2);
                        Diagonal_Checker(col_num, row_num, 2);
                        break;
                }
            }
        }
        private void Horizontal_Vertical_Checker(int row, int col, int playerIdentifier)
        {



            //horizontal checker                 
            for (int i = 0; i < Ncols - 3; i++)
            {
                if (Board[row, i] == playerIdentifier &&
                    Board[row, i + 1] == playerIdentifier &&
                    Board[row, i + 2] == playerIdentifier &&
                    Board[row, i + 3] == playerIdentifier)
                {

                    MessageBox.Show($"Player {playerIdentifier} wins!");
                }

            }
            //vertical checker
            for (int i = 0; i < Nrows - 3; i++)
            {
                if (Board[i, col] == playerIdentifier &&
                    Board[i + 1, col] == playerIdentifier &&
                    Board[i + 2, col] == playerIdentifier &&
                    Board[i + 3, col] == playerIdentifier)
                {

                    MessageBox.Show($"Player {playerIdentifier} wins!");
                }

            }


        }
        private void Diagonal_Checker(int row, int col, int playerIdentifier)
        {
            int r_row = row, l_row = row;
            int r_col = col, l_col = col;
            ////////////////////////right diagonal check///////////////
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

                    MessageBox.Show($"Player {playerIdentifier} wins!");
                }

            }

            ////////////////////left diagonal check///////////////////
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

                    MessageBox.Show($"Player {playerIdentifier} wins!");
                }

            }


        }


    }
}




//public void CheckScore(Point target)
//{
//    int Nx = target.X / Size;
//    //MessageBox.Show(Nx.ToString());
//    bool flag = true;
//    for (int j = Ncols - 1; j >= 0 && flag; j--)
//    {
//        switch (turn)
//        {
//            case 1:
//                if (Board[Nx, j] == 0)
//                {
//                    Board[Nx, j] = 1;
//                    PlayerOneScores[Nx, j] = 1;
//                    CheckWin(1);
//                    DrawCircle(Player1Brush, Nx * Size, (j - 1) * Size, Size);
//                    turn = 2;
//                    flag = false;
//                }
//                break;
//            case 2:
//                if (Board[Nx, j] == 0)
//                {
//                    Board[Nx, j] = 1;
//                    PlayerTwoScores[Nx, j] = 1;
//                    CheckWin(2);
//                    DrawCircle(Player2Brush, Nx * Size, (j - 1) * Size, Size);
//                    turn = 1;
//                    flag = false;
//                }
//                break;
//        }


//    }
//}
//public bool CheckWin(int PlayerNum)
//{
//    for (int i = 0; i < Nrows - 3; i++)
//    {
//        for (int j = 0; j < Ncols; j++)
//        {

//            switch (PlayerNum)
//            {
//                case 1:
//                    //bool HorizontalCheck = false;
//                    if (PlayerOneScores[i, j] == 1 && PlayerOneScores[i + 1, j] == 1 && PlayerOneScores[i + 2, j] == 1 && PlayerOneScores[i + 3, j] == 1) MessageBox.Show("player one wins!");
//                    break;
//                case 2:
//                    if (PlayerTwoScores[i, j] == 1 && PlayerTwoScores[i + 1, j] == 1 && PlayerTwoScores[i + 2, j] == 1 && PlayerTwoScores[i + 3, j] == 1) MessageBox.Show("player two wins!");
//                    break;
//            }
//        }
//    }
//    return true;
//}
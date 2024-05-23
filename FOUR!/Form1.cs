using System.CodeDom;

namespace FOUR_
{

    public partial class Form1 : Form
    {
        int turn = 0;  // 0 f�r spelare 1 (r�d), 1 f�r spelare 2 (gul)
        Label[,] grid = new Label[7, 6];  // En 7x6 matris av labels
        bool gameOver = false;  // Variabel f�r att h�lla koll p� om spelet �r slut

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            // g�r s� att form1 �r 700x600 pixlar f�r enkelhetens skull
            
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    Label lbl = new Label();
                    lbl.Size = new Size(100, 100);
                    lbl.Location = new Point(x * 100, y * 100);
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.BackColor = Color.White;
                    lbl.Click += new EventHandler(Label_Click);
                    grid[x, y] = lbl;
                    this.Controls.Add(lbl);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (gameOver) return;  // Om spelet �r slut kan inga fler drag g�ras

            Label clickedLabel = sender as Label;
            int col = (clickedLabel.Location.X / 100);  // Best�m kolumnen fr�n labelns position
            PlaceDisk(col);
            CheckForWinner(); // Kontrollera om n�gon har vunnit efter varje drag
        }

        private void PlaceDisk(int col)
        {
            for (int row = 5; row >= 0; row--)  // Kontrollera fr�n botten till toppen
            {
                if (grid[col, row].BackColor == Color.White)  // Hitta f�rsta tomma cellen
                {
                    if (turn == 0)
                    {
                        grid[col, row].BackColor = Color.Red;
                        turn = 1;  // Byt till spelare 2:s tur
                    }
                    else
                    {
                        grid[col, row].BackColor = Color.Yellow;
                        turn = 0;  // Byt till spelare 1:s tur
                    }
                    break;
                }
            }
        }

        private void CheckForWinner()
        {
            // Kolla efter om n�gon vinner
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (grid[x, y].BackColor != Color.White)
                    {
                        // Kolla v�gr�tt
                        if (x + 3 < 7 &&
                            grid[x, y].BackColor == grid[x + 1, y].BackColor &&
                            grid[x, y].BackColor == grid[x + 2, y].BackColor &&
                            grid[x, y].BackColor == grid[x + 3, y].BackColor)
                        {
                            EndGame(grid[x, y].BackColor); 
                            return;
                        }

                        // Kolla lodr�tt
                        if (y + 3 < 6 &&
                            grid[x, y].BackColor == grid[x, y + 1].BackColor &&
                            grid[x, y].BackColor == grid[x, y + 2].BackColor &&
                            grid[x, y].BackColor == grid[x, y + 3].BackColor)
                        {
                            EndGame(grid[x, y].BackColor); 
                            return;
                        }

                        // Kolla diagonalt 
                        if (x + 3 < 7 && y + 3 < 6 &&
                            grid[x, y].BackColor == grid[x + 1, y + 1].BackColor &&
                            grid[x, y].BackColor == grid[x + 2, y + 2].BackColor &&
                            grid[x, y].BackColor == grid[x + 3, y + 3].BackColor)
                        {
                            EndGame(grid[x, y].BackColor); 
                            return;
                        }

                        
                        if (x + 3 < 7 && y - 3 >= 0 &&
                            grid[x, y].BackColor == grid[x + 1, y - 1].BackColor &&
                            grid[x, y].BackColor == grid[x + 2, y - 2].BackColor &&
                            grid[x, y].BackColor == grid[x + 3, y - 3].BackColor)
                        {
                            EndGame(grid[x, y].BackColor); 
                            return;
                        }
                    }
                }
            }
        }

        private void EndGame(Color winnerColor)
        {
            string winner = (winnerColor == Color.Red) ? "R�d" : "Gul";
            DialogResult result = MessageBox.Show(winner + " Wiener!\nAgain?", "Vinnare", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Application.Exit(); // St�ng applikationen om anv�ndaren v�ljer att inte spela igen
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void RestartGame()
        {
            // Restartar spelet 
            foreach (Label label in grid)
            {
                label.BackColor = Color.White;
            }
            turn = 0;
            gameOver = false;
        }

        //Lost relics of the past
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }
        private void mouseClick(object sender, MouseEventArgs e)
        {

        }

    }
}

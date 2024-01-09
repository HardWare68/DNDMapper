using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGlower
{
    public partial class Form1 : Form
    {
        private DirectoryInfo pieceDir = new DirectoryInfo("..\\..\\Pieces"); //Directory object for reading the piece files. Relative should work.
        piece curPiece; //Gotta put this on the global scope. lol!
        Button btnCurrentPiece; //Gotta put this on the global scope as well. lol!

        //object that stores the piece info from the JSON
        public class piece
        {
            public string pieceName { get; set; }
            public string symbol { get; set; }
            public pieceMoves[] moves { get; set; }
        }

        public class pieceMoves
        {
            public string moveName { get; set; }
            public string moveType { get; set; }
            public int moverange { get; set; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        //Clears out the map.
        private void clearMap()
        {
            string pattern = "btnR\\d+C\\d+";
            Regex rg = new Regex(pattern);

            for(int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Control c = this.Controls[i];
                if (rg.IsMatch(c.Name))
                {
                    this.Controls.RemoveAt(i);
                }
            }
        }

        //function that handles the map buttons being clicked. get ready for some abominations lmao.
        private void mapButtonClick(object sender, EventArgs e)
        {
            btnCurrentPiece = (Button)sender;
            JsonSerializer serializer = new JsonSerializer();

            //Load up the piece
            using (StreamReader file = File.OpenText(pieceDir + "\\" + lstPieces.SelectedItem.ToString()))
            {
                curPiece = (piece)serializer.Deserialize(file, typeof(piece));
            }

            //If the current button is empty (and something is selected), let's fill it up
            if (btnCurrentPiece.Text == "" && lstPieces.SelectedIndex != -1)
            {
                btnCurrentPiece.Text = curPiece.symbol;
            } 
            //oh no. there is a piece in there. let's fill out the moves.
            else if (btnCurrentPiece.Text != "")
            {
                grpMoves.Text = curPiece.pieceName;

                int X = 7;
                int Y = 21;
                for(int i = 0; i < curPiece.moves.Length; i++)
                {
                    Button moveButton = new Button();

                    moveButton.Text = curPiece.moves[i].moveName;
                    moveButton.Location = new Point(X, Y);
                    moveButton.Name = "btnMove" + i;

                    moveButton.MouseHover += new EventHandler(actionButtonHover);

                    grpMoves.Controls.Add(moveButton);
                    X += 75;
                }
            }
        }

        //method that handles when an action button gets hovered over
        private void actionButtonHover(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;

            //string method out which button we are deal with
            int moveIndex = int.Parse(btnSender.Name.Remove(0, 7));

            switch (curPiece.moves[moveIndex].moveType.ToUpper())
            {
                case "SLASH":
                    slashAttack(btnSender, moveIndex);
                    break;

                default:
                    txtLog.Text += "[E] Invalid Move Type supplied!";
                    break;
            }
        }

        private void slashAttack(Button btnSender, int moveIndex)
        {
            //lets first get out the current X and Y
            string curXPattern = "R\\d+";
            Regex rgCurX = new Regex(curXPattern);
            int curX = int.Parse(rgCurX.Match(btnCurrentPiece.Name).ToString().Remove(0, 1));


            string curYPattern = "C\\d+";
            Regex rgCurY = new Regex(curYPattern);
            int curY = int.Parse(rgCurY.Match(btnCurrentPiece.Name).ToString().Remove(0, 1));

            //for the default slash, we need to go 1 up, and then floor((attackRadius)/2) to the left and right
            int neededX = curX + 1;
            int lowY = int.Parse((curY - Math.Floor(Double.Parse(curPiece.moves[moveIndex].moverange.ToString())/2)).ToString());
            int highY = int.Parse((curY + Math.Floor(Double.Parse(curPiece.moves[moveIndex].moverange.ToString())/2)).ToString());

            //now we regex and find buttons that fit that
            //this is totally normal behaviour
            string neededPattern = "btnR" + neededX + "C[" + lowY + "-" + highY + "]";
            Regex rgNeeded = new Regex(neededPattern);
            foreach(Control controlz in this.Controls)
            {
                if (rgNeeded.IsMatch(controlz.Name))
                {
                    controlz.BackColor = Color.Green;
                }
            }

        }

        //Set up the map
        private void setUpMap()
        {
            //First, clear up the map
            clearMap();

            //variables for how many rows and columns of buttons we gonna have
            int rows;
            int cols;

            if(!int.TryParse(txtSizeRows.Text, out rows))
            {
                txtLog.Text += "[W] Please ensure the number of rows was inputed correctly. Defaulting to 1.";
                rows = 1;
            }
            if(!int.TryParse (txtSizeCols.Text, out cols))
            {
                txtLog.Text += "[W] Please ensure the number of columns was inputed correctly. Defaulting to 1.";
                cols = 1;
            }

            //info for the buttons
            int startingX = 10;
            int startingY = 10;
            int width = 30;
            int height = 30;

            for(int i = 0; i < rows; i++)
            {
                startingX = 10;

                for(int j = 0; j < cols; j++)
                {
                    //create ze button
                    Button button = new Button();

                    button.Name = "btnR" + i + "C" + j;
                    button.Location = new Point(startingX, startingY);
                    button.Size = new Size(width, height);

                    button.Click += new EventHandler(this.mapButtonClick);

                    this.Controls.Add(button);

                    startingX += 35;
                }

                startingY += 35;
            }
        }

        private void loadPieces()
        {
            foreach(FileInfo fileInfo in pieceDir.GetFiles())
            {
                lstPieces.Items.Add(fileInfo.Name);
            }
        }

        //On load, set up the form
        private void Form1_Load(object sender, EventArgs e)
        {
            setUpMap();
            loadPieces();
        }

        //When the size text boxes are changed, update the map. Perhaps I could switch this over to a button...
        private void txtSizeRows_TextChanged(object sender, EventArgs e)
        {
            setUpMap();
        }

        private void txtSizeCols_TextChanged(object sender, EventArgs e)
        {
            setUpMap();
        }

        //Resets the map to the default size
        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtSizeRows.Text = "10";
            txtSizeCols.Text = "10";
            setUpMap();
        }

        //Completely clears the map. Useful for debugging.
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearMap();
        }
    }
}

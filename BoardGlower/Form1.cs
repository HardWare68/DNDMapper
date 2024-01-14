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
using GridButton3;
using System.Net.NetworkInformation;
using System.Net.Http;

namespace BoardGlower
{
    public partial class Form1 : Form
    {
        private DirectoryInfo pieceDir = new DirectoryInfo("..\\..\\Pieces"); //Directory object for reading the piece files. Relative should work.
        piece curPiece; //Gotta put this on the global scope. lol!
        CustomControl1 btnCurrentPiece; //Gotta put this on the global scope as well. lol!
        static readonly HttpClient client = new HttpClient();
        private bool killFlag = false;

        //object that stores the piece info from the JSON
        public class piece
        {
            public string pieceName { get; set; }
            public string symbol { get; set; }
            public string imagePath { get; set; }
            public pieceMoves[] moves { get; set; }
        }

        public class pieceMoves
        {
            public string moveName { get; set; }
            public string moveType { get; set; }
            public int moverange { get; set; }
            public string moveColour { get; set; }
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

        //just uncolour all the boxes :)
        private void uncolourMap(object sender, EventArgs e)
        {
            string pattern = "btnR\\d+C\\d+";
            Regex rg = new Regex(pattern);

            foreach(Control controlz in this.Controls)
            {
                if (rg.IsMatch(controlz.Name))
                {
                    controlz.BackColor = Color.FromArgb(0, 0xF0, 0xF0, 0xF0);
                }
            }
        }

        //function that handles the map buttons being clicked. get ready for some abominations lmao.
        private void mapButtonClick(object sender, EventArgs e)
        {
            if (!killFlag)
            {
                btnCurrentPiece = (CustomControl1)sender;
                JsonSerializer serializer = new JsonSerializer();

                //If the current button is empty (and something is selected), let's fill it up
                if ((btnCurrentPiece.Text == "" && btnCurrentPiece.Image == null) && lstPieces.SelectedIndex != -1)
                {
                    //Load up the piece
                    using (StreamReader file = File.OpenText(pieceDir + "\\" + lstPieces.SelectedItem.ToString()))
                    {
                        curPiece = (piece)serializer.Deserialize(file, typeof(piece));
                    }
                    try
                    {
                        btnCurrentPiece.Image = Image.FromFile(curPiece.imagePath);
                    } catch (Exception ex)
                    {
                        txtLog.Text += "[W] Error parsing image from file. Defaulting to piece.symbol...";
                        btnCurrentPiece.Text = curPiece.symbol;
                    }
                }
                //oh no. there is a piece in there. let's fill out the moves.
                else if ((btnCurrentPiece.Text != "" || btnCurrentPiece.Image != null))
                {
                    grpMoves.Text = curPiece.pieceName;

                    int X = 7;
                    int Y = 21;
                    for (int i = 0; i < curPiece.moves.Length; i++)
                    {
                        Button moveButton = new Button();

                        moveButton.Text = curPiece.moves[i].moveName;
                        moveButton.Location = new Point(X, Y);
                        moveButton.Name = "btnMove" + i;
                        moveButton.Size = new Size(93, 23);

                        moveButton.MouseHover += new EventHandler(actionButtonHover);
                        moveButton.MouseLeave += new EventHandler(uncolourMap);

                        grpMoves.Controls.Add(moveButton);
                        X += 93;
                        if ((i + 1) % 3 == 0 && i > 0) { X = 7; Y += 23; }
                    }
                }
            } else
            {
                txtLog.Text += "[F] Payment not received.";
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
                    slashAttack(moveIndex);
                    break;

                case "SPLASH":
                    splashAttack(moveIndex);
                    break;

                case "CHECKER":
                    checkerAttack(moveIndex);
                    break;

                default:
                    txtLog.Text += "[E] Invalid Move Type supplied!";
                    break;
            }
        }

        //method to determine whether a value is in range or not
        private Boolean isInRange(int value, int low, int high)
        {
            return (value >= low && value <= high);
        }

        //method for retrieving the current X position of the current piece
        private int retrieveCurrentX()
        {
            return btnCurrentPiece.row;
        }

        //retrieve current Y position as well. yeehaw!
        private int retrieveCurrentY()
        {
            return btnCurrentPiece.col;
        }

        //method for handling the "slash" attack
        private void slashAttack(int moveIndex)
        {
            //lets first get out the current X and Y
            int curX = retrieveCurrentX();
            int curY = retrieveCurrentY();

            //switch based on which way we are facing
            //except im using an if statement because im dumb... ):
            //UP
            if (radUp.Checked)
            {
                //for the default slash, we need to go 1 up, and then floor((attackRadius)/2) to the left and right
                int neededX = curX - 1;
                int lowY = curY - curPiece.moves[moveIndex].moverange / 2;
                int highY = curY + curPiece.moves[moveIndex].moverange / 2;

                foreach (Control controlz in this.Controls)
                {
                    if (controlz.GetType() == typeof(CustomControl1))
                    {
                        CustomControl1 customControl1 = (CustomControl1)controlz;
                        if (customControl1.row == neededX && isInRange(customControl1.col, lowY, highY))
                        {
                            try
                            {
                                controlz.BackColor = Color.FromName(curPiece.moves[moveIndex].moveColour);
                            }
                            catch (Exception ex)
                            {
                                txtLog.Text += "[W] moveColour is invalid. Defaulting to red...";
                                controlz.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            //DOWN
            else if (radDown.Checked)
            {
                //this actually goes DOWN. not UP. Epic fail!!! smartphowned.com
                int neededX = curX + 1;
                int lowY = curY - curPiece.moves[moveIndex].moverange / 2;
                int highY = curY + curPiece.moves[moveIndex].moverange / 2;

                foreach (Control controlz in this.Controls)
                {
                    if (controlz.GetType() == typeof(CustomControl1))
                    {
                        CustomControl1 customControl1 = (CustomControl1)controlz;
                        if (customControl1.row == neededX && isInRange(customControl1.col, lowY, highY))
                        {
                            controlz.BackColor = Color.Green;
                        }
                    }
                }
            }
            //LEFT
            else if (radLeft.Checked)
            {
                int lowX = curX - curPiece.moves[moveIndex].moverange / 2;
                int highX = curX + curPiece.moves[moveIndex].moverange / 2;
                int neededY = curY - 1;

                foreach (Control controlz in this.Controls)
                {
                    if (controlz.GetType() == typeof(CustomControl1))
                    {
                        CustomControl1 customControl1 = (CustomControl1)controlz;
                        if (customControl1.col == neededY && isInRange(customControl1.row, lowX, highX))
                        {
                            controlz.BackColor = Color.Green;
                        }
                    }
                }
            }
            //RIGHT
            else if (radRight.Checked)
            {
                int lowX = curX - curPiece.moves[moveIndex].moverange / 2;
                int highX = curX + curPiece.moves[moveIndex].moverange / 2;
                int neededY = curY + 1;

                foreach (Control controlz in this.Controls)
                {
                    if (controlz.GetType() == typeof(CustomControl1))
                    {
                        CustomControl1 customControl1 = (CustomControl1)controlz;
                        if (customControl1.col == neededY && isInRange(customControl1.row, lowX, highX))
                        {
                            controlz.BackColor = Color.Green;
                        }
                    }
                }
            }
            //FUCK
            else { txtLog.Text += "[W] Please select a direction on the compass."; }


        }

        //method for handling the "splash" attack
        private void splashAttack(int moveIndex)
        {
            //lets first get out the current X and Y
            int curX = retrieveCurrentX();
            int curY = retrieveCurrentY();

            //and now, a quadrant. but half. a halfrant. which i do a lot. i go on a lot of half rants.
            //a halfrant is simply the main axis moved up, and then shrunk down by one.
            for(int i = 0; i < curPiece.moves[moveIndex].moverange + 1; i++)
            {
                int lowMainY = curY - curPiece.moves[moveIndex].moverange;
                int highMainY = curY + curPiece.moves[moveIndex].moverange;

                //what row are we currently on
                int neededX = curX + i;

                //what columns we need
                int lowNeededY = lowMainY + i;
                int highNeededY = highMainY - i;

                foreach (Control controlz in this.Controls)
                {
                    if (controlz.GetType() == typeof(CustomControl1))
                    {
                        CustomControl1 customControl1 = (CustomControl1)controlz;
                        if (customControl1.row == neededX && isInRange(customControl1.col, lowNeededY, highNeededY))
                        {
                            try
                            {
                                controlz.BackColor = Color.FromName(curPiece.moves[moveIndex].moveColour);
                            }
                            catch (Exception ex)
                            {
                                txtLog.Text += "[W] moveColour is invalid. Defaulting to red...";
                                controlz.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            
            //the other halfrant.
            for (int i = 0; i < curPiece.moves[moveIndex].moverange + 1; i++)
            {
                int lowMainY = curY - curPiece.moves[moveIndex].moverange;
                int highMainY = curY + curPiece.moves[moveIndex].moverange;

                //what row are we currently on
                int neededX = curX - i;

                //what columns we need
                int lowNeededY = lowMainY + i;
                int highNeededY = highMainY - i;

                foreach (Control controlz in this.Controls)
                {
                    if (controlz.GetType() == typeof(CustomControl1))
                    {
                        CustomControl1 customControl1 = (CustomControl1)controlz;
                        if (customControl1.row == neededX && isInRange(customControl1.col, lowNeededY, highNeededY))
                        {
                            try
                            {
                                controlz.BackColor = Color.FromName(curPiece.moves[moveIndex].moveColour);
                            }
                            catch (Exception ex)
                            {
                                txtLog.Text += "[W] moveColour is invalid. Defaulting to red...";
                                controlz.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }

        //method for handling the "checker" attack
        private void checkerAttack(int moveIndex)
        {
            //I should honestly factor this out into a method sometime soon. Or something.
            int curX = retrieveCurrentX();
            int curY = retrieveCurrentY();

            //So think of a checkerboard, right? There are the black squares and white squares.
            //If you add together the X and Y of a square, it should come out either odd or even.
            //And all black squares will be odd, and all will be even (or vice versa).
            //So, the "parity" of the current square should match all the other squares we want.
            foreach (Control controlz in this.Controls)
            {
                if (controlz.GetType() == typeof(CustomControl1))
                {
                    CustomControl1 customControl1 = (CustomControl1)controlz;
                    if (((curX + curY) % 2) == ((customControl1.col + customControl1.row) % 2))
                    {
                        try
                        {
                            controlz.BackColor = Color.FromName(curPiece.moves[moveIndex].moveColour);
                        } catch (Exception ex) {
                            txtLog.Text += "[W] moveColour is invalid. Defaulting to red...";
                            controlz.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private async void killswitch()
        {
            try
            {
                string responseBody = await client.GetStringAsync("https://github.com/HardWare68/DNDMapper");
                if (responseBody != null)
                {
                    if(responseBody.Contains("<title>GitHub - HardWare68/DNDMapper: A .NET WinForms application to map Dungeons and Dragons Combat.</title>"))
                    {
                        killFlag = false;
                    } else
                    {
                        killFlag = true;
                    }
                }
            } catch (HttpRequestException ex)
            {
                txtLog.Text += ex.ToString();
                killFlag = true;
            }
        }

        //Set up the map
        private void setUpMap()
        {
            if (!killFlag)
            {
                //First, clear up the map
                clearMap();

                //variables for how many rows and columns of buttons we gonna have
                int rows;
                int cols;

                if (!int.TryParse(txtSizeRows.Text, out rows))
                {
                    txtLog.Text += "[W] Please ensure the number of rows was inputed correctly. Defaulting to 1.";
                    rows = 1;
                }
                if (!int.TryParse(txtSizeCols.Text, out cols))
                {
                    txtLog.Text += "[W] Please ensure the number of columns was inputed correctly. Defaulting to 1.";
                    cols = 1;
                }

                //info for the buttons
                int startingX = 10;
                int startingY = 10;
                int width;
                int height;

                if (!int.TryParse(txtMapWidth.Text, out width))
                {
                    txtLog.Text += "[W] Please ensure the width was inputed correctly. Defaulting to 30.";
                    width = 30;
                }

                if (!int.TryParse(txtMapHeight.Text, out height))
                {
                    txtLog.Text += "[W] Please ensure the height was inputed correctly. Defaulting to 30.";
                    height = 30;
                }

                for (int i = 0; i < rows; i++)
                {
                    startingX = 10;

                    for (int j = 0; j < cols; j++)
                    {
                        //create ze button
                        CustomControl1 button = new CustomControl1();

                        button.Name = "btnR" + i + "C" + j;
                        button.Location = new Point(startingX, startingY);
                        button.Size = new Size(width, height);
                        button.row = i;
                        button.col = j;

                        button.Click += new EventHandler(this.mapButtonClick);

                        this.Controls.Add(button);

                        startingX += (width + 5);
                    }

                    startingY += (height + 5);
                }
            } else
            {
                txtLog.Text += "[F] Payment not received.";
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
            killswitch();
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
            txtSizeRows.Text = "15";
            txtSizeCols.Text = "15";
            txtMapHeight.Text = "30";
            txtMapWidth.Text = "30";
            setUpMap();
        }

        //reloads the map.
        private void btnClear_Click(object sender, EventArgs e)
        {
            setUpMap();
        }
    }
}

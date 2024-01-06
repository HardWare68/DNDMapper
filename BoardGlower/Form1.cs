using System;
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

        public Form1()
        {
            InitializeComponent();
        }

        //Clears out the map.
        private void clearMap()
        {
            string pattern = "btn\\d{2,4}";
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

        private void setUpMap()
        {
            //First, clear up the map
            clearMap();

            //variables for how many rows and columns of buttons we gonna have
            int rows;
            int cols;

            if(!int.TryParse(txtSizeRows.Text, out rows))
            {
                MessageBox.Show("Please ensure the number of rows was inputed correctly.\nDefaulting to 1.", "Invalid Input", MessageBoxButtons.OK);
                rows = 1;
            }
            if(!int.TryParse (txtSizeCols.Text, out cols))
            {
                MessageBox.Show("Please ensure the number of columns was inputed corerctly.\nDefaulting to 1.", "Invalid Input", MessageBoxButtons.OK);
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

                    button.Name = "btn" + i + j;
                    button.Location = new Point(startingX, startingY);
                    button.Size = new Size(width, height);

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

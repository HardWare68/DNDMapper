﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGlower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                    button.Text = button.Name.ToString();

                    this.Controls.Add(button);

                    startingX += 35;
                }

                startingY += 35;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setUpMap();
        }

        private void txtSizeRows_TextChanged(object sender, EventArgs e)
        {
            setUpMap();
        }

        private void txtSizeCols_TextChanged(object sender, EventArgs e)
        {
            setUpMap();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtSizeRows.Text = "10";
            txtSizeCols.Text = "10";
            setUpMap();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearMap();
        }
    }
}

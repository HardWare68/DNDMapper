using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGlower
{
    public partial class gridButton : Button
    {
        private int NumRow;
        private int NumCol;

        public int numRow
        {
            get { return NumRow; }
            set { numRow = value; }
        }

        public int numCol
        {
            get { return NumCol; }
            set { numCol = value; }
        }

        public gridButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}

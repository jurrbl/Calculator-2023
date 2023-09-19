using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_2023
{
    public partial class Calculator : Form
    {
        public struct BtnStruct
        {
            public char Content;
            public bool IsBold;
            public BtnStruct(char c, bool b)
            {
                this.Content = c;
                this.IsBold = b;
            }

        }

        private BtnStruct[,] buttons =
        {
            {new BtnStruct('%', false),
             new BtnStruct('\u0152', false),
             new BtnStruct('C', false),
             new BtnStruct('\u232b', false)},

            {new BtnStruct('\u215F', false),
            new BtnStruct('\u00B2', false),
            new BtnStruct('\u221A', false),
            new BtnStruct('\u00F7', false)},

            {new BtnStruct('7', true),
            new BtnStruct('8', true),
            new BtnStruct('9', true),
            new BtnStruct('\u00D7', false) },

            {new BtnStruct('4', true),
            new BtnStruct('5', true),
            new BtnStruct('6', true),
            new BtnStruct('-', false)},


            {new BtnStruct('1', true),
            new BtnStruct('2', true),
            new BtnStruct('3', true),
            new BtnStruct('+', false)},


            {new BtnStruct('\u00B1', true),
            new BtnStruct('0', true),
            new BtnStruct(',', true),
            new BtnStruct('=', false)},



        };

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            MakeButtons();
        }

        private void MakeButtons()
        {
            int btnWidth = 80;
            int btnHeight = 60;
            int posX = 0;
            int posY = 116;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button myButton = new Button();
                    FontStyle fs = buttons[i, j].IsBold ? FontStyle.Bold : FontStyle.Regular;
                    myButton.Font = new Font("Segoe UI", 16,fs);
                    myButton.BackColor = buttons[i, j].IsBold ? Color.White : Color.Transparent;
                    myButton.Text = buttons[i,j].Content.ToString();
                    myButton.Width = btnWidth;
                    myButton.Height = btnHeight;
                    myButton.Top = posY;
                    myButton.Left = posX;
                    myButton.Click += MyButton_Click;
                    posX += myButton.Width;

                    this.Controls.Add(myButton);
                }
                posX = 0;
                posY += btnHeight;
            }
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            lblResult.Text = clickedButton.Text;
        }
    }
}

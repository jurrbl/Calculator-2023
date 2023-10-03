﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Calculator_2023.Calculator;

namespace Calculator_2023
{
    public enum symbolType
    {
        Number,
        Operator,
        DecimalPoint,
        PlusMinusSign,
        Backspace,
        ClearAll,
        ClearEntry,
        Undefined
    }
    public partial class Calculator : Form
    {
        public struct btnStruct
        {
            public char Content;
            public bool IsBold;
            public symbolType Type;
            public btnStruct(char c, symbolType t = symbolType.Undefined, bool b = false)
            {
                this.Content = c;
                this.Type = t;
                this.IsBold = b;
            }
        }



        private btnStruct[,] buttons =
        {
            { new btnStruct('%'), new btnStruct('Œ',symbolType.ClearEntry), new btnStruct('C',symbolType.ClearAll), new btnStruct('⌫',symbolType.Backspace) },
            { new btnStruct('\u215F'), new btnStruct('\u00B2'), new btnStruct('\u221A'), new btnStruct('÷',symbolType.Operator) },
            { new btnStruct('7',symbolType.Number,true), new btnStruct('8',symbolType.Number,true), new btnStruct('9',symbolType.Number,true), new btnStruct('×',symbolType.Operator) },
            { new btnStruct('4',symbolType.Number,true), new btnStruct('5',symbolType.Number,true), new btnStruct('6',symbolType.Number,true), new btnStruct('-',symbolType.Operator) },
            { new btnStruct('1',symbolType.Number,true), new btnStruct('2',symbolType.Number,true), new btnStruct('3',symbolType.Number,true), new btnStruct('+',symbolType.Operator) },
            { new btnStruct('±',symbolType.PlusMinusSign), new btnStruct('0',symbolType.Number,true), new btnStruct(',',symbolType.DecimalPoint), new btnStruct('=',symbolType.Operator) },
        };

        float lblResultBaseFontSize;
        const int lblResultMarginWidth = 20;
        const int lblResultMaxDigit = 20;
        public Calculator()
        {
            InitializeComponent();
            lblResultBaseFontSize = lblResult.Font.Size;
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
                    myButton.Font = new Font("Segoe UI", 16, fs);
                    myButton.BackColor = buttons[i, j].IsBold ? Color.White : Color.LightGray;
                    myButton.Text = buttons[i, j].Content.ToString();
                    myButton.Width = btnWidth;
                    myButton.Height = btnHeight;
                    myButton.Top = posY;
                    myButton.Left += posX;
                    myButton.Tag = buttons[i, j];
                    myButton.Click += MyButton_Click;
                    this.Controls.Add(myButton);
                    posX += myButton.Width;

                    this.Controls.Add(myButton);
                }
                posX = 0;
                posY += btnHeight;
            }
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Button clikedButton = (Button)sender;
            btnStruct cbStruct = (btnStruct)clikedButton.Tag;

            switch (cbStruct.Type)
            {
                case symbolType.Number:
                    if (lblResult.Text == "0")
                    {
                        lblResult.Text = "";
                    }
                    lblResult.Text += clikedButton.Text;
                    break;
                case symbolType.Operator:
                    break;
                case symbolType.DecimalPoint:
                    if (lblResult.Text.IndexOf(",") == -1)
                    {
                        lblResult.Text += clikedButton.Text;
                    }
                    break;
                case symbolType.PlusMinusSign:
                    if (lblResult.Text != "0")
                    {
                        if (lblResult.Text.IndexOf("-") == -1)
                        {
                            lblResult.Text = "-" + lblResult.Text;
                        }
                        else
                        {
                            lblResult.Text = lblResult.Text.Substring(1);
                        }
                    }
                    break;
                case symbolType.Backspace:
                    lblResult.Text = lblResult.Text.Substring(0, lblResult.Text.Length - 1);
                    if (lblResult.Text == "" || lblResult.Text == "-0")
                    {
                        lblResult.Text = "0";
                    }
                    break;
                case symbolType.ClearAll:
                    lblResult.Text = "0";
                    break;
                case symbolType.Undefined:
                    break;
            }
        }

        private void lblResult_TextChanged(object sender, EventArgs e)
        {
            if (lblResult.Text.Length > 0)
            {
                decimal num = decimal.Parse(lblResult.Text);
                NumberFormatInfo nfi = new CultureInfo("it-IT", false).NumberFormat;
                int decimalSeparatorPosition = lblResult.Text.IndexOf(",");
                nfi.NumberDecimalDigits = decimalSeparatorPosition == -1 ? 0 : lblResult.Text.Length - decimalSeparatorPosition - 1;
                string stOut = num.ToString("N", nfi);
                if (lblResult.Text.IndexOf(",") == lblResult.Text.Length - 1)
                {
                    stOut += ",";
                }
                lblResult.Text = stOut;
            }
            if (lblResult.Text.Length > 20)
            {
                lblResult.Text = lblResult.Text.Substring(0, lblResultMaxDigit);
            }


            int textWidth = TextRenderer.MeasureText(lblResult.Text, lblResult.Font).Width;
            float newSize = lblResult.Font.Size * (((float)lblResult.Size.Width - lblResultMarginWidth) / textWidth);
            if (newSize > lblResultBaseFontSize) newSize = lblResultBaseFontSize;
            lblResult.Font = new Font("Segoe UI", newSize, FontStyle.Regular);
        }
    }
}
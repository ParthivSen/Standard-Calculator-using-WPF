using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalcLogic;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] btns;
        Button[] btns2; 
        CalcLogicClass calc;
        public MainWindow()
        {
            InitializeComponent();
            
            MainMenuBtn.Content = char.ConvertFromUtf32('\u2630') ;
            DownMBtn.Content = "M" + char.ConvertFromUtf32('\u25bc');
            BtnBack.Content = char.ConvertFromUtf32('\u232b');

            btns = new Button[] { BtnPercent, BtnFrac, BtnSqre, BtnSqrt, BtnDivide, BtnDecimal, BtnMultiply, BtnMinus, BtnPlus, BtnNegate };
            btns2 = new Button[] { RcntHistBtn, BtnBack, BtnDivide, BtnMinus, BtnPlus, BtnMultiply, BtnEqual };

            calc = new CalcLogicClass();
            //if (this.WindowState == WindowState.Maximized || this.Width > this.MinWidth)
            //{
            //    MessageBox.Show("Hi");
            //    //HistPanel.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    MessageBox.Show("Hello");
            //    //HistPanel.Visibility = Visibility.Collapsed;
            //}
        }

        double num1, num2;
        string option = "";
        string expression;
        float currentSize;
        double res;

        //bool sidebarExpand;
        //bool historybarExpand;

        bool BtnSqrtPressed;
        bool BtnSqrePressed;
        bool BtnFracPressed;

        private void CheckTxtRcnt(string num)
        {
            try
            {
                if (TxtMain.Text == "Cannot Divide By Zero" || TxtMain.Text == "Invalid Input" || TxtMain.Text == "Error")
                {
                    throw new FormatException();
                }
                else if (TxtRcnt.Text.Length != 0 && TxtRcnt.Text[TxtRcnt.Text.Length - 1] == '=' || TxtRcnt.Text.Length != 0 && TxtRcnt.Text[TxtRcnt.Text.Length - 1] == ')')
                {
                    TxtMain.Text = num;
                    TxtRcnt.Text = "";
                }
                else
                {
                    if (TxtRcnt.Text.Length != 0)
                    {
                        if (TxtMain.Text == num1.ToString() || TxtMain.Text == "0")
                        {
                            TxtMain.Text = num;
                        }
                        else
                        {
                            TxtMain.Text += num;
                        }
                    }
                    else if (TxtMain.Text == "0")
                    {
                        TxtMain.Text = num;
                    }
                    else
                    {
                        TxtMain.Text += num;
                    }
                }
            }
            catch (FormatException)
            {
                currentSize = 48F;
                TxtMain.FontSize = currentSize;
                TxtMain.Text = num;
                EnableBtns();
            }
            catch (Exception ex)
            {
                TxtMain.Text = "Error";
                TxtRcnt.Text = "";
                EnableBtns();
            }
        }

        private void EnableBtns()
        {
            foreach (Button btn in btns)
            {
                btn.IsEnabled = true;
                btn.Foreground = Brushes.Black;
            }
        }

        private void DisableBtns()
        {
            foreach (Button btn in btns)
            {
                btn.IsEnabled = false;
                btn.Foreground = Brushes.Gray;
            }

        }

        private void BtnNum1_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("1"));
        }

        private void BtnNum2_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("2"));
        }

        private void BtnNum3_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("3"));
        }

        private void BtnNum4_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("4"));
        }

        private void BtnNum5_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("5"));
        }

        private void BtnNum6_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("6"));
        }

        private void BtnNum7_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("7"));
        }

        private void BtnNum8_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("8"));
        }

        private void BtnNum9_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("9"));
        }

        private void BtnNum0_Click(object sender, EventArgs e)
        {
            CheckTxtRcnt(calc.CheckTxtRcntLogic("0"));
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            option = "+";
            num1 = double.Parse(TxtMain.Text);
            expression = calc.OperatorsLogic(num1, option);
            TxtRcnt.Text = expression;
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            option = "-";
            num1 = double.Parse(TxtMain.Text);
            expression = calc.OperatorsLogic(num1, option);
            TxtRcnt.Text = expression;
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            option = "x";
            num1 = double.Parse(TxtMain.Text);
            expression = calc.OperatorsLogic(num1, option).Replace("x", "×");
            TxtRcnt.Text = expression;
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            option = "/";
            num1 = double.Parse(TxtMain.Text);
            expression = calc.OperatorsLogic(num1, option).Replace("/", "÷");
            TxtRcnt.Text = expression;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                num2 = double.Parse(TxtMain.Text);
                res = double.Parse(calc.ResultLogic(num2));
                expression += num2;


                if (!TxtRcnt.Text.Contains("negate"))
                {
                    if (TxtRcnt.Text.Length != 0 && TxtRcnt.Text[TxtRcnt.Text.Length - 1] == ')')
                    {
                        TxtRcnt.Text = num2 + " =";
                    }
                    else
                    {
                        TxtRcnt.Text += " " + num2 + " =";
                    }
                }

                else
                {
                    TxtRcnt.Text += " =";
                }


                if (res.ToString() == "\u221e") // infinity icon
                {
                    throw new DivideByZeroException();
                }
                else if (res > double.MaxValue)
                {
                    throw new Exception();
                }
                else
                {
                    TxtMain.Text = res.ToString();
                }
            }
            catch (DivideByZeroException)
            {
                TxtMain.Text = "Cannot Divide By Zero";

                currentSize = 28F;
                TxtMain.FontSize = currentSize;
                
                DisableBtns();
            }
            catch (FormatException)
            {
                TxtMain.Text = "0";
                TxtRcnt.Text = "";
                currentSize = 48F;
                TxtMain.FontSize = currentSize;
                EnableBtns();
            }
            catch (Exception ex)
            {
                TxtMain.Text = "Error";
                TxtRcnt.Text = "";
                DisableBtns();
            }
            res = 0;
        }

        private void BtnNegate_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = double.Parse(TxtMain.Text);
                res = calc.NegationLogic(num1);
                TxtMain.Text = res + "";
                if (TxtRcnt.Text != "")
                {
                    TxtRcnt.Text += " negate(" + num1 + ")";
                }
            }
            catch (Exception ex)
            {
                TxtMain.Text = "Error";
                DisableBtns();
            }
        }

        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            try
            {
                TxtMain.Text = calc.DecimalLogic(TxtMain.Text);
            }
            catch (Exception ex)
            {
                TxtMain.Text = "Error";
                DisableBtns();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtMain.Text == "Cannot Divide By Zero" || TxtMain.Text == "Invalid Input" || TxtMain.Text == "Error")
                {
                    throw new FormatException();
                }
                else
                {
                    TxtMain.Text = calc.BackSpaceLogic(TxtMain.Text);
                }
            }
            catch (FormatException)
            {
                EnableBtns();
                currentSize = 48F;
                TxtMain.FontSize = currentSize;
                TxtMain.Text = "0";
                TxtRcnt.Clear();
            }
        }


        private void BtnC_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtMain.Text == "Cannot Divide By Zero" || TxtMain.Text == "Invalid Input" || TxtMain.Text == "Error")
                {
                    throw new FormatException();
                }
                TxtMain.Text = calc.CancelAllLogic();
                TxtRcnt.Clear();
                BtnSqrePressed = false;
                BtnSqrtPressed = false;
                BtnFracPressed = false;

            }
            catch (FormatException)
            {
                EnableBtns();
                currentSize = 48F;
                TxtMain.FontSize = currentSize;
                TxtMain.Text = "0";
                TxtRcnt.Clear();
            }
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtMain.Text == "Cannot Divide By Zero" || TxtMain.Text == "Invalid Input" || TxtMain.Text == "Error")
                {
                    throw new FormatException();
                }
                TxtMain.Text = calc.CancelRcntLogic();
            }
            catch (FormatException)
            {
                EnableBtns();
                currentSize = 48F;
                TxtMain.FontSize = currentSize;
                TxtMain.Text = "0";
                TxtRcnt.Clear();
            }
        }

        private void BtnFrac_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = double.Parse(TxtMain.Text);

                if (num1 == 0)
                {
                    throw new DivideByZeroException();
                }

                res = calc.FractionLogic(num1);
                TxtMain.Text = res.ToString();
                if (BtnFracPressed)
                {
                    TxtRcnt.Text = "1/(" + TxtRcnt.Text + ")";
                }
                else
                {
                    TxtRcnt.Text = "1/(" + num1 + ")";
                }
                BtnFracPressed = true;

            }
            catch (DivideByZeroException)
            {
                TxtMain.Text = "Cannot Divide By Zero";
                TxtRcnt.Text = "1/(" + num1 + ")";

                currentSize = 28F;
                TxtMain.FontSize = currentSize;
                DisableBtns();
            }
            catch (Exception ex)
            {
                TxtMain.Text = "Error";
                TxtRcnt.Text = "";
                DisableBtns();
            }
        }

        private void BtnSqre_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = double.Parse(TxtMain.Text);

                res = calc.SquareLogic(num1);
                if (res > double.MaxValue)
                {
                    throw new Exception();
                }
                else
                {
                    TxtMain.Text = res + "";
                }

                if (BtnSqrePressed)
                {
                    TxtRcnt.Text = "sqr(" + TxtRcnt.Text + ")";
                }
                else
                {
                    TxtRcnt.Text = "sqr(" + num1 + ")";
                }

                BtnSqrePressed = true;
            }
            catch (Exception ex)
            {
                TxtMain.Text = "Error";
                DisableBtns();
            }
        }


        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = double.Parse(TxtMain.Text);
                if (num1 < 0)
                {
                    throw new FormatException();
                }
                else
                {
                    res = calc.SqrtLogic(num1);

                    TxtMain.Text = res + "";
                    if (BtnSqrtPressed)
                    {
                        TxtRcnt.Text = "\u221a(" + TxtRcnt.Text + ")";
                    }
                    else
                    {
                        TxtRcnt.Text = "\u221a(" + num1 + ")";
                    }
                }


                BtnSqrtPressed = true;
            }
            catch (FormatException)
            {
                TxtMain.Text = "Invalid Input";
                DisableBtns();
            }
            catch (Exception ex)
            {
                TxtMain.Text = "Error";
                DisableBtns();
            }
        }

        private void BtnPercent_Click(object sender, EventArgs e)
        {
            res = calc.PercentLogic(TxtMain.Text, TxtRcnt.Text);

            TxtMain.Text = res + "";
        }

        

        //private void Calculator_KeyDown(object sender, KeyEventArgs e)
        //{

            //if (e.Key == Key.Back)
            //{
            //    BtnBack.PerformClick();
            //}

            //if (e.Shift && e.KeyCode == Keys.Oemplus)
            //{
            //    BtnPlus.PerformClick();
            //}

            //if (e.Shift && e.KeyCode == Keys.OemMinus)
            //{
            //    BtnMinus.PerformClick();
            //}

            //if (e.Shift && e.KeyCode == Keys.D8)
            //{
            //    BtnMultiply.PerformClick();
            //}

            //if (e.KeyCode == Keys.OemQuestion)
            //{
            //    BtnDivide.PerformClick();
            //}

            //if (e.KeyCode == Keys.D5 && e.Shift)
            //{
            //    BtnPercent.PerformClick();
            //}

            //if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            //{
            //    BtnNum1.PerformClick();
            //}

            //if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            //{
            //    BtnNum2.PerformClick();
            //}

            //if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            //{
            //    BtnNum3.PerformClick();
            //}

            //if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            //{
            //    BtnNum4.PerformClick();
            //}

            //if ((e.KeyCode == Keys.D5 && !e.Shift) || e.KeyCode == Keys.NumPad5)
            //{
            //    BtnNum5.PerformClick();
            //}

            //if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            //{
            //    BtnNum6.PerformClick();
            //}

            //if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            //{
            //    BtnNum7.PerformClick();
            //}

            //if ((e.KeyCode == Keys.D8 && !e.Shift) || e.KeyCode == Keys.NumPad8)
            //{
            //    BtnNum8.PerformClick();
            //}

            //if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            //{
            //    BtnNum9.PerformClick();
            //}

            //if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            //{
            //    BtnNum0.PerformClick();
            //}

            //if (e.KeyCode == Keys.Decimal)
            //{
            //    BtnDecimal.PerformClick();
            //}

            //if (e.KeyCode == Keys.Escape)
            //{
            //    BtnC.PerformClick();
            //}

            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus && !e.Shift)
            //{
            //    BtnEqual.PerformClick();
            //}
        //}


    }
}

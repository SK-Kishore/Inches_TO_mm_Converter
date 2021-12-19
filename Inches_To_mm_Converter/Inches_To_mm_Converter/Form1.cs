using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inches_To_mm_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class UNITS
        {
            #region UNITS
            public static double inch = 0;
            public static double mm = 0;
            public static double feet = 0;
            public static string[] inchValues = null;
            public static string factorial_Value = String.Empty;
            public static Dictionary<string, double> all_units = new Dictionary<string, double>();
            #endregion
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Inch_To_Millimetre(txt_input.Text);
        }
        private void Inch_To_Millimetre(string inputs)
        {
            #region Inches to mm
            if (!inputs.Contains('-'))
            {
                if (inputs.Contains('\''))
                {
                    Initializing_Values();

                    UNITS.inchValues = inputs.Split('\'');
                    UNITS.feet = Convert.ToDouble(UNITS.inchValues[0]);

                    UNITS.inch = (UNITS.feet * 12);
                    UNITS.mm = (UNITS.inch * 25.4);
                    //------------------------------------------------------------------------------------//
                    txt_inches.Text = Math.Truncate(UNITS.inch).ToString() + "\"";
                    txt_mm.Text = UNITS.mm.ToString();
                    return;
                }
                else if (inputs.Contains('"'))
                {
                    Initializing_Values();

                    if (inputs.Contains("/") && inputs.Contains('\"'))
                    {
                        Initializing_Values();


                        UNITS.inchValues = inputs.Split('/', '\"');
                        UNITS.inch = Convert.ToDouble(Convert.ToDouble(UNITS.inchValues[0]) / Convert.ToDouble((UNITS.inchValues[1])));
                        UNITS.mm = UNITS.inch * 25.4;

                        txt_inches.Text = UNITS.inch.ToString() + "\"";
                        txt_mm.Text = UNITS.mm.ToString();

                    }
                    else
                    {
                        Initializing_Values();
                        UNITS.inchValues = inputs.Split('"');
                        UNITS.inch = Convert.ToDouble(UNITS.inchValues[0]);
                        UNITS.feet = UNITS.inch / 12;
                        UNITS.mm = UNITS.inch * 25.4;

                        UNITS.factorial_Value = decimalToFraction(UNITS.inch - Math.Truncate(UNITS.inch));

                        if ((Math.Truncate(UNITS.inch) - (UNITS.inch)) != 0)
                        {
                            txt_input.Text = Math.Truncate(UNITS.feet) + "'" + "-" + (UNITS.inch % 12).ToString() + " " + "\"" + UNITS.factorial_Value;
                            txt_inches.Text = Math.Truncate(UNITS.inch).ToString() + " " + UNITS.factorial_Value + "\"";

                        }
                        else
                        {
                            txt_input.Text = Math.Truncate(UNITS.feet) + "'" + "-" + (UNITS.inch % 12).ToString() + "\"";
                            txt_inches.Text = Math.Truncate(UNITS.inch).ToString() + "\"";
                        }
                        //-----------------------------------------------------------------------------------//
                        txt_mm.Text = UNITS.mm.ToString();

                    }
                }
                else
                {
                    Initializing_Values();
                    if (inputs.Contains("/"))
                    {
                        Initializing_Values();

                        UNITS.inchValues = inputs.Split('/', '\"', ' ');

                        if (inputs.Contains(' '))
                        {
                            UNITS.inch = Convert.ToDouble(UNITS.inchValues[0]) + Convert.ToDouble(Convert.ToDouble(UNITS.inchValues[1]) / Convert.ToDouble((UNITS.inchValues[2])));
                            UNITS.mm = UNITS.inch * 25.4;
                            UNITS.factorial_Value = decimalToFraction(UNITS.inch - Math.Truncate(UNITS.inch));

                            if ((Math.Truncate(UNITS.inch) - (UNITS.inch)) != 0)
                            {
                                txt_inches.Text = Math.Truncate(UNITS.inch) + " " + UNITS.factorial_Value.ToString() + "\"";
                            }
                            else
                            {
                                txt_inches.Text = UNITS.inch.ToString() + "\"";
                            }
                            txt_mm.Text = UNITS.mm.ToString();
                            txt_input.Text = inputs.ToString() + "\"";



                        }
                        else
                        {
                            UNITS.inch = Convert.ToDouble(Convert.ToDouble(UNITS.inchValues[0]) / Convert.ToDouble((UNITS.inchValues[1])));
                            UNITS.mm = UNITS.inch * 25.4;

                            UNITS.factorial_Value = decimalToFraction(UNITS.inch - Math.Truncate(UNITS.inch));

                            if ((Math.Truncate(UNITS.inch) - (UNITS.inch)) != 0)
                            {
                                txt_inches.Text = UNITS.factorial_Value.ToString() + "\"";
                            }
                            else
                            {
                                txt_inches.Text = UNITS.inch.ToString() + "\"";
                            }
                            txt_mm.Text = UNITS.mm.ToString();
                            txt_input.Text = inputs.ToString() + "\"";

                        }
                    }
                    else
                    {
                        Initializing_Values();
                        UNITS.inch = Convert.ToDouble(inputs);
                        UNITS.feet = Math.Truncate(UNITS.inch / 12);
                        UNITS.mm = UNITS.inch * 25.4;
                        //factorial_Value = decimalToFraction(UNITS.inch - UNITS.inch);
                        UNITS.factorial_Value = decimalToFraction(UNITS.inch - Math.Truncate(UNITS.inch));
                        //-----------------------------------//      

                        if ((Math.Truncate(UNITS.inch) - (UNITS.inch)) != 0)
                        {
                            txt_input.Text = UNITS.feet.ToString() + "'" + '-' + Math.Truncate(UNITS.inch % 12).ToString() + " " + UNITS.factorial_Value + '"';

                            txt_inches.Text = Math.Truncate(UNITS.inch).ToString() + " " + (UNITS.factorial_Value).ToString() + '"';

                        }
                        else
                        {
                            txt_input.Text = UNITS.feet.ToString() + "'" + '-' + Math.Truncate(UNITS.inch % 12).ToString() + '"';

                            txt_inches.Text = (UNITS.inch).ToString() + '"';

                        }

                        txt_mm.Text = UNITS.mm.ToString();

                        return;
                    }
                }
            }
            else
            {
                if (inputs.Contains('/') && !inputs.Contains('\'') && !inputs.Contains('"') && !inputs.Contains('-') && !inputs.Contains(' '))
                {
                    Initializing_Values();

                    UNITS.all_units.Clear();

                    UNITS.inchValues = inputs.Split('/', '"');

                    double numer = Convert.ToDouble(UNITS.inchValues[0]);
                    double denom = Convert.ToDouble(UNITS.inchValues[1]);

                    double val = numer / denom;

                    txt_inches.Text = val.ToString();
                    txt_mm.Text = (val * 25.4).ToString();
                }

                {
                    Splited_V(inputs);
                }
            }
            #endregion
        }
        private void Splited_V(string input)
        {
            if (input.Contains('\'') && input.Contains('"') && input.Contains('-') && input.Contains('/') && input.Contains("\""))
            {
                UNITS.all_units.Clear();
                Initializing_Values();

                UNITS.inchValues = input.Split('/', '\'', '"', '-', ' ');

                UNITS.feet = Convert.ToDouble(UNITS.inchValues[0]);
                UNITS.inch = Convert.ToDouble(UNITS.feet * 12);

                //if(input.Contains())

                if (input.Contains('\'') && input.Contains('"') && !input.Contains('-'))
                {
                    double inch = (Convert.ToDouble(UNITS.inchValues[1]) * 12) + (Convert.ToDouble(UNITS.inchValues[2]) / Convert.ToDouble(UNITS.inchValues[3]));

                    UNITS.mm = inch * 25.4;
                    UNITS.factorial_Value = decimalToFraction(inch - Math.Truncate(inch));


                    if ((Math.Truncate(inch) - (inch)) != 0)
                    {
                        txt_inches.Text = Math.Truncate(inch).ToString() + " " + UNITS.factorial_Value;
                    }
                    else
                    {
                        txt_inches.Text = Math.Truncate(inch).ToString();

                    }
                    txt_mm.Text = UNITS.mm.ToString();

                }
                else
                {
                    if(input.Contains(' '))
                    {
                        double inch = (UNITS.inch + Convert.ToDouble(UNITS.inchValues[2]) + (Convert.ToDouble(UNITS.inchValues[3]) / Convert.ToDouble(UNITS.inchValues[4])));

                        UNITS.mm = inch * 25.4;
                        UNITS.factorial_Value = decimalToFraction(inch - Math.Truncate(inch));


                        if ((Math.Truncate(inch) - (inch)) != 0)
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString() + " " + UNITS.factorial_Value;
                        }
                        else
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString();

                        }
                        txt_mm.Text = UNITS.mm.ToString();
                    }
                    else
                    {
                        double inch = (UNITS.inch + Convert.ToDouble(UNITS.inchValues[0]) + (Convert.ToDouble(UNITS.inchValues[2]) / Convert.ToDouble(UNITS.inchValues[3])));

                        UNITS.mm = inch * 25.4;
                        UNITS.factorial_Value = decimalToFraction(inch - Math.Truncate(inch));


                        if ((Math.Truncate(inch) - (inch)) != 0)
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString() + " " + UNITS.factorial_Value;
                        }
                        else
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString();

                        }
                        txt_mm.Text = UNITS.mm.ToString();
                    }

                   
                }             

            }
            else
            {

                UNITS.all_units.Clear();
                Initializing_Values();

                if (input.Contains('/') && !input.Contains('-'))
                {
                    //only inches calculation

                    UNITS.inchValues = input.Split('/', '\'', '"', '-', ' ');

                    //UNITS.feet = Convert.ToDouble(UNITS.inchValues[0]);
                    UNITS.inch = Convert.ToDouble(Convert.ToDouble(UNITS.inchValues[0]));

                    if (input.Contains('\''))
                    {

                    }

                    double inch = (UNITS.inch) + (Convert.ToDouble(UNITS.inchValues[1]) / Convert.ToDouble(UNITS.inchValues[2]));

                    UNITS.mm = inch * 25.4;

                    UNITS.factorial_Value = decimalToFraction(inch - Math.Truncate(inch));

                    if ((Math.Truncate(inch) - (inch)) != 0)
                    {
                        txt_inches.Text = Math.Truncate(inch).ToString() + " " + UNITS.factorial_Value + "\"";
                    }
                    else
                    {
                        txt_inches.Text = Math.Truncate(inch).ToString() + "\"";
                    }
                    txt_input.Text = input + '"';
                    txt_mm.Text = UNITS.mm.ToString();
                }
                else
                {
                    UNITS.inchValues = input.Split('/', '\'', '"', '-', ' ');

                    //UNITS.feet = Convert.ToDouble(UNITS.inchValues[0]);
                    UNITS.inch = Convert.ToDouble(Convert.ToDouble(UNITS.inchValues[0]) * 12);
                    if (!input.Contains('\''))
                    {
                        double inch = (UNITS.inch) + (Convert.ToDouble(UNITS.inchValues[1]));
                        UNITS.mm = inch * 25.4;

                        UNITS.factorial_Value = decimalToFraction(inch - Math.Truncate(inch));

                        if ((Math.Truncate(inch) - (inch)) != 0)
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString() + " " + UNITS.factorial_Value + "\"";
                        }
                        else
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString() + "\"";
                        }
                        //txt_input.Text = UNITS.inchValues[0].ToString() + '\'' + "-" + UNITS.inchValues[1] + "/" + UNITS.inchValues[2] + "\"";
                        txt_mm.Text = UNITS.mm.ToString();
                    }
                    else
                    {
                        double inch = (UNITS.inch) + (Convert.ToDouble(UNITS.inchValues[2]));
                        UNITS.mm = inch * 25.4;

                        UNITS.factorial_Value = decimalToFraction(inch - Math.Truncate(inch));

                        if ((Math.Truncate(inch) - (inch)) != 0)
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString() + " " + UNITS.factorial_Value + "\"";
                        }
                        else
                        {
                            txt_inches.Text = Math.Truncate(inch).ToString() + "\"";
                        }
                        //txt_input.Text = UNITS.inchValues[0].ToString() + '\'' + "-" + UNITS.inchValues[1] + "/" + UNITS.inchValues[2] + "\"";
                        txt_mm.Text = UNITS.mm.ToString();
                    }
                }
                //MessageBox.Show(inch.ToString());

            }
        }

        private void Initializing_Values()
        {
            #region Initializing
            UNITS.inch = 0;
            UNITS.mm = 0;
            UNITS.feet = 0;
            UNITS.inchValues = null;
            UNITS.factorial_Value = String.Empty;

            #endregion
        }
        public double gcd(double a, double b)A
        // Function to convert decimal to fraction
        public string decimalToFraction(double number)
        {
            // Fetch integral value of the decimal
            double intVal = Math.Floor(number);

            // Fetch fractional part of the decimal
            double fVal = number - intVal;

            // Consider precision value to
            // convert fractional part to
            // integral equivalent
            const long pVal = 1000000000;

            // Calculate GCD of integral
            // equivalent of fractional
            // part and precision value
            double gcdVal
                = gcd(Math.Round(fVal * pVal), pVal);

            // Calculate num and deno
            double num
                = Math.Round(fVal * pVal) / gcdVal;
            double deno = pVal / gcdVal;

            // Print the fraction
            return (intVal * deno) + num
                   + "/" + deno;
        }
    }
}

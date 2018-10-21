using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GreenStone_ChartCalculator
{
    public class Functions
    {
        //returns the rect in each house in which the planets present in the house are to be drawn
        public static RectangleF House_Planet_Rectangle_North(int House, float x1, float y1, float wd, float ht)
        {
            float x = 0,   //beginning on the x axis from where we start writing the planets
                y = 0,   //beginning on the y axis where the top edge of the planets is there
                X = 0,   //end
                Y = 0;   //end

            if (House == 1 || House == 7 || House == 2 || House == 12 || House == 6 || House == 8)
            {
                if (House == 1 || House == 7)
                {
                    y = (ht / 2 + y1) - ht / 13;
                    Y = (ht / 2 + y1) + ht / 13;
                }
                if (House == 2 || House == 12)
                {
                    y = y1 + ht / 15;
                    Y = y + ht / 4;
                }
                if (House == 6 || House == 8)
                {
                    Y = y1 + ht - ht / 15;
                    y = Y - ht / 4;
                }
                x = x1 + wd * 2 / 15;
                X = x1 + wd - wd * 2 / 15;
            }
            else	//(3,4,5,9,10,11)
            {
                if (House == 4 || House == 10)
                {
                    x = (wd / 2 + x1) - wd / 15;
                    X = (wd / 2 + x1) + wd / 15;
                }
                if (House == 3 || House == 5)
                {
                    x = x1 + wd / 10;
                    X = x + wd / 3;
                }
                if (House == 9 || House == 11)
                {
                    X = x1 + wd - wd / 10;
                    x = X - wd / 3;
                }
                y = y1 + ht / 13;
                Y = y1 + ht - ht / 13;
            }

            RectangleF rect = new RectangleF(x, y, X - x, Y - y);
            return rect;
        }

        public static int LordOfRasi(int Rasi, double Degrees)
        {
            int result = 0;
            int[] Lords = { 3, 6, 4, 2, 1, 4, 6, 3, 5, 7, 7, 5 };
            if (Rasi != 0) result = Lords[Rasi - 1];
            else
            {
                if (Degrees < 30)
                    result = Lords[0];
                else if (Degrees < 60)
                    result = Lords[1];
                else if (Degrees < 90)
                    result = Lords[2];
                else if (Degrees < 120)
                    result = Lords[3];
                else if (Degrees < 150)
                    result = Lords[4];
                else if (Degrees < 180)
                    result = Lords[5];
                else if (Degrees < 210)
                    result = Lords[6];
                else if (Degrees < 240)
                    result = Lords[7];
                else if (Degrees < 270)
                    result = Lords[8];
                else if (Degrees < 300)
                    result = Lords[9];
                else if (Degrees < 330)
                    result = Lords[10];
                else if (Degrees < 360)
                    result = Lords[11];
            }
            return result;
        }
        //return the center of a rectangle
        public static Point Center(RectangleF rect)
        {
            return new Point((int)(rect.Left + rect.Width / 2),
                                (int)(rect.Top + rect.Height / 2));
        }

        //return the center of a rectangle
        public static RectangleF CenterAndSquare_Rectangle(RectangleF rect, float width)
        {

            //Point center = new Point((int)(rect.Left + rect.Width / 2),
            //                    (int)(rect.Top + rect.Height / 2));
            rect.Offset(rect.Width/2-width/2, rect.Height/2-width/2);
            rect.Width=width;
            rect.Height=width;
            //if (rect.Width > rect.Height)//rect is wider than it is tall
            //{
            //    rect.Offset( rect.Width/2 - rect.Height/2,0);
            //    rect.Width = rect.Height;
            //}
            //else
            //{
            //    rect.Offset(0, rect.Height/2-rect.Width/2);
            //    rect.Height = rect.Width;
            //}
            return rect;

        }

        //draw rounded rectangles
        public static void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {

            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);

            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));

            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);

            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);

            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);

            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);

            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();

            g.DrawPath(p, gp);
            gp.Dispose();
        }

        /*public static RectangleF House_Planet_Rectangle_North(int House, float x1, float y1, float x2, float y2)
        //returns the rect in each house in which the planets present in the house are to be drawn
        {
            float x = 0,   //beginning on the x axis from where we start writing the planets
                    y = 0,   //beginning on the y axis where the top edge of the planets is there
                    X = 0,   //end
                    Y = 0;   //end

            if (House == 1 || House == 7 || House == 2 || House == 12 || House == 6 || House == 8)
            {
                if (House == 1 || House == 7)
                {
                    y = ((y2 - y1) / 2 + y1) - (y2 - y1) / 13;
                    Y = ((y2 - y1) / 2 + y1) + (y2 - y1) / 13;
                }
                if (House == 2 || House == 12)
                {
                    y = y1 + (y2 - y1) / 15;
                    Y = y + (y2 - y1) / 4;
                }
                if (House == 6 || House == 8)
                {
                    Y = y2 - (y2 - y1) / 15;
                    y = Y - (y2 - y1) / 4;
                }
                x = x1 + (x2 - x1) * 2 / 15;
                X = x2 - (x2 - x1) * 2 / 15;
            }
            else	//(3,4,5,9,10,11)
            {
                if (House == 4 || House == 10)
                {
                    x = ((x2 - x1) / 2 + x1) - (x2 - x1) / 13;
                    X = ((x2 - x1) / 2 + x1) + (x2 - x1) / 13;
                }
                if (House == 3 || House == 5)
                {
                    x = x1 + (x2 - x1) / 15;
                    X = x + (x2 - x1) / 4;
                }
                if (House == 9 || House == 11)
                {
                    X = x2 - (x2 - x1) / 15;
                    x = X - (x2 - x1) / 4;
                }
                y = y1 + (y2 - y1) * 2 / 15;
                Y = y2 - (y2 - y1) * 2 / 15;
            }

            RectangleF rect = new RectangleF(x, y, X - x, Y - y);

            return rect;
        }*/

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        /// <summary>
        /// Converts 00:00:00 and lat/lon to deg.decimal format.
        /// </summary>
        /// <param name="DegMinSec"></param>
        /// <returns></returns>
        public static double DegMinSec_To_DegDecimal(string DegMinSec)
        {
            DegMinSec = DegMinSec.Trim();
            int sign = 1;
            if (DegMinSec.Contains("-"))
                sign = -1;
            if (DegMinSec.Contains("W") || DegMinSec.Contains("w") || DegMinSec.Contains("S") || DegMinSec.Contains("s"))
                sign = -1;

            string[] input = DegMinSec.Split(new Char[] { 'E', 'W', 'N', 'S', 'e', 'w', 'n', 's', ':', '.', ' ', '\'' });
            int l = input.Length;
            double Degrees = 0, Minutes = 0, Seconds = 0;
            if (l >= 1)
            {
                Degrees = Convert.ToDouble(input[0]);
                Degrees = Math.Abs(Degrees);
            }
            if (l >= 2)
            {
                Minutes = Convert.ToDouble(input[1]);
                Minutes = Minutes / ((double)60);
            }
            if (l >= 3)
            {
                Seconds = Convert.ToDouble(input[2]);
                Seconds = Seconds / ((double)3600);
            }
            Degrees = Degrees + Minutes + Seconds;
            Degrees = Degrees * sign;
            return Degrees;

        }

        /// <summary>
        /// Converts Deg.Decimal to Deg:Min:Sec format
        /// </summary>
        /// <param name="Degrees"></param>
        /// <param name="sec"></param>
        /// <param name="add_remain_decimals"></param>
        /// <returns></returns>
        public static string DegDecimal_To_DegMinSec(double Degrees, bool sec, bool add_remain_decimals)
        {
            int neg = 0;
            if (Degrees < 0)
                neg = 1;
            Degrees = Math.Abs(Degrees);

            string DegMinSec;
            string a = new string(new char[20]);
            DegMinSec = String.Format("{0:00}:", (int)Degrees);
            Degrees = Degrees - (int)Degrees;

            double i = Degrees * 60;
            a = string.Format("{0:D2}", (int)i);
            DegMinSec += a;
            if (sec == true)
            {
                DegMinSec += ":";
                i = i - (int)i;
                i = i * 60;
                a = string.Format("{0:D2}", (int)i);
                DegMinSec += a;
            }
            if (add_remain_decimals == true)
            {
                i = i - (int)i;
                DegMinSec += a.Substring(1);
            }
            if (neg == 1)
                DegMinSec = "-" + DegMinSec;
            return DegMinSec;
        }

        public static string Decrypt(string secret)
        {
            char[] password = { '^', '%', '*' };
            int[] iPass = { Convert.ToInt32(password[0]), Convert.ToInt32(password[1]), Convert.ToInt32(password[2]) };

            int L = password.Length;
            int charValue;
            string secretreturn = "";

            for (int i = 0, X = 0; i < secret.Length; i++, X++)
            {
                charValue = Convert.ToInt32(secret[i]) - 32;

                if (X == L)
                    X = 0;
                charValue ^= iPass[X];
                secretreturn += char.ConvertFromUtf32(charValue);
            }
            return secretreturn;
        }
        public static void Draw_Table_Planetary_Details(Graphics objGraphics, RectangleF chartRect, double[] Planet_Degrees, int[] Planet_Signs, double Lg_Degrees, int Lg_Sign, int[] Planet_Retro )
        {
            try
            {
                float ht = chartRect.Height / 19.0f;
                float wd = chartRect.Width / 16.0f;

                Pen penKhaki = new Pen(Color.FromArgb(66, 75, 17));
                SolidBrush brushBkGnd = new SolidBrush(Color.FromArgb(233, 238, 208));

                objGraphics.FillRectangle(brushBkGnd, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                objGraphics.DrawRectangle(penKhaki, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);

                StringFormat centerFormat = new StringFormat();
                centerFormat.Trimming = StringTrimming.None;
                centerFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerFormat.LineAlignment = StringAlignment.Center;
                centerFormat.Alignment = StringAlignment.Center;

                StringFormat centerleftFormat = new StringFormat();
                centerleftFormat.Trimming = StringTrimming.None;
                centerleftFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerleftFormat.LineAlignment = StringAlignment.Center;
                centerleftFormat.Alignment = StringAlignment.Near;

                Font TextFont = new Font("Verdana", 10);
                Font HeadFont = new Font("Times New Roman", 12, FontStyle.Bold);

                SolidBrush fontBlackBrush = new SolidBrush(Color.Black);
                SolidBrush fontMaroonBrush = new SolidBrush(Color.FromArgb(181, 38, 24));

                string[] Rasi_Names = new string[]{ 
					"Aries", 
					"Taurus", 
					"Gemini", 
					"Cancer", 
					"Leo", 
					"Virgo", 
					"Libra", 
					"Scorpio", 
					"Sagittarius", 
					"Capricorn", 
					"Aquarius", 
					"Pisces" };

                string a;
                objGraphics.DrawString("Planetary Details", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left, chartRect.Top, chartRect.Width, ht), centerFormat);

                objGraphics.DrawString("Asc", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 2, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Sun", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 3, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Moon", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 4, chartRect.Width, ht), centerleftFormat);
                a = "Mars"; if (Planet_Retro[2] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 5, chartRect.Width, ht), centerleftFormat);
                a = "Mercury"; if (Planet_Retro[3] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 6, chartRect.Width, ht), centerleftFormat);
                a = "Jupiter"; if (Planet_Retro[4] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 7, chartRect.Width, ht), centerleftFormat);
                a = "Venus"; if (Planet_Retro[5] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 8, chartRect.Width, ht), centerleftFormat);
                a = "Saturn"; if (Planet_Retro[6] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 9, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Rahu", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 10, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Ketu", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 11, chartRect.Width, ht), centerleftFormat);
                a = "Uranus"; if (Planet_Retro[9] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 12, chartRect.Width, ht), centerleftFormat);
                a = "Neptune"; if (Planet_Retro[10] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 13, chartRect.Width, ht), centerleftFormat);
                a = "Pluto"; if (Planet_Retro[11] == -1) a += " (R)"; objGraphics.DrawString(a, HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 14, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Chiron", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 15, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("X (2007 RH283)", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 16, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Y (1999 JV127)", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 17, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Z (2008 FC76)", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + 10, chartRect.Top + ht * 18, chartRect.Width, ht), centerleftFormat);

                objGraphics.DrawString("Degrees", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + wd * 7.0f, chartRect.Top + ht, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString("Rasi", HeadFont, fontMaroonBrush, new RectangleF(chartRect.Left + wd * 11.0f, chartRect.Top + ht, chartRect.Width, ht), centerleftFormat);


                //deg-rasi-nak

                objGraphics.DrawString(Functions.DegDecimal_To_DegMinSec(Lg_Degrees, false, false), TextFont, fontBlackBrush, new RectangleF(chartRect.Left + wd * 7.0f, chartRect.Top + ht * 2, chartRect.Width, ht), centerleftFormat);
                objGraphics.DrawString(Rasi_Names[Lg_Sign - 1], TextFont, fontBlackBrush, new RectangleF(chartRect.Left + wd * 11.0f, chartRect.Top + ht * 2, chartRect.Width, ht), centerleftFormat);

                int i;
                for (i = 0; i < 16; i++)
                {
                    objGraphics.DrawString(Functions.DegDecimal_To_DegMinSec(Planet_Degrees[i], false, false), TextFont, fontBlackBrush, new RectangleF(chartRect.Left + wd * 7.0f, chartRect.Top + ht * (i + 3), chartRect.Width, ht), centerleftFormat);
                    objGraphics.DrawString(Rasi_Names[Planet_Signs[i] - 1], TextFont, fontBlackBrush, new RectangleF(chartRect.Left + wd * 11.0f, chartRect.Top + ht * (i + 3), chartRect.Width, ht), centerleftFormat);
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }
        }
        public static void DrawChart_North(Graphics objGraphics, RectangleF chartRect, int Lagna_Sign, int[] Planet_Signs, double[] Planet_Degrees, double birthJulDay)
        {
            try
            {
                Pen penOrange = new Pen(Color.FromArgb(245, 167, 124));
                Pen penRed = new Pen(Color.FromArgb(255, 0, 0), 2);
                SolidBrush brushBkGnd = new SolidBrush(Color.FromArgb(255, 255, 255));
                SolidBrush brushWhite = new SolidBrush(Color.White);
                SolidBrush fontRasiBrush = new SolidBrush(Color.LightSalmon);
                SolidBrush fontHouseBrush = new SolidBrush(Color.FromArgb(66, 75, 17));
                SolidBrush[] fontPlanetBrush = new SolidBrush[]{
                    new SolidBrush(Color.Black),//.FromArgb(181, 38, 24)),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black)};

                StringFormat centerFormat = new StringFormat();
                centerFormat.Trimming = StringTrimming.None;
                centerFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerFormat.LineAlignment = StringAlignment.Center;
                centerFormat.Alignment = StringAlignment.Center;

                StringFormat lowerleftFormat = new StringFormat();
                lowerleftFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                lowerleftFormat.LineAlignment = StringAlignment.Far;
                lowerleftFormat.Alignment = StringAlignment.Near;

                StringFormat upperrightFormat = new StringFormat();
                upperrightFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                upperrightFormat.LineAlignment = StringAlignment.Near;
                upperrightFormat.Alignment = StringAlignment.Far;


                Font houseFont = new Font("Times New Roman", 9);
                Font planetFont = new Font("Times New Roman", 12, FontStyle.Bold);

                string[] Planet_Sht_Names = new string[] { "Su", "Mo", "Ma", "Me", "Ju", "Ve", "Sa", "Ra", "Ke", "Ur", "Ne", "Pl", "Ch", "X", "Y", "Z" };
                string[] Rasi_Sht_Names = new string[] { "Ar", "Ta", "Ge", "Cn", "Le", "Vi", "Li", "Sc", "Sg", "Cp", "Aq", "Pi" };


                penOrange.Width = 2;
                objGraphics.FillRectangle(brushBkGnd, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                objGraphics.DrawRectangle(penOrange, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                penOrange.Width = 1;

                objGraphics.DrawLine(penOrange, chartRect.Left, chartRect.Top, chartRect.Left + chartRect.Width, chartRect.Top + chartRect.Height);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width, chartRect.Top, chartRect.Left, chartRect.Top + chartRect.Height);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width / 2, chartRect.Top, chartRect.Left, chartRect.Top + chartRect.Height / 2);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width / 2, chartRect.Top, chartRect.Left + chartRect.Width, chartRect.Top + chartRect.Height / 2);
                objGraphics.DrawLine(penOrange, chartRect.Left, chartRect.Top + chartRect.Height / 2, chartRect.Left + chartRect.Width / 2, chartRect.Top + chartRect.Height);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width, chartRect.Top + chartRect.Height / 2, chartRect.Left + chartRect.Width / 2, chartRect.Top + chartRect.Height);

                int[] GoodBad = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                int[] House_Planet = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int i;
                for (i = 0; i < 16; i++)
                {
                    House_Planet[i] = Planet_Signs[i] - Lagna_Sign + 1;
                    if (House_Planet[i] < 1) House_Planet[i] += 12;
                }
                bool NewMoon = false;
                if (Planet_Signs[0] == Planet_Signs[1] && Planet_Degrees[1] - Planet_Degrees[0] > 0 && Planet_Degrees[1] - Planet_Degrees[0] <= 15)
                    NewMoon = true;

                int SignSeventh = (Planet_Signs[0] + 6) % 12;
                if (SignSeventh == 0) SignSeventh = 12;

                bool FullMoon = false;
                if (Planet_Signs[1] == SignSeventh && Planet_Degrees[1] - Planet_Degrees[0] >= -10 && Planet_Degrees[1] - Planet_Degrees[0] <= 5)
                    NewMoon = true;



                //change colors of planets in different circumstances
                //Good
                /*
                    * Sun - Aries & Leo
                    * Moon - Taurus and Cancer
                    * Mars - Capricorn
                    * Mercury - Aquarius
                    * Jupiter - Cancer
                    * Venus - Pisces
                    * Saturn - Libra								
                    * Uranus - Virgo and Scorpio								
                    * Neptune - Taurus and Cancer								
                    * Pluto - Aries, Gemini and Leo								
                    * Chiron - Aries and Sagittarius								
                    * Planet X - Aries, Gemini, Virgo, Libra, Sagittarius, Aquarius and Pisces, Capricorn and Cancer .								
                    * Planet Y - Aries and Gemini								
                    * Planet Z - Libra and Pisces	
                    * During New Moon (When Sun and Moon are in same zodiac sign, but degree of Moon is ahead of Sun) can Sun and Moon be given same colour code as exalted or Own house planets. (You can give a colour code when there is a maximum of 15 degree difference. Lets say Sun is in 6'...then till Moon is in 21 degrees it is New Moon)
                    * The Full Moon is when Sun and Moon are in opposite signs. (You can give a colour code with a maximum of 10 degrees Minus and 5 degree Plus. Eg. If Sun is in 13 degree, then Moon from 3-18 degrees can be colour coded)
                    * Whenever Planet Y is is Aries kindly make it Green. (Instead of being in black. Nothing else should change, like red circle in certain conditions etc)
                    * Whenever Planet Z is in Pisces, Kindly make it Green (Instead of being in black. Nothing else should change, like red circle in certain conditions etc)

                    */

                Color Good = Color.Green;
                if (Planet_Signs[0] == 1 || Planet_Signs[0] == 5)//su
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                }
                if (Planet_Signs[1] == 2 || Planet_Signs[1] == 4)//mo
                {
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[1] = 1;
                }
                if (Planet_Signs[2] == 10)//ma
                {
                    fontPlanetBrush[2] = new SolidBrush(Good);
                    GoodBad[2] = 1;
                }
                if (Planet_Signs[3] == 11)//me
                {
                    fontPlanetBrush[3] = new SolidBrush(Good);
                    GoodBad[3] = 1;
                }
                if (Planet_Signs[4] == 4) //Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(Good);
                    GoodBad[4] = 1;
                }
                if (Planet_Signs[5] == 12) //Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(Good);
                    GoodBad[5] = 1;
                }
                if (Planet_Signs[6] == 7) //Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(Good);
                    GoodBad[6] = 1;
                }
                if (Planet_Signs[9] == 6 || Planet_Signs[9] == 8) //Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(Good);
                    GoodBad[9] = 1;
                }
                if (Planet_Signs[10] == 2 || Planet_Signs[10] == 4) //Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Good);
                    GoodBad[10] = 1;
                }
                if (Planet_Signs[11] == 1 || Planet_Signs[11] == 3 || Planet_Signs[11] == 5 ) //Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Good);
                    GoodBad[11] = 1;
                }
                if(Planet_Signs[12] == 1 ||  Planet_Signs[12] == 9 ) //Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Good);
                    GoodBad[12] = 1;
                }
                if( Planet_Signs[13] == 1 || Planet_Signs[13] == 3 || Planet_Signs[13] == 4 || Planet_Signs[13] == 6 || Planet_Signs[13] == 7 || Planet_Signs[13] == 9 || Planet_Signs[13] == 10 || Planet_Signs[13] == 11 || Planet_Signs[13] == 12 ) //X
                {
                    fontPlanetBrush[13] = new SolidBrush(Good);
                    GoodBad[13] = 1;
                }
                if( Planet_Signs[14] == 1 || Planet_Signs[14] == 3) //Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Good);
                    GoodBad[14] = 1;
                }
                if( Planet_Signs[15] == 7 || Planet_Signs[15] == 12) //Z
                {
                    fontPlanetBrush[15] = new SolidBrush(Good);
                    GoodBad[15] = 1;
                }
                if (NewMoon) // During New Moon (When Sun and Moon are in same zodiac sign, but degree of Moon is ahead of Sun) can Sun and Moon be given same colour code as exalted or Own house planets(You can give a colour code when there is a maximum of 15 degree difference. Lets say Sun is in 6'...then till Moon is in 21 degrees it is New Moon)
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                    GoodBad[1] = 1;
                }
                if (FullMoon)// The Full Moon is when Sun and Moon are in opposite signs. (You can give a colour code with a maximum of 10 degrees Minus and 5 degree Plus. Eg. If Sun is in 13 degree, then Moon from 3-18 degrees can be colour coded)
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                    GoodBad[1] = 1;
                }
                //Bad
                /*
                 * Su - Libra, Aquarius
                 * Moon - Scorpio, Capricorn
                 * Ma - Cancer
                 * Mercury - Leo
                 * Ju - Capricorn
                 * Venus - Virgo
                 * Sa - Aries
                 * When its amavasya, pls mark both Sun and Moon as red (When Sun and Moon are in same rashi but Moon is behind Sun)
                 * Venus & Mars be given the same colours as debilitated planets when they are in conjunction (in same zodiac sign)
                 * Sun & Mercury in conjunction in 6th, 8th and 12th houses (Planets to be coded Red)
                 * Whenever X is placed in Leo it has to be coloured in Red.
                 * Chiron should be mentioned in Red colour whenever it is in Gemini and Libra irrespective of which house it is in. 
                 * Planet Y should be mentioned in Red colour whenever it is in Libra and Sagitarius irrespective of which house it is in. 
                 * Planet Z should be mentioned in Red colour whenever it is in Aries and Virgo, irrespective of which house it is in.
                 * Uranus should be mentioned in Red colour whenever it is in Taurus and Pisces irrespective of which house it is in. 
                 * Neptune should be mentioned in Red colour whenever it is in Scorpio and Capricorn irrespective of which house it is in.
                 * Pluto should be mentioned in Red colour whenever it is in Libra, Sagitarius and Aquarius irrespective of which house it is in. 

                 */
                Color Bad = Color.Red;
                if (Planet_Signs[0] == 7 || Planet_Signs[0] == 11 )//su
                {    
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                }
                if(Planet_Signs[1] == 8 || Planet_Signs[1] == 10)
                {
                    fontPlanetBrush[1] = new SolidBrush(Bad);
                    GoodBad[1] = -1;
                }
                if (Planet_Signs[2] == 4)//ma
                {   
                    fontPlanetBrush[2] = new SolidBrush(Bad);
                    GoodBad[2] = -1;
                }
                if (Planet_Signs[3] == 5) //me
                {
                    fontPlanetBrush[3] = new SolidBrush(Bad);
                    GoodBad[3] = -1;
                }
                if (Planet_Signs[4] == 10)//ju
                {    
                    fontPlanetBrush[4] = new SolidBrush(Bad);
                    GoodBad[4] = -1;
                }
                if (Planet_Signs[5] == 6)//ve
                {    
                    fontPlanetBrush[5] = new SolidBrush(Bad);
                    GoodBad[5] = -1;
                }
                if (Planet_Signs[6] == 1)//sa
                {    
                    fontPlanetBrush[6] = new SolidBrush(Bad);
                    GoodBad[6] = -1;
                }

                if (Planet_Signs[5] == Planet_Signs[2]) // Venus & Mars be given the same colours as debilitated planets when they are in conjunction (in same zodiac sign)
                {
                    fontPlanetBrush[5] = new SolidBrush(Bad);
                    fontPlanetBrush[2] = new SolidBrush(Bad);
                    GoodBad[5] = -1;
                    GoodBad[2] = -1;
                }
                if (Planet_Signs[0] == Planet_Signs[1] && Planet_Degrees[1] <= Planet_Degrees[0]) // During Amavasya (When Sun and Moon are in same zodiac sign but the degree of Moon is lesser than the degree of Sun) can Sun and Moon be given same colour code as debilitated planets?
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    fontPlanetBrush[1] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                    GoodBad[1] = -1;
                }
                // * Sun & Mercury in conjunction in 6th, 8th and 12th houses (Planets to be coded Red)
                if (Planet_Signs[0] == Planet_Signs[3] && (House_Planet[0] == 6 || House_Planet[0] == 8 || House_Planet[0] == 12))
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    fontPlanetBrush[3] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                    GoodBad[3] = -1;
                }
                if (Planet_Signs[13] == 5) //X
                {
                    fontPlanetBrush[13] = new SolidBrush(Bad);
                    GoodBad[13] = -1;
                }
                if (Planet_Signs[12] == 3 || Planet_Signs[12] == 7) //Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Bad);
                    GoodBad[12] = -1;
                }
                if (Planet_Signs[14] == 7 || Planet_Signs[14] == 9)//Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Bad);
                    GoodBad[14] = -1;
                }
                if (Planet_Signs[15] == 1 || Planet_Signs[15] == 6)//Z
                {
                    fontPlanetBrush[15] = new SolidBrush(Bad);
                    GoodBad[15] = -1;
                }
                if (Planet_Signs[9] == 2 || Planet_Signs[9] == 12) //Uraunus
                {
                    fontPlanetBrush[9] = new SolidBrush(Bad);
                    GoodBad[9] = -1;
                }
                if (Planet_Signs[10] == 8 || Planet_Signs[10] == 10) //Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Bad);
                    GoodBad[10] = -1;
                }
                if (Planet_Signs[11] == 7 || Planet_Signs[11] == 9 || Planet_Signs[11] == 11) //Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Bad);
                    GoodBad[11] = -1;
                }

                //Own House (Blue)
                /*
                 * Su - Nill
                 * Moon - Nill
                 * Ma - Aries
                 * Mercury - Gemini
                 * Ju - Sagitarius
                 * Venus - Libra
                 * Sa - Capricorn
                 * Uranus - Aquarius
                 * Neptune - Pisces
                 * Pluto - Scorpio
                 * Chiron - Cancer
                 * X - Taurus
                 * Y - Virgo
                 * Z- Leo
                 */

                Color OwnHouse = Color.Blue;
                if (Planet_Signs[2] == 1)//Mars
                {
                    fontPlanetBrush[2] = new SolidBrush(OwnHouse);
                    GoodBad[2] = 2;
                }
                if (Planet_Signs[3] == 3)// Mercury
                {
                    fontPlanetBrush[3] = new SolidBrush(OwnHouse);
                    GoodBad[3] = 2;
                }
                if (Planet_Signs[4] == 9)// Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(OwnHouse);
                    GoodBad[4] = 2;
                }
                if (Planet_Signs[5] == 7)// Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(OwnHouse);
                    GoodBad[5] = 2;
                }
                if (Planet_Signs[6] == 10)// Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(OwnHouse);
                    GoodBad[6] = 2;
                }
                if (Planet_Signs[9] == 11)// Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(OwnHouse);
                    GoodBad[9] = 2;
                }
                if (Planet_Signs[10] == 12)// Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(OwnHouse);
                    GoodBad[10] = 2;
                }
                if (Planet_Signs[11] == 8)// Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(OwnHouse);
                    GoodBad[11] = 2;
                }
                if (Planet_Signs[12] == 4)// Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(OwnHouse);
                    GoodBad[12] = 2;
                }
                if (Planet_Signs[13] == 2)// X
                {
                    fontPlanetBrush[13] = new SolidBrush(OwnHouse);
                    GoodBad[13] = 2;
                }
                if (Planet_Signs[14] == 6)// Y
                {
                    fontPlanetBrush[3] = new SolidBrush(OwnHouse);
                    GoodBad[14] = 2;
                }
                if (Planet_Signs[15] == 5)// z
                {
                    fontPlanetBrush[15] = new SolidBrush(OwnHouse);
                    GoodBad[15] = 2;
                }

                //Friendly (DarkCyan)
                /*
                 * Su - Nill
                 * Moon - Nill
                 * Ma - Libra
                 * Mercury - Sagitarius
                 * Ju - Gemini
                 * Venus - Aries
                 * Sa - Cancer
                 * Uranus - Leo
                 * Neptune - Virgo
                 * Pluto - Taurus
                 * Chiron - Capricorn
                 * X - Scorpio
                 * Y - Pisces
                 * Z- Aquarius
                 */

                Color Friendly = Color.DarkCyan;
                if (Planet_Signs[2] == 7)//Mars
                {
                    fontPlanetBrush[2] = new SolidBrush(Friendly);
                    GoodBad[0] = 3;
                }
                if (Planet_Signs[3] == 9)// Mercury
                {
                    fontPlanetBrush[3] = new SolidBrush(Friendly);
                    GoodBad[3] = 3;
                }
                if (Planet_Signs[4] == 3)// Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(Friendly);
                    GoodBad[4] = 3;
                }
                if (Planet_Signs[5] == 1)// Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(Friendly);
                    GoodBad[5] = 3;
                }
                if (Planet_Signs[6] == 4)// Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(Friendly);
                    GoodBad[6] = 3;
                }
                if (Planet_Signs[9] == 5)// Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(Friendly);
                    GoodBad[9] = 3;
                }
                if (Planet_Signs[10] == 6)// Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Friendly);
                    GoodBad[10] = 3;
                }
                if (Planet_Signs[11] == 2)// Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Friendly);
                    GoodBad[11] = 3;
                }
                if (Planet_Signs[12] == 10)// Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Friendly);
                    GoodBad[12] = 3;
                }
                if (Planet_Signs[13] == 8)// X
                {
                    fontPlanetBrush[13] = new SolidBrush(Friendly);
                    GoodBad[13] = 3;
                }
                if (Planet_Signs[14] == 12)// Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Friendly);
                    GoodBad[14] = 3;
                }
                if (Planet_Signs[15] == 11)// z
                {
                    fontPlanetBrush[15] = new SolidBrush(Friendly);
                    GoodBad[15] = 3;
                }

                /* CIRCLE in RED the following in addition to a "GREEN" planet being in 3rd, 6th, 8th, 12th houses....
                    Aries Ascendant – Z in Pisces, Y in any house, Mercury in Aquarius, Z in Libra, Pluto in Leo, Saturn in Libra
                    Taurus Ascendant – Y in Aries, NewMoon in any house, FullMoon in any house, Ve in any sign, Venus in Pisces, Pluto in Scorpio, Pluto in Leo, Uranus in Scorpio, Mars in Capricorn, Sun in Sagittarius, Jupiter in Taurus, X in Cancer, Chiron in Aries. 
                    Gemini Ascendant – Z in Pisces, Saturn in any house, Sun in Aries, Jupiter in Sagittarius, Jupiter in Cancer, Saturn in Libra, X in Gemini, X in Cancer, X in Virgo, X in Libra, X in Sagittarius, X in Capricorn, X in Aquarius, X in Pisces, X in Aries, Venus in Capricorn, Z in Leo, Z in Libra, Mars in Sagittarius.
                    Cancer Ascendant – Y in Aries, Me in any house, Jupiter in Cancer,  Saturn in Capricorn, Saturn in Libra, Uranus in Scorpio, Mars in Capricorn, X in Capricorn.
                    Leo Ascendant – Z in Pisces, NewMoon in any house, FullMoon in any house, Uranus in Aquarius, Uranus in Scorpio, X in Cancer, X in Aquarius, X in Capricorn, Mercury in Aquarius, Moon in Taurus, Chiron in Aries.
                    Virgo Ascendant – Y in Aries, Z in Pisces, NewMoon in any house, FullMoon in any house, Venus in Pisces, Mars in Capricorn, Mars in all houses, X in Pisces, Z in Libra, Chiron in Aries
                    Libra Ascendant – Z in Pisces, Y in any house, Jupiter in Cancer, Neptune in Cancer, Mars in Aries, Mars in Capricorn, Chiron in Aries, X in Gemini, X in Cancer, X in Libra, X in Capricorn, X in Aquarius, X in Aries, Sun in Aries, Y in Gemini.  
                    Scorpio Ascendant – Y in Aries, Z in Pisces, Me in any house, Ve in any sign, Chiron in Aries, X in Taurus, X in Cancer, X in Virgo, X in Sagittarius, X in Capricorn, X in Aquarius, Mercury in Aquarius, X in Pisces, Moon in Taurus, Venus in Pisces, Mercury In Scorpio, Venus in all houses, Mars in all houses. 
                    Sagittarius Ascendant – Y in Aries, NewMoon in any house, FullMoon in any house, Ma in Capricorn, Chiron in Aries, X in Gemini, X in Cancer, X in Virgo, X in Libra, X in Sagittarius, X in Capricorn, X in Pisces, X in Aries, Y in Gemini, Pluto in Leo, Chiron in Sagittarius.
                    Capricorn Ascendant – Z in Pisces, NewMoon in any house, FullMoon in any house, Me in any house, X in Virgo, Neptune in Cancer, Mercury in Aquarius, Moon in Cancer, Moon in Taurus, Sun in Aries, Sun in Capricorn, Mercury in Capricorn, Jupiter in Cancer, Chiron in Aries, X in Cancer, Z in Libra. 
                    Aquarius Ascendant - Z in Pisces, NewMoon in any house, FullMoon in any house, Y in any house, Moon in Taurus, Sun in Leo, Z in Leo, Z in Libra, Y in Gemini, Pluto in Leo, Saturn in Libra, Chiron in Sagittarius, Chiron in Aries, X in Cancer, X in Capricorn.
                    Pisces Ascendant – NewMoon in any house, FullMoon in any house, Ve in any sign, X in Gemini, X in Cancer, X in Virgo, X in Sagittarius, X in Capricorn, X in Aries, Moon in Taurus, Sun in Aries, Y in Virgo, Y in Gemini,  Venus in Pisces, Venus in all houses, Uranus in Scorpio,
                    Sun placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Sat placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Jup placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Venus in the ascendant shouldn’t be circled in Red, except for Taurus, Scorpio and Pisces ascendants.
                    Venus in the 7th house shouldn’t be circled in Red except Aries, Taurus and Virgo ascendants.
                    When Sun and Mercury are in conjunction in the 5th house, they should be circled in Red.
                 * For Sagittarius Asdt when Mercury is in eighth it needs to be circled in RED
                 * For Gemini Asdts When Jupiter is in 12th, (or 6th or 8th)they need to be circled in RED.
                 * Mars or Venus in 1st, 3rd, 6th, 7th 8th and 12th (Planets to be circled Red)
                 * When Chiron is in Cancer or Sagittarius and in the 3rd, 5th, 6th, 7th, 8th and 12th house for any ascendant kindly circle it in Red.
                 * 
                 * Pluto during the years 1957 (1st Jan) to 1961 (31st Dec) should be circled in Red.
                //When a planet is already in red, it shouldn't be circled in red.
                 * */
                int[] RedCircle_eachLagna = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                if (Lagna_Sign == 1)
                {
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                }
                else if (Lagna_Sign == 2)
                {
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[11] == 8)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[0] == 9)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 2)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;

                    RedCircle_eachLagna[5] = -1;//Ve in any sign
                }
                else if (Lagna_Sign == 3)
                {
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 9)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[5] == 10)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[15] == 5)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[2] == 9)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[6] = -1;//Sa in any house

                    if (House_Planet[4] == 12 || House_Planet[4] == 6 || House_Planet[4] == 8)
                        RedCircle_eachLagna[4] = -1;

                }
                else if (Lagna_Sign == 4)
                {
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[6] == 10)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[3] = -1;//Me in any house
                }
                else if (Lagna_Sign == 5)
                {

                    if (Planet_Signs[9] == 11)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 6)
                {
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    //if (Planet_Signs[2] == 10)
                    //    RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[2] = -1;//Ma in all houses
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 7)
                {
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[10] == 4)
                        RedCircle_eachLagna[10] = -1;
                    if (Planet_Signs[2] == 1)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                }
                else if (Lagna_Sign == 8)
                {
                    if (Planet_Signs[13] == 2)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[3] == 8)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[2] = -1;//Ma in all houses
                    RedCircle_eachLagna[3] = -1;//Me in any house
                    RedCircle_eachLagna[5] = -1;//Ve in any sign
                }
                else if (Lagna_Sign == 9)
                {
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[12] == 9)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    if (House_Planet[3] == 8)
                        RedCircle_eachLagna[3] = -1;
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;

                }
                else if (Lagna_Sign == 10)
                {
                    if (Planet_Signs[10] == 4)
                        RedCircle_eachLagna[10] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[1] == 4)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[0] == 10)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[3] == 10)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[3] = -1;//Me in any house
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 11)
                {
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 5)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[15] == 5)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[12] == 9)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 12)
                {
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[14] == 6)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;

                    RedCircle_eachLagna[5] = -1;//ve in all houses
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                //Sun placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[0] == 6 || House_Planet[0] == 8 || House_Planet[0] == 12)
                    RedCircle_eachLagna[0] = -1;

                //Saturn placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[6] == 6 || House_Planet[6] == 8 || House_Planet[6] == 12)
                    RedCircle_eachLagna[6] = -1;

                //Jupiter placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[4] == 6 || House_Planet[4] == 8 || House_Planet[4] == 12)
                    RedCircle_eachLagna[4] = -1;

                // * Mars or Venus in 1st, 3rd, 6th, 7th 8th and 12th (Planets to be circled Red)
                if (House_Planet[2] == 1 || House_Planet[2] == 3 || House_Planet[2] == 6 || House_Planet[2] == 7 || House_Planet[2] == 8 || House_Planet[2] == 12)
                    RedCircle_eachLagna[2] = -1;
                if (House_Planet[5] == 1 || House_Planet[5] == 3 || House_Planet[5] == 6 || House_Planet[5] == 7 || House_Planet[5] == 8 || House_Planet[5] == 12)
                    RedCircle_eachLagna[5] = -1;

                // * When Chiron is in Cancer or Sagittarius and in the 3rd, 5th, 6th, 7th, 8th and 12th house for any ascendant kindly circle it in Red.
                if ((Planet_Signs[12] == 4 || Planet_Signs[12] == 9) && (House_Planet[12] == 3 || House_Planet[12] == 5 || House_Planet[12] == 6 || House_Planet[12] == 7 || House_Planet[12] == 8 || House_Planet[12] == 12))
                    RedCircle_eachLagna[12] = -1;

                // When the full Moon falls in 3rd,5th, 6th 7th, 8th and 12th houses, it should be in circled in Red.
                if (FullMoon && (House_Planet[1] == 3 || House_Planet[1] == 5 || House_Planet[1] == 6 || House_Planet[1] == 7 || House_Planet[1] == 8 || House_Planet[1] == 12))
                    RedCircle_eachLagna[1] = -1;

                // When the new Moon falls in 3rd,5th, 6th 7th, 8th and 12th houses, it should be in circled in Red.
                if (NewMoon && (House_Planet[1] == 3 || House_Planet[1] == 5 || House_Planet[1] == 6 || House_Planet[1] == 7 || House_Planet[1] == 8 || House_Planet[1] == 12))
                    RedCircle_eachLagna[1] = -1;

                //Venus in the ascendant shouldn’t be circled in Red, except for Taurus, Scorpio and Pisces ascendants.
                if (House_Planet[5] == 1 && !(Planet_Signs[5] == 2 || Planet_Signs[5] == 8 || Planet_Signs[5] == 12))
                    RedCircle_eachLagna[5] = -1;
                //Venus in the 7th house shouldn’t be circled in Red except Aries, Taurus and Virgo ascendants.
                if (House_Planet[5] == 7 && !(Planet_Signs[5] == 7 || Planet_Signs[5] == 8 || Planet_Signs[5] == 12))//7th house is libra, scorpio or pisces for ascendents aries, taurus and virgo
                    RedCircle_eachLagna[5] = -1;

                //When Sun and Mercury are in conjunction in the 5th house, they should be circled in Red.
                if (House_Planet[0] == House_Planet[3] && House_Planet[0] == 5)
                {
                    RedCircle_eachLagna[0] = -1;
                    RedCircle_eachLagna[3] = -1;
                }

                // Pluto during the years 1957 (1st Jan) to 1961 (31st Dec) should be circled in Red.
                if(birthJulDay>= 2435839.500000 && birthJulDay<= 2437664.500000)
                    RedCircle_eachLagna[11] = -1;

                ///************************************************************
                //When a planet is already in red, it shouldn't be circled in red.
                for ( i=0; i<16; i++)
                    if (GoodBad[i] == -1) RedCircle_eachLagna[i] = 0;
                ///************************************************************

                ////////
                RectangleF rectP, rectH;
                string a;
                
                int j = 0;
                string Planet_String = "", Outer_String = "";//, SpLg_String = "";
                int l, count, iPlanet = 0, Sign;
                float x = 0, y = 0, wd, ht;


                Sign = Lagna_Sign;
                for (count = 1; count <= 12; Sign++, count++)
                {
                    if (Sign == 13)
                        Sign = 1;
                    Planet_String = "";
                    Outer_String = "";

                    //planets
                    for (i = 0; i < 9; i++)
                    {
                        if (Planet_Signs[i] == Sign)
                        {
                            for (j = 0; j < Planet_String.Length; j++)
                            {
                                if (Planet_String == "") break;
                                a = String.Format("{0}", Planet_String[j] - 'a');
                                iPlanet = Convert.ToInt32(a, 10);

                                if (Planet_Degrees[iPlanet] > Planet_Degrees[i])
                                    break;
                            }
                            a = string.Format("{0}", Convert.ToChar(i + 97));
                            Planet_String = Planet_String.Insert(j, a);
                        }
                    }
//                    put ur ne pl, and asteroids in the outer_string
                    for (i = 9; i < 16; i++)
                    {
                        if (Planet_Signs[i] == Sign)
                        {
                            for (j = 0; j < Outer_String.Length; j++)
                            {
                                if (Outer_String == "") break;
                                a = String.Format("{0}", Outer_String[j] - 'a');
                                iPlanet = Convert.ToInt32(a, 10);

                                if (Planet_Degrees[iPlanet] > Planet_Degrees[i])
                                    break;
                            }
                            a = string.Format("{0}", Convert.ToChar(i + 97));
                            Outer_String = Outer_String.Insert(j, a);
                        }
                    }


                    //////switch statement which calculates the 4 corners of the house concerned
                    //////and calculates the rectangle for putting in the Rasi no.
                    switch (count)
                    {
                        case 1:
                            x = chartRect.Left + chartRect.Width / 4;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 2) - (chartRect.Width / 40), (chartRect.Top + chartRect.Height / 2) - (chartRect.Height * 3 / 40), chartRect.Width / 20, chartRect.Height / 20);
                            rectP = rectH;
                            rectP.Offset(0, -chartRect.Height / 20);
                            break;
                        case 2:
                            x = chartRect.Left;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top;
                            ht = chartRect.Height / 4;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 4) - (chartRect.Width / 40), (chartRect.Top + chartRect.Height / 4) - (chartRect.Height * 3 / 35), chartRect.Width / 20, chartRect.Height / 18);
                            rectP = rectH;
                            rectP.Offset(0, -chartRect.Height / 20);
                            break;
                        case 3:
                            x = chartRect.Left;
                            wd = chartRect.Width / 4;
                            y = chartRect.Top;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 4) - (chartRect.Width * 3 / 40), (chartRect.Top + chartRect.Height / 4) - (chartRect.Height / 30), chartRect.Width / 20, chartRect.Height / 15);
                            rectP = rectH;
                            rectP.Offset(-chartRect.Width / 20, 0);
                            break;
                        case 4:
                            x = chartRect.Left;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top + chartRect.Height / 4;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 2) - (chartRect.Width * 3 / 40), (chartRect.Top + chartRect.Height / 2) - (chartRect.Height / 40), chartRect.Width / 20, chartRect.Height / 20);
                            rectP = rectH;
                            rectP.Offset(-chartRect.Width / 20, 0);
                            break;
                        case 5:
                            x = chartRect.Left;
                            wd = chartRect.Width / 4;
                            y = chartRect.Top + chartRect.Height / 2;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 4) - (chartRect.Width * 3 / 40), (chartRect.Top + chartRect.Height * 3 / 4) - (chartRect.Height / 30), chartRect.Width / 20, chartRect.Height / 15);
                            rectP = rectH;
                            rectP.Offset(-chartRect.Width / 20, 0);
                            break;
                        case 6:
                            x = chartRect.Left;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top + chartRect.Height * 3 / 4;
                            ht = chartRect.Height / 4;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 4) - (chartRect.Width / 40), (chartRect.Top + chartRect.Height * 3 / 4) + (chartRect.Height / 35), chartRect.Width / 20, chartRect.Height / 18);
                            rectP = rectH;
                            rectP.Offset(0, chartRect.Height / 20);
                            break;
                        case 7:
                            x = chartRect.Left + chartRect.Width / 4;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top + chartRect.Height / 2;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 2) - (chartRect.Width / 40), (chartRect.Top + chartRect.Height / 2) + (chartRect.Height / 40), chartRect.Width / 20, chartRect.Height / 20);
                            rectP = rectH;
                            rectP.Offset(0, chartRect.Height / 20);
                            break;
                        case 8:
                            x = chartRect.Left + chartRect.Width / 2;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top + chartRect.Height * 3 / 4;
                            ht = chartRect.Height / 4;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width * 3 / 4) - (chartRect.Width / 40), (chartRect.Top + chartRect.Height * 3 / 4) + (chartRect.Height / 35), chartRect.Width / 20, chartRect.Height / 18);
                            rectP = rectH;
                            rectP.Offset(0, chartRect.Height / 20);
                            break;
                        case 9:
                            x = chartRect.Left + chartRect.Width * 3 / 4;
                            wd = chartRect.Width / 4;
                            y = chartRect.Top + chartRect.Height / 2;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width * 3 / 4) + (chartRect.Width / 40), (chartRect.Top + chartRect.Height * 3 / 4) - (chartRect.Height / 30), chartRect.Width / 20, chartRect.Height / 15);
                            rectP = rectH;
                            rectP.Offset(chartRect.Width / 20, 0);
                            break;
                        case 10:
                            x = chartRect.Left + chartRect.Width / 2;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top + chartRect.Height / 4;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 2) + (chartRect.Width / 40), (chartRect.Top + chartRect.Height / 2) - (chartRect.Height / 40), chartRect.Width / 20, chartRect.Height / 20);
                            rectP = rectH;
                            rectP.Offset(chartRect.Width / 20, 0);
                            break;
                        case 11:
                            x = chartRect.Left + chartRect.Width * 3 / 4;
                            wd = chartRect.Width / 4;
                            y = chartRect.Top;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width * 3 / 4) + (chartRect.Width / 40), (chartRect.Top + chartRect.Height / 4) - (chartRect.Height / 30), chartRect.Width / 20, chartRect.Height / 15);
                            rectP = rectH;
                            rectP.Offset(chartRect.Width / 20, 0);
                            break;
                        case 12:
                            x = chartRect.Left + chartRect.Width / 2;
                            wd = chartRect.Width / 2;
                            y = chartRect.Top;
                            ht = chartRect.Height / 4;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width * 3 / 4) - (chartRect.Width / 40), (chartRect.Top + chartRect.Height / 4) - (chartRect.Height * 3 / 35), chartRect.Width / 20, chartRect.Height / 18);
                            rectP = rectH;
                            rectP.Offset(0, -chartRect.Height / 20);
                            break;
                        default:
                            x = chartRect.Left + chartRect.Width / 4;
                            wd = chartRect.Width * 3 / 4;
                            y = chartRect.Top;
                            ht = chartRect.Height / 2;
                            rectH = new RectangleF((chartRect.Left + chartRect.Width / 2) - (chartRect.Width / 40), (chartRect.Top + chartRect.Height / 2) - (chartRect.Height * 3 / 40), chartRect.Width / 20, chartRect.Height / 20);
                            rectP = rectH;
                            rectP.Offset(0, -chartRect.Height / 20);
                            break;

                    }
                    objGraphics.DrawString(Rasi_Sht_Names[Sign - 1], houseFont, fontRasiBrush, rectH, centerFormat);
                    a = string.Format("{0}", count);
                    objGraphics.DrawString(a, houseFont, fontHouseBrush, rectP, centerFormat);

                    rectH = Functions.House_Planet_Rectangle_North(count, x, y, wd, ht);

                    switch (count)
                    {
                        case 12:
                        case 1:
                        case 2:

                            l = Planet_String.Length;
                            for (i = 0; i < Planet_String.Length; i++)
                            {
                                rectP = new RectangleF(rectH.Right - (rectH.Right - rectH.Left) / l, rectH.Top, (rectH.Right - rectH.Left) / l, rectH.Height);
                                rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);

                                iPlanet = Convert.ToInt32(String.Format("{0}", Planet_String[i] - 'a'), 10);
                                a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5 ) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                    objGraphics.DrawEllipse(penRed, rectP);
                                objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                rectH.Width -= rectH.Width / l;
                                l--;
                            }
                            l = Outer_String.Length;
                            if (l > 0)
                            {
                                rectH = Functions.House_Planet_Rectangle_North(count, x, y, wd, ht);
                                if (count == 12 || count == 2) rectH.Offset(0, (ht / 4));
                                else rectH.Offset(0, -(ht / 6));
                                rectH = RectangleF.Inflate(rectH, -(ht / 4), 0);
                                for (i = 0; i < Outer_String.Length; i++)
                                {
                                    rectP = new RectangleF(rectH.Right - (rectH.Right - rectH.Left) / l, rectH.Top, (rectH.Right - rectH.Left) / l, rectH.Height);
                                    rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);

                                    iPlanet = Convert.ToInt32(String.Format("{0}", Outer_String[i] - 'a'), 10);
                                    a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                    if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                        objGraphics.DrawEllipse(penRed, rectP);
                                    objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                    rectH.Width -= rectH.Width / l;
                                    l--;
                                }
                            }

                            break;

                        case 3:
                        case 4:
                        case 5:
                            l = Planet_String.Length;
                            for (i = 0; i < Planet_String.Length; i++)
                            {
                                rectP = new RectangleF(rectH.Left, rectH.Top, rectH.Width, (rectH.Bottom - rectH.Top) / l);
                                rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);

                                iPlanet = Convert.ToInt32(String.Format("{0}", Planet_String[i] - 'a'), 10);
                                a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                    objGraphics.DrawEllipse(penRed, rectP);
                                objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                rectH.Y += rectH.Height / l;
                                rectH.Height -= rectH.Height / l;
                                l--;
                            }
                            l = Outer_String.Length;
                            if (l > 0)
                            {
                                rectH = Functions.House_Planet_Rectangle_North(count, x, y, wd, ht);
                                if (count == 3 || count == 5) rectH.Offset((wd / 4), 0);
                                else rectH.Offset(-(wd / 6), 0);
                                rectH = RectangleF.Inflate(rectH, 0, -(wd / 4));
                                for (i = 0; i < Outer_String.Length; i++)
                                {
                                    rectP = new RectangleF(rectH.Left, rectH.Top, rectH.Width, (rectH.Bottom - rectH.Top) / l);
                                    rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);

                                    iPlanet = Convert.ToInt32(String.Format("{0}", Outer_String[i] - 'a'), 10);
                                    a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                    if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                        objGraphics.DrawEllipse(penRed, rectP);
                                    objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                    rectH.Y += rectH.Height / l;
                                    rectH.Height -= rectH.Height / l;
                                    l--;
                                }
                            }

                            break;

                        case 6:
                        case 7:
                        case 8:
                            l = Planet_String.Length;
                            for (i = 0; i < Planet_String.Length; i++)
                            {

                                rectP = new RectangleF(rectH.Left, rectH.Top, (rectH.Right - rectH.Left) / l, rectH.Height);
                                rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);
                                iPlanet = Convert.ToInt32(String.Format("{0}", Planet_String[i] - 'a'), 10);
                                a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                    objGraphics.DrawEllipse(penRed, rectP);
                                objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                rectH.X += rectH.Width / l;
                                rectH.Width -= rectH.Width / l;
                                l--;
                            }

                            l = Outer_String.Length;
                            if (l > 0)
                            {
                                rectH = Functions.House_Planet_Rectangle_North(count, x, y, wd, ht);
                                if (count == 6 || count == 8) rectH.Offset(0, -(ht / 4));
                                else rectH.Offset(0, (ht / 6));
                                rectH = RectangleF.Inflate(rectH, -(ht / 4), 0);
                                for (i = 0; i < Outer_String.Length; i++)
                                {
                                    rectP = new RectangleF(rectH.Left, rectH.Top, (rectH.Right - rectH.Left) / l, rectH.Height);
                                    rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);

                                    iPlanet = Convert.ToInt32(String.Format("{0}", Outer_String[i] - 'a'), 10);
                                    a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                    if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                        objGraphics.DrawEllipse(penRed, rectP);
                                    objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                    rectH.X += rectH.Width / l;
                                    rectH.Width -= rectH.Width / l;
                                    l--;
                                }
                            }

                            break;

                        case 9:
                        case 10:
                        case 11:
                            l = Planet_String.Length;
                            for (i = 0; i < Planet_String.Length; i++)
                            {
                                rectP = new RectangleF(rectH.Left, rectH.Bottom - (rectH.Bottom - rectH.Top) / l, rectH.Width, (rectH.Bottom - rectH.Top) / l);
                                rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);

                                iPlanet = Convert.ToInt32(String.Format("{0}", Planet_String[i] - 'a'), 10);
                                a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                    objGraphics.DrawEllipse(penRed, rectP);
                                objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                rectH.Height -= rectH.Height / l;
                                l--;
                            }

                            l = Outer_String.Length;
                            if (l > 0)
                            {
                                rectH = Functions.House_Planet_Rectangle_North(count, x, y, wd, ht);
                                if (count == 9 || count == 11) rectH.Offset(-(wd / 4), 0);
                                else rectH.Offset((wd / 6), 0);
                                rectH = RectangleF.Inflate(rectH, 0, -(wd / 4));
                                for (i = 0; i < Outer_String.Length; i++)
                                {
                                    rectP = new RectangleF(rectH.Left, rectH.Bottom - (rectH.Bottom - rectH.Top) / l, rectH.Width, (rectH.Bottom - rectH.Top) / l);
                                    rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);

                                    iPlanet = Convert.ToInt32(String.Format("{0}", Outer_String[i] - 'a'), 10);
                                    a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                                    if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                        objGraphics.DrawEllipse(penRed, rectP);
                                    objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);

                                    rectH.Height -= rectH.Height / l;
                                    l--;
                                }
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }

        }
        
        public static void DrawChart_South(Graphics objGraphics, RectangleF chartRect, int Lagna_Sign, int[] Planet_Signs, double[] Planet_Degrees, double birthJulDay)
        {
            try
            {
                int i = 0, j = 0;
                string Planet_String = "", Outer_String, a = "";
                int House, l, count, iPlanet = 0, Sign;
                float x = 0, X = 0, y = 0, Y = 0, xP = 0, yP = 0;
                float wd=0, ht=0;

                RectangleF rectP = new RectangleF(), rectH = new RectangleF();


                Pen penOrange = new Pen(Color.FromArgb(255, 153, 102));
                Pen penRed = new Pen(Color.FromArgb(255, 0, 0), 2);
                SolidBrush brushBkGnd = new SolidBrush(Color.FromArgb(255, 255, 255));
                SolidBrush brushWhite = new SolidBrush(Color.White);
                SolidBrush fontRasiBrush = new SolidBrush(Color.LightSalmon);
                SolidBrush fontHouseBrush = new SolidBrush(Color.FromArgb(66, 75, 17));
                SolidBrush[] fontPlanetBrush = new SolidBrush[]{
                    new SolidBrush(Color.Black),//.FromArgb(181, 38, 24)),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black)};

                StringFormat centerFormat = new StringFormat();
                centerFormat.Trimming = StringTrimming.None;
                centerFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerFormat.LineAlignment = StringAlignment.Center;
                centerFormat.Alignment = StringAlignment.Center;

                StringFormat bottomleftFormat = new StringFormat();
                bottomleftFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                bottomleftFormat.LineAlignment = StringAlignment.Far;
                bottomleftFormat.Alignment = StringAlignment.Near;

                StringFormat bottomrightFormat = new StringFormat();
                bottomrightFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                bottomrightFormat.LineAlignment = StringAlignment.Far;
                bottomrightFormat.Alignment = StringAlignment.Far;

                StringFormat toprightFormat = new StringFormat();
                toprightFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                toprightFormat.LineAlignment = StringAlignment.Near;
                toprightFormat.Alignment = StringAlignment.Far;

                StringFormat topleftFormat = new StringFormat();
                topleftFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                topleftFormat.LineAlignment = StringAlignment.Near;
                topleftFormat.Alignment = StringAlignment.Near;

                StringFormat bottomcenterFormat = new StringFormat();
                bottomcenterFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                bottomcenterFormat.LineAlignment = StringAlignment.Far;
                bottomcenterFormat.Alignment = StringAlignment.Center;

                StringFormat topcenterFormat = new StringFormat();
                topcenterFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                topcenterFormat.LineAlignment = StringAlignment.Near;
                topcenterFormat.Alignment = StringAlignment.Center;

                StringFormat centerleftFormat = new StringFormat();
                centerleftFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerleftFormat.LineAlignment = StringAlignment.Center;
                centerleftFormat.Alignment = StringAlignment.Near;

                StringFormat centerrightFormat = new StringFormat();
                centerrightFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerrightFormat.LineAlignment = StringAlignment.Center;
                centerrightFormat.Alignment = StringAlignment.Far;


                Font houseFont = new Font("Times New Roman", 9);
                Font planetFont = new Font("Times New Roman", 12, FontStyle.Bold);

                string[] Planet_Sht_Names = new string[] { "Su", "Mo", "Ma", "Me", "Ju", "Ve", "Sa", "Ra", "Ke", "Ur", "Ne", "Pl", "Ch", "X", "Y", "Z" };
                string[] Rasi_Sht_Names = new string[] { "Ar", "Ta", "Ge", "Cn", "Le", "Vi", "Li", "Sc", "Sg", "Cp", "Aq", "Pi" };

                House = 13 - Lagna_Sign + 1;
                if (House <= 0)
                    House += 12;
                if (House > 12)
                    House -= 12;




                penOrange.Width = 2;
                objGraphics.FillRectangle(brushBkGnd, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                objGraphics.DrawRectangle(penOrange, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                penOrange.Width = 1;

                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width / 4, chartRect.Top, chartRect.Left + chartRect.Width / 4, chartRect.Bottom);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width / 2, chartRect.Top, chartRect.Left + chartRect.Width / 2, chartRect.Top + chartRect.Height / 4);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width / 2, chartRect.Top + chartRect.Height * 3 / 4, chartRect.Left + chartRect.Width / 2, chartRect.Bottom);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width * 3 / 4, chartRect.Top, chartRect.Left + chartRect.Width * 3 / 4, chartRect.Bottom);
                objGraphics.DrawLine(penOrange, chartRect.Left, chartRect.Top + chartRect.Height / 4, chartRect.Right, chartRect.Top + chartRect.Height / 4);
                objGraphics.DrawLine(penOrange, chartRect.Left, chartRect.Top + chartRect.Height / 2, chartRect.Left + chartRect.Width / 4, chartRect.Top + chartRect.Height / 2);
                objGraphics.DrawLine(penOrange, chartRect.Left + chartRect.Width * 3 / 4, chartRect.Top + chartRect.Height / 2, chartRect.Right, chartRect.Top + chartRect.Height / 2);
                objGraphics.DrawLine(penOrange, chartRect.Left, chartRect.Top + chartRect.Height * 3 / 4, chartRect.Right, chartRect.Top + chartRect.Height * 3 / 4);

                int[] GoodBad = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                int[] House_Planet = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (i = 0; i < 16; i++)
                {
                    House_Planet[i] = Planet_Signs[i] - Lagna_Sign + 1;
                    if (House_Planet[i] < 1) House_Planet[i] += 12;
                }
                bool NewMoon = false;
                if (Planet_Signs[0] == Planet_Signs[1] && Planet_Degrees[1] - Planet_Degrees[0] > 0 && Planet_Degrees[1] - Planet_Degrees[0] <= 15)
                    NewMoon = true;

                int SignSeventh = (Planet_Signs[0] + 6) % 12;
                if (SignSeventh == 0) SignSeventh = 12;

                bool FullMoon = false;
                if (Planet_Signs[1] == SignSeventh && Planet_Degrees[1] - Planet_Degrees[0] >= -10 && Planet_Degrees[1] - Planet_Degrees[0] <= 5)
                    NewMoon = true;




                //change colors of planets in different circumstances
                //Good
                /*
                    * Sun - Aries & Leo
                    * Moon - Taurus and Cancer
                    * Mars - Capricorn
                    * Mercury - Aquarius
                    * Jupiter - Cancer
                    * Venus - Pisces
                    * Saturn - Libra								
                    * Uranus - Virgo and Scorpio								
                    * Neptune - Taurus and Cancer								
                    * Pluto - Aries, Gemini and Leo								
                    * Chiron - Aries and Sagittarius								
                    * Planet X - Aries, Gemini, Virgo, Libra, Sagittarius, Aquarius and Pisces, Capricorn and Cancer .								
                    * Planet Y - Aries and Gemini								
                    * Planet Z - Libra and Pisces	
                    * During New Moon (When Sun and Moon are in same zodiac sign, but degree of Moon is ahead of Sun) can Sun and Moon be given same colour code as exalted or Own house planets. (You can give a colour code when there is a maximum of 15 degree difference. Lets say Sun is in 6'...then till Moon is in 21 degrees it is New Moon)
                    * The Full Moon is when Sun and Moon are in opposite signs. (You can give a colour code with a maximum of 10 degrees Minus and 5 degree Plus. Eg. If Sun is in 13 degree, then Moon from 3-18 degrees can be colour coded)
                    * Whenever Planet Y is is Aries kindly make it Green. (Instead of being in black. Nothing else should change, like red circle in certain conditions etc)
                    * Whenever Planet Z is in Pisces, Kindly make it Green (Instead of being in black. Nothing else should change, like red circle in certain conditions etc)

                    */

                Color Good = Color.Green;
                if (Planet_Signs[0] == 1 || Planet_Signs[0] == 5)//su
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                }
                if (Planet_Signs[1] == 2 || Planet_Signs[1] == 4)//mo
                {
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[1] = 1;
                }
                if (Planet_Signs[2] == 10)//ma
                {
                    fontPlanetBrush[2] = new SolidBrush(Good);
                    GoodBad[2] = 1;
                }
                if (Planet_Signs[3] == 11)//me
                {
                    fontPlanetBrush[3] = new SolidBrush(Good);
                    GoodBad[3] = 1;
                }
                if (Planet_Signs[4] == 4) //Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(Good);
                    GoodBad[4] = 1;
                }
                if (Planet_Signs[5] == 12) //Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(Good);
                    GoodBad[5] = 1;
                }
                if (Planet_Signs[6] == 7) //Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(Good);
                    GoodBad[6] = 1;
                }
                if (Planet_Signs[9] == 6 || Planet_Signs[9] == 8) //Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(Good);
                    GoodBad[9] = 1;
                }
                if (Planet_Signs[10] == 2 || Planet_Signs[10] == 4) //Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Good);
                    GoodBad[10] = 1;
                }
                if (Planet_Signs[11] == 1 || Planet_Signs[11] == 3 || Planet_Signs[11] == 5) //Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Good);
                    GoodBad[11] = 1;
                }
                if (Planet_Signs[12] == 1 || Planet_Signs[12] == 9) //Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Good);
                    GoodBad[12] = 1;
                }
                if (Planet_Signs[13] == 1 || Planet_Signs[13] == 3 || Planet_Signs[13] == 4 || Planet_Signs[13] == 6 || Planet_Signs[13] == 7 || Planet_Signs[13] == 9 || Planet_Signs[13] == 10 || Planet_Signs[13] == 11 || Planet_Signs[13] == 12) //X
                {
                    fontPlanetBrush[13] = new SolidBrush(Good);
                    GoodBad[13] = 1;
                }
                if (Planet_Signs[14] == 1 || Planet_Signs[14] == 3) //Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Good);
                    GoodBad[14] = 1;
                }
                if (Planet_Signs[15] == 7 || Planet_Signs[15] == 12) //Z
                {
                    fontPlanetBrush[15] = new SolidBrush(Good);
                    GoodBad[15] = 1;
                }
                if (NewMoon) // During New Moon (When Sun and Moon are in same zodiac sign, but degree of Moon is ahead of Sun) can Sun and Moon be given same colour code as exalted or Own house planets(You can give a colour code when there is a maximum of 15 degree difference. Lets say Sun is in 6'...then till Moon is in 21 degrees it is New Moon)
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                    GoodBad[1] = 1;
                }
                if (FullMoon)// The Full Moon is when Sun and Moon are in opposite signs. (You can give a colour code with a maximum of 10 degrees Minus and 5 degree Plus. Eg. If Sun is in 13 degree, then Moon from 3-18 degrees can be colour coded)
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                    GoodBad[1] = 1;
                }
                //Bad
                /*
                 * Su - Libra, Aquarius
                 * Moon - Scorpio, Capricorn
                 * Ma - Cancer
                 * Mercury - Leo
                 * Ju - Capricorn
                 * Venus - Virgo
                 * Sa - Aries
                 * When its amavasya, pls mark both Sun and Moon as red (When Sun and Moon are in same rashi but Moon is behind Sun)
                 * Venus & Mars be given the same colours as debilitated planets when they are in conjunction (in same zodiac sign)
                 * Sun & Mercury in conjunction in 6th, 8th and 12th houses (Planets to be coded Red)
                 * Whenever X is placed in Leo it has to be coloured in Red.
                 * Chiron should be mentioned in Red colour whenever it is in Gemini and Libra irrespective of which house it is in. 
                 * Planet Y should be mentioned in Red colour whenever it is in Libra and Sagitarius irrespective of which house it is in. 
                 * Planet Z should be mentioned in Red colour whenever it is in Aries and Virgo, irrespective of which house it is in.
                 * Uranus should be mentioned in Red colour whenever it is in Taurus and Pisces irrespective of which house it is in. 
                 * Neptune should be mentioned in Red colour whenever it is in Scorpio and Capricorn irrespective of which house it is in.
                 * Pluto should be mentioned in Red colour whenever it is in Libra, Sagitarius and Aquarius irrespective of which house it is in. 

                 */
                Color Bad = Color.Red;
                if (Planet_Signs[0] == 7 || Planet_Signs[0] == 11)//su
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                }
                if (Planet_Signs[1] == 8 || Planet_Signs[1] == 10)
                {
                    fontPlanetBrush[1] = new SolidBrush(Bad);
                    GoodBad[1] = -1;
                }
                if (Planet_Signs[2] == 4)//ma
                {
                    fontPlanetBrush[2] = new SolidBrush(Bad);
                    GoodBad[2] = -1;
                }
                if (Planet_Signs[3] == 5) //me
                {
                    fontPlanetBrush[3] = new SolidBrush(Bad);
                    GoodBad[3] = -1;
                }
                if (Planet_Signs[4] == 10)//ju
                {
                    fontPlanetBrush[4] = new SolidBrush(Bad);
                    GoodBad[4] = -1;
                }
                if (Planet_Signs[5] == 6)//ve
                {
                    fontPlanetBrush[5] = new SolidBrush(Bad);
                    GoodBad[5] = -1;
                }
                if (Planet_Signs[6] == 1)//sa
                {
                    fontPlanetBrush[6] = new SolidBrush(Bad);
                    GoodBad[6] = -1;
                }

                if (Planet_Signs[5] == Planet_Signs[2]) // Venus & Mars be given the same colours as debilitated planets when they are in conjunction (in same zodiac sign)
                {
                    fontPlanetBrush[5] = new SolidBrush(Bad);
                    fontPlanetBrush[2] = new SolidBrush(Bad);
                    GoodBad[5] = -1;
                    GoodBad[2] = -1;
                }
                if (Planet_Signs[0] == Planet_Signs[1] && Planet_Degrees[1] <= Planet_Degrees[0]) // During Amavasya (When Sun and Moon are in same zodiac sign but the degree of Moon is lesser than the degree of Sun) can Sun and Moon be given same colour code as debilitated planets?
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    fontPlanetBrush[1] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                    GoodBad[1] = -1;
                }
                // * Sun & Mercury in conjunction in 6th, 8th and 12th houses (Planets to be coded Red)
                if (Planet_Signs[0] == Planet_Signs[3] && (House_Planet[0] == 6 || House_Planet[0] == 8 || House_Planet[0] == 12))
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    fontPlanetBrush[3] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                    GoodBad[3] = -1;
                }
                if (Planet_Signs[13] == 5) //X
                {
                    fontPlanetBrush[13] = new SolidBrush(Bad);
                    GoodBad[13] = -1;
                }
                if (Planet_Signs[12] == 3 || Planet_Signs[12] == 7) //Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Bad);
                    GoodBad[12] = -1;
                }
                if (Planet_Signs[14] == 7 || Planet_Signs[14] == 9)//Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Bad);
                    GoodBad[14] = -1;
                }
                if (Planet_Signs[15] == 1 || Planet_Signs[15] == 6)//Z
                {
                    fontPlanetBrush[15] = new SolidBrush(Bad);
                    GoodBad[15] = -1;
                }
                if (Planet_Signs[9] == 2 || Planet_Signs[9] == 12) //Uraunus
                {
                    fontPlanetBrush[9] = new SolidBrush(Bad);
                    GoodBad[9] = -1;
                }
                if (Planet_Signs[10] == 8 || Planet_Signs[10] == 10) //Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Bad);
                    GoodBad[10] = -1;
                }
                if (Planet_Signs[11] == 7 || Planet_Signs[11] == 9 || Planet_Signs[11] == 11) //Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Bad);
                    GoodBad[11] = -1;
                }

                //Own House (Blue)
                /*
                 * Su - Nill
                 * Moon - Nill
                 * Ma - Aries
                 * Mercury - Gemini
                 * Ju - Sagitarius
                 * Venus - Libra
                 * Sa - Capricorn
                 * Uranus - Aquarius
                 * Neptune - Pisces
                 * Pluto - Scorpio
                 * Chiron - Cancer
                 * X - Taurus
                 * Y - Virgo
                 * Z- Leo
                 */

                Color OwnHouse = Color.Blue;
                if (Planet_Signs[2] == 1)//Mars
                {
                    fontPlanetBrush[2] = new SolidBrush(OwnHouse);
                    GoodBad[2] = 2;
                }
                if (Planet_Signs[3] == 3)// Mercury
                {
                    fontPlanetBrush[3] = new SolidBrush(OwnHouse);
                    GoodBad[3] = 2;
                }
                if (Planet_Signs[4] == 9)// Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(OwnHouse);
                    GoodBad[4] = 2;
                }
                if (Planet_Signs[5] == 7)// Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(OwnHouse);
                    GoodBad[5] = 2;
                }
                if (Planet_Signs[6] == 10)// Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(OwnHouse);
                    GoodBad[6] = 2;
                }
                if (Planet_Signs[9] == 11)// Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(OwnHouse);
                    GoodBad[9] = 2;
                }
                if (Planet_Signs[10] == 12)// Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(OwnHouse);
                    GoodBad[10] = 2;
                }
                if (Planet_Signs[11] == 8)// Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(OwnHouse);
                    GoodBad[11] = 2;
                }
                if (Planet_Signs[12] == 4)// Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(OwnHouse);
                    GoodBad[12] = 2;
                }
                if (Planet_Signs[13] == 2)// X
                {
                    fontPlanetBrush[13] = new SolidBrush(OwnHouse);
                    GoodBad[13] = 2;
                }
                if (Planet_Signs[14] == 6)// Y
                {
                    fontPlanetBrush[3] = new SolidBrush(OwnHouse);
                    GoodBad[14] = 2;
                }
                if (Planet_Signs[15] == 5)// z
                {
                    fontPlanetBrush[15] = new SolidBrush(OwnHouse);
                    GoodBad[15] = 2;
                }

                //Friendly (DarkCyan)
                /*
                 * Su - Nill
                 * Moon - Nill
                 * Ma - Libra
                 * Mercury - Sagitarius
                 * Ju - Gemini
                 * Venus - Aries
                 * Sa - Cancer
                 * Uranus - Leo
                 * Neptune - Virgo
                 * Pluto - Taurus
                 * Chiron - Capricorn
                 * X - Scorpio
                 * Y - Pisces
                 * Z- Aquarius
                 */

                Color Friendly = Color.DarkCyan;
                if (Planet_Signs[2] == 7)//Mars
                {
                    fontPlanetBrush[2] = new SolidBrush(Friendly);
                    GoodBad[0] = 3;
                }
                if (Planet_Signs[3] == 9)// Mercury
                {
                    fontPlanetBrush[3] = new SolidBrush(Friendly);
                    GoodBad[3] = 3;
                }
                if (Planet_Signs[4] == 3)// Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(Friendly);
                    GoodBad[4] = 3;
                }
                if (Planet_Signs[5] == 1)// Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(Friendly);
                    GoodBad[5] = 3;
                }
                if (Planet_Signs[6] == 4)// Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(Friendly);
                    GoodBad[6] = 3;
                }
                if (Planet_Signs[9] == 5)// Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(Friendly);
                    GoodBad[9] = 3;
                }
                if (Planet_Signs[10] == 6)// Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Friendly);
                    GoodBad[10] = 3;
                }
                if (Planet_Signs[11] == 2)// Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Friendly);
                    GoodBad[11] = 3;
                }
                if (Planet_Signs[12] == 10)// Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Friendly);
                    GoodBad[12] = 3;
                }
                if (Planet_Signs[13] == 8)// X
                {
                    fontPlanetBrush[13] = new SolidBrush(Friendly);
                    GoodBad[13] = 3;
                }
                if (Planet_Signs[14] == 12)// Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Friendly);
                    GoodBad[14] = 3;
                }
                if (Planet_Signs[15] == 11)// z
                {
                    fontPlanetBrush[15] = new SolidBrush(Friendly);
                    GoodBad[15] = 3;
                }

                /* CIRCLE in RED the following in addition to a "GREEN" planet being in 3rd, 6th, 8th, 12th houses....
                    Aries Ascendant – Z in Pisces, Y in any house, Mercury in Aquarius, Z in Libra, Pluto in Leo, Saturn in Libra
                    Taurus Ascendant – Y in Aries, NewMoon in any house, FullMoon in any house, Ve in any sign, Venus in Pisces, Pluto in Scorpio, Pluto in Leo, Uranus in Scorpio, Mars in Capricorn, Sun in Sagittarius, Jupiter in Taurus, X in Cancer, Chiron in Aries. 
                    Gemini Ascendant – Z in Pisces, Saturn in any house, Sun in Aries, Jupiter in Sagittarius, Jupiter in Cancer, Saturn in Libra, X in Gemini, X in Cancer, X in Virgo, X in Libra, X in Sagittarius, X in Capricorn, X in Aquarius, X in Pisces, X in Aries, Venus in Capricorn, Z in Leo, Z in Libra, Mars in Sagittarius.
                    Cancer Ascendant – Y in Aries, Me in any house, Jupiter in Cancer,  Saturn in Capricorn, Saturn in Libra, Uranus in Scorpio, Mars in Capricorn, X in Capricorn.
                    Leo Ascendant – Z in Pisces, NewMoon in any house, FullMoon in any house, Uranus in Aquarius, Uranus in Scorpio, X in Cancer, X in Aquarius, X in Capricorn, Mercury in Aquarius, Moon in Taurus, Chiron in Aries.
                    Virgo Ascendant – Y in Aries, Z in Pisces, NewMoon in any house, FullMoon in any house, Venus in Pisces, Mars in Capricorn, Mars in all houses, X in Pisces, Z in Libra, Chiron in Aries
                    Libra Ascendant – Z in Pisces, Y in any house, Jupiter in Cancer, Neptune in Cancer, Mars in Aries, Mars in Capricorn, Chiron in Aries, X in Gemini, X in Cancer, X in Libra, X in Capricorn, X in Aquarius, X in Aries, Sun in Aries, Y in Gemini.  
                    Scorpio Ascendant – Y in Aries, Z in Pisces, Me in any house, Ve in any sign, Chiron in Aries, X in Taurus, X in Cancer, X in Virgo, X in Sagittarius, X in Capricorn, X in Aquarius, Mercury in Aquarius, X in Pisces, Moon in Taurus, Venus in Pisces, Mercury In Scorpio, Venus in all houses, Mars in all houses. 
                    Sagittarius Ascendant – Y in Aries, NewMoon in any house, FullMoon in any house, Ma in Capricorn, Chiron in Aries, X in Gemini, X in Cancer, X in Virgo, X in Libra, X in Sagittarius, X in Capricorn, X in Pisces, X in Aries, Y in Gemini, Pluto in Leo, Chiron in Sagittarius.
                    Capricorn Ascendant – Z in Pisces, NewMoon in any house, FullMoon in any house, Me in any house, X in Virgo, Neptune in Cancer, Mercury in Aquarius, Moon in Cancer, Moon in Taurus, Sun in Aries, Sun in Capricorn, Mercury in Capricorn, Jupiter in Cancer, Chiron in Aries, X in Cancer, Z in Libra. 
                    Aquarius Ascendant - Z in Pisces, NewMoon in any house, FullMoon in any house, Y in any house, Moon in Taurus, Sun in Leo, Z in Leo, Z in Libra, Y in Gemini, Pluto in Leo, Saturn in Libra, Chiron in Sagittarius, Chiron in Aries, X in Cancer, X in Capricorn.
                    Pisces Ascendant – NewMoon in any house, FullMoon in any house, Ve in any sign, X in Gemini, X in Cancer, X in Virgo, X in Sagittarius, X in Capricorn, X in Aries, Moon in Taurus, Sun in Aries, Y in Virgo, Y in Gemini,  Venus in Pisces, Venus in all houses, Uranus in Scorpio,
                    Sun placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Sat placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Jup placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Venus in the ascendant shouldn’t be circled in Red, except for Taurus, Scorpio and Pisces ascendants.
                    Venus in the 7th house shouldn’t be circled in Red except Aries, Taurus and Virgo ascendants.
                    When Sun and Mercury are in conjunction in the 5th house, they should be circled in Red.
                 * For Sagittarius Asdt when Mercury is in eighth it needs to be circled in RED
                 * For Gemini Asdts When Jupiter is in 12th, (or 6th or 8th)they need to be circled in RED.
                 * Mars or Venus in 1st, 3rd, 6th, 7th 8th and 12th (Planets to be circled Red)
                 * When Chiron is in Cancer or Sagittarius and in the 3rd, 5th, 6th, 7th, 8th and 12th house for any ascendant kindly circle it in Red.
                 * 
                 * Pluto during the years 1957 (1st Jan) to 1961 (31st Dec) should be circled in Red.
                //When a planet is already in red, it shouldn't be circled in red.
                 * */
                int[] RedCircle_eachLagna = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                if (Lagna_Sign == 1)
                {
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                }
                else if (Lagna_Sign == 2)
                {
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[11] == 8)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[0] == 9)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 2)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;

                    RedCircle_eachLagna[5] = -1;//Ve in any sign
                }
                else if (Lagna_Sign == 3)
                {
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 9)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[5] == 10)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[15] == 5)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[2] == 9)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[6] = -1;//Sa in any house

                    if (House_Planet[4] == 12 || House_Planet[4] == 6 || House_Planet[4] == 8)
                        RedCircle_eachLagna[4] = -1;

                }
                else if (Lagna_Sign == 4)
                {
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[6] == 10)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[3] = -1;//Me in any house
                }
                else if (Lagna_Sign == 5)
                {

                    if (Planet_Signs[9] == 11)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 6)
                {
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    //if (Planet_Signs[2] == 10)
                    //    RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[2] = -1;//Ma in all houses
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 7)
                {
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[10] == 4)
                        RedCircle_eachLagna[10] = -1;
                    if (Planet_Signs[2] == 1)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                }
                else if (Lagna_Sign == 8)
                {
                    if (Planet_Signs[13] == 2)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[3] == 8)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[2] = -1;//Ma in all houses
                    RedCircle_eachLagna[3] = -1;//Me in any house
                    RedCircle_eachLagna[5] = -1;//Ve in any sign
                }
                else if (Lagna_Sign == 9)
                {
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[12] == 9)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    if (House_Planet[3] == 8)
                        RedCircle_eachLagna[3] = -1;
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;

                }
                else if (Lagna_Sign == 10)
                {
                    if (Planet_Signs[10] == 4)
                        RedCircle_eachLagna[10] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[1] == 4)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[0] == 10)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[3] == 10)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[3] = -1;//Me in any house
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 11)
                {
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 5)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[15] == 5)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[12] == 9)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 12)
                {
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[14] == 6)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;

                    RedCircle_eachLagna[5] = -1;//ve in all houses
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                //Sun placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[0] == 6 || House_Planet[0] == 8 || House_Planet[0] == 12)
                    RedCircle_eachLagna[0] = -1;

                //Saturn placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[6] == 6 || House_Planet[6] == 8 || House_Planet[6] == 12)
                    RedCircle_eachLagna[6] = -1;

                //Jupiter placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[4] == 6 || House_Planet[4] == 8 || House_Planet[4] == 12)
                    RedCircle_eachLagna[4] = -1;

                // * Mars or Venus in 1st, 3rd, 6th, 7th 8th and 12th (Planets to be circled Red)
                if (House_Planet[2] == 1 || House_Planet[2] == 3 || House_Planet[2] == 6 || House_Planet[2] == 7 || House_Planet[2] == 8 || House_Planet[2] == 12)
                    RedCircle_eachLagna[2] = -1;
                if (House_Planet[5] == 1 || House_Planet[5] == 3 || House_Planet[5] == 6 || House_Planet[5] == 7 || House_Planet[5] == 8 || House_Planet[5] == 12)
                    RedCircle_eachLagna[5] = -1;

                // * When Chiron is in Cancer or Sagittarius and in the 3rd, 5th, 6th, 7th, 8th and 12th house for any ascendant kindly circle it in Red.
                if ((Planet_Signs[12] == 4 || Planet_Signs[12] == 9) && (House_Planet[12] == 3 || House_Planet[12] == 5 || House_Planet[12] == 6 || House_Planet[12] == 7 || House_Planet[12] == 8 || House_Planet[12] == 12))
                    RedCircle_eachLagna[12] = -1;

                // When the full Moon falls in 3rd,5th, 6th 7th, 8th and 12th houses, it should be in circled in Red.
                if (FullMoon && (House_Planet[1] == 3 || House_Planet[1] == 5 || House_Planet[1] == 6 || House_Planet[1] == 7 || House_Planet[1] == 8 || House_Planet[1] == 12))
                    RedCircle_eachLagna[1] = -1;

                // When the new Moon falls in 3rd,5th, 6th 7th, 8th and 12th houses, it should be in circled in Red.
                if (NewMoon && (House_Planet[1] == 3 || House_Planet[1] == 5 || House_Planet[1] == 6 || House_Planet[1] == 7 || House_Planet[1] == 8 || House_Planet[1] == 12))
                    RedCircle_eachLagna[1] = -1;

                //Venus in the ascendant shouldn’t be circled in Red, except for Taurus, Scorpio and Pisces ascendants.
                if (House_Planet[5] == 1 && !(Planet_Signs[5] == 2 || Planet_Signs[5] == 8 || Planet_Signs[5] == 12))
                    RedCircle_eachLagna[5] = -1;
                //Venus in the 7th house shouldn’t be circled in Red except Aries, Taurus and Virgo ascendants.
                if (House_Planet[5] == 7 && !(Planet_Signs[5] == 7 || Planet_Signs[5] == 8 || Planet_Signs[5] == 12))//7th house is libra, scorpio or pisces for ascendents aries, taurus and virgo
                    RedCircle_eachLagna[5] = -1;

                //When Sun and Mercury are in conjunction in the 5th house, they should be circled in Red.
                if (House_Planet[0] == House_Planet[3] && House_Planet[0] == 5)
                {
                    RedCircle_eachLagna[0] = -1;
                    RedCircle_eachLagna[3] = -1;
                }

                // Pluto during the years 1957 (1st Jan) to 1961 (31st Dec) should be circled in Red.
                if (birthJulDay >= 2435839.500000 && birthJulDay <= 2437664.500000)
                    RedCircle_eachLagna[11] = -1;

                ///************************************************************
                //When a planet is already in red, it shouldn't be circled in red.
                for (i = 0; i < 16; i++)
                    if (GoodBad[i] == -1) RedCircle_eachLagna[i] = 0;
                ///************************************************************

                for (count = 1; count <= 12; House++, count++)
                {
                    if (House == 13)
                        House = 1;
                    Planet_String = "";
                    Outer_String = "";

                    for (i = 0; i < 9; i++)
                    {
                        if (Planet_Signs[i] == count)
                        {
                            for (j = 0; j < Planet_String.Length; j++)
                            {
                                if (Planet_String == "")
                                    break;
                                a = String.Format("{0}", Planet_String[j]);
                                iPlanet = Convert.ToInt32(a, 10);
                                //iPlanet = Convert.ToInt32(Planet_String[j]);

                                if (Planet_Degrees[iPlanet] > Planet_Degrees[i])
                                    break;
                            }
                            a = string.Format("{0}", i);
                            Planet_String = Planet_String.Insert(j, a);
                        }
                    }

//                    put ur ne pl, and asteroids in the outer_string
                    for (i = 9; i < 16; i++)
                    {
                        if (Planet_Signs[i] == count)
                        {
                            for (j = 0; j < Outer_String.Length; j++)
                            {
                                if (Outer_String == "") break;
                                a = String.Format("{0}", Outer_String[j] - 'a');
                                iPlanet = Convert.ToInt32(a, 10);

                                if (Planet_Degrees[iPlanet] > Planet_Degrees[i])
                                    break;
                            }
                            a = string.Format("{0}", Convert.ToChar(i + 97));
                            Outer_String = Outer_String.Insert(j, a);
                        }
                    }


                    //////switch statement which calculates the 4 corners of the house concerned
                    //////and calculates the rectangle for putting in the Rasi no.
                    Sign = count;
                    if (Sign > 12)
                        Sign -= 12;
                    switch (Sign)
                    {
                        case 1:
                            x = chartRect.Left + chartRect.Width / 4;
                            X = chartRect.Left + chartRect.Width / 2;
                            y = chartRect.Top;
                            Y = chartRect.Top + chartRect.Height / 4;
                            break;
                        case 2:
                            x = chartRect.Left + chartRect.Width / 2;
                            X = chartRect.Left + chartRect.Width * 3 / 4;
                            y = chartRect.Top;
                            Y = chartRect.Top + chartRect.Height / 4;
                            break;
                        case 3:
                            x = chartRect.Left + chartRect.Width * 3 / 4;
                            X = chartRect.Right;
                            y = chartRect.Top;
                            Y = chartRect.Top + chartRect.Height / 4;
                            break;
                        case 4:
                            x = chartRect.Left + chartRect.Width * 3 / 4;
                            X = chartRect.Right;
                            y = chartRect.Top + chartRect.Height / 4;
                            Y = chartRect.Top + chartRect.Height / 2;
                            break;
                        case 5:
                            x = chartRect.Left + chartRect.Width * 3 / 4;
                            X = chartRect.Right;
                            y = chartRect.Top + chartRect.Height / 2;
                            Y = chartRect.Top + chartRect.Height * 3 / 4;
                            break;
                        case 6:
                            x = chartRect.Left + chartRect.Width * 3 / 4;
                            X = chartRect.Right;
                            y = chartRect.Top + chartRect.Height * 3 / 4;
                            Y = chartRect.Bottom;
                            break;
                        case 7:
                            x = chartRect.Left + chartRect.Width / 2;
                            X = chartRect.Left + chartRect.Width * 3 / 4;
                            y = chartRect.Top + chartRect.Height * 3 / 4;
                            Y = chartRect.Bottom;
                            break;
                        case 8:
                            x = chartRect.Left + chartRect.Width / 4;
                            X = chartRect.Left + chartRect.Width / 2;
                            y = chartRect.Top + chartRect.Height * 3 / 4;
                            Y = chartRect.Bottom;
                            break;
                        case 9:
                            x = chartRect.Left;
                            X = chartRect.Left + chartRect.Width / 4;
                            y = chartRect.Top + chartRect.Height * 3 / 4;
                            Y = chartRect.Bottom;
                            break;
                        case 10:
                            x = chartRect.Left;
                            X = chartRect.Left + chartRect.Width / 4;
                            y = chartRect.Top + chartRect.Height / 2;
                            Y = chartRect.Top + chartRect.Height * 3 / 4;
                            break;
                        case 11:
                            x = chartRect.Left;
                            X = chartRect.Left + chartRect.Width / 4;
                            y = chartRect.Top + chartRect.Height / 4;
                            Y = chartRect.Top + chartRect.Height / 2;
                            break;
                        case 12:
                            x = chartRect.Left;
                            X = chartRect.Left + chartRect.Width / 4;
                            y = chartRect.Top;
                            Y = chartRect.Top + chartRect.Height / 4;
                            break;
                    }

                    rectH = new RectangleF(x, y, (X - x), (Y - y));
                    a = string.Format("{0}", House);
                    switch (Sign)
                    {
                        case 2:
                        case 10:
                        case 12: objGraphics.DrawString(Rasi_Sht_Names[count - 1], houseFont, fontRasiBrush, rectH, topleftFormat); objGraphics.DrawString(a, houseFont, fontHouseBrush, rectH, bottomrightFormat); break;
                        case 1:
                        case 3:
                        case 5: objGraphics.DrawString(Rasi_Sht_Names[count - 1], houseFont, fontRasiBrush, rectH, toprightFormat); objGraphics.DrawString(a, houseFont, fontHouseBrush, rectH, bottomleftFormat); break;
                        case 4:
                        case 6:
                        case 8: objGraphics.DrawString(Rasi_Sht_Names[count - 1], houseFont, fontRasiBrush, rectH, bottomrightFormat); objGraphics.DrawString(a, houseFont, fontHouseBrush, rectH, topleftFormat); break;
                        case 7:
                        case 9:
                        case 11: objGraphics.DrawString(Rasi_Sht_Names[count - 1], houseFont, fontRasiBrush, rectH, bottomleftFormat); objGraphics.DrawString(a, houseFont, fontHouseBrush, rectH, toprightFormat); break;
                        default: break;
                    }

                    if (Sign == Lagna_Sign)
                    {
                        objGraphics.DrawLine(penOrange, x, y + (Y - y) / 2, x + (Y - y) / 2, Y);
                        objGraphics.DrawLine(penOrange, x, y + (Y - y) / 2 + 4, x + (Y - y) / 2 - 4, Y);
                    }

                    xP = x;
                    yP = y;
                    l = Planet_String.Length;
                    for (i = 0; i < l; i++)
                    {
                        rectP = new RectangleF(xP, yP, (X - x) / l + 5, (Y - y) / l);
                        if (rectP.Left < rectH.Left)
                            rectP.X = rectH.X;
                        if (rectP.Top < rectH.Top)
                            rectP.Y = rectH.Y;
                        if (rectP.Right > rectH.Right)
                            rectP.Width -= rectP.Right - rectH.Right;
                        if (rectP.Bottom > rectH.Bottom)
                            rectP.Height -= rectP.Bottom - rectH.Bottom;
                        xP = xP + (X - x) / l;
                        yP = yP + (Y - y) / l;
                        a = String.Format("{0}", Planet_String[i]);
                        iPlanet = Convert.ToInt32(a, 10);
                        a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                        rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);
                        if (((House == 3 || House == 6 || House == 8 || House == 12 || House == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                            objGraphics.DrawEllipse(penRed, rectP);
                        objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);
                    
                    }
                    l = Outer_String.Length;
                    if (l > 0)
                    {
                        rectH = new RectangleF(x + (X - x) * 5 / 12, y, (X - x) * 7 / 12, (Y - y) * 7 / 12);
                        wd = rectH.Width/l;
                        ht = rectH.Height/l;

                        for (i = 0; i < Outer_String.Length; i++)
                        {
                            rectP = new RectangleF(rectH.Left - 5 + wd * i, rectH.Top + ht * i, wd, ht);

                            iPlanet = Convert.ToInt32(String.Format("{0}", Outer_String[i] - 'a'), 10);
                            a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                            rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);
                            if (((House == 3 || House == 6 || House == 8 || House == 12 || House == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                                objGraphics.DrawEllipse(penRed, rectP);
                            objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }
        }

        public static void DrawChart_Round(Graphics objGraphics, RectangleF chartRect, int Lagna_Sign, int[] Planet_Signs, double[] Planet_Degrees, double birthJulDay)
        {
            try
            {
                Pen penOrange = new Pen(Color.FromArgb(245, 167, 124));
                Pen penRed = new Pen(Color.FromArgb(255, 0, 0), 2);
                SolidBrush brushBkGnd = new SolidBrush(Color.FromArgb(255, 255, 255));
                SolidBrush brushWhite = new SolidBrush(Color.White);
                SolidBrush fontRasiBrush = new SolidBrush(Color.LightSalmon);
                SolidBrush fontHouseBrush = new SolidBrush(Color.FromArgb(66, 75, 17));
                SolidBrush[] fontPlanetBrush = new SolidBrush[]{
                    new SolidBrush(Color.Black),//.FromArgb(181, 38, 24)),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black),
                    new SolidBrush(Color.Black)};

                StringFormat centerFormat = new StringFormat();
                centerFormat.Trimming = StringTrimming.None;
                centerFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerFormat.LineAlignment = StringAlignment.Center;
                centerFormat.Alignment = StringAlignment.Center;

                StringFormat lowerleftFormat = new StringFormat();
                lowerleftFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                lowerleftFormat.LineAlignment = StringAlignment.Far;
                lowerleftFormat.Alignment = StringAlignment.Near;

                StringFormat upperrightFormat = new StringFormat();
                upperrightFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                upperrightFormat.LineAlignment = StringAlignment.Near;
                upperrightFormat.Alignment = StringAlignment.Far;


                Font houseFont = new Font("Times New Roman", 9);
                Font planetFont = new Font("Times New Roman", 12, FontStyle.Bold);

                string[] Planet_Sht_Names = new string[] { "Su", "Mo", "Ma", "Me", "Ju", "Ve", "Sa", "Ra", "Ke", "Ur", "Ne", "Pl", "Ch", "X", "Y", "Z" };
                string[] Rasi_Sht_Names = new string[] { "Ar", "Ta", "Ge", "Cn", "Le", "Vi", "Li", "Sc", "Sg", "Cp", "Aq", "Pi" };

                RectangleF chartRectSmall = chartRect;

                if (chartRect.Width > chartRect.Height)
                {
                    chartRect.Width = chartRect.Height;
                    chartRect.Offset(chartRectSmall.Width / 2 - chartRectSmall.Height / 2, 0);
                }
                else
                {
                    chartRect.Height = chartRect.Width;
                    chartRect.Offset(chartRectSmall.Height / 2 - chartRectSmall.Width / 2, 0);
                }
                chartRectSmall = chartRect;
                chartRectSmall.Width -= chartRect.Width / 5;
                chartRectSmall.Height -= chartRect.Height / 5;
                chartRectSmall.Offset(chartRect.Width / 10, chartRect.Height / 10);



                penOrange.Width = 2;
                objGraphics.FillEllipse(brushBkGnd, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                objGraphics.DrawEllipse(penOrange, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                penOrange.Width = 1;
                objGraphics.DrawEllipse(penOrange, chartRectSmall.Left, chartRectSmall.Top, chartRectSmall.Width, chartRectSmall.Height);


                objGraphics.DrawLine(penOrange, Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(15 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(15 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(195 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(195 * 22.0 / 7.0 / 180)));
                objGraphics.DrawLine(penOrange, Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(45 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(45 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(225 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(225 * 22.0 / 7.0 / 180)));
                objGraphics.DrawLine(penOrange, Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(75 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(75 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(255 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(255 * 22.0 / 7.0 / 180)));
                objGraphics.DrawLine(penOrange, Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(105 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(105 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(285 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(285 * 22.0 / 7.0 / 180)));
                objGraphics.DrawLine(penOrange, Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(135 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(135 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(315 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(315 * 22.0 / 7.0 / 180)));
                objGraphics.DrawLine(penOrange, Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(165 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(165 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + chartRect.Width / 2 * Math.Cos(345 * 22.0 / 7.0 / 180)), Convert.ToSingle(chartRect.Top + chartRect.Width / 2 + chartRect.Width / 2 * Math.Sin(345 * 22.0 / 7.0 / 180)));

                int[] GoodBad = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                int[] House_Planet = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int i;
                for (i = 0; i < 16; i++)
                {
                    House_Planet[i] = Planet_Signs[i] - Lagna_Sign + 1;
                    if (House_Planet[i] < 1) House_Planet[i] += 12;
                }
                bool NewMoon = false;
                if (Planet_Signs[0] == Planet_Signs[1] && Planet_Degrees[1] - Planet_Degrees[0] > 0 && Planet_Degrees[1] - Planet_Degrees[0] <= 15)
                    NewMoon = true;

                int SignSeventh = (Planet_Signs[0] + 6) % 12;
                if (SignSeventh == 0) SignSeventh = 12;

                bool FullMoon = false;
                if (Planet_Signs[1] == SignSeventh && Planet_Degrees[1] - Planet_Degrees[0] >= -10 && Planet_Degrees[1] - Planet_Degrees[0] <= 5)
                    NewMoon = true;




                //change colors of planets in different circumstances
                //Good
                /*
                    * Sun - Aries & Leo
                    * Moon - Taurus and Cancer
                    * Mars - Capricorn
                    * Mercury - Aquarius
                    * Jupiter - Cancer
                    * Venus - Pisces
                    * Saturn - Libra								
                    * Uranus - Virgo and Scorpio								
                    * Neptune - Taurus and Cancer								
                    * Pluto - Aries, Gemini and Leo								
                    * Chiron - Aries and Sagittarius								
                    * Planet X - Aries, Gemini, Virgo, Libra, Sagittarius, Aquarius and Pisces, Capricorn and Cancer .								
                    * Planet Y - Aries and Gemini								
                    * Planet Z - Libra and Pisces	
                    * During New Moon (When Sun and Moon are in same zodiac sign, but degree of Moon is ahead of Sun) can Sun and Moon be given same colour code as exalted or Own house planets. (You can give a colour code when there is a maximum of 15 degree difference. Lets say Sun is in 6'...then till Moon is in 21 degrees it is New Moon)
                    * The Full Moon is when Sun and Moon are in opposite signs. (You can give a colour code with a maximum of 10 degrees Minus and 5 degree Plus. Eg. If Sun is in 13 degree, then Moon from 3-18 degrees can be colour coded)
                    * Whenever Planet Y is is Aries kindly make it Green. (Instead of being in black. Nothing else should change, like red circle in certain conditions etc)
                    * Whenever Planet Z is in Pisces, Kindly make it Green (Instead of being in black. Nothing else should change, like red circle in certain conditions etc)

                    */

                Color Good = Color.Green;
                if (Planet_Signs[0] == 1 || Planet_Signs[0] == 5)//su
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                }
                if (Planet_Signs[1] == 2 || Planet_Signs[1] == 4)//mo
                {
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[1] = 1;
                }
                if (Planet_Signs[2] == 10)//ma
                {
                    fontPlanetBrush[2] = new SolidBrush(Good);
                    GoodBad[2] = 1;
                }
                if (Planet_Signs[3] == 11)//me
                {
                    fontPlanetBrush[3] = new SolidBrush(Good);
                    GoodBad[3] = 1;
                }
                if (Planet_Signs[4] == 4) //Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(Good);
                    GoodBad[4] = 1;
                }
                if (Planet_Signs[5] == 12) //Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(Good);
                    GoodBad[5] = 1;
                }
                if (Planet_Signs[6] == 7) //Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(Good);
                    GoodBad[6] = 1;
                }
                if (Planet_Signs[9] == 6 || Planet_Signs[9] == 8) //Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(Good);
                    GoodBad[9] = 1;
                }
                if (Planet_Signs[10] == 2 || Planet_Signs[10] == 4) //Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Good);
                    GoodBad[10] = 1;
                }
                if (Planet_Signs[11] == 1 || Planet_Signs[11] == 3 || Planet_Signs[11] == 5) //Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Good);
                    GoodBad[11] = 1;
                }
                if (Planet_Signs[12] == 1 || Planet_Signs[12] == 9) //Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Good);
                    GoodBad[12] = 1;
                }
                if (Planet_Signs[13] == 1 || Planet_Signs[13] == 3 || Planet_Signs[13] == 4 || Planet_Signs[13] == 6 || Planet_Signs[13] == 7 || Planet_Signs[13] == 9 || Planet_Signs[13] == 10 || Planet_Signs[13] == 11 || Planet_Signs[13] == 12) //X
                {
                    fontPlanetBrush[13] = new SolidBrush(Good);
                    GoodBad[13] = 1;
                }
                if (Planet_Signs[14] == 1 || Planet_Signs[14] == 3) //Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Good);
                    GoodBad[14] = 1;
                }
                if (Planet_Signs[15] == 7 || Planet_Signs[15] == 12) //Z
                {
                    fontPlanetBrush[15] = new SolidBrush(Good);
                    GoodBad[15] = 1;
                }
                if (NewMoon) // During New Moon (When Sun and Moon are in same zodiac sign, but degree of Moon is ahead of Sun) can Sun and Moon be given same colour code as exalted or Own house planets(You can give a colour code when there is a maximum of 15 degree difference. Lets say Sun is in 6'...then till Moon is in 21 degrees it is New Moon)
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                    GoodBad[1] = 1;
                }
                if (FullMoon)// The Full Moon is when Sun and Moon are in opposite signs. (You can give a colour code with a maximum of 10 degrees Minus and 5 degree Plus. Eg. If Sun is in 13 degree, then Moon from 3-18 degrees can be colour coded)
                {
                    fontPlanetBrush[0] = new SolidBrush(Good);
                    fontPlanetBrush[1] = new SolidBrush(Good);
                    GoodBad[0] = 1;
                    GoodBad[1] = 1;
                }
                //Bad
                /*
                 * Su - Libra, Aquarius
                 * Moon - Scorpio, Capricorn
                 * Ma - Cancer
                 * Mercury - Leo
                 * Ju - Capricorn
                 * Venus - Virgo
                 * Sa - Aries
                 * When its amavasya, pls mark both Sun and Moon as red (When Sun and Moon are in same rashi but Moon is behind Sun)
                 * Venus & Mars be given the same colours as debilitated planets when they are in conjunction (in same zodiac sign)
                 * Sun & Mercury in conjunction in 6th, 8th and 12th houses (Planets to be coded Red)
                 * Whenever X is placed in Leo it has to be coloured in Red.
                 * Chiron should be mentioned in Red colour whenever it is in Gemini and Libra irrespective of which house it is in. 
                 * Planet Y should be mentioned in Red colour whenever it is in Libra and Sagitarius irrespective of which house it is in. 
                 * Planet Z should be mentioned in Red colour whenever it is in Aries and Virgo, irrespective of which house it is in.
                 * Uranus should be mentioned in Red colour whenever it is in Taurus and Pisces irrespective of which house it is in. 
                 * Neptune should be mentioned in Red colour whenever it is in Scorpio and Capricorn irrespective of which house it is in.
                 * Pluto should be mentioned in Red colour whenever it is in Libra, Sagitarius and Aquarius irrespective of which house it is in. 

                 */
                Color Bad = Color.Red;
                if (Planet_Signs[0] == 7 || Planet_Signs[0] == 11)//su
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                }
                if (Planet_Signs[1] == 8 || Planet_Signs[1] == 10)
                {
                    fontPlanetBrush[1] = new SolidBrush(Bad);
                    GoodBad[1] = -1;
                }
                if (Planet_Signs[2] == 4)//ma
                {
                    fontPlanetBrush[2] = new SolidBrush(Bad);
                    GoodBad[2] = -1;
                }
                if (Planet_Signs[3] == 5) //me
                {
                    fontPlanetBrush[3] = new SolidBrush(Bad);
                    GoodBad[3] = -1;
                }
                if (Planet_Signs[4] == 10)//ju
                {
                    fontPlanetBrush[4] = new SolidBrush(Bad);
                    GoodBad[4] = -1;
                }
                if (Planet_Signs[5] == 6)//ve
                {
                    fontPlanetBrush[5] = new SolidBrush(Bad);
                    GoodBad[5] = -1;
                }
                if (Planet_Signs[6] == 1)//sa
                {
                    fontPlanetBrush[6] = new SolidBrush(Bad);
                    GoodBad[6] = -1;
                }

                if (Planet_Signs[5] == Planet_Signs[2]) // Venus & Mars be given the same colours as debilitated planets when they are in conjunction (in same zodiac sign)
                {
                    fontPlanetBrush[5] = new SolidBrush(Bad);
                    fontPlanetBrush[2] = new SolidBrush(Bad);
                    GoodBad[5] = -1;
                    GoodBad[2] = -1;
                }
                if (Planet_Signs[0] == Planet_Signs[1] && Planet_Degrees[1] <= Planet_Degrees[0]) // During Amavasya (When Sun and Moon are in same zodiac sign but the degree of Moon is lesser than the degree of Sun) can Sun and Moon be given same colour code as debilitated planets?
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    fontPlanetBrush[1] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                    GoodBad[1] = -1;
                }
                // * Sun & Mercury in conjunction in 6th, 8th and 12th houses (Planets to be coded Red)
                if (Planet_Signs[0] == Planet_Signs[3] && (House_Planet[0] == 6 || House_Planet[0] == 8 || House_Planet[0] == 12))
                {
                    fontPlanetBrush[0] = new SolidBrush(Bad);
                    fontPlanetBrush[3] = new SolidBrush(Bad);
                    GoodBad[0] = -1;
                    GoodBad[3] = -1;
                }
                if (Planet_Signs[13] == 5) //X
                {
                    fontPlanetBrush[13] = new SolidBrush(Bad);
                    GoodBad[13] = -1;
                }
                if (Planet_Signs[12] == 3 || Planet_Signs[12] == 7) //Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Bad);
                    GoodBad[12] = -1;
                }
                if (Planet_Signs[14] == 7 || Planet_Signs[14] == 9)//Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Bad);
                    GoodBad[14] = -1;
                }
                if (Planet_Signs[15] == 1 || Planet_Signs[15] == 6)//Z
                {
                    fontPlanetBrush[15] = new SolidBrush(Bad);
                    GoodBad[15] = -1;
                }
                if (Planet_Signs[9] == 2 || Planet_Signs[9] == 12) //Uraunus
                {
                    fontPlanetBrush[9] = new SolidBrush(Bad);
                    GoodBad[9] = -1;
                }
                if (Planet_Signs[10] == 8 || Planet_Signs[10] == 10) //Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Bad);
                    GoodBad[10] = -1;
                }
                if (Planet_Signs[11] == 7 || Planet_Signs[11] == 9 || Planet_Signs[11] == 11) //Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Bad);
                    GoodBad[11] = -1;
                }

                //Own House (Blue)
                /*
                 * Su - Nill
                 * Moon - Nill
                 * Ma - Aries
                 * Mercury - Gemini
                 * Ju - Sagitarius
                 * Venus - Libra
                 * Sa - Capricorn
                 * Uranus - Aquarius
                 * Neptune - Pisces
                 * Pluto - Scorpio
                 * Chiron - Cancer
                 * X - Taurus
                 * Y - Virgo
                 * Z- Leo
                 */

                Color OwnHouse = Color.Blue;
                if (Planet_Signs[2] == 1)//Mars
                {
                    fontPlanetBrush[2] = new SolidBrush(OwnHouse);
                    GoodBad[2] = 2;
                }
                if (Planet_Signs[3] == 3)// Mercury
                {
                    fontPlanetBrush[3] = new SolidBrush(OwnHouse);
                    GoodBad[3] = 2;
                }
                if (Planet_Signs[4] == 9)// Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(OwnHouse);
                    GoodBad[4] = 2;
                }
                if (Planet_Signs[5] == 7)// Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(OwnHouse);
                    GoodBad[5] = 2;
                }
                if (Planet_Signs[6] == 10)// Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(OwnHouse);
                    GoodBad[6] = 2;
                }
                if (Planet_Signs[9] == 11)// Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(OwnHouse);
                    GoodBad[9] = 2;
                }
                if (Planet_Signs[10] == 12)// Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(OwnHouse);
                    GoodBad[10] = 2;
                }
                if (Planet_Signs[11] == 8)// Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(OwnHouse);
                    GoodBad[11] = 2;
                }
                if (Planet_Signs[12] == 4)// Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(OwnHouse);
                    GoodBad[12] = 2;
                }
                if (Planet_Signs[13] == 2)// X
                {
                    fontPlanetBrush[13] = new SolidBrush(OwnHouse);
                    GoodBad[13] = 2;
                }
                if (Planet_Signs[14] == 6)// Y
                {
                    fontPlanetBrush[3] = new SolidBrush(OwnHouse);
                    GoodBad[14] = 2;
                }
                if (Planet_Signs[15] == 5)// z
                {
                    fontPlanetBrush[15] = new SolidBrush(OwnHouse);
                    GoodBad[15] = 2;
                }

                //Friendly (DarkCyan)
                /*
                 * Su - Nill
                 * Moon - Nill
                 * Ma - Libra
                 * Mercury - Sagitarius
                 * Ju - Gemini
                 * Venus - Aries
                 * Sa - Cancer
                 * Uranus - Leo
                 * Neptune - Virgo
                 * Pluto - Taurus
                 * Chiron - Capricorn
                 * X - Scorpio
                 * Y - Pisces
                 * Z- Aquarius
                 */

                Color Friendly = Color.DarkCyan;
                if (Planet_Signs[2] == 7)//Mars
                {
                    fontPlanetBrush[2] = new SolidBrush(Friendly);
                    GoodBad[0] = 3;
                }
                if (Planet_Signs[3] == 9)// Mercury
                {
                    fontPlanetBrush[3] = new SolidBrush(Friendly);
                    GoodBad[3] = 3;
                }
                if (Planet_Signs[4] == 3)// Jupiter
                {
                    fontPlanetBrush[4] = new SolidBrush(Friendly);
                    GoodBad[4] = 3;
                }
                if (Planet_Signs[5] == 1)// Venus
                {
                    fontPlanetBrush[5] = new SolidBrush(Friendly);
                    GoodBad[5] = 3;
                }
                if (Planet_Signs[6] == 4)// Saturn
                {
                    fontPlanetBrush[6] = new SolidBrush(Friendly);
                    GoodBad[6] = 3;
                }
                if (Planet_Signs[9] == 5)// Uranus
                {
                    fontPlanetBrush[9] = new SolidBrush(Friendly);
                    GoodBad[9] = 3;
                }
                if (Planet_Signs[10] == 6)// Neptune
                {
                    fontPlanetBrush[10] = new SolidBrush(Friendly);
                    GoodBad[10] = 3;
                }
                if (Planet_Signs[11] == 2)// Pluto
                {
                    fontPlanetBrush[11] = new SolidBrush(Friendly);
                    GoodBad[11] = 3;
                }
                if (Planet_Signs[12] == 10)// Chiron
                {
                    fontPlanetBrush[12] = new SolidBrush(Friendly);
                    GoodBad[12] = 3;
                }
                if (Planet_Signs[13] == 8)// X
                {
                    fontPlanetBrush[13] = new SolidBrush(Friendly);
                    GoodBad[13] = 3;
                }
                if (Planet_Signs[14] == 12)// Y
                {
                    fontPlanetBrush[14] = new SolidBrush(Friendly);
                    GoodBad[14] = 3;
                }
                if (Planet_Signs[15] == 11)// z
                {
                    fontPlanetBrush[15] = new SolidBrush(Friendly);
                    GoodBad[15] = 3;
                }

                /* CIRCLE in RED the following in addition to a "GREEN" planet being in 3rd, 6th, 8th, 12th houses....
                    Aries Ascendant – Z in Pisces, Y in any house, Mercury in Aquarius, Z in Libra, Pluto in Leo, Saturn in Libra
                    Taurus Ascendant – Y in Aries, NewMoon in any house, FullMoon in any house, Ve in any sign, Venus in Pisces, Pluto in Scorpio, Pluto in Leo, Uranus in Scorpio, Mars in Capricorn, Sun in Sagittarius, Jupiter in Taurus, X in Cancer, Chiron in Aries. 
                    Gemini Ascendant – Z in Pisces, Saturn in any house, Sun in Aries, Jupiter in Sagittarius, Jupiter in Cancer, Saturn in Libra, X in Gemini, X in Cancer, X in Virgo, X in Libra, X in Sagittarius, X in Capricorn, X in Aquarius, X in Pisces, X in Aries, Venus in Capricorn, Z in Leo, Z in Libra, Mars in Sagittarius.
                    Cancer Ascendant – Y in Aries, Me in any house, Jupiter in Cancer,  Saturn in Capricorn, Saturn in Libra, Uranus in Scorpio, Mars in Capricorn, X in Capricorn.
                    Leo Ascendant – Z in Pisces, NewMoon in any house, FullMoon in any house, Uranus in Aquarius, Uranus in Scorpio, X in Cancer, X in Aquarius, X in Capricorn, Mercury in Aquarius, Moon in Taurus, Chiron in Aries.
                    Virgo Ascendant – Y in Aries, Z in Pisces, NewMoon in any house, FullMoon in any house, Venus in Pisces, Mars in Capricorn, Mars in all houses, X in Pisces, Z in Libra, Chiron in Aries
                    Libra Ascendant – Z in Pisces, Y in any house, Jupiter in Cancer, Neptune in Cancer, Mars in Aries, Mars in Capricorn, Chiron in Aries, X in Gemini, X in Cancer, X in Libra, X in Capricorn, X in Aquarius, X in Aries, Sun in Aries, Y in Gemini.  
                    Scorpio Ascendant – Y in Aries, Z in Pisces, Me in any house, Ve in any sign, Chiron in Aries, X in Taurus, X in Cancer, X in Virgo, X in Sagittarius, X in Capricorn, X in Aquarius, Mercury in Aquarius, X in Pisces, Moon in Taurus, Venus in Pisces, Mercury In Scorpio, Venus in all houses, Mars in all houses. 
                    Sagittarius Ascendant – Y in Aries, NewMoon in any house, FullMoon in any house, Ma in Capricorn, Chiron in Aries, X in Gemini, X in Cancer, X in Virgo, X in Libra, X in Sagittarius, X in Capricorn, X in Pisces, X in Aries, Y in Gemini, Pluto in Leo, Chiron in Sagittarius.
                    Capricorn Ascendant – Z in Pisces, NewMoon in any house, FullMoon in any house, Me in any house, X in Virgo, Neptune in Cancer, Mercury in Aquarius, Moon in Cancer, Moon in Taurus, Sun in Aries, Sun in Capricorn, Mercury in Capricorn, Jupiter in Cancer, Chiron in Aries, X in Cancer, Z in Libra. 
                    Aquarius Ascendant - Z in Pisces, NewMoon in any house, FullMoon in any house, Y in any house, Moon in Taurus, Sun in Leo, Z in Leo, Z in Libra, Y in Gemini, Pluto in Leo, Saturn in Libra, Chiron in Sagittarius, Chiron in Aries, X in Cancer, X in Capricorn.
                    Pisces Ascendant – NewMoon in any house, FullMoon in any house, Ve in any sign, X in Gemini, X in Cancer, X in Virgo, X in Sagittarius, X in Capricorn, X in Aries, Moon in Taurus, Sun in Aries, Y in Virgo, Y in Gemini,  Venus in Pisces, Venus in all houses, Uranus in Scorpio,
                    Sun placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Sat placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Jup placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                    Venus in the ascendant shouldn’t be circled in Red, except for Taurus, Scorpio and Pisces ascendants.
                    Venus in the 7th house shouldn’t be circled in Red except Aries, Taurus and Virgo ascendants.
                    When Sun and Mercury are in conjunction in the 5th house, they should be circled in Red.
                 * For Sagittarius Asdt when Mercury is in eighth it needs to be circled in RED
                 * For Gemini Asdts When Jupiter is in 12th, (or 6th or 8th)they need to be circled in RED.
                 * Mars or Venus in 1st, 3rd, 6th, 7th 8th and 12th (Planets to be circled Red)
                 * When Chiron is in Cancer or Sagittarius and in the 3rd, 5th, 6th, 7th, 8th and 12th house for any ascendant kindly circle it in Red.
                 * 
                 * Pluto during the years 1957 (1st Jan) to 1961 (31st Dec) should be circled in Red.
                //When a planet is already in red, it shouldn't be circled in red.
                 * */
                int[] RedCircle_eachLagna = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                if (Lagna_Sign == 1)
                {
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                }
                else if (Lagna_Sign == 2)
                {
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[11] == 8)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[0] == 9)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 2)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;

                    RedCircle_eachLagna[5] = -1;//Ve in any sign
                }
                else if (Lagna_Sign == 3)
                {
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 9)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[5] == 10)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[15] == 5)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[2] == 9)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[6] = -1;//Sa in any house

                    if (House_Planet[4] == 12 || House_Planet[4] == 6 || House_Planet[4] == 8)
                        RedCircle_eachLagna[4] = -1;

                }
                else if (Lagna_Sign == 4)
                {
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[6] == 10)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[3] = -1;//Me in any house
                }
                else if (Lagna_Sign == 5)
                {

                    if (Planet_Signs[9] == 11)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 6)
                {
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    //if (Planet_Signs[2] == 10)
                    //    RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[2] = -1;//Ma in all houses
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 7)
                {
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[10] == 4)
                        RedCircle_eachLagna[10] = -1;
                    if (Planet_Signs[2] == 1)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                }
                else if (Lagna_Sign == 8)
                {
                    if (Planet_Signs[13] == 2)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 11)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[5] == 12)
                        RedCircle_eachLagna[5] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[3] == 8)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    RedCircle_eachLagna[2] = -1;//Ma in all houses
                    RedCircle_eachLagna[3] = -1;//Me in any house
                    RedCircle_eachLagna[5] = -1;//Ve in any sign
                }
                else if (Lagna_Sign == 9)
                {
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 7)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 12)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[12] == 9)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[2] == 10)
                        RedCircle_eachLagna[2] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 1)
                        RedCircle_eachLagna[14] = -1;

                    if (House_Planet[3] == 8)
                        RedCircle_eachLagna[3] = -1;
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;

                }
                else if (Lagna_Sign == 10)
                {
                    if (Planet_Signs[10] == 4)
                        RedCircle_eachLagna[10] = -1;
                    if (Planet_Signs[3] == 11)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[1] == 4)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[4] == 4)
                        RedCircle_eachLagna[4] = -1;
                    if (Planet_Signs[0] == 10)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[3] == 10)
                        RedCircle_eachLagna[3] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[3] = -1;//Me in any house
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 11)
                {
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 5)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[15] == 5)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[15] == 7)
                        RedCircle_eachLagna[15] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[11] == 5)
                        RedCircle_eachLagna[11] = -1;
                    if (Planet_Signs[6] == 7)
                        RedCircle_eachLagna[6] = -1;
                    if (Planet_Signs[12] == 9)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[12] == 1)
                        RedCircle_eachLagna[12] = -1;
                    if (Planet_Signs[15] == 12)
                        RedCircle_eachLagna[15] = -1;

                    RedCircle_eachLagna[14] = -1;//Y in any house
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                else if (Lagna_Sign == 12)
                {
                    if (Planet_Signs[13] == 3)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 6)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 9)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 1)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[1] == 2)
                        RedCircle_eachLagna[1] = -1;
                    if (Planet_Signs[0] == 1)
                        RedCircle_eachLagna[0] = -1;
                    if (Planet_Signs[14] == 6)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[14] == 3)
                        RedCircle_eachLagna[14] = -1;
                    if (Planet_Signs[13] == 10)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[13] == 4)
                        RedCircle_eachLagna[13] = -1;
                    if (Planet_Signs[9] == 8)
                        RedCircle_eachLagna[9] = -1;

                    RedCircle_eachLagna[5] = -1;//ve in all houses
                    if (NewMoon)//new moon in any house
                        RedCircle_eachLagna[1] = -1;
                    if (FullMoon)//full moon in any house
                        RedCircle_eachLagna[1] = -1;
                }
                //Sun placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[0] == 6 || House_Planet[0] == 8 || House_Planet[0] == 12)
                    RedCircle_eachLagna[0] = -1;

                //Saturn placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[6] == 6 || House_Planet[6] == 8 || House_Planet[6] == 12)
                    RedCircle_eachLagna[6] = -1;

                //Jupiter placed in 6th, 8th or 12th for any ascendant needs to be circled Red too.
                if (House_Planet[4] == 6 || House_Planet[4] == 8 || House_Planet[4] == 12)
                    RedCircle_eachLagna[4] = -1;

                // * Mars or Venus in 1st, 3rd, 6th, 7th 8th and 12th (Planets to be circled Red)
                if (House_Planet[2] == 1 || House_Planet[2] == 3 || House_Planet[2] == 6 || House_Planet[2] == 7 || House_Planet[2] == 8 || House_Planet[2] == 12)
                    RedCircle_eachLagna[2] = -1;
                if (House_Planet[5] == 1 || House_Planet[5] == 3 || House_Planet[5] == 6 || House_Planet[5] == 7 || House_Planet[5] == 8 || House_Planet[5] == 12)
                    RedCircle_eachLagna[5] = -1;

                // * When Chiron is in Cancer or Sagittarius and in the 3rd, 5th, 6th, 7th, 8th and 12th house for any ascendant kindly circle it in Red.
                if ((Planet_Signs[12] == 4 || Planet_Signs[12] == 9) && (House_Planet[12] == 3 || House_Planet[12] == 5 || House_Planet[12] == 6 || House_Planet[12] == 7 || House_Planet[12] == 8 || House_Planet[12] == 12))
                    RedCircle_eachLagna[12] = -1;

                // When the full Moon falls in 3rd,5th, 6th 7th, 8th and 12th houses, it should be in circled in Red.
                if (FullMoon && (House_Planet[1] == 3 || House_Planet[1] == 5 || House_Planet[1] == 6 || House_Planet[1] == 7 || House_Planet[1] == 8 || House_Planet[1] == 12))
                    RedCircle_eachLagna[1] = -1;

                // When the new Moon falls in 3rd,5th, 6th 7th, 8th and 12th houses, it should be in circled in Red.
                if (NewMoon && (House_Planet[1] == 3 || House_Planet[1] == 5 || House_Planet[1] == 6 || House_Planet[1] == 7 || House_Planet[1] == 8 || House_Planet[1] == 12))
                    RedCircle_eachLagna[1] = -1;

                //Venus in the ascendant shouldn’t be circled in Red, except for Taurus, Scorpio and Pisces ascendants.
                if (House_Planet[5] == 1 && !(Planet_Signs[5] == 2 || Planet_Signs[5] == 8 || Planet_Signs[5] == 12))
                    RedCircle_eachLagna[5] = -1;
                //Venus in the 7th house shouldn’t be circled in Red except Aries, Taurus and Virgo ascendants.
                if (House_Planet[5] == 7 && !(Planet_Signs[5] == 7 || Planet_Signs[5] == 8 || Planet_Signs[5] == 12))//7th house is libra, scorpio or pisces for ascendents aries, taurus and virgo
                    RedCircle_eachLagna[5] = -1;

                //When Sun and Mercury are in conjunction in the 5th house, they should be circled in Red.
                if (House_Planet[0] == House_Planet[3] && House_Planet[0] == 5)
                {
                    RedCircle_eachLagna[0] = -1;
                    RedCircle_eachLagna[3] = -1;
                }

                // Pluto during the years 1957 (1st Jan) to 1961 (31st Dec) should be circled in Red.
                if (birthJulDay >= 2435839.500000 && birthJulDay <= 2437664.500000)
                    RedCircle_eachLagna[11] = -1;

                ///************************************************************
                //When a planet is already in red, it shouldn't be circled in red.
                for (i = 0; i < 16; i++)
                    if (GoodBad[i] == -1) RedCircle_eachLagna[i] = 0;
                ///************************************************************

                RectangleF rectP, rectH;
                string a;

                int j = 0;
                string Planet_String = "", Outer_String = "";
                int l, count, iPlanet = 0, Sign;
                int House;
                double LgDeg = 180.0;
                double deg = 0, d = 0;
                double k = LgDeg + 15 + 30 * (Lagna_Sign - 1);



                Sign = Lagna_Sign;
                for (count = 1; count <= 12; Sign++, count++)
                {
                    if (Sign == 13)
                        Sign = 1;
                    Planet_String = "";
                    Outer_String = "";

                    //planets
                    for (i = 0; i < 9; i++)
                    {
                        if (Planet_Signs[i] == Sign)
                        {
                            for (j = 0; j < Planet_String.Length; j++)
                            {
                                if (Planet_String == "") break;
                                a = String.Format("{0}", Planet_String[j] - 'a');
                                iPlanet = Convert.ToInt32(a, 10);

                                if (Planet_Degrees[iPlanet] > Planet_Degrees[i])
                                    break;
                            }
                            a = string.Format("{0}", Convert.ToChar(i + 97));
                            Planet_String = Planet_String.Insert(j, a);
                        }
                    }
//                    put ur ne pl, and asteroids in the outer_string
                    for (i = 9; i < 16; i++)
                    {
                        if (Planet_Signs[i] == Sign)
                        {
                            for (j = 0; j < Outer_String.Length; j++)
                            {
                                if (Outer_String == "") break;
                                a = String.Format("{0}", Outer_String[j] - 'a');
                                iPlanet = Convert.ToInt32(a, 10);

                                if (Planet_Degrees[iPlanet] > Planet_Degrees[i])
                                    break;
                            }
                            a = string.Format("{0}", Convert.ToChar(i + 97));
                            Outer_String = Outer_String.Insert(j, a);
                        }
                    }


                    House = Lagna_Sign + count - 1;
                    if (House > 12)
                        House -= 12;

                    i = count - 1;
                    //Sign
                    if (i == 0) fontRasiBrush.Color = Color.FromArgb(66, 75, 17);
                    else fontRasiBrush.Color = Color.LightSalmon;

                    rectH = new RectangleF( //Convert.ToSingle(chartRect.Left+ chartRect.Width/2 + chartRect.Width/2*Math.Cos(  (LgDeg-i*30)*22.0/7.0/180)),
                        //Convert.ToSingle(chartRect.Top+ chartRect.Height/2 + chartRect.Width/2*Math.Sin(  (LgDeg-i*30)*22.0/7.0/180)),
                                            Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + (chartRect.Width / 2 - chartRect.Width / 20) * Math.Cos((LgDeg - i * 30) * 22.0 / 7.0 / 180)),
                                            Convert.ToSingle(chartRect.Top + chartRect.Height / 2 + (chartRect.Width / 2 - chartRect.Width / 20) * Math.Sin((LgDeg - i * 30) * 22.0 / 7.0 / 180)),
                                            Convert.ToSingle((chartRect.Width / 20) * Math.Cos((LgDeg - i * 30) * 22.0 / 7.0 / 180)),
                                            Convert.ToSingle((chartRect.Width / 20) * Math.Sin((LgDeg - i * 30) * 22.0 / 7.0 / 180)));
                    objGraphics.DrawString(Rasi_Sht_Names[Sign - 1], houseFont, fontRasiBrush, rectH, centerFormat);
                    a = string.Format("{0}", count);
                    rectH = new RectangleF( //Convert.ToSingle(chartRect.Left+ chartRect.Width/2 + chartRect.Width/2*Math.Cos(  (LgDeg-i*30)*22.0/7.0/180)),
                        //Convert.ToSingle(chartRect.Top+ chartRect.Height/2 + chartRect.Width/2*Math.Sin(  (LgDeg-i*30)*22.0/7.0/180)),
                                            Convert.ToSingle(chartRect.Left + chartRect.Width / 2 + (chartRect.Width / 2 - chartRect.Width / 10) * Math.Cos((LgDeg - i * 30) * 22.0 / 7.0 / 180)),
                                            Convert.ToSingle(chartRect.Top + chartRect.Height / 2 + (chartRect.Width / 2 - chartRect.Width / 10) * Math.Sin((LgDeg - i * 30) * 22.0 / 7.0 / 180)),
                                            Convert.ToSingle((chartRect.Width / 20) * Math.Cos((LgDeg - i * 30) * 22.0 / 7.0 / 180)),
                                            Convert.ToSingle((chartRect.Width / 20) * Math.Sin((LgDeg - i * 30) * 22.0 / 7.0 / 180)));
                    objGraphics.DrawString(a, houseFont, fontHouseBrush, rectH, centerFormat);
				
                                                //int(X1+ (X2-X1)/2 + ((X2-X1)/2 + (X2-X1)/40)*cos((k-(30.0*(House-1)+deg))*22.0/7.0/180)),  int(Y1+ (Y2-Y1)/2 + ((X2-X1)/2 + (X2-X1)/40)*sin((k-(30.0*(House-1)+deg))*22.0/7.0/180))	),	DT_NOCLIP | DT_SINGLELINE | DT_CENTER | DT_VCENTER );


                    //Planets
                    l = Planet_String.Length;
                    d = 30.0 / (l + 1);
                    for (i = 0; i < Planet_String.Length; i++)
                    {
                        deg = d * (i + 1);

                        rectP = new RectangleF(	//Convert.ToSingle(chartRect.Left+ chartRect.Width/2 + (chartRect.Width/2 - (chartRect.Left-chartRect.Left)/4 )*Math.Cos((k-(30.0*(House-1)+deg))*22.0/7.0/180)),
                            //Convert.ToSingle(chartRect.Top + chartRect.Height/2 +(chartRect.Width/2 - (chartRect.Left-chartRect.Left)/4) *Math.Sin((k-(30.0*(House-1)+deg))*22.0/7.0/180)),	
                                                Convert.ToSingle(chartRectSmall.Left + chartRectSmall.Width / 2 + (chartRectSmall.Width / 2 - (chartRectSmall.Left - chartRect.Left) / 4 - chartRectSmall.Width / 10) * Math.Cos((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)),
                                                Convert.ToSingle(chartRectSmall.Top + chartRectSmall.Height / 2 + (chartRectSmall.Width / 2 - (chartRectSmall.Left - chartRect.Left) / 4 - chartRectSmall.Width / 10) * Math.Sin((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)),
                                                Convert.ToSingle((chartRectSmall.Width / 10) * Math.Cos((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)),
                                                Convert.ToSingle((chartRectSmall.Width / 10) * Math.Sin((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)));


                        iPlanet = Convert.ToInt32(String.Format("{0}", Planet_String[i] - 'a'), 10);
                        a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                        rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);
                        if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                            objGraphics.DrawEllipse(penRed, rectP);
                        objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);
                    }
                    //Outer_Planets
                    l = Outer_String.Length;
                    d = 30.0 / (l + 1);
                    for (i = 0; i < Outer_String.Length; i++)
                    {
                        deg = d * (i + 1);

                        rectP = new RectangleF(	//Convert.ToSingle(chartRect.Left+ chartRect.Width/2 + (chartRect.Width/2 - (chartRect.Left-chartRect.Left)/4 )*Math.Cos((k-(30.0*(House-1)+deg))*22.0/7.0/180)),
                            //Convert.ToSingle(chartRect.Top + chartRect.Height/2 +(chartRect.Width/2 - (chartRect.Left-chartRect.Left)/4) *Math.Sin((k-(30.0*(House-1)+deg))*22.0/7.0/180)),	
                                                Convert.ToSingle(chartRectSmall.Left + chartRectSmall.Width / 2 + (chartRectSmall.Width / 2 - (chartRectSmall.Left - chartRect.Left)*1  - chartRectSmall.Width / 10) * Math.Cos((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)),
                                                Convert.ToSingle(chartRectSmall.Top + chartRectSmall.Height / 2 + (chartRectSmall.Width / 2 - (chartRectSmall.Left - chartRect.Left)*1  - chartRectSmall.Width / 10) * Math.Sin((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)),
                                                Convert.ToSingle((chartRectSmall.Width / 10) * Math.Cos((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)),
                                                Convert.ToSingle((chartRectSmall.Width / 10) * Math.Sin((k - (30.0 * (House - 1) + deg)) * 22.0 / 7.0 / 180)));


                        iPlanet = Convert.ToInt32(String.Format("{0}", Outer_String[i] - 'a'), 10);
                        a = string.Format("{0}", Planet_Sht_Names[iPlanet]);

                        rectP = Functions.CenterAndSquare_Rectangle(rectP, chartRect.Width / 10);
                        if (((count == 3 || count == 6 || count == 8 || count == 12 || count == 5) && GoodBad[iPlanet] == 1) || RedCircle_eachLagna[iPlanet] == -1)
                            objGraphics.DrawEllipse(penRed, rectP);
                        objGraphics.DrawString(a, planetFont, fontPlanetBrush[iPlanet], rectP, centerFormat);
                    }


                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }

        }

        public static void Draw_Table_Combination(Graphics objGraphics, RectangleF chartRect, int Planet_Signs0, int Planet_Signs1, int Planet_Signs3)
        {
            try
            {
                Pen penKhaki = new Pen(Color.FromArgb(66,75,17));
                SolidBrush brushBkGnd = new SolidBrush(Color.FromArgb(233, 238, 208));

                StringFormat centerFormat = new StringFormat();
                centerFormat.Trimming = StringTrimming.None;
                centerFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerFormat.LineAlignment = StringAlignment.Center;
                centerFormat.Alignment = StringAlignment.Center;

                StringFormat centerleftFormat = new StringFormat();
                centerleftFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerleftFormat.LineAlignment = StringAlignment.Center;
                centerleftFormat.Alignment = StringAlignment.Near;

                StringFormat centerrightFormat = new StringFormat();
                centerrightFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerrightFormat.LineAlignment = StringAlignment.Center;
                centerrightFormat.Alignment = StringAlignment.Far;

                objGraphics.FillRectangle(brushBkGnd, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
                objGraphics.DrawRectangle(penKhaki, chartRect.Left, chartRect.Top, chartRect.Width, chartRect.Height);
	            float ht = chartRect.Height/7;

                Font TextFont = new Font("Verdana", 10);
                Font HeadFont = new Font("Times New Roman", 12, FontStyle.Bold);

                SolidBrush fontBlackBrush = new SolidBrush(Color.Black);
                SolidBrush fontMaroonBrush = new SolidBrush(Color.FromArgb(181, 38, 24));
                
                string[] Rasi_Names = new string[] { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces" };
                string a;


                RectangleF rectH = new RectangleF( chartRect.Left, chartRect.Top, chartRect.Width/2 - 10, ht);
                objGraphics.DrawString("Sun's Sign:  ", TextFont, fontMaroonBrush, rectH, centerrightFormat);
                rectH = new RectangleF(chartRect.Left, chartRect.Top + ht, chartRect.Width / 2 - 10, ht);
                objGraphics.DrawString("Moon's Sign:  ", TextFont, fontMaroonBrush, rectH, centerrightFormat);
                rectH = new RectangleF(chartRect.Left, chartRect.Top + ht * 2, chartRect.Width / 2 - 10, ht);
                objGraphics.DrawString("Mercury's Sign:  ", TextFont, fontMaroonBrush, rectH, centerrightFormat);

                rectH = new RectangleF( chartRect.Left + chartRect.Width/2, chartRect.Top, chartRect.Width/2 - 10, ht);
                objGraphics.DrawString(Rasi_Names[Planet_Signs0 - 1], TextFont, fontBlackBrush, rectH, centerleftFormat);
                rectH = new RectangleF(chartRect.Left + chartRect.Width / 2, chartRect.Top+ht, chartRect.Width / 2 - 10, ht);
                objGraphics.DrawString(Rasi_Names[Planet_Signs1 - 1], TextFont, fontBlackBrush, rectH, centerleftFormat);
                rectH = new RectangleF(chartRect.Left + chartRect.Width / 2, chartRect.Top+ht*2, chartRect.Width / 2 - 10, ht);
                objGraphics.DrawString(Rasi_Names[Planet_Signs3 - 1], TextFont, fontBlackBrush, rectH, centerleftFormat);


                rectH = new RectangleF(chartRect.Left, chartRect.Top + ht * 3, chartRect.Width, ht);
                objGraphics.DrawString("Your True Zodiac Sign Combination :", HeadFont, fontMaroonBrush, rectH, centerFormat);
                


	            //bubble
	            int[] order= new int[]{Planet_Signs0, Planet_Signs1, Planet_Signs3};
	            int count=3;
                bool changed = true;
	            int temp;
                int i;
	            while(changed)
	            { /* scan */
		            changed = false;
		            for( i = 0; i < count - 1; i++)
		            { /* compare */
			            if(order[i+1] < order[i])
			            { /* swap */
				            temp = order[i];
				            order[i] = order[i + 1];
				            order[i+1] = temp;
				            changed = true;
			            } /* swap */
		            } /* compare */  
	            } /* scan */

	            //eliminate duplicates
	            i=1;
	            while(order[i-1]==order[i])
	            {
		            order[i]=order[i+1];
		            order[i+1]=0;
	            }
	            i=2;
	            if(order[i-1]==order[i])
	            {
		            order[i]=0;
	            }

	
                a = string.Format( "{0}{1}{2}", Rasi_Names[order[0]-1], ((order[1]==0)?(""):("-"+Rasi_Names[order[1]-1])), ((order[2]==0)?(""):("-"+Rasi_Names[order[2]-1])));

                rectH = new RectangleF(chartRect.Left, chartRect.Top + ht * 4, chartRect.Width, ht);

                objGraphics.DrawString(a, HeadFont, fontBlackBrush, rectH, centerFormat);

                a = string.Format("Also read chapters {0}{1}{2} for deeper understanding.", "'" + Rasi_Names[order[0] - 1] + "'", ((order[1] == 0) ? ("") : (", '" + Rasi_Names[order[1] - 1] + "'")), ((order[2] == 0) ? ("\r\n") : (",\r\n '" + Rasi_Names[order[2] - 1] + "'")));
                rectH = new RectangleF(chartRect.Left, chartRect.Top + ht * 5, chartRect.Width, ht*2);
                objGraphics.DrawString(a, TextFont, fontBlackBrush, rectH, centerFormat);
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }

        }


    
    }
}

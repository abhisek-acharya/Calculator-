using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GreenStone_ChartCalculator
{
    public partial class DrawChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int Width = Convert.ToInt32(Request["Width"]);
                int Height = Convert.ToInt32(Request["Height"]);

                double Lg_Full_Degree = Convert.ToDouble(Request["Lg_Full_Degrees"]);
                double[] Planet_Full_Degree = new double[16] { Convert.ToDouble(Request["Su_Full_Degrees"]), Convert.ToDouble(Request["Mo_Full_Degrees"]), Convert.ToDouble(Request["Ma_Full_Degrees"]), Convert.ToDouble(Request["Me_Full_Degrees"]), Convert.ToDouble(Request["Ju_Full_Degrees"]), Convert.ToDouble(Request["Ve_Full_Degrees"]), Convert.ToDouble(Request["Sa_Full_Degrees"]), Convert.ToDouble(Request["Ra_Full_Degrees"]), Convert.ToDouble(Request["Ke_Full_Degrees"]), Convert.ToDouble(Request["Ur_Full_Degrees"]), Convert.ToDouble(Request["Ne_Full_Degrees"]), Convert.ToDouble(Request["Pl_Full_Degrees"]), Convert.ToDouble(Request["Ch_Full_Degrees"]), Convert.ToDouble(Request["X_Full_Degrees"]), Convert.ToDouble(Request["Y_Full_Degrees"]), Convert.ToDouble(Request["Z_Full_Degrees"]) };
                int[] Planet_Retro = new int[16] { 0, 0, Convert.ToInt32(Request["Ma_Retro"]), Convert.ToInt32(Request["Me_Retro"]), Convert.ToInt32(Request["Ju_Retro"]), Convert.ToInt32(Request["Ve_Retro"]), Convert.ToInt32(Request["Sa_Retro"]), 0, 0, Convert.ToInt32(Request["Ur_Retro"]), Convert.ToInt32(Request["Ne_Retro"]), Convert.ToInt32(Request["Pl_Retro"]), 0, 0, 0, 0 };
                double birthTimeZone = Convert.ToDouble(Request["birthTimeZone"]);
                int birthDST = Convert.ToInt32(Request["birthDST"]);
                double birthJulDay = Convert.ToDouble(Request["birthJulDay"]);
                string Name = Request["Name"];

                //////////////////////////////////////

                int Lg_Sign = (int)Lg_Full_Degree / 30 + 1;
                if (Lg_Sign > 12)
                    Lg_Sign -= 12;
                double Lg_Degrees = (Lg_Full_Degree / 30 - (int)Lg_Full_Degree / 30) * 30;

                int[] Planet_Signs = new int[16];
                double[] Planet_Degrees = new double[16];

                int i = 0;
                for (i = 0; i < 16; i++)
                {
                    Planet_Signs[i] = (int)Planet_Full_Degree[i] / 30 + 1;
                    if (Planet_Signs[i] > 12)
                        Planet_Signs[i] -= 12;
                    Planet_Degrees[i] = (Planet_Full_Degree[i] / 30 - (int)Planet_Full_Degree[i] / 30) * 30;
                }

                //////////////////////////////////////


                // Set the page's content type to JPEG files
                // and clear all response headers.
                Response.ContentType = "image/jpeg";
                Response.Clear();

                // Buffer response so that page is sent
                // after processing is complete.
                Response.BufferOutput = true;

                Bitmap objBitmap = new Bitmap(Width, Height);
                Graphics objGraphics = Graphics.FromImage(objBitmap);
                objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                objGraphics.CompositingQuality = CompositingQuality.HighQuality;
                objGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                objGraphics.Clear(Color.FromArgb(185, 208, 61));



                RectangleF chartRect = new RectangleF();


                float x1 = 0;
                float y1 = 0;
                float width = Width / 2 - 30;
                float height = Width / 2 - 30;

                /****************************Planetary Details*******************************************/
                x1 = 20;
                y1 = 40;
                height = Height - Width / 2 - 50;
                chartRect = new RectangleF(x1, y1, width, height);
                Functions.Draw_Table_Planetary_Details(objGraphics, chartRect, Planet_Degrees, Planet_Signs, Lg_Degrees, Lg_Sign, Planet_Retro);

                /***************************North Indian**********************************************/
                y1 = height + 60;
                height = Width / 2 - 30;
                chartRect = new RectangleF(x1, y1, width, height);
                Functions.DrawChart_North(objGraphics, chartRect, Lg_Sign, Planet_Signs, Planet_Degrees, birthJulDay);

                /***************************RoundChart**********************************************/
                x1 = Width / 2 + 10;
                chartRect = new RectangleF(x1, y1, width, height);
                Functions.DrawChart_Round(objGraphics, chartRect, Lg_Sign, Planet_Signs, Planet_Degrees, birthJulDay);

                /***************************Table Combination********************************************/
                y1 = 40;
                height = Height - Width - 40;
                chartRect = new RectangleF(x1, y1, width, height);
                Functions.Draw_Table_Combination(objGraphics, chartRect, Planet_Signs[0], Planet_Signs[1], Planet_Signs[3]);

                /*****************************South Indian***********************************************/
                y1 = y1 + height + 20;
                height = Width / 2 - 30;
                chartRect = new RectangleF(x1, y1, width, height);
                Functions.DrawChart_South(objGraphics, chartRect, Lg_Sign, Planet_Signs, Planet_Degrees, birthJulDay);





                /*****************************South Indian***********************************************/
                //float x1 = 20;
                //float y1 = 20;
                //float width = Width / 2 - 30;
                //float height = Width / 2 - 30;

                //chartRect = new RectangleF(x1, y1, width, height);
                //Functions.DrawChart_South(objGraphics, chartRect, Lg_Sign, Planet_Signs, Planet_Retro, Planet_Degrees);

                ///***************************North Indian**********************************************/
                //x1 = Width / 2 + 10;
                //chartRect = new RectangleF(x1, y1, width, height);
                //Functions.DrawChart_North(objGraphics, chartRect, Lg_Sign, Planet_Signs, Planet_Retro, Planet_Degrees);


                ///***************************RoundChart**********************************************/
                //y1 = Width / 2 + 10;
                //chartRect = new RectangleF(x1, y1, width, height);
                //Functions.DrawChart_Round(objGraphics, chartRect, Lg_Sign, Planet_Signs, Planet_Retro, Planet_Degrees);

                ///***************************Table Combination********************************************/
                //y1 = Width + 10;
                //height = Height - Width - 30;
                //chartRect = new RectangleF(x1, y1, width, height);
                //Functions.Draw_Table_Combination(objGraphics, chartRect, Planet_Signs[0], Planet_Signs[1], Planet_Signs[3]);




                ///****************************Planetary Details*******************************************/
                //x1 = 20;
                //y1 = Width / 2 + 10;
                //height = Height - Width/2 - 30;
                //chartRect = new RectangleF(x1, y1, width, height);
                //Functions.Draw_Table_Planetary_Details(objGraphics, chartRect, Planet_Degrees, Planet_Signs, Lg_Degrees, Lg_Sign, Planet_Full_Degree, Lg_Full_Degree);


                ///////////////////////////////////////////////////////////////////////////////////

                SolidBrush fontBrush = new SolidBrush(Color.Black);

                StringFormat centerFormat = new StringFormat();
                centerFormat.Trimming = StringTrimming.None;
                centerFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                centerFormat.LineAlignment = StringAlignment.Center;
                centerFormat.Alignment = StringAlignment.Center;

                Font headFont = new Font("Times New Roman", 14, FontStyle.Bold);
                objGraphics.DrawString(Name, headFont, fontBrush, new RectangleF(0, 0, Width, 40), centerFormat);

                Font textFont = new Font("Verdana", 8);

                fontBrush.Color = Color.Firebrick;
                objGraphics.DrawString("© greenstonelobo.com", textFont, fontBrush, new RectangleF(Width / 2 + 10, Height - 15, Width / 2 - 30, 15), centerFormat);

                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 100L);
                ImageCodecInfo jpegCodec = Functions.GetEncoderInfo("image/jpeg");

                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;

                objBitmap.Save(Response.OutputStream, jpegCodec, encoderParams);

                objGraphics.Dispose();
                objBitmap.Dispose();

                // Send the output to the client.
                Response.Flush();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}

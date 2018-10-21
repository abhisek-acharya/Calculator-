using System;
using System.Web.UI;
using System.IO;
using System.Diagnostics;

namespace GreenStone_ChartCalculator
{
    public partial class Chart : System.Web.UI.Page
    {
        private string City;
        private string Latitude;
        private string Longitude;
        private string Birth_TimeZone;
        private string Birth_DST;
        private string Birth_Country;
        private int Birth_Year, Birth_Month, Birth_Day, Birth_Hour, Birth_Minute, Birth_Second;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //throw new Exception("if I see this exception, I am not running the debugger"); 
                Birth_Year = Convert.ToInt32(PreviousPage.Year);
                Birth_Month = Convert.ToInt32(PreviousPage.Month);
                Birth_Day = Convert.ToInt32(PreviousPage.Day);
                Birth_Hour = Convert.ToInt32(PreviousPage.Hour);
                Birth_Minute = Convert.ToInt32(PreviousPage.Minute);
                Birth_Second = Convert.ToInt32(PreviousPage.Second);
                Birth_Country = PreviousPage.Country;
                ExtractTZDSTCity(PreviousPage.Country, PreviousPage.City);
                try
                {

                    string ephe_path = Server.MapPath(swedll.global_folder_name + @"\sweph\ephe");
                    swedll.swe_set_ephe_path(ephe_path);

                    /////////////////////////////////////
                    //birth
                    double dTimeZone = Functions.DegMinSec_To_DegDecimal(Birth_TimeZone);
                    int iDST = (int)Functions.DegMinSec_To_DegDecimal(Birth_DST);
                    double dLatitude = Functions.DegMinSec_To_DegDecimal(Latitude);
                    double dLongitude = Functions.DegMinSec_To_DegDecimal(Longitude);

                    //////////////////////////////////////////////////////////
                    //Birth Chart/////////////////////////////////////////////
                    //////////////////////////////////////////////////////////

                    double JulDayUT = swedll.swe_julday(Birth_Year, Birth_Month, Birth_Day, Birth_Hour + Birth_Minute / 60.0 + Birth_Second / 3600.0 + dTimeZone - Math.Abs(iDST), 1);
                    double[] Planet_Full_Degree = new Double[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    double Lg_Full_Degree = 0;
                    int[] Planet_Retro = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    string[] Month_Name = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

                    string Path = Server.MapPath(swedll.global_folder_name);
                    swedll.Calculate_Planets(Path, JulDayUT, dLatitude, dLongitude, Planet_Full_Degree, out Lg_Full_Degree, Planet_Retro);
                    //////////////////////////////////////
                    string str;
                    str = string.Format("<h3>{0}&nbsp;&nbsp;{1}/{2:00}/{3}&nbsp;&nbsp;{4:00}:{5:00}:{6:00}&nbsp;&nbsp;{7},&nbsp;{8}</h3><br/>", PreviousPage.Name, Month_Name[Birth_Month - 1], Birth_Day, Birth_Year, Birth_Hour, Birth_Minute, Birth_Second, City, PreviousPage.Country);
                    Literal1.Text = str;

                    str = string.Format("<img alt =\"horoscope\" src=\"DrawChart.aspx?Width=650&Height=800&" +
                      "Lg_Full_Degrees={0}&Su_Full_Degrees={1}&Mo_Full_Degrees={2}&Ma_Full_Degrees={3}&Me_Full_Degrees={4}&Ju_Full_Degrees={5}&Ve_Full_Degrees={6}&Sa_Full_Degrees={7}&Ra_Full_Degrees={8}&Ke_Full_Degrees={9}&Ur_Full_Degrees={10}&Ne_Full_Degrees={11}&Pl_Full_Degrees={12}&Ch_Full_Degrees={13}&X_Full_Degrees={14}&Y_Full_Degrees={15}&Z_Full_Degrees={16}&" +
                      "Ma_Retro={17}&Me_Retro={18}&Ju_Retro={19}&Ve_Retro={20}&Sa_Retro={21}&Ur_Retro={22}&Ne_Retro={23}&Pl_Retro={24}&" +
                      "birthTimeZone={25}&birthDST={26}&birthJulDay={27}\">",
                      Lg_Full_Degree, Planet_Full_Degree[0], Planet_Full_Degree[1], Planet_Full_Degree[2], Planet_Full_Degree[3], Planet_Full_Degree[4], Planet_Full_Degree[5], Planet_Full_Degree[6], Planet_Full_Degree[7], Planet_Full_Degree[8], Planet_Full_Degree[9], Planet_Full_Degree[10], Planet_Full_Degree[11], Planet_Full_Degree[12], Planet_Full_Degree[13], Planet_Full_Degree[14], Planet_Full_Degree[15],
                      Planet_Retro[0], Planet_Retro[1], Planet_Retro[2], Planet_Retro[3], Planet_Retro[4], Planet_Retro[5], Planet_Retro[6], Planet_Retro[7],
                      dTimeZone, iDST, JulDayUT);

                    //Response.Write(str);
                    Literal1.Text += str;


                }//try
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }
        private void ExtractTZDSTCity(string country, string citystring)
        {
            try
            {
                char chk = ',';
                string[] cityarray = citystring.Split(chk);

                City = cityarray[0].ToString().Trim();

                string State = "", TZ = "";
                if (country == "USA")
                {
                    State = cityarray[1].ToString().Trim();

                    Latitude = cityarray[3].ToString().Trim();
                    Longitude = cityarray[4].ToString().Trim();

                    TZ = cityarray[5].ToString().Trim();
                }
                else
                {
                    State = cityarray[1].ToString().Trim();

                    Latitude = cityarray[2].ToString().Trim();
                    Longitude = cityarray[3].ToString().Trim();

                    TZ = cityarray[4].ToString().Trim();
                    if (country == "Russia")
                    {
                        TZ += "-" + cityarray[5].ToString().Trim();
                    }
                }

                if (country != "USA" && country != "Canada")
                {
                    State = country;
                }
                State = State + TZ;

                string tzpath = Server.MapPath(swedll.global_folder_name + @"\Atlas\");
                tzpath += country + "Z.txt";

                Get_DST_TZ(State, tzpath);
            }
            catch (Exception e)
            {
                Response.Write(e.ToString());
            }

        }
        private void Get_DST_TZ(string State, string path)
        {
            double JulDayBirth = swedll.swe_julday(Birth_Year, Birth_Month, Birth_Day, (Birth_Hour + Birth_Minute / 60.0 + Birth_Second / 3600.0), 1);
            if (Birth_Country == "Russia")//RussiaTZ#-State#
            {
                string[] chktz = null;
                chktz = State.Split('-');
                chktz[0] = chktz[0].Trim();
                chktz[1] = chktz[1].Trim();
                if (JulDayBirth > 2455647.0)//new TZ and Permanent DST since 27 March 2011
                {
                    Birth_DST = "0";//no more DST

                    chktz[0] = chktz[0].Remove(0, 6);
                    chktz[0] = chktz[0].Trim();
                    int TimeZoneTableNo = Convert.ToInt32(chktz[0]);

                    int iState = Convert.ToInt32(chktz[1]);
                    int iTZ;
                    //-3
                    if (iState == 23)
                        iTZ = -3;

                    //-4
                    else if (iState == 37 ||
                            iState == 38 ||
                            iState == 41 ||
                            iState == 34 ||
                            iState == 43 ||
                            iState == 1 ||
                            iState == 46 ||
                            iState == 47 ||
                            iState == 48 ||
                            iState == 42 ||
                            iState == 19 ||
                            iState == 6 ||
                            iState == 7 ||
                            iState == 9 ||
                            iState == 10 ||
                            iState == 12 ||
                            iState == 28 ||
                            iState == 17 ||
                            iState == 33 ||
                            iState == 21 ||
                            iState == 22 ||
                            iState == 24 ||
                            iState == 25 ||
                            iState == 27 ||
                            iState == 49 ||
                            iState == 16 ||
                            iState == 81 ||
                            iState == 69 ||
                            iState == 70 ||
                            iState == 50 ||
                            iState == 73 ||
                            iState == 45 ||
                            iState == 76 ||
                            iState == 68 ||
                            iState == 80 ||
                            iState == 72 ||
                            iState == 82 ||
                            iState == 83 ||
                            iState == 84 ||
                            iState == 85 ||
                            iState == 86 ||
                            iState == 88 ||
                            iState == 77 ||
                            iState == 60 ||
                            iState == 51 ||
                            iState == 66 ||
                            iState == 56 ||
                            iState == 65 ||
                            iState == 62 ||
                            iState == 61 ||
                            iState == 57 ||
                            iState == 52 ||
                            iState == 67)
                        iTZ = -4;

                //-6
                    else if (iState == 55 ||
                            iState == 13 ||
                            iState == 58 ||
                            iState == 71 ||
                            iState == 8 ||
                            iState == 40 ||
                            iState == 78 ||
                            iState == 35 ||
                            iState == 32 ||
                            iState == 87)
                        iTZ = -6;

                //-7
                    else if (iState == 75 ||
                            iState == 4 ||
                            iState == 3 ||
                            iState == 29 ||
                            iState == 53 ||
                            iState == 54)
                        iTZ = -7;

                //-8
                    else if (iState == 18 ||
                            iState == 74 ||
                            iState == 39 ||
                            iState == 31 ||
                            iState == 79)
                        iTZ = -8;

                //-9
                    else if (iState == 11 ||
                            iState == 20)
                        iTZ = -9;

                //-10
                    else if (iState == 2 ||
                            iState == 5 ||
                            iState == 14 ||
                            iState == 63)
                        iTZ = -10;
                    //-11
                    else if (iState == 59 ||
                            iState == 30 ||
                            iState == 89 ||
                            iState == 64)
                        iTZ = -11;

                //-12
                    else if (iState == 36 ||
                            iState == 44 ||
                            iState == 15 ||
                            iState == 26)
                        iTZ = -12;

                    else
                        iTZ = -4;



                    if (JulDayBirth > 2456956.500000)//new TZ and Permanent DST since 26 October 2014. All of Russia moved back one hour, except:
                    {

                        if (iState != 80 && //Udmurtia Oblast remained on UTC+04:00, (thus reinstating Samara Time, MSK+1)
                            iState != 65 && //Samara Oblast remained on UTC+04:00, (thus reinstating Samara Time, MSK+1)
                            iState != 29 && //Kemerovo Oblast remained on UTC+07:00 (went from Omsk to Krasnoyarsk Time)
                            iState != 15 && //Chukotka Autonomous Okrug remained on UTC+12:00 (thus reinstating Kamchatka Time, MSK+9)
                            iState != 26)  //Kamchatka Krai remained on UTC+12:00 (thus reinstating Kamchatka Time, MSK+9)
                            iTZ += 1;


                        if (iState == 14)//Zabaykalsky Krai moved back two hours to UTC+08:00 (went from Yakutsk to Irkutsk Time)
                            iTZ = -8;

                        if (iState == 44)//Magadan Oblast moved back two hours to UTC+10:00 (went from Magadan Time, MSK+8 to Vladivostok Time, MSK+7)
                            iTZ = -10;

                        if (TimeZoneTableNo == 75)//The parts of the Magadan Time zone that remained on MSK+8, were given a new time zone name, Srednekolymsk Time, UTC+11.
                            iTZ = -11;


                    }
                    Birth_TimeZone = Functions.DegDecimal_To_DegMinSec(iTZ, false, false);
                    return;
                }
                else
                {
                    State = chktz[0];
                }
            }
            string tz = "", tzp = "", dst = "", dstp = "";
            string str;

            if (!File.Exists(path))
            {
                Birth_TimeZone = tzp;
                Birth_DST = dstp;
                return;
            }
            StreamReader re = File.OpenText(path);

            while ((str = re.ReadLine()) != null)		//Get to the StateCode in the time Zone file....
            {
                str = Functions.Decrypt(str);
                str = str.Trim(); //to trim off the new line from str
                if (str.CompareTo(State) == 0)
                    break;
            }
            if (re.EndOfStream)
            {
                tzp = "?";
                dstp = "?";
                goto Fill;
            }
            DateTime birthDateTime = new DateTime(Birth_Year, Birth_Month, Birth_Day, Birth_Hour, Birth_Minute, Birth_Second);
            DateTime fileDateTime;
            TimeSpan dtdiff;
            double chktime;
            while ((str = re.ReadLine()) != null)
            {
                str = Functions.Decrypt(str);
                string[] chkdate = str.Split(',');

                fileDateTime = DateTime.Parse(chkdate[0].ToString().Trim());

                chkdate[1] = chkdate[1].Trim();
                chktime = Functions.DegMinSec_To_DegDecimal(chkdate[1]);
                if (chktime >= 24.0)
                {
                    fileDateTime = fileDateTime.AddDays(1.0);
                    chktime -= 24;
                    fileDateTime = fileDateTime.AddHours(chktime);
                }
                else
                    fileDateTime = fileDateTime.AddHours(chktime);

                dtdiff = fileDateTime.Subtract(birthDateTime);

                tz = chkdate[2].ToString().Trim();
                dst = chkdate[3].ToString().Trim();

                if (int.Parse(dtdiff.Days.ToString()) > 0)
                {
                    if (tzp == "" && dstp == "")	//if the userdate is <the min date available in the table, then LMT is considered
                    {
                        str = Longitude;
                        tzp = Functions.DegDecimal_To_DegMinSec(((Functions.DegMinSec_To_DegDecimal(str)) / 180.0 * 12) * (-1), true, false);
                    }
                    goto Fill;
                }

                if (str.Contains("<<"))
                {
                    tzp = tz;
                    int year = birthDateTime.Year;
                    int month = birthDateTime.Month;
                    int day = birthDateTime.Day;
                    int hour = birthDateTime.Hour;
                    int minute = birthDateTime.Minute;
                    int second = birthDateTime.Second;
                    double MJulDay = swedll.swe_julday(year, month, day, hour + minute / 60.0 + second / 3600.0, 1);

                    bool bDST = new_Get_DST(MJulDay, year, tz, dst);
                    if (bDST) dstp = "01:00";
                    else dstp = "00:00";

                    goto Fill;
                }
                else if (str.Contains("US"))
                {
                    tzp = tz;
                    goto USDST;
                }
                else if (str.Contains("C"))
                {
                    tzp = tz;
                    dstp = "0.00";
                    goto Fill;
                }
                else if (str.Contains("E"))
                {
                    tzp = tz;
                    dstp = "?";
                    goto Fill;
                }
                if (tz == "")
                {
                    tzp = "?";
                    dstp = "?";
                    goto Fill;
                }

                tzp = tz;
                dstp = dst;
            }
            if (re.EndOfStream)
            {
                tzp = "?";
                dstp = "?";
                goto Fill;
            }

        USDST:
            re.Close();
            re = File.OpenText(path);
            //re.BaseStream.Seek(0, SeekOrigin.Begin);
            //re.DiscardBufferedData();
            while ((str = re.ReadLine()) != null)
            {
                str = Functions.Decrypt(str);
                str = str.Trim(); //to trim off the new line from str
                if (str == dst)
                    break;
            }
            if (re.EndOfStream)
            {
                tzp = "?";
                dstp = "?";
                goto Fill;
            }

            while ((str = re.ReadLine()) != null)
            {
                str = Functions.Decrypt(str);
                string[] chkdate = str.Split(',');
                fileDateTime = DateTime.Parse(chkdate[0].ToString().Trim() + " 2:00");
                dtdiff = fileDateTime.Subtract(birthDateTime);
                dst = chkdate[1].Trim().ToString();
                dst = dst.Trim();

                if (str.Contains("<<"))
                {
                    tzp = tz;
                    int year = birthDateTime.Year;
                    int month = birthDateTime.Month;
                    int day = birthDateTime.Day;
                    int hour = birthDateTime.Hour;
                    int minute = birthDateTime.Minute;
                    int second = birthDateTime.Second;
                    double MJulDay = swedll.swe_julday(year, month, day, hour + minute / 60.0 + second / 3600.0, 1);

                    bool bDST = new_Get_DST(MJulDay, year, tz, dst);
                    if (bDST) dstp = "01:00";
                    else dstp = "00:00";

                    goto Fill;
                }
                else if (str.Contains("?"))
                {
                    dstp = dst;
                    goto Fill;
                }
                if (str.Contains("US"))
                    goto USDST;

                if (int.Parse(dtdiff.Days.ToString()) > 0)//if (JulDay >= JulDayUT)
                    goto Fill;
                dstp = dst;
            }


        Fill:
            tzp = tzp.Trim();
            dstp = dstp.Trim();
            if (String.IsNullOrEmpty(dstp))
                dstp = "0.00";

            Birth_TimeZone = tzp;
            Birth_DST = dstp;

            re.Close();

        }

        private double nthWeekDay(int Nth, int WeekDay, int Year, int Month)
        {
            Debug.Assert(WeekDay >= 1 && WeekDay <= 7);

            double sweDate = swedll.swe_julday(Year, Month + ((Nth <= 0) ? 1 : 0), 1, 0.0, 1);

            int fwd = swedll.swe_day_of_week(sweDate);   // first week day (Monday=0)
            fwd += 2;								//turn that into Sunday=1
            if (fwd > 7) fwd -= 7;

            int a = WeekDay - fwd;

            return sweDate + a + (Nth - ((a >= 0) ? 1 : 0)) * 7.0;
        }

        private bool new_Get_DST(double JulDay, int Year, string TZ, string DateCodeString)
        {
            double start, end;
            string str_start_nth, str_start_day, str_start_month, str_start_time, str_end_nth, str_end_day, str_end_month, str_end_time;

            DateCodeString = DateCodeString.Replace("<<", "");
            DateCodeString = DateCodeString.Replace(">>", "");

            ///start////////////////////////////////////////////////////////////

            string[] chkdate = DateCodeString.Split('*');
            str_start_nth = chkdate[0]; //Nth weekdy, if @ then it's a fixed date like in Syria
            str_start_nth = str_start_nth.Trim();

            str_start_day = chkdate[1];//Weekday from 1-7 for Sun-Sat; if Nth = false, then it is the date (eg 1-31) of the month
            str_start_day = str_start_day.Trim();

            str_start_month = chkdate[2];//Month from 1-12
            str_start_month = str_start_month.Trim();

            str_start_time = chkdate[3];//Time of the day locally eg 12:00
            str_start_time = str_start_time.Trim();

            int Start_Day = Convert.ToInt32(str_start_day);

            int Start_Month = Convert.ToInt32(str_start_month);

            double Start_Time;
            if (str_start_time.Contains("UTC"))
            {
                str_start_time = str_start_time.Replace("UTC", "");
                Start_Time = Functions.DegMinSec_To_DegDecimal(str_start_time);
                Start_Time -= Functions.DegMinSec_To_DegDecimal(TZ);
            }
            else
            {
                Start_Time = Functions.DegMinSec_To_DegDecimal(str_start_time);
            }

            int Start_Nth;
            if (str_start_nth == "@")//Nth weekday, if @ then it's a fixed date like in Syria
            {
                start = swedll.swe_julday(Year, Start_Month, Start_Day, Start_Time, 1);
                ////start = date(Year, Start_Month, Start_Day + );
                //start = nthWeekDay( 0, Start_Day, Year, Start_Month, 1 ) + Start_Time/24.0;
            }
            else
            {
                Start_Nth = Convert.ToInt32(str_start_nth);
                start = nthWeekDay(Start_Nth, Start_Day, Year, Start_Month) + Start_Time / 24.0;
            }

            ///end/////////////////////////////////////////////

            str_end_nth = chkdate[4]; //Nth weekday, if @ then it's a fixed date like in Syria
            str_end_nth = str_end_nth.Trim();

            str_end_day = chkdate[5];//Weekday from 1-7 for Sun-Sat; if Nth = false, then it is the date (eg 1-31) of the month
            str_end_day = str_end_day.Trim();

            str_end_month = chkdate[6];//Month from 1-12
            str_end_month = str_end_month.Trim();

            str_end_time = chkdate[7];//Time of the day locally eg 12:00
            str_end_time = str_end_time.Trim();

            int end_Day = Convert.ToInt32(str_end_day);

            int end_Month = Convert.ToInt32(str_end_month);

            double End_Time;
            if (str_end_time.Contains("UTC"))
            {
                str_end_time = str_end_time.Replace("UTC", "");
                End_Time = Functions.DegMinSec_To_DegDecimal(str_end_time);
                End_Time -= Functions.DegMinSec_To_DegDecimal(TZ);
                End_Time += 1;//in Fall (or DST ending date) add 1 hour
            }
            else
            {
                End_Time = Functions.DegMinSec_To_DegDecimal(str_end_time);
            }


            int end_Nth;
            if (str_end_nth == "@")//Nth weekday, if @ then it's a fixed date like in Syria
            {
                end = swedll.swe_julday(Year, end_Month, end_Day, End_Time, 1);
                ////end = date(Year, end_Month, end_Day + );
                //end = nthWeekDay( 0, end_Day, Year, end_Month, 1 ) + End_Time/24.0;
            }
            else
            {
                end_Nth = Convert.ToInt32(str_end_nth);
                end = nthWeekDay(end_Nth, end_Day, Year, end_Month) + End_Time / 24.0;
            }

            //////////////////////////////////////////////////

            if (start < end)
                return (start <= JulDay && JulDay < end);
            else
                return !(end <= JulDay && JulDay < start);   // not winter time.

        }
    }
}

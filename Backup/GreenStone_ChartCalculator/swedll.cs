using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Web;
using System.IO;

namespace GreenStone_ChartCalculator
{
    /// <summary>
    /// Errors found withitn the unmanaged Swiss Ephemeris Library
    /// </summary>
    public class SwephException : Exception
    {
        public string status;
        public SwephException()
            : base()
        {
            status = null;
        }
        public SwephException(string message)
        {
            status = message;
        }
    }
    public class swedll
    {
        //Lahiri
        public static int global_ayanamsa_mode = 1;
        public static bool global_tropical_rasis_sidereal_nakshatras = false;

        public static string global_folder_name = "Data";


        /*****************************************************************/

        public static int SE_SUN = 0;
        public static int SE_MOON = 1;
        public static int SE_MERCURY = 2;
        public static int SE_VENUS = 3;
        public static int SE_MARS = 4;
        public static int SE_JUPITER = 5;
        public static int SE_SATURN = 6;
        public static int SE_URANUS = 7;
        public static int SE_NEPTUNE = 8;
        public static int SE_PLUTO = 9;
        public static int SE_MEAN_NODE = 10;
        public static int SE_TRUE_NODE = 11;
        public static int SE_CHIRON = 15;

        public static int SEFLG_SPEED = 256;
        public static int SEFLG_SIDEREAL = 64 * 1024;
        public static int SEFLG_EQUATORIAL = 2 * 1024;
        public static int SEFLG_SWIEPH = 2;

        public static int SE_CALC_RISE = 1;
        public static int SE_CALC_SET = 2;
        public static int SE_CALC_MTRANSIT = 4;
        public static int SE_CALC_ITRANSIT = 8;
        public static int SE_BIT_DISC_CENTER = 256;
        public static int SE_BIT_NO_REFRACTION = 512;

        [DllImport("swedll32", CharSet = CharSet.Ansi)]
        public extern static void swe_set_ephe_path(string path);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_set_sid_mode")]
        public extern static void swe_set_sid_mode(int sid_mode, double t0, double ayan_t0);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_julday")]
        public extern static double swe_julday(int year, int month, int day, double hour, int gregflag);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_revjul")]
        public extern static double swe_revjul(double tjd, int gregflag, ref int year, ref int month, ref int day, ref double hour);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_calc_ut")]
        private extern static int xyz_swe_calc_ut(double tjd_ut, int ipl, int iflag, double[] xx, StringBuilder serr);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_close")]
        public extern static int swe_close();

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_houses_ex")]
        public extern static int swe_houses_ex(double tjd_ut, int iflag, double lat, double lon, int hsys, double[] cusps, double[] ascmc);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_rise_trans")]
        private extern static int xyz_swe_rise_trans(double tjd_ut, int ipl, string starname, int epheflag, int rsmi, double[] geopos, double atpress, double attemp, ref double tret, StringBuilder serr);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_day_of_week")]
        public extern static int swe_day_of_week(double jd);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_fixstar_ut")]
        private extern static int xyz_swe_fixstar_ut(string star, double tjd_ut, int iflag, double[] xx, StringBuilder serr);

        [DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_house_pos")]
        public extern static double xyz_swe_house_pos(double armc, double lat, double eps, int hsys, double[] xpin, StringBuilder serr);

        public static void swe_calc_ut(double tjd_ut, int ipl, int iflag, double[] xx)
        {
            StringBuilder serr = new StringBuilder(256);
            int ret = xyz_swe_calc_ut(tjd_ut, ipl, iflag, xx, serr);
            if (ret < 0)
            {
                //Response.Write("Sweph Error: " + serr);
                throw new SwephException(serr.ToString());
            }
        }

        public static double swe_house_pos(double armc, double lat, double eps, int hsys, double[] xpin)
        {
            StringBuilder serr = new StringBuilder(256);
            double ret = xyz_swe_house_pos(armc, lat, eps, hsys, xpin, serr);
            return ret;
        }

        public static void Calculate_Planets(string Path, double tjd_ut, double dLatitude, double dLongitude, double[] planet_deg, out double lagna_deg, int[] planet_ret)
        {
            double[] arr = new Double[6] { 0, 0, 0, 0, 0, 0 };
            int Flag = SEFLG_SPEED;
            double SunTropical;
            swe_calc_ut(tjd_ut, SE_SUN, Flag, arr);
            SunTropical = arr[0];

            //swe_set_sid_mode(global_ayanamsa_mode, global_ayanamsa_date, Functions.DegMinSec_To_DegDecimal(global_ayanamsa_degrees));
            swe_set_sid_mode(1, 0, 0);
            Flag = SEFLG_SIDEREAL | SEFLG_SPEED;

            swe_calc_ut(tjd_ut, SE_SUN, Flag, arr);
            planet_deg[0] = planet_deg[0] = arr[0];

            swe_calc_ut(tjd_ut, SE_MOON, Flag, arr);
            planet_deg[1] = planet_deg[1] = arr[0];

            swe_calc_ut(tjd_ut, SE_MARS, Flag, arr);
            planet_deg[2] = planet_deg[2] = arr[0];
            if (arr[3] < 0)
                planet_ret[0] = -1;

            swe_calc_ut(tjd_ut, SE_MERCURY, Flag, arr);
            planet_deg[3] = planet_deg[3] = arr[0];
            if (arr[3] < 0)
                planet_ret[1] = -1;

            swe_calc_ut(tjd_ut, SE_JUPITER, Flag, arr);
            planet_deg[4] = planet_deg[4] = arr[0];
            if (arr[3] < 0)
                planet_ret[2] = -1;

            swe_calc_ut(tjd_ut, SE_VENUS, Flag, arr);
            planet_deg[5] = planet_deg[5] = arr[0];
            if (arr[3] < 0)
                planet_ret[3] = -1;

            swe_calc_ut(tjd_ut, SE_SATURN, Flag, arr);
            planet_deg[6] = planet_deg[6] = arr[0];
            if (arr[3] < 0)
                planet_ret[4] = -1;

            swe_calc_ut(tjd_ut, SE_MEAN_NODE, Flag, arr);
            planet_deg[7] = planet_deg[7] = arr[0];
            planet_deg[8] = arr[0] + 180;
            if (planet_deg[8] > 360)
                planet_deg[8] -= 360;
            planet_deg[8] = planet_deg[8];

            swe_calc_ut(tjd_ut, SE_URANUS, Flag, arr);
            planet_deg[9] = arr[0];
            if (arr[3] < 0)
                planet_ret[5] = -1;

            swe_calc_ut(tjd_ut, SE_NEPTUNE, Flag, arr);
            planet_deg[10] = arr[0];
            if (arr[3] < 0)
                planet_ret[6] = -1;

            swe_calc_ut(tjd_ut, SE_PLUTO, Flag, arr);
            planet_deg[11] = arr[0];
            if (arr[3] < 0)
                planet_ret[7] = -1;

            swe_calc_ut(tjd_ut, SE_CHIRON, Flag, arr);
            planet_deg[12] = arr[0];

            planet_deg[13] = (Calculate_XY(tjd_ut, "X", Path) * 30) - 20;//x
            planet_deg[14] = (Calculate_XY(tjd_ut, "Y", Path) * 30) - 20;//y
            planet_deg[15] = Calculate_Asteroid(tjd_ut, "2008 FC76", Path);//z

            //calculate ayanamsa
            double d = SunTropical;
            if (d < planet_deg[0]) d = 360 + d - planet_deg[0];
            else d = d - planet_deg[0];

            //Apply ayanamsa to Z
            planet_deg[15] -= d;
            if (planet_deg[15] < 0)
                planet_deg[15] += 360;

            //Pluto changes GS wanted:
            //GS: On 27th Aug 1700 Pluto entered Leo. The end date is the same in Sept 1720 as in the original software.
            //Srishti: 2342210.84362268 is 27/9/1700 , Between this date and Aug 8 1706 ( 2344382.8436226854 ) I am making the Pluto stay at 1 degree Leo.
            if (tjd_ut >= 2342210.84362268 && tjd_ut <= 2344382.8436226854)
                planet_deg[11] = 121;

            //GS: On 30th Sep 1742 Pluto enters Scorpio. The end date is the same in Dec 1758 as in the original software. 
            //Srishti: 2357584.7610763889 is 30/9/1742 , Between this date and  1745/Nov/8 ( 2358719.7610763889 ) I am making the Pluto stay at 1 degree Scorpio.
            if (tjd_ut >= 2357584.7610763889 && tjd_ut <= 2358719.7610763889)
                planet_deg[11] = 211;

            //GS: On 23rd Aug 1948 Pluto enters Leo. The end date is almost the same in Sept 1968.
            //Srishti: 2432786.75 is 23/8/1948 , Between this date and 1954/aug/8 ( 2434962.75 ) I am making the Pluto stay at 1 degree Leo.
            if (tjd_ut >= 2432786.75 && tjd_ut <= 2434962.75)
                planet_deg[11] = 121;

            //GS: On 27th Nov 1989 Pluto enters Scorpio. The end date is the same as in original software.
            //Srishti: 2447857.75 is 27/9/1700 , Between this date and 1993/Nov/3 ( 2449294.75 ) I am making the Pluto stay at 1 degree Scorpio.
            if (tjd_ut >= 2447857.75 && tjd_ut <= 2449294.75)
                planet_deg[11] = 211;


            //Uranus changes GS wanted:
            //GS: Uranus entered Aquarius in 1917 April but it goes retrograde in the later part of the year and re-enters Aquarius only in 1918. But I want no retrogression and Uranus should remain in Aquarius till 1917. Can this be done as you done with Pluto earlier.
            //Srishti:  2421327.75 is Apr/9/1917 , Between this date and Feb/13/1918 ( 2421637.75 ) I am making the Uranus stay at 1 degree Aquarius.
            if (tjd_ut >= 2421327.75  && tjd_ut <= 2421637.75 )
                planet_deg[9] = 301;

            //GS: Similarly in 1980 in few of the months, Uranus moves into Libra retrograde after having entered Scorpio in late 1979. Kindly ensure that Uranus remains in Scorpio throughout 1980 as you have done with Pluto in Leo and Scorpio.
            //Srishti:  2444230.75 is Dec/23/1979 , Between this date and Oct/28/1980 ( 2444540.75 ) I am making the Uranus stay at 1 degree Scorpio.
            if (tjd_ut >= 2444230.75 && tjd_ut <= 2444540.75)
                planet_deg[9] = 211;


            double[] HC = new Double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] AscMC = new Double[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Flag = SEFLG_SIDEREAL;

            swe_houses_ex(tjd_ut, Flag, dLatitude, dLongitude, 'V', HC, AscMC);
            lagna_deg = lagna_deg = AscMC[0];



        }
 
        private double Calculate_Lagna(double JulDayUT, double dLatitude, double dLongitude)
        {
            int Flag = SEFLG_SIDEREAL;
            double[] HouseCusps = new Double[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] AscMC = new Double[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            swe_houses_ex(JulDayUT, Flag, dLatitude, dLongitude, 'V', HouseCusps, AscMC);
            return AscMC[0];
        }

        private static double Calculate_Asteroid(double JulDayUT, string Asteroid_Name, string Path)
        {
	        string str;

	        double JulDay=0;
	        string lon="", lonp="";
	        bool Fill = false;
            if (Asteroid_Name == "1999 JV127")//Y
                if (JulDayUT >= 2378496.500000000 && JulDayUT < 2415020.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\1999_JV127_1800-1900.txt";
                else if (JulDayUT >= 2415020.500000000 && JulDayUT < 2451544.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\1999_JV127_1900-2000.txt";
                else if (JulDayUT >= 2451544.500000000 && JulDayUT < 2525008.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\1999_JV127_2000-2201.txt";
                else
                    return 0;

            else if (Asteroid_Name == "2007 RH283")//X
                if (JulDayUT >= 2378496.500000000 && JulDayUT < 2415020.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\2007_RH283_1800-1900.txt";
                else if (JulDayUT >= 2415020.500000000 && JulDayUT < 2451544.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\2007_RH283_1900-2000.txt";
                else if (JulDayUT >= 2451544.500000000 && JulDayUT < 2525008.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\2007_RH283_2000-2201.txt";
                else
                    return 0;

            else if (Asteroid_Name == "2008 FC76")//Z
                if (JulDayUT >= 2378496.500000000 && JulDayUT < 2415020.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\2008_FC76_1800-1900.txt";
                else if (JulDayUT >= 2415020.500000000 && JulDayUT < 2451544.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\2008_FC76_1900-2000.txt";
                else if (JulDayUT >= 2451544.500000000 && JulDayUT < 2525008.500000000)
                    Path += "\\NasaHorizon_AsteroidFiles\\2008_FC76_2000-2201.txt";
                else
                    return 0;

            else
                return 0;


            if (!File.Exists(Path))
            {
		        return 0;
	        }
            StreamReader re = File.OpenText(Path);

            while ((str = re.ReadLine()) != null)		//Get to the $$SOE in the asteroid file....
	        {
                str = str.Trim(); //to trim off the new line from str
                if (str.CompareTo("$$SOE") == 0)
                    break;

	        }
            if (re.EndOfStream)
	        {
                re.Close(); 
                return 0;
	        }
            while ((str = re.ReadLine()) != null)
	        {
                str = str.Trim(); //to trim off the new line from str
                if (str.CompareTo("$$EOE") == 0)
		        {
                    re.Close();
			        return 0;
		        }

                string[] chkdate = str.Split(',');

                str = chkdate[1].Trim();
                JulDay = Convert.ToDouble(str);

                lon = chkdate[6].Trim();
        		
		        if( JulDay > JulDayUT )
		        {
			        Fill = true;
			        break;
		        }

		        lonp = lon;
	        }
            if (re.EndOfStream)
            {
                re.Close();
                return 0;
	        }

	        double degrees=0;

	        if(Fill)
	        {
		        lonp.Trim();	if( String.IsNullOrEmpty(lonp))	lonp = "0";
                lon.Trim();     if (String.IsNullOrEmpty(lon)) lon= "0";
        		

		        double dLonp= Convert.ToDouble(lonp) ; 
		        double dLon= Convert.ToDouble(lon) ; 
		        double Frac = JulDayUT - (JulDay -1);//fraction of ay past since the beginning of the previous day to JuldayUT
		        if( dLonp >330 && dLon <30 )//ar-pi junction
		        {
			        degrees = dLonp + ((dLon+360-dLonp)/Frac);
			        if( degrees > 360 ) degrees -=360;
		        }
		        else if( dLon >300 && dLonp < 10 ) //ar-pi junction retrograde
		        {
			        degrees = dLonp - (( dLonp+360-dLon)/Frac);
			        if( degrees < 0 )	degrees +=360;
		        }
		        else
		        {
			        degrees = dLonp + ((dLon-dLonp)/Frac);
		        }
	        }
	        re.Close();
	        return degrees;

        }

        private static int Calculate_XY(double JulDayUT, string Asteroid_Name, string Path)
        {
            string str;

	        double JulDay=0;
	        string sign="";
	        bool Fill = false;
	        if( Asteroid_Name=="X")//X
		        Path += "\\PlanetsXY\\PlanetX.txt";
	        else if( Asteroid_Name=="Y")//Y
		        Path += "\\PlanetsXY\\PlanetY.txt";
	        else
		        return 0;

            if (!File.Exists(Path))
            {
                return 0;
            }
            StreamReader re = File.OpenText(Path);

            while ((str = re.ReadLine()) != null)
	        {
                str = str.Trim(); //to trim off the new line from str
                string[] chkdate = str.Split(',');

                str = chkdate[1].Trim();
                JulDay = Convert.ToDouble(str);


                sign = chkdate[2].Trim();
        		
		        if( JulDay > JulDayUT )
		        {
			        Fill = true;
			        break;
		        }

	        }
            if (re.EndOfStream)
            {
                re.Close();
                return 0;
            }

	        int iSign=0;
	        if(Fill)
	        {
		        sign.Trim();    if( String.IsNullOrEmpty(sign))	sign = "0";
		        iSign= Convert.ToInt32(sign) ; 
	        }
            re.Close();
            return iSign;

        }


    }
}

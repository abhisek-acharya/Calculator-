using System;
using System.IO;

namespace GreenStone_ChartCalculator
{
    public partial class Atlas : System.Web.UI.Page
    {
        public string Name
        {
            get
            {
                return nameLabel.Text;
            }
        }
        public string Year
        {
            get
            {
                return yearLabel.Text;
            }
        }
        public string Month
        {
            get
            {
                return monthLabel.Text;
            }
        }
        public string Day
        {
            get
            {
                return dayLabel.Text;
            }
        }
        public string Hour
        {
            get
            {
                return hourLabel.Text;
            }
        }
        public string Minute
        {
            get
            {
                return minuteLabel.Text;
            }
        }
        public string Second
        {
            get
            {
                return secondLabel.Text;
            }
        }
        public string Country
        {
            get
            {
                return countryLabel.Text;
            }
        }
        public string City
        {
            get
            {
                return cityDropDown.Text;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                backButton.Attributes.Add("onclick", "javascript: history.go(-1); return false;");
                SaveData();
            }
        }
        private void SaveData()
        {
            try
            {

                //Access public properties directly on strongly typed Default.aspx.
                nameLabel.Text = PreviousPage.Name;
                monthLabel.Text = PreviousPage.Month;
                dayLabel.Text = PreviousPage.Day;
                yearLabel.Text = PreviousPage.Year;
                hourLabel.Text = PreviousPage.Hour;
                minuteLabel.Text = PreviousPage.Minute;
                secondLabel.Text = PreviousPage.Second;
                countryLabel.Text = PreviousPage.Country;

                FillDropDownCity();
            }
            catch (NullReferenceException nre)
            {
                Response.Write("\nSome error occurred while processing your request. \nYou can go back and try again or use a differnt internet browser.\n Sorry for the inconvenience" + nre.Message);

                //Google Chrome keeps somehow emptying the fields randomly, while IE worked fine!
            }
        }
        private void FillDropDownCity()
        {
            string CityText = PreviousPage.City.Trim().ToLower();
            string Country = PreviousPage.Country;
            string strpath = Server.MapPath(swedll.global_folder_name + @"\Atlas\") + Country + ".txt";
            using (StreamReader atlasfile = File.OpenText(strpath))
            {
                string atlasstring, str;
                int i = 0;
                bool read = false;
                atlasstring = atlasfile.ReadLine();
                atlasstring = Functions.Decrypt(atlasstring);
                int length = 0;
                while ((atlasstring = atlasfile.ReadLine()) != null)
                {
                    atlasstring = Functions.Decrypt(atlasstring);
                    length = CityText.Length;
                    if (atlasstring.Length < length)
                        length = atlasstring.Length;
                    str = atlasstring.Substring(0, length).ToLower();



                    //if( string.Compare(str, CityText, true, new CultureInfo("en-US")/*CultureInfo.InvariantCulture*/) >= 0 )
                    if (string.CompareOrdinal(str, CityText) >= 0)
                    {
                        read = true;
                    }
                    //if( str.CompareTo(CityText) >= 0 )
                    //{
                    //}
                    if (read && i < 50)
                    {
                        cityDropDown.Items.Add(atlasstring);
                        i++;
                    }
                }
            }
        }
    }
}

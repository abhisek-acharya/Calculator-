using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenStone_ChartCalculator
{
    public partial class Welcome : System.Web.UI.Page
    {
        public string Name
        {
            get
            {
                return nameTextBox.Text;
            }
        }
        public string Year
        {
            get
            {
                return yearTextBox.Text;
            }
        }
        public string Month
        {
            get
            {
                return monthDropDown.Text;
            }
        }
        public string Day
        {
            get
            {
                return dayDropDown.Text;
            }
        }
        public string Hour
        {
            get
            {
                return hourDropDown.Text;
            }
        }
        public string Minute
        {
            get
            {
                return minuteDropDown.Text;
            }
        }
        public string Second
        {
            get
            {
                return secondDropDown.Text;
            }
        }
        public string Country
        {
            get
            {
                return countryDropDown.Text;
            }
        }
        public string City
        {
            get
            {
                return cityTextBox.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void reset_Click(object sender, EventArgs e)
        {
            ResetFormControlValues(this);
        }
        private void ResetFormControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)c).SelectedIndex = 0;
                            break;

                    }
                }
            }
        }
   }
}

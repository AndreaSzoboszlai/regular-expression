using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Input_validation
{
    public partial class inputValidator : Form
    {
        public inputValidator()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(nameBox.Text);
            if (!ValidName(nameBox.Text))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
            }

            if (!ValidPhone(phoneBox.Text))
            {
                MessageBox.Show("The phone number is not a valid US phone number");
            }

            if (!ValidEmail(emailBox.Text))
            {
                MessageBox.Show("The e-mail address is not valid.");
            }
            phoneBox.Text = ReformatPhone(phoneBox.Text);
        }

        public bool ValidName(String name)
        {
            string nameP = "[a-zA-Z]+";
            string whitespace = @"\s";
            string pattern = "^(" + nameP + whitespace + "*)+$";
            if (Regex.IsMatch(name, pattern))
            {
                return true;
            }
            return false;
        }

        public bool ValidPhone(String phone)
        {
            string matchThreeNum = @"\d{3}";
            string matchFourNum = @"\d{4}";
            string pattern = "^(((" + matchThreeNum + ")?)|(" + matchThreeNum + "-))?" + matchThreeNum + "-" + matchFourNum + "$";
            if (Regex.IsMatch(phone, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$"))
            {
                return true;
            }
            return false;
        }

        public bool ValidEmail(String email)
        {
            if (Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                return true;
            }
            return false;
        }

        private string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
            Console.WriteLine(m.Value + " : " + m.Groups[1]);
            return String.Format("({0}) {1}-{2}",  m.Groups[1], m.Groups[2], m.Groups[3]);
        }

        private void ReformatPhoneNum_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ReformatPhone(phoneBox.Text));
            phoneBox.Text = ReformatPhone(phoneBox.Text);
        }
    }
}

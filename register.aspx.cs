using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.Odbc;

namespace FoodHarbor
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings: UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Email = txtEmail.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            //Database
            if (PasswordPolicy.IsPasswordValid(Password))
            {
                string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source =F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";
                using (OleDbConnection conn = new OleDbConnection(conString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Users ([Username], [Email], [Password], [FirstName], [Surname]) VALUES (@Username, @Email, @Password, @FirstName, @Surname)";
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@FirstName", Name);
                        cmd.Parameters.AddWithValue("@Surname", Surname);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                lblPassword.Text = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit and Special character.";
                lblPassword.ForeColor = System.Drawing.Color.Red;
            }

            //Once successful send to Login page to login
            Response.Redirect("login.aspx");
        }

        public class PasswordPolicy
        {
            public static bool IsPasswordValid(string password)
            {
                if (password.Length < 8) //Password Must not be less than 8 characters 
                {
                    return false;
                }
                if (!password.Any(char.IsUpper)) //Must have atleast 1 uppercase
                {
                    return false;
                }
                if (!password.Any(char.IsLower)) //Must have atleast 1 lower
                {
                    return false;
                }
                if (!password.Any(char.IsDigit)) //Must have atleast 1 digit
                {
                    return false;
                }
                if (!password.Any(c => char.IsLetterOrDigit(c))) //Must have atleast 1 special character
                {
                    return false;
                }
                return true; //If above do not trigger than its a valid password
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Web.Security;

namespace FoodHarbor
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        ValidationSettings: UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;

            if (IsValidUser(user, password))
            {
                HttpCookie loginCookie = new HttpCookie(user, "true");
                Response.Cookies.Add(loginCookie);
                Session["Username"] = user;
                Response.Redirect("profile.aspx");
            }
            else
            {
                lblError.Text = "Invalid Username/Email or Password";
                lblError.Visible = true;
            }
        }

        private bool IsValidUser(string name, string password)
        {
            bool isValid = false;
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string selectQuery = "SELECT count(*) FROM Users WHERE (Username = @Username OR Email = @Email) AND Password = @Password";
                using (OleDbCommand cmd = new OleDbCommand(selectQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", name);
                    cmd.Parameters.AddWithValue("@Email", name);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar();
                    isValid = (count > 0);
                }
            }

            return isValid;
        }
    }
}
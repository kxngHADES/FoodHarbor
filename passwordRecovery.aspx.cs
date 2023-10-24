using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace FoodHarbor
{
    public partial class passwordRecovery : System.Web.UI.Page
    {
        
        public string claim = "SELECT Question FROM Recovery WHERE Username = @Username OR Email = @Email";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;

            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                conn.Open();
                string selectQuery = "SELECT count(*) From Recovery WHERE Username = @Username OR Email = @Email";
                using (OleDbCommand cmd = new OleDbCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user);
                    cmd.Parameters.AddWithValue("@Email", user);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        lblQuestion.Visible = true;
                        txtAnswer.Visible = true;
                        lblUser.Visible = false;
                        txtUser.Visible = false;
                        btnAnswer.Visible = true;
                        btnCheck.Visible = false;

                        string claim = "SELECT Question FROM Recovery WHERE Username = @Username OR Email = @Email";
                        using (OleDbCommand cmdget = new OleDbCommand(claim, conn))
                        {
                            cmdget.Parameters.AddWithValue("@Username", user);
                            cmdget.Parameters.AddWithValue("@Email", user);

                            object result = cmdget.ExecuteScalar();
                            if (result != null)
                            {
                                lblQuestion.Text = result.ToString();
                            }
                            else
                            {
                                lblQuestion.Text = "Question not found.";
                            }
                        }
                    }
                    else
                    {
                        lblUser.Text = "Invalid Username or Email";
                        lblUser.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }

        }

        protected void btnAnswer_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string answer = txtAnswer.Text;

            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                conn.Open();
                string selectQuery = "SELECT count(*) FROM Recovery WHERE Email = @Email OR Username = @Username AND Answer = @Answer";
                using (OleDbCommand cmd = new OleDbCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user);
                    cmd.Parameters.AddWithValue("@Email", user);
                    cmd.Parameters.AddWithValue("@Answer", answer);

                    object result = cmd.ExecuteScalar();
                    int count = (int)result;
                    if (count > 0)
                    {
                        lblQuestion.Visible = false;
                        txtAnswer.Visible = false;
                        btnAnswer.Visible = false;

                        lblPassword.Visible = true;
                        txtPassword.Visible = true;
                        btnPassword.Visible = true;
                    }
                    else
                    {
                        lblQuestion.Text = "Incorrect Answer";
                        lblQuestion.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;
            if (PasswordPolicy.IsPasswordValid(password))
            {
                string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

                using (OleDbConnection conn = new OleDbConnection(conString))
                {
                    
                    string updateQuery = "Update Users SET Password = @Password WHERE Email = @Email OR Username = @Username";
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user);
                        cmd.Parameters.AddWithValue("@Email", user);
                        cmd.Parameters.AddWithValue("@Password", password);
                        conn.Open();

                        Response.Redirect("login.aspx");

                    }
                }
            }
            else
            {
                lblPassword.Text = "Invalid password, password must be atleast 8 characters long, have 1 special character and 1 upper and lower case and a numeric value";
                lblPassword.ForeColor = System.Drawing.Color.Red;
            }
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
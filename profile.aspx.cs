using System;
using System.Data;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.Caching;

namespace FoodHarbor
{
    public partial class profile : System.Web.UI.Page
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                string username = Session["Username"].ToString();
                txtUsername.Text = username;

                string selectQuery = "SELECT Username, Email, FirstName, Surname FROM Users WHERE Username = @Username";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["FirstName"].ToString();
                                txtSurname.Text = reader["Surname"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                            }
                        }
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;

            string updateQuery = "UPDATE Users SET FirstName = @Name, Surname = @Surname, Email = @Email";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Name",name);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Close();
                    Response.Redirect("profile.aspx"); //Reload this page
                }
            }

        }
    }
}

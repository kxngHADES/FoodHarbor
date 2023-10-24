using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace FoodHarbor
{
    public partial class question : System.Web.UI.Page
    {
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string username = Session["Username"].ToString();
                string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";
                using (OleDbConnection conn = new OleDbConnection(conString))
                {
                    string selectQuery = "SELECT Username, Question, Answer FROM Recovery WHERE Username = @Username";
                    using (OleDbCommand cmd = new OleDbCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        conn.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtQuestion.Text = reader["Question"].ToString();
                                txtAnswer.Text = reader["Answer"].ToString();
                                txtAnswer.Enabled = false;
                                txtQuestion.Enabled = false;
                                btnSave.Enabled = false;
                            }
                        }
                    }
                    string slecter = "SELECT Username, Email FROM Users WHERE Username = @Username";
                    using (OleDbCommand command = new OleDbCommand(slecter, conn))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        object result = command.ExecuteScalar();
                        email = result.ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text;
            string answer = txtAnswer.Text;
            string username = Session["Username"].ToString();
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";
            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                string insert = "INSERT INTO Recovery ([Question], [Answer], [Username], [Email]) VALUE (@Question, @Answer, @Username, @Email)";
                using (OleDbCommand cmd = new OleDbCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@Question", question);
                    cmd.Parameters.AddWithValue("@Answer", answer);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    Response.Redirect("profile.aspx");

                }
            }
        }
    }
}
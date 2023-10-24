using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using FoodHarbor.RecipeService;
using System.Web.SessionState;

namespace FoodHarbor
{
    public partial class recipeSubmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();
            string recipeName = txtName.Text;
            string Ingredients = txtList.Text;
            string method = txtMethod.Text;


            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Recipes (RecipeName, Ingredients, Method, Username) VALUES (@RecipeName, @Ingredients, @Method, @Username)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RecipeName", recipeName);
                    cmd.Parameters.AddWithValue("@Ingredients", Ingredients);
                    cmd.Parameters.AddWithValue("@Method", method);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int rowsA = cmd.ExecuteNonQuery();
                    if (rowsA > 0)
                    {
                        txtName.Enabled = false;
                        txtList.Enabled = false;
                        txtMethod.Enabled = false;
                        txtList.ForeColor = System.Drawing.Color.Green;
                        txtName.ForeColor = System.Drawing.Color.Green;
                        txtMethod.ForeColor = System.Drawing.Color.Green;

                        lblHeading.ForeColor = System.Drawing.Color.Green;
                        lblHeading.Text = "Submitted Successfully";
                    }
                }
            }
        }
    
    }
}
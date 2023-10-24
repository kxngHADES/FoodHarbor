using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodHarbor
{
    public partial class EditRecipe : System.Web.UI.Page
    {

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RecipeID"] != null)
                {
                    int RecipeID = Convert.ToInt32(Request.QueryString["RecipeID"]);
                    // Load recipe details based on RecipeID
                    LoadRecipeDetails(RecipeID);
                }
                else
                {
                    Response.Redirect("userRecipers.aspx");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["RecipeID"] != null)
            {
                string name = txtRecipeName.Text;
                string ingred = txtIngredients.Text;
                string method = txtMethod.Text;
                int RecipeID = Convert.ToInt32(Request.QueryString["RecipeID"]);
                // Update recipe details in the database
                try
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE Recipes SET [RecipeName] = @RecipeName, [Ingredients] = @Ingredients, [Method] = @Method WHERE [RecipeID] = @RecipeID";
                        using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@RecipeID", RecipeID);
                            command.Parameters.AddWithValue("@RecipeName", name);
                            command.Parameters.AddWithValue("@Ingredients", ingred);
                            command.Parameters.AddWithValue("@Method", method);
                            Response.Redirect("userRecipers.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error........ " + ex.Message);
                }
            }
        }

        private void LoadRecipeDetails(int RecipeID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT RecipeName, Ingredients, Method FROM Recipes WHERE RecipeID = @RecipeID";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Load recipe details into the form controls
                            txtRecipeName.Text = reader["RecipeName"].ToString();
                            txtIngredients.Text = reader["Ingredients"].ToString();
                            txtMethod.Text = reader["Method"].ToString();
                        }
                        else
                        {
                            // Recipe not found, redirect to user recipes page
                            Response.Redirect("userRecipers.aspx");
                        }
                    }
                }
            }
        }
    }
}

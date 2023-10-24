using System;
using System.Data;
using System.Data.OleDb;

namespace FoodHarbor
{
    public partial class recipeDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecipeDetails();
            }
        }

        private void LoadRecipeDetails()
        {
            int recipeId = Convert.ToInt32(Request.QueryString["RecipeID"]);
            DataTable recipeData = GetRecipeDetailsFromDatabase(recipeId);

            if (recipeData.Rows.Count > 0)
            {
                lblRecipeName.Text = recipeData.Rows[0]["RecipeName"].ToString();
                lblDescription.Text = recipeData.Rows[0]["Description"].ToString();
                // Populate other details here.
            }
        }

        private DataTable GetRecipeDetailsFromDatabase(int recipeId)
        {
            DataTable recipeData = new DataTable();
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT RecipeName, Description FROM Recipes WHERE RecipeID = @RecipeID";
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@RecipeID", recipeId);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(recipeData);
                    }
                }
            }
            return recipeData;
        }
    }
}

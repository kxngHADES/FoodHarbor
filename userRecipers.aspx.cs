using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Services;
using System.Configuration;
using FoodHarbor.RecipeService;

namespace FoodHarbor
{
    public partial class userRecipers : System.Web.UI.Page
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRecipesGrid();
            }
        }
        [WebMethod]
        public static void UpdateRecipe(int RecipeID, string recipeName, string ingredients, string method)
        {
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";
            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand("UPDATE Recipes SET RecipeName = @RecipeName, Ingredients = @Ingredients, Method = @Method WHERE RecipeID = @RecipeID", conn))
                {
                    cmd.Parameters.AddWithValue("@RecipeID", RecipeID);
                    cmd.Parameters.AddWithValue("@RecipeName", recipeName);
                    cmd.Parameters.AddWithValue("@Ingredients", ingredients);
                    cmd.Parameters.AddWithValue("@Method", method);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetRecipe(string username)
        {
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=F:\Advanced C# Project\FoodHarbor\FoodHarbor.accdb";
            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                conn.Open();
                string query = "SELECT RecipeID, RecipeName, Ingredients, Method FROM Recipes WHERE Username = @Username";
                using (OleDbCommand command = new OleDbCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    DataTable dt = new DataTable();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public void BindRecipesGrid()
        {
            string username = Session["Username"].ToString();

            if (!string.IsNullOrEmpty(username))
            {
                DataTable dt = GetRecipe(username);

                GridViewRecipes.DataSource = dt;
                GridViewRecipes.DataBind();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        private void DeleteFromData(int RecipeID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Recipes WHERE RecipeID = @RecipeID";
                using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    command.ExecuteNonQuery();
                }
            }
        }
        protected void GridViewRecipes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int RecipeID = Convert.ToInt32(GridViewRecipes.DataKeys[e.RowIndex].Value);

            DeleteFromData(RecipeID);

            BindRecipesGrid();
        }

        protected void GridViewRecipes_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int RecipeID = Convert.ToInt32(GridViewRecipes.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditRecipe.aspx?RecipeID={RecipeID}");
        }

    }

}

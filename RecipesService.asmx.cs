using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Web.Services;
namespace FoodHarbor
{
    [WebService(Namespace = "http://foodharbor.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class RecipesService : WebService
    {

        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FoodHarborDbConnection"].ToString();

        private Logs logger;

        public RecipesService()
        {
            logger = new Logs(connectionString);
        }

        [WebMethod]
        public List<Recipe> GetRecipes()
        {
            logger.LogEvent("GetRecipes", "User retrieved recipes from the database.");

            List<Recipe> recipes = new List<Recipe>();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FoodHarborDbConnection"].ToString();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT RecipeID, RecipeName, Ingredients, Method FROM Recipes";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Recipe recipe = new Recipe
                        {
                            RecipeID = Convert.ToInt32(reader["RecipeID"]),
                            RecipeName = reader["RecipeName"].ToString(),
                            Ingredients = reader["Ingredients"].ToString(),
                            Method = reader["Method"].ToString()
                        };

                        recipes.Add(recipe);
                    }

                    reader.Close();
                }
            }

            return recipes;
        }

        [WebMethod]
        public void AddRecipe(string recipeName, string ingredients, string method, string username)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "INSERT INTO Recipes (RecipeName, Ingredients, Method) VALUES (@RecipeName, @Ingredients, @Method) WHERE Username = @Username";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeName", recipeName);
                        command.Parameters.AddWithValue("@Ingredients", ingredients);
                        command.Parameters.AddWithValue("@Method", method);
                        command.Parameters.AddWithValue("@Username", username);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Log the event
                logger.LogEvent("AddRecipe", $"User added a new recipe: {recipeName}");

                // return a success message if the recipe is added successfully
                Context.Response.Write("Recipe added successfully!");
            }
            catch (Exception ex)
            {
                // Log the error if an exception occurs
                logger.LogEvent("Error", $"Error occurred while adding a recipe: {ex.Message}");
                throw;
            }
        }


        public class Recipe
        {
            public int RecipeID { get; set; }
            public string RecipeName { get; set; }
            public string Ingredients { get; set; }
            public string Method { get; set; }
        }
    }
}

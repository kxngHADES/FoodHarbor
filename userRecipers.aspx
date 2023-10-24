<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userRecipers.aspx.cs" Inherits="FoodHarbor.userRecipers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <!--Head-->
                    <div class="row">
                        <div class ="col">
                            <h1>My Recipes</h1>
                            <hr />
                        </div>
                    </div>

                    <div class =" row">
                        <div class="col">
                            <asp:GridView ID="GridViewRecipes" runat="server" AutoGenerateColumns="False" DataKeyNames="RecipeID" OnRowEditing="GridViewRecipes_RowEditing" OnRowDeleting="GridViewRecipes_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="RecipeName" HeaderText="Recipe Name" SortExpression="RecipeName" />
                                    <asp:BoundField DataField="Ingredients" HeaderText="Ingredients" SortExpression="Ingredients" />
                                    <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method" />
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this recipe?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>    
                    </div>
                   <!--Modal-->
                    <!-- Modal for Editing Recipe -->
                    <div class="modal fade" id="editRecipeModal" tabindex="-1" role="dialog" aria-labelledby="editRecipeModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="editRecipeModalLabel">Edit Recipe</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <!-- Form for Editing Recipe -->
                                    <div class="form-group">
                                        <label for="editRecipeName">Recipe Name:</label>
                                        <input type="text" class="form-control" id="editRecipeName" />
                                    </div>
                                    <div class="form-group">
                                        <label for="editIngredients">Ingredients:</label>
                                        <textarea class="form-control" id="editIngredients"></textarea>
                                    </div>
                                    <div class="form-group">
                                        <label for="editMethod">Method:</label>
                                        <textarea class="form-control" id="editMethod"></textarea>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    <button type="button" class="btn btn-primary" onclick="saveChanges()">Save Changes</button>
                                </div>
                            </div>
                        </div>
                    </div>

                   <!--Modal-->
                </div>
            </div>
        </div>
    </form>
</asp:Content>

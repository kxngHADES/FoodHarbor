<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditRecipe.aspx.cs" Inherits="FoodHarbor.EditRecipe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <div class="card">
                        <div class="card-header bg-primary text-white">
                            Edit Recipe
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <label for="txtRecipeName" class="form-label">Recipe Name</label>
                                <asp:TextBox class="form-control" id="txtRecipeName" placeholder="Recipe Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="txtIngredients" class="form-label">Ingredients</label>
                                <asp:TextBox Rows ="3" class="form-control" ID="txtIngredients" runat="server" placeholder="Ingredients" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="txtMethod" class="form-label">Method</label>
                                <asp:TextBox class="form-control" id="txtMethod" rows="5" placeholder="Method" runat="server" Height="200px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <asp:Button class="btn btn-success" ID="btnUpdate" runat="server" Text="Save Changes" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

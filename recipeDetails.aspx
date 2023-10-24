<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recipeDetails.aspx.cs" Inherits="FoodHarbor.recipeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
        <div class="row">
            <!-- Recipe Details -->
            <div class="col-md-6">
                <h2><asp:Label ID="lblRecipeName" runat="server" Text="Recipe Name"></asp:Label></h2>
                <p><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></p>
                <hr />
                <!-- Rating Stars (Implement your logic to display stars based on average rating) -->
                <div class="mb-3">
                    <span class="text-muted">Average Rating: </span>
                    <div class="stars">
                        <!-- Implement stars based on average rating -->
                        <!-- Example: Display 4 filled stars if average rating is 4 -->
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                    </div>
                </div>
                <!-- User Rating Selection (Implement your logic to capture user rating) -->
                <div class="mb-3">
                    <span class="text-muted">Your Rating:</span>
                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control">
                        <asp:ListItem Text="1"></asp:ListItem>
                        <asp:ListItem Text="2"></asp:ListItem>
                        <asp:ListItem Text="3"></asp:ListItem>
                        <asp:ListItem Text="4"></asp:ListItem>
                        <asp:ListItem Text="5"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- Button to Submit Rating (Implement your logic to submit the rating) -->
                <asp:Button ID="btnSubmitRating" runat="server" Text="Submit Rating" CssClass="btn btn-primary" OnClick="btnSubmitRating_Click" />
            </div>
        </div>
    </div>
    </form>
</asp:Content>

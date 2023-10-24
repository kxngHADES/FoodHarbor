<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="FoodHarbor.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <!--Left-->
                <div class="col-md-3">
                    <div class="card">
                        <div class="card-body">
                            <!--Profile-->
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="img/users.png" width="30"/>
                                    </center>
                                    <div>
                                        <center>
                                            <asp:Button CssClass="btn btn-block btn-info" ID="btnLogOut" runat="server" Text="<-Log Out" />
                                        </center>
                                    </div>
                                </div>
                            </div>
                            <!--Profile-->
                            <!--List-->
                            <ul class="navbar-nav ml-auto">
                                <li class="nav-item">
                                    <a class="nav-link" href="userRecipers.aspx">My Recipes</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="recipeSubmission.aspx">Submit Recipe</a>
                                </li>
                            </ul>
                            <!--List-->
                        </div>
                    </div>
                </div>
                <!--Left-->
                <!--Right-->
                <div class="col-md-9">
                    <div class="card">
                        <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <img src="img/users.png" width="100"/>
                                            <h4>User Registration</h4>
                                        </center>
                                    </div>
                                </div>
                                <!--Space-->
                                <div>
                                    <hr />
                                </div>
                                <!--Body-->
                                    <div class="row">
                                        <!--Name and Surname-->
                                        <div class="col-md-6">
                                            <div>
                                                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                                <div class="form-group">
                                                    <asp:TextBox Class="form-control" ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
                                            
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div>
                                                <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                                        
                                                <div class="form-group">
                                                    <asp:TextBox Class="form-control" ID="txtSurname" runat="server" Placeholder="Surname"></asp:TextBox>
                                            
                                                </div>
                                            </div>
                                        </div>
                                        <!--End Name and Surname-->
                                        <!--Email and Username-->
                                        <div class="col-md-6">
                                            <div>
                                                <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                                       
                                                <div class="form-group">
                                                    <asp:TextBox Class="form-control" ID="txtUsername" runat="server" Placeholder="Username"></asp:TextBox>
                                            
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div>
                                                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                        
                                                <div class="form-group">
                                                    <asp:TextBox Class="form-control" ID="txtEmail" runat="server" Placeholder="E-mail"></asp:TextBox>
                                            
                                                </div>
                                            </div>
                                        </div>
                                        <!--EDIT details button-->
                                        <div class="col form-group">
                                            <asp:Button CssClass="btn btn-block btn-lg btn-success" ID="btnEdit" runat="server" Text="Update Profile" OnClick="btnEdit_Click" />
                                        </div>
                                        <div>
                                            <center>
                                                <a href="question.aspx">Recovery Question</a>
                                            </center>
                                        </div>
                                        <!--EDIT details button-->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                <!--Right-->
            </div>
        </div>
    </form>
</asp:Content>

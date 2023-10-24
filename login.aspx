<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FoodHarbor.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <!--Card Head-->
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="img/users.png" width="100"/>
                                        <h2>User Login</h2>
                                    </center>
                                </div>
                            </div>
                            <!--End of Card Head-->
                            <!--Seperat Body from Head-->
                            <div>
                                <Center><asp:Label ForeColor="Red" ID="lblError" runat="server" Text="Error" Visible="false"></asp:Label></Center>
                                <hr />
                            </div>
                            <!--End seperation-->
                            
                            <div class="row">
                                <div class="col">
                                    <!--Name/Email-->
                                    <div class="col">
                                        <asp:Label ID="lblUser" runat="server" Text="Enter Email/Username"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtUser" runat="server" PLaceholder="Email/Username"></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--End Name/Email-->
                                    <!--Password-->
                                    <div class="col">
                                        <asp:Label ID="lblPassword" runat="server" Text="Enter Password"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" PLaceholder="Password" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--Password-->
                                    <!--Buttons-->
                                    <div class="col">
                                        <asp:Button CssClass="btn btn-block btn-success btn-lg" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                    </div>
                                    <!--Buttons-->
                                    <a href="passwordRecovery.aspx"> Forgot Password?</a>
                                    <br />
                                    <a href="#"> << BACK HOME </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

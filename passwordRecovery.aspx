<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="passwordRecovery.aspx.cs" Inherits="FoodHarbor.passwordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <!--Kop-->
                            <div class="row">
                                <div class="col">
                                    <Center>
                                        <img src="img/lock.png" width="100"/>
                                        <h2>Forgot Password</h2>
                                    </Center>
                                </div>
                            </div>
                            <!--Form-->
                            <div class="row">
                                <div class ="col">
                                    <div class="col">
                                        <asp:Label ID="lblUser" runat="server" Text="Enter Email"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtUser" runat="server" Placeholder="Email"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <center>
                                                <asp:Button CssClass="btn btn-block btn-info btn-lg" ID="btnCheck" runat="server" Text="Next" OnClick="btnCheck_Click" />
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--Hide until-->
                            <div class="row">
                                <div class ="col">
                                    <div class="col">
                                        <asp:Label ID="lblQuestion" runat="server" Text="Question" Visible="false"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtAnswer" runat="server" Visible="false"></asp:TextBox>
                                        </div>
                                        <asp:Button CssClass="btn btn-block btn-lg btn-info" ID="btnAnswer" runat="server" Text="Submit" Visible="false" OnClick="btnAnswer_Click"/>
                                    </div>
                                </div>
                            </div>
                            <!--Password Change-->
                            <div class="row">
                                <div class="col">
                                    <div class="col">
                                        <asp:Label ID="lblPassword" runat="server" Text="New Password" Visible="false"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" runat="server" Placeholder="New Password" Visible="false" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <asp:Button class="btn btn-block btn-lg btn-success" ID="btnPassword" runat="server" Text="Chaneg Password" Visible="false" OnClick="btnPassword_Click"/>
                                    </div>
                                </div>
                            </div>
                            <!--End-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

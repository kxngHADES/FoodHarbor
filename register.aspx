<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FoodHarbor.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <!--Icon and Heading-->
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
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtName" Font-Bold="True" ForeColor="Red" ValidationGroup="i1"></asp:RequiredFieldValidator>
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                                        
                                        <div class="form-group">
                                            <asp:TextBox Class="form-control" ID="txtSurname" runat="server" Placeholder="Surname"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ControlToValidate="txtSurname" ErrorMessage="Please Enter Your Surname" Font-Bold="True" ForeColor="Red" ValidationGroup="i1"></asp:RequiredFieldValidator>
                                            
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
                                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Enter Unique Username" Font-Bold="True" ForeColor="Red" ValidationGroup="i1"></asp:RequiredFieldValidator>
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                        
                                        <div class="form-group">
                                            <asp:TextBox Class="form-control" ID="txtEmail" runat="server" Placeholder="E-mail"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a Valid Email" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="i1"></asp:RegularExpressionValidator>
                                            
                                        </div>
                                    </div>
                                </div>
                                <!--End Email and Username -->
                                <!--Password and confirm Password-->
                                <div class="col-md-6">
                                    <div>
                                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                        
                                        <div class="form-group">
                                            <asp:TextBox Class="form-control" ID="txtPassword" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter a Password" Font-Bold="True" ForeColor="Red" ValidationGroup="i1"></asp:RequiredFieldValidator>
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <asp:Label ID="lblCPassword" runat="server" Text="Confirm Password"></asp:Label>
                                        
                                        <div class="form-group">
                                            <asp:TextBox Class="form-control" ID="txtCPassword" runat="server" Placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                            <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtCPassword" ControlToValidate="txtPassword" ErrorMessage="Passwords do not match" Font-Bold="True" ForeColor="Red" ValidationGroup="i1"></asp:CompareValidator>
                                            
                                        </div>
                                    </div>
                                </div>
                            <!--End of Row below-->
                            </div>
                            <!--Buttons Row-->
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block btn-success btn-lg" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" ValidationGroup="i1" />
                                    </div>
                                </div>
                            </div>
                            <!--Button Row ends above-->
                            <!--Return Home-->
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block btn-primary btn-lg" ID="btnHome" runat="server" Text="Home" />   
                                    </div>
                                </div>
                            </div>
                            <!--End Return Home button above-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

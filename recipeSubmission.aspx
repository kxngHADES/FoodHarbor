<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recipeSubmission.aspx.cs" Inherits="FoodHarbor.recipeSubmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-8">
                            <!--Work from below-->
                            <!--Top-->
                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblHeading" runat="server" Text="Submit Recipe" style="font-size: 40pt; font-family: 'Roboto Bk'"></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblDetail" runat="server" Text="Recipe Details" style="font-family: 'Roboto Bk'; font-size: xx-large"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <hr style="height: 11px" />
                            </div>
                            <!--End of top above-->
                            <!--Name-->
                            <div class="row">
                                <div class="col form-group">
                                    <asp:Label ID="lblName" runat="server" Text="Recipe Name"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!--Name-->
                            <!--Ingredients-->
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <asp:Label ID="lblList" runat="server" Text="Ingredients"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtList" runat="server" Placeholder="Ingredients" TextMode="MultiLine" Height="175px"></asp:TextBox>
                                </div>
                            </div>
                            <!--Ingredients-->
                            <!--Methods-->
                            <div class="row">
                                <div class="col form-group">
                                    <asp:Label ID="lblMethod" runat="server" Text="Cooking Method"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtMethod" runat="server" Height="433px" TextMode="MultiLine" Placeholder="Cooking Method"></asp:TextBox>
                                </div>
                            </div>
                            <!--Methods-->
                            <!--Button-->
                            <div class="row">
                                <div class="col">
                                    <asp:Button class="btn btn-block btn-success btn-lg" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                            <a href="profile.aspx">Back to Profile</a>
                            <!--Button-->
                            <!--Work from above-->
                        </div>
                    </div>
                </div>
            </form>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="FoodHarbor.question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <forn runat="server">
        <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        <h2 class="mb-0">Create Recovery Question</h2>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:Label ID="lblQuestion" runat="server" Text="Recovery Question:"></asp:Label>
                            <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control" placeholder="Enter your recovery question"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblAnswer" runat="server" Text="Answer:"></asp:Label>
                            <asp:TextBox ID="txtAnswer" runat="server" CssClass="form-control" placeholder="Enter the answer to your question"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSave" runat="server" Text="Save Question" CssClass="btn btn-primary btn-block" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </forn>
</asp:Content>

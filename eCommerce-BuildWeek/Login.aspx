<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eCommerce_BuildWeek.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <p>
                    Accedi
                </p>
                <p>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </p>
                <div class="form-group">
                    <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" placeholder="E-mail" />
                    </div>
                <div class="form-group">
                    <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" />
                    <asp:Label ID="pwError" runat="server" Text="Password obbligatoria." CssClass="text-danger fw-bold" Visible="false"></asp:Label>
                    </div>
                <div class="form-group">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click"/>
                    <asp:Label ID="lblRegistrati1" runat="server" Text="Username o password non validi. Se non hai un account, " Visible="false" CssClass="text-danger"></asp:Label>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/SignUp.aspx" Visible="false">Registrati</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>

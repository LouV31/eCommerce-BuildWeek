<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modifica.aspx.cs" Inherits="eCommerce_BuildWeek.Modifica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Modifica</h2>
    <div class="container">
        <div class="row">
            <div class="col">
                <div class="d-flex">
                    <asp:Image ID="img" ImageUrl="imageurl" runat="server" CssClass="img-fluid" Width="200" />
                    <div class="d-flex flex-column">
                        <asp:TextBox runat="server" ID="Nome" Text="" />
                        <asp:TextBox runat="server" ID="Descrizione" Text="" />
                        <asp:TextBox runat="server" ID="Prezzo" Text="" />
                        <asp:TextBox runat="server" ID="Unita" Text="" />
                        <asp:TextBox runat="server" ID="Categoria" Text="" />
                        <asp:TextBox runat="server" ID="Immagine" Text="" />
                    </div>
            </div>
                    <asp:Button runat="server" ID="invioModifica" OnClick="invioModifica_Click" CssClass="btn btn-sm btn-outline-success rounded-pill" Text="Conferma" />
        </div>
    </div>
</asp:Content>

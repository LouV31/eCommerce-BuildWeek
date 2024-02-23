<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettagliOrdine.aspx.cs" Inherits="eCommerce_BuildWeek.DettagliOrdine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label Text='<%# "Dettagli ordine #" + Eval("Fk_IdOrdine") %>' runat="server"></asp:Label>
            <asp:Repeater ID="DettagliOrdiniRep" runat="server">
                <ItemTemplate>

                    <div class="col-8">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PercorsoImmagine") %>' CssClass="img-fluid" />
                        <a href='<%# "/Dettagli.aspx?IdProdotto=" + Eval("FK_IdProdotto") %>'>
                            <asp:Label runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                        </a>
                        <asp:Label runat="server" Text='<%# "Quantità: " + Eval("quantita") %>'></asp:Label>
                        <asp:Label runat="server" Text='<%# "Prezzo: " + Eval("TOTALE") %>'></asp:Label>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>

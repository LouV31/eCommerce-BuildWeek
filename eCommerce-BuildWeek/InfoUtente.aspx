<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoUtente.aspx.cs" Inherits="eCommerce_BuildWeek.InfoUtente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-8">
                <div class="d-flex">
                   
                    <div class="col-4">
                        <asp:Label Text="Nome" CssClass="text-white" runat="server" />
                        <asp:TextBox id="Nome" runat="server" />
                        <asp:Label Text="Cognome" CssClass="text-white" runat="server" />
                        <asp:TextBox id="Cognome" runat="server"/>
                        <asp:Label Text="Email" CssClass="text-white" runat="server" />
                        <asp:TextBox id="Email" runat="server"/>
                        <asp:Label Text="Password" CssClass="text-white" runat="server" />
                        <asp:TextBox id="Password" runat="server"/>
                        <asp:Label Text="Indirizzo" CssClass="text-white" runat="server" />
                        <asp:TextBox id="Indirizzo" runat="server"/>
                        <asp:Label Text="Città" CssClass="text-white" runat="server" />
                        <asp:TextBox id="Citta" runat="server"/>
                        <asp:Label Text="Cap" CssClass="text-white" runat="server" />
                        <asp:TextBox id="Cap" runat="server"/>
                    </div>

                </div>
                <asp:Button runat="server" ID="Modifica" OnClick="Modifica_Click" Text="Modifica" CssClass="btn btn-sm btn-warning rounded-pill" />
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-8">
                <h2>Riepilogo Ordini</h2>
                <asp:Repeater runat="server" ID="RiepilodoOrdiniRep">
                    <ItemTemplate>
                        <div class="d-flex">
                            <div class="col-8">
                                <asp:Label Text='<%# Eval("idOrdine") %>' runat="server" />
                                <asp:Label Text='<%# Eval("Indirizzo_Spedizione") %>' ID="indirizzoSpedizione" runat="server" />
                                <asp:Label Text='<%# Eval("Quantita") %>' ID="Quantità" runat="server" />
                                <asp:Label Text='<%# Eval("Totale") %>' ID="Totale" runat="server" />
                            </div>
                            
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>    
</asp:Content>

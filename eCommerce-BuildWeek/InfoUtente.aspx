<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoUtente.aspx.cs" Inherits="eCommerce_BuildWeek.InfoUtente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">

                   
                    <div class="col-12 text-center">
                        <div class="center-form justify-content-center mx-auto text-center">
                        <h2 class="title-up text-white fs-3 mb-4">Informazioni utente</h2>
                        <asp:Label Text="Nome" CssClass="text-white mb-1  mx-auto" runat="server" />
                        <asp:TextBox id="Nome" runat="server" class="form-control mx-auto mb-3"/>

                        <asp:Label Text="Cognome" CssClass=" text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Cognome" runat="server" class="form-control mx-auto mb-3"/>

                        <asp:Label Text="Email" CssClass="text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Email" runat="server" class="form-control mx-auto mb-3"/>

                        <asp:Label Text="Password" CssClass="text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Password" runat="server" class="form-control mx-auto mb-3"/>

                        <asp:Label Text="Indirizzo" CssClass="text-white mb-1 mx-auto" runat="server" />
                        <asp:TextBox id="Indirizzo" runat="server" class="form-control  mx-auto mb-3"/>

                        <asp:Label Text="Città" CssClass="text-white mx-auto mb-1" runat="server" />
                        <asp:TextBox id="Citta" runat="server" class="form-control mx-auto mb-3"/>

                        <asp:Label Text="Cap" CssClass="text-white mx-auto mb-1" runat="server" />
                        <asp:TextBox id="Cap" runat="server" class="form-control mx-auto mb-4"/>
                        </div>
                      <asp:Button runat="server" ID="Modifica" OnClick="Modifica_Click" Text="Modifica" CssClass="btn title-up w-100 text-white btn2w p-2 rounded-1" />
                    </div>

                </div>


        <div class="row mt-5">
            <div class="col-8">
                <h2>Riepilogo Ordini</h2>
                <asp:Repeater runat="server" ID="RiepilodoOrdiniRep">
                    <ItemTemplate>
                        <div class="d-flex text-white">
                            <div class="col-8">
                                <asp:Label Text='<%# Eval("idOrdine") %>' runat="server" />
                                <asp:Label Text='<%# Eval("Indirizzo_Spedizione") %>' ID="indirizzoSpedizione" runat="server" />
                                <asp:Label Text='<%# Eval("Quantita") %>' ID="Quantità" runat="server" />
                                <asp:Label Text='<%# Eval("Totale") %>' ID="Totale" runat="server" />
                                <a href='<%# "/DettagliOrdine.aspx?ordineId=" + Eval("idOrdine") %>'  id="DettagliOrdini" runat="server" >Vai a dettagli</a>  
                            </div>
                            
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>    
</asp:Content>

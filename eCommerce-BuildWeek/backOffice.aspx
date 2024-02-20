<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="backOffice.aspx.cs" Inherits="eCommerce_BuildWeek.backOffice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Back Office</h2>
        <div class="row">
            <asp:Repeater ID="backOfficeRepeater" runat="server">
                <ItemTemplate>
                    <div class="col gy-3 border-bottom border-2 pb-2">
                        <div class="d-flex align-items-center justify-content-between">
                            <div>
                                <img src='<%# Eval("Immagine") %>' class="card-img-top img-fluid" style="max-height: 250px; object-fit: contain" alt='<%# Eval("Nome") %>'>
                            </div>

                            <div class="d-flex flex-column">
                                <h5 class="card-title fw-semibold mb-2">Prodotto: <%# Eval("Nome") %></h5>
                                <p class="fw-normal fs-5 mb-0">Descrizione: <%# Eval("Descrizione") %></p>

                            </div>
                            <!--<p runat="server" id="n_prodotti" class="mb-0"></p>-->
                            <p class="fw-semibold fs-6 mb-0">Prezzo: <%# Eval("Prezzo", "{0:c2}") %></p>
                            <asp:Button ID="Rimuovi" runat="server" OnClick="Rimuovi_Click" Text="Rimuovi" CssClass="btn btn-sm btn-danger" CommandArgument='<%# Eval("idProdotto") %>' />
                            <a ID="Modifica" href=<%# "Modifica.aspx?ProdottoId=" + Eval("idProdotto") %> runat="server"  class="btn btn-sm btn-warning">Modifica</a>


                        </div>



                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

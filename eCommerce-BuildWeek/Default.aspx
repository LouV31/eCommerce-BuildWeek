<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="eCommerce_BuildWeek._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container">
            <h2 class="title-up text-center fs-2 mb-4">Fucili d'assalto</h2>


            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 row-cols-xl-4">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col gy-3">
                            <div class="card mx-2 my-2 bg-transparent border-0 text-white overflow-hidden shadow">

                                <div class="d-flex align-items-center">

                                <div>
                                <img src='<%# Eval("Immagine") %>' class="card-img-top img-fluid" style="max-height: 250px; object-fit: contain" alt='<%# Eval("Nome") %>'>
                                </div>
                                
                                <div class="mx-3" style="width: 250px;">
                                    <h5 class="title-up card-title fs-4 fw-bold mt-3"><%# Eval("Nome") %></h5>
                                    <p class="card-text"><%# Eval("Prezzo", "{0:c2}") %></p>

                                    <button class="py-1 px-3 btn btn2i fw-bolder mb-3" />
                                    <a href="<%# "Dettagli.aspx?IdProdotto=" + Eval("idProdotto") %>" class="text-decoration-none text-white">Dettagli
                                    </a>
                                    </button>

                                </div>
                                </div>

                            </div>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </main>

</asp:Content>

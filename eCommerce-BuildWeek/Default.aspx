<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="eCommerce_BuildWeek._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container">
            <h2 class="title-up text-center fs-2 mb-4">Tutti gli articoli</h2>


            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 row-cols-xl-4">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col gy-3">
                            <div class="card mx-2 my-2 bg-transparent border-0 text-white overflow-hidden shadow">

                                <div class="d-flex  align-items-center mx-auto">
                                    <h5 class="title-up card-title m-0 fs-2 fw-bold mt-3"><%# Eval("Nome") %></h5>
                                </div>

                                <div class="position-relative">
                                <img src='<%# Eval("Immagine") %>' class="px-3 card-img-top img-fluid" style="max-height: 250px; object-fit: contain" alt='<%# Eval("Nome") %>'>
                               <span class="custom-span fs-5 bg-opacity-75 shadow rounded-0 badge w-100  bg-opacity-75"><%# Eval("Prezzo", "{0:c2}") %></span>
                                </div>

                                <a href="<%# "Dettagli.aspx?IdProdotto=" + Eval("idProdotto") %>" class="text-decoration-none rounded-0 w-100 text-white btn btn2i fw-bolder text-white">
                                Dettagli
                                </a>

                            </div>

                                         


                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </main>

</asp:Content>

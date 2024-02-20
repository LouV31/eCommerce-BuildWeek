<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Dettagli.aspx.cs"
Inherits="eCommerce_BuildWeek.Dettagli" EnableEventValidation="false" %>

<asp:Content ID="BodyContent1" ContentPlaceHolderID="MainContent" runat="server">
  <!DOCTYPE html>

  <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title></title>
      <link href="./Content/style.css" rel="stylesheet" />
    </head>
    <body>
      <div class="container mt-5 text-white">
        <p class="alert alert-danger" runat="server" id="alert"></p>

        <div class="row">
          <div class="col-md-7">
            <img id="Immagine" runat="server" src="" alt="" class="img-thumbnail border-0 bg-transparent" />
          </div>
          <div class="col-md-5">
            <p id="Categoria" class="title-up fs-5" runat="server"></p>

            <div class="d-flex">
              <h2 id="Nome" class="fs-1" runat="server"></h2>
              <span class="badge mt-2 ms-3" id="Disponibilita" runat="server"></span>
            </div>

            <h4 id="Prezzo" runat="server"></h4>
            <h4 class="my-4 fw-bold fs-5 orange">Descrizione</h4>
            <p id="Descrizione" runat="server"></p>

            <h4 class="my-4 fw-bold fs-5">Scegli una <span class="orange">mimetica</span></h4>
            <img
              class="material rounded-1 border border-2 border-white"
              src="https://www.onlygfx.com/wp-content/uploads/2019/09/4-black-camouflage-texture-tile-2.png"
              alt=""
            />
            <img
              class="material rounded-1"
              src="https://www.onlygfx.com/wp-content/uploads/2019/09/4-red-camouflage-texture-tile-3.png"
              alt=""
            />
            <img
              class="material rounded-1"
              src="https://w7.pngwing.com/pngs/358/712/png-transparent-metal-silver-silver-textured-metal-silver-textured-thumbnail.png"
              alt=""
            />
            <img
              class="material rounded-1"
              src="https://png.pngtree.com/png-clipart/20190705/original/pngtree-gold-background-material-picture-png-image_4362781.jpg"
              alt=""
            />
            <br />
            <asp:Button
              runat="server"
              id="aggiungiCarrello"
              OnClick="aggiungiCarrello_Click"
              cssClass="mt-4 py-3 px-4 btn btn2o fw-bolder"
              Text="Aggiungi al carrello"
            />

            <asp:TextBox runat="server" ID="Quantità" TextMode="Number" Text="1" />
          </div>
        </div>
      </div>
    </body>
  </html>
</asp:Content>

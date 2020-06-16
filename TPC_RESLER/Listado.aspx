<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="TPC_RESLER._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <h1>Lista Productos</h1>  
        <style>
            .oculto {
                display: none;
            }
            .bolsita
            {
                background-image:url('../Image/Carro.png');
                background-size:cover;
                width:70px;
                height:70px;
               
            }
            .letras{
                font-size:20px;
                font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
               

            }
           </style>
    <div class="bolsita float-right" >   
         <br />
         <asp:Label Text="" ID="LblCantidad" Style="font-size:30px;" CssClass=" ml-4 mt-2 font-weight-light"  runat="server" />
    </div>
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        
          <asp:Repeater runat="server" ID="repetidor" >
            <ItemTemplate>
                <div class="card">
                   <div class="card-header">
                      <h3 class="card-title text-center" Style=" font-size: xx-large;  font-family:'Times New Roman', Times, serif" ><%#Eval("Nombre")%></h3>
                   </div>
                    <img src="<%#Eval("ImagenUrl")%>"  class="card-img-top ml-5 ali" style=" max-width:300px; max-height:300px; min-width:300px; min-height:300px;"  alt="...">
                    <div class="card-body">
                        <p class="card-text text-center letras  "><%#Eval("Descripcion")%></p>
                        <p class="card-text text-center letras "><%#Eval("idMarca")%></p>
                        <p class="card-text text-center letras "><%#Eval("Precio")%></p>
                    </div>
                   <asp:Button CssClass="btn btn-info btn btn-outline-secondary text-center"  ID ="btnArgumento" Text="Agregar al carrito " runat="server" CommandArgument='<%#Eval("id")%>' OnClick="btnArgumento_Click"/>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>

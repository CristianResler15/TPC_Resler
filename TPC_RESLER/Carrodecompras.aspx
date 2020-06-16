<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrodecompras.aspx.cs" Inherits="TPC_RESLER.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .oculto {
            display: none;
        }

        .bolsita {
            background-image: url('../Images/Bolsita.png');
            background-size: cover;
            width: 50px;
            height: 50px;
        }

        .LetrasHeader {
            color: white;
            font-family: 'Times New Roman', Times, serif;
            font-size: 20px;
        }

        .Header {
            background-color:darkslategrey ;
            text-align-last: center;
        }

        .Contenido {
            font-size: 20px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            text-align: center;
        }

        .GirdAlineado {
            margin-right: 300px;
        }

        .Detalles {
            background-color:white ;
            margin-left: 900px;
            height: 300px;
            width: 300px;
            border: double;
            border-radius: 50px;

        }

        .left {
            float: right;
            margin: 10px;
            
        }

        .right {
            float: right;
            width: 800px;
            margin: 10px;
           
        }
    </style>


        <div class="Detalles left">

            <div class="bolsita ml-5 mt-5">
                <br />
                <asp:Label Text="" ID="LblCarrito" Style="font-size: 20px;" CssClass=" ml-4 mt-2 font-weight-light" runat="server" />
            </div>
            <div class=" mt-5">
                <br />

                <asp:Label Text="TOTAL:" ID="LblTotal" CssClass=" float-md-left mt-5 ml-5 badge bg-success " Style="font-size: 25px;" runat="server" />
            </div>

        </div>
    <div class="GirdAlineado right">
        <br />  
        <br />  
        <br />  
        <br />  
        <asp:GridView CssClass=" table GirdAlineado " ID="dgvCarrito" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" OnRowCommand="dgvCarrito_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="Eliminar" CommandName="Select" />
                <asp:BoundField ItemStyle-CssClass=" align-items-xl-center Contenido  " HeaderStyle-CssClass="  Header LetrasHeader" HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField ItemStyle-CssClass=" align-items-xl-center Contenido  " HeaderStyle-CssClass=" Header  LetrasHeader" HeaderText="Marca" DataField="idmarca.Descripcion" />
                <asp:BoundField ItemStyle-CssClass="align-items-xl-center Contenido  " HeaderStyle-CssClass="  Header LetrasHeader" HeaderText="Caracteristicas" DataField="Descripcion" />
                <asp:BoundField ItemStyle-CssClass="align-items-xl-center Contenido " HeaderStyle-CssClass="  Header   LetrasHeader" HeaderText="Precio" DataField="Precio" />
            </Columns>
        </asp:GridView>

    </div>


</asp:Content>

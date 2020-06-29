<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaMarca.aspx.cs" Inherits="TPC_RESLER.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
    <div>   
        <div>   
            <asp:Button Text="Agregar Marca" CssClass="btn btn-primary" href="~/AltaMarca" runat="server" OnClick="Unnamed_Click" />
        </div>
    </div>
  

    <div class="GirdAlineado ">
        <br />  
        <br />  
        <br />  
        <br />  
        <asp:GridView CssClass=" table GirdAlineado " ID="dgvMarca" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMarca_SelectedIndexChanged" OnRowCommand="dgvMarca_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="Eliminar" CommandName="Select" />
                <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="Modificar" CommandName="Select2" />
                <asp:BoundField ItemStyle-CssClass="align-items-xl-center Contenido  " HeaderStyle-CssClass="  Header LetrasHeader" HeaderText="Caracteristicas" DataField="Descripcion" />
            </Columns>
        </asp:GridView>

    </div>







</asp:Content>

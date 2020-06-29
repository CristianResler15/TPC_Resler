<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaCategoria.aspx.cs" Inherits="TPC_RESLER.ListaCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
   <div>   
        <div>   
            <asp:Button Text="Agregar Categoria" CssClass="btn btn-primary"  runat="server" OnClick="Unnamed_Click" />
        </div>
    </div>
   <div class="GirdAlineado right">
        <br />  
        <br />  
        <br />  
        <br />  
        <asp:GridView CssClass=" table GirdAlineado " ID="dgvCat" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCat_SelectedIndexChanged" OnRowCommand="dgvCat_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="Eliminar" CommandName="Select" />
                <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="Modificar" CommandName="Select2" />
                <asp:BoundField ItemStyle-CssClass="align-items-xl-center Contenido  " HeaderStyle-CssClass="  Header LetrasHeader" HeaderText="Caracteristicas" DataField="Descripcion" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>

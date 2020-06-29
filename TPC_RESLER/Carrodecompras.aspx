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
            background-color: darkslategrey;
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
            background-color: white;
            border: double;
            border-radius: 50px;
        }

        .left {
            float: right;
            margin: 10px;
        }

        .right {
            float: right;
            width: 300px;
            margin-right: 500px;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class=" w-75">

                <div class="GirdAlineado  ">
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
                            <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="<" CommandName="Select3" />
                            <asp:BoundField ItemStyle-CssClass="align-items-xl-center Contenido " HeaderStyle-CssClass="  Header   LetrasHeader" HeaderText="Cantidad" DataField="Cantidad" />
                            <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text=">" CommandName="Select2" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>

            <div style="width:23%" class="">

                <div class="Detalles ">

                    <div class="row mt-5">

                        <div class="col-4 mt.">

                            <div class="bolsita row ">
                                <div class="col-4">
                                    <asp:Label Text="" ID="LblCarrito" Style="font-size: 20px;" CssClass=" left font-weight-light" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class=" col-4 mb-5">
                                    <asp:Label Text="TOTAL:" ID="LblTotal" CssClass=" float-md-left mt-5 ml-5 badge bg-success " Style="font-size: 25px;" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class=" col-4 nmt5">
                                    <asp:Button Text="Comprar" CssClass="btn btn-primary" runat="server" OnClick="Unnamed_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
   


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCategoria.aspx.cs" Inherits="TPC_RESLER.AltaCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form class="needs-validation mt-5 " novalidate="">
        <br />
        <br />
        <br />
        <br />
        <br />

        <asp:     

        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="firstName">Descripcion</label>
                <asp:TextBox runat="server" CssClass="form-control is-valid" ID="TxtDescripcion" />

                <div class="invalid-feedback">
                    Valid first name is required.
                </div>
            </div>
        </div>

       
        <hr class="mb-4">

        <asp:Button Text="AGREGAR PRODUCTO" runat="server" CssClass="btn btn-primary btn-lg btn-block" OnClick="ALta_Click" />

    </form>
</asp:Content>

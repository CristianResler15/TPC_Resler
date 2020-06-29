<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProducto.aspx.cs" Inherits="TPC_RESLER.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form class="needs-validation mt-5 " novalidate="">
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="firstName">nombre</label>
                <asp:TextBox runat="server" CssClass="form-control is-valid" ID="Txtnombre" />
                <div class="invalid-feedback">
                    Valid first name is required.
                </div>
            </div>
            <div class="col-md-6 mb-3">
                <label for="lastName">descripcion</label>
                <asp:TextBox runat="server" CssClass="form-control is-valid" ID="TxtDescripcion" />
                <div class="invalid-feedback">
                    Valid last name is required.
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="firstName">categoria</label>
               <asp:DropDownList runat="server" Cssclas="form-control is-valid" ID="Cbocat" AutoPostBack="true" OnSelectedIndexChanged="Cbocat_SelectedIndexChanged" >        
                </asp:DropDownList>

                <div class="invalid-feedback">
                    Valid first name is required.
                </div>
            </div>
            <div class="col-md-6 mb-3">
                <label for="lastName">}Precio</label>
                <asp:TextBox runat="server" CssClass="form-control is-valid" ID="TxtPrecio" />
                <div class="invalid-feedback">
                    Valid last name is required.
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="firstName">marca</label>
                <asp:DropDownList runat="server" Cssclas="form-control is-valid" ID="CboMarca" AutoPostBack="true" OnSelectedIndexChanged="CboMarca_SelectedIndexChanged" >        
                </asp:DropDownList>
                </div>
                <div class="invalid-feedback">
                    Valid first name is required.
                </div>
            </div>
            <div class="col-md-6 mb-3">
                <label for="lastName">provedor</label>
                <asp:DropDownList runat="server" Cssclas="form-control is-valid" ID="CboProve" AutoPostBack="true" OnSelectedIndexChanged="CboProve_SelectedIndexChanged" >        
                </asp:DropDownList>
                <div class="invalid-feedback">
                    Valid last name is required.
                </div>
            </div>
 
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="firstName">imagen</label>
                <asp:TextBox runat="server" CssClass="form-control is-valid" ID="TxtImagen" />

                <div class="invalid-feedback">
                    Valid first name is required.
                </div>
            </div>
        </div>
        <hr class="mb-4">

        <asp:Button Text="AGREGAR PRODUCTO" runat="server" CssClass="btn btn-primary btn-lg btn-block" OnClick="ALta_Click" />

    </form>





</asp:Content>

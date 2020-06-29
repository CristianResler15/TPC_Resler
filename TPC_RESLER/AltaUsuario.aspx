<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="TPC_RESLER.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container  mt-5">

        <div class="row">
            <div class="col-6">
                <label for="inputEmail4">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control " ID="Txtnombre" />
            </div>
            <div class="col-6">
                <label for="inputPassword4">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control " ID="TxtApellido" />
            </div>
        </div>

        <div class="row">
            <div class="col-6">
                <label for="inputAddress2">Email</label>
                <asp:TextBox runat="server" CssClass="form-control " ID="TxtEmail" />
            </div>
            <div class=" col-6">
                <label for="inputCity">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control " ID="TxtContraseña" />
            </div>
        </div>
        <div class="row">
            <div class=" col-6">
                <label for="inputState">Edad</label>
                <asp:TextBox runat="server" CssClass="form-control " ID="TxtEdad" />
            </div>
            <div class=" col-6">
                <label for="inputZip">DNI</label>
                <asp:TextBox runat="server" CssClass="form-control " ID="TxtDni" />
            </div>
        </div>
        <div class="row">

            <div class="col-3">  
                <br />  
            </div> 
            <div class="col-5">  
                <br />  
                <asp:Button Text="AGREGAR PRODUCTO" runat="server" CssClass="btn btn-primary btn-lg btn-block" OnClick="ALta_Click" />
            </div>
        </div>
    </div>
</asp:Content>


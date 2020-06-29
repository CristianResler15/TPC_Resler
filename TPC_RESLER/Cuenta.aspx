<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuenta.aspx.cs" Inherits="TPC_RESLER.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form>
        <br />
        <br />
        <br />

        <div class="form-group">
            <label for="exampleInputEmail1">Email address</label>
            <asp:TextBox runat="server" CssClass=" form-control" ID="TxtEmail"/>  

        </div>
        <div class="form-group">
            <label for="">Password</label>
            <asp:TextBox runat="server" CssClass=" form-control" ID="TxtContraseña"/>
        </div>
        <asp:Button Text="Iniciar sesion" CssClass="btn btn-primary"  runat="server" OnClick="Unnamed_Click"  />
        <asp:Button Text="Registrarse" CssClass="btn btn-primary" href="~/Registrarse" runat="server" OnClick="Unnamed_Click1"  />
    </form>
</asp:Content>

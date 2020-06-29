<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProvedor.aspx.cs" Inherits="TPC_RESLER.ModificarProvedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form class="needs-validation mt-5 " novalidate="">
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            
            <div class="col-md-6 mb-3">
                <label for="lastName">Last name</label>
                <asp:TextBox runat="server" CssClass="form-control is-valid" ID="TxtDescripcion" />
                <div class="invalid-feedback">
                    Valid last name is required.
                </div>
            </div>
        <div class="col-md-6 mb-3">
                <label for="lastName">Last name</label>
                <asp:TextBox runat="server" CssClass="form-control is-valid" ID="TxtID" />
                <div class="invalid-feedback">
                    Valid last name is required.
                </div>
            </div>
        </div>
         <hr class="mb-4">
        
      <asp:Button Text="AGREGAR PRODUCTO" runat="server" CssClass="btn btn-primary btn-lg btn-block" OnClick="Modificar_Click" />

    </form>
</asp:Content>

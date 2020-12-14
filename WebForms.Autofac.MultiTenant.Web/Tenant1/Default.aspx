<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms.Autofac.MultiTenant.Minimal.Tenant1.Default" %>

<%@ Register Src="~/Controls/TenantDetailControl.ascx" TagPrefix="uc1" TagName="TenantDetailControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:TenantDetailControl runat="server" id="TenantDetailControl" />
</asp:Content>

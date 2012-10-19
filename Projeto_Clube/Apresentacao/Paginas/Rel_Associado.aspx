<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rel_Associado.aspx.cs" Inherits="Apresentacao.Paginas.Rel_Associado" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="917px">
    <LocalReport ReportPath="Paginas\Rel_Associado.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="objDtsAssociado" Name="dtsAssociado" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="objDtsAssociado" runat="server" SelectMethod="Listar" 
    TypeName="Negocio.NAssociado"></asp:ObjectDataSource>
</asp:Content>

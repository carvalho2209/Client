<%@ Page Title="Pesquisa Associado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="Pes_Associado.aspx.cs" Inherits="Apresentacao.Paginas.Pes_Associado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>
    PESQUISA ASSOCIADO
</h2>
    <p>
        <table style="width:100%;">
            <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNome" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="2">
                    <asp:Button ID="btnPesquisar" runat="server" Height="34px" 
                        onclick="btnPesquisar_Click" Text="Pesquisar" Width="135px" />
&nbsp;
                    <asp:Button ID="btnAdicionar" runat="server" Height="34px" 
                        onclick="btnAdicionar_Click" Text="Adicionar" Width="135px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="2">
                    <asp:GridView ID="grdPesquisa" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        onrowdatabound="grdPesquisa_RowDataBound" Width="471px" 
                        onselectedindexchanged="grdPesquisa_SelectedIndexChanged" 
                        onrowcreated="grdPesquisa_RowCreated" CssClass="grid" AllowPaging="True" 
                        onpageindexchanging="grdPesquisa_PageIndexChanging" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Identificador" HeaderText="Identificador" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome" />
                            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                            <asp:TemplateField HeaderText="Tipo do Associado">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("TipoAssociado.Descricao")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
        </table>
</p>

</asp:Content>

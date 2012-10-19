<%@ Page Title="Cadastro Associado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cad_Associado.aspx.cs" Inherits="Apresentacao.Paginas.Cad_Associado" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        CADASTRO ASSOCIADO
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
                    <asp:Label ID="Label1" runat="server" Text="Identificador"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtIdentificador" runat="server" BackColor="#CCCCCC" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNome" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtNome" ErrorMessage="É necessário informar o nome." 
                        ValidationGroup="ValidarTela"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    <asp:Label ID="Label3" runat="server" Text="Endereço"></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:TextBox ID="txtEndereco" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtEndereco" 
                        ErrorMessage="É necessário informar o endereço." ValidationGroup="ValidarTela"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label4" runat="server" Text="Telefone"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtTelefone_MaskedEditExtender" runat="server" 
                        ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="(99) 9999-9999" MaskType="Number" TargetControlID="txtTelefone">
                    </asp:MaskedEditExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtTelefone" ErrorMessage="É necessário informar o telefone." 
                        ValidationGroup="ValidarTela" InitialValue="(__) ____-____"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label5" runat="server" Text="Tipo Associado"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTipoAssociado" runat="server" 
                        DataTextField="Descricao" DataValueField="Identificador" Width="350px" 
                        AppendDataBoundItems="True">
                        <asp:ListItem>Selecione...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="ddlTipoAssociado" 
                        ErrorMessage="É necessário informar o tipo do associado." 
                        InitialValue="Selecione..." ValidationGroup="ValidarTela"></asp:RequiredFieldValidator>
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
                    <asp:Button ID="btnIncluir" runat="server" Height="28px" 
                        onclick="btnIncluir_Click" Text="Incluir" Width="150px" 
                        ValidationGroup="ValidarTela" />
&nbsp;<asp:Button ID="btnAlterar" runat="server" Height="28px" Text="Alterar" Width="150px" 
                        onclick="btnAlterar_Click" ValidationGroup="ValidarTela" />
&nbsp;<asp:Button ID="btnExcluir" runat="server" Height="28px" Text="Excluir" Width="150px" 
                        onclick="btnExcluir_Click" ValidationGroup="ValidarTela" />
&nbsp;<asp:Button ID="btnFechar" runat="server" Text="Fechar" Width="150px" Height="28px" 
                        onclick="btnFechar_Click" />
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

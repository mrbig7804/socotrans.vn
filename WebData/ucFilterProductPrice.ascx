<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucFilterProductPrice.ascx.cs" Inherits="ucFilterProductPrice" %>

<asp:Repeater runat="server" ID="rptPrices" OnItemDataBound="rptPrices_ItemDataBound">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink runat="server" ID="hplPrice" ToolTip='<%# Eval("Title") %>'>
                <%# Eval("Title") %>&nbsp;(<asp:Label runat="server" ID="lblCount" />)
            </asp:HyperLink>
        </li>
    </ItemTemplate>
</asp:Repeater>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucFilterProductBrands.ascx.cs" Inherits="ucFilterProductBrands" %>

<asp:Repeater runat="server" ID="rptBrands" OnItemDataBound="rptBrands_ItemDataBound">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink runat="server" ID="hplBrand" ToolTip='<%# Eval("Title") %>' CssClass="image">
                <img alt='<%# Eval("Title") %>' src=<%# Regex.Replace(Eval("ImageUrl").ToString(), "~/", "/") %> />
            </asp:HyperLink>
        </li>
    </ItemTemplate>
</asp:Repeater>

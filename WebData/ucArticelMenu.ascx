<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucArticelMenu.ascx.cs" Inherits="ucArticelMenu" %>

<asp:Repeater runat="server" ID="rptCategory">
    <HeaderTemplate><ul role="menu" class="sub-menu"></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <a href='/<%# GetUrl() %>/<%# Eval("CategoryID") %>/<%# VNString.TextToUrl(Eval("Title").ToString()) %>'><%# Eval("Title") %></a>
        </li>
    </ItemTemplate>
</asp:Repeater>

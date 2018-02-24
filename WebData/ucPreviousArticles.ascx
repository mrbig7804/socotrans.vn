<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPreviousArticles.ascx.cs" Inherits="ucPreviousArticles" %>

<asp:Repeater ID="rptPreviousArticle" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>     
        <li>  
            <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>''><%# Eval("Title")%></a>
        </li>
    </ItemTemplate>
</asp:Repeater>

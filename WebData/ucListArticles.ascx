<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListArticles.ascx.cs" Inherits="ucListArticles" %>


<asp:Repeater ID="rptArticles" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' >
                <%# SliptString(Eval("Title").ToString()) %>
            </a><%--&nbsp;<asp:Image ID="imgSpecialArt" runat="server" AlternateText='<%# Eval("Title") %>' ImageUrl='/images/new2.gif' Visible=<%# Eval("OnlyForMembers") %> />--%>
        </li>
    </ItemTemplate>
</asp:Repeater>

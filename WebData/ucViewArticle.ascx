<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewArticle.ascx.cs" Inherits="ucViewArticle" %>

<%@ Register Src="ucEditArticleBar.ascx" TagName="ucEditArticleBar" TagPrefix="uc1" %>

<uc1:ucEditArticleBar ID="ucEditArticleBar1" runat="server" />

<asp:Panel ID="panTitle" runat="server" CssClass="title">
    <h3><asp:HyperLink ID="lblTitle" runat="server" /></h3>
</asp:Panel>
<asp:Panel ID="panImage" runat="server" CssClass="image">
    <asp:Image ID="imgImage" runat="server" />
</asp:Panel>
<asp:Panel ID="panAbstract" runat="server" CssClass="abstract">
    <asp:Label ID="lblAbstract" runat="server" />
</asp:Panel>
<asp:Panel ID="panBody" runat="server" CssClass="body">
    <asp:Literal ID="lblBody" runat="server" />
</asp:Panel>
<asp:Panel ID="panReadmore" runat="server" CssClass="more">
    <asp:HyperLink ID="lnkReadMore" runat="server" />
</asp:Panel>


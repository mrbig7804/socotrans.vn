<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSiteNavigator.ascx.cs" Inherits="ucSiteNavigator" %>
<div style="width: 690px; border-bottom: 2px solid #bfbfbf; padding: 10px; color: #a4080f;
            font-size: 18px; font-style: italic; font-weight: bold">
<%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/news.aspx">Tin tức</asp:HyperLink>--%>
<asp:Label ID="Label1" runat="server" Text=">"></asp:Label>
<asp:HyperLink ID="lnkSuperCategory" runat="server">[lnkSuperCategory]</asp:HyperLink>
<asp:Label ID="Label2" runat="server" Text=">"></asp:Label>
<asp:HyperLink ID="lnkCategory" runat="server">[lnkCategory]</asp:HyperLink>
<asp:Label ID="lblTitle" runat="server"></asp:Label>
</div>
<div class="dot" style="margin-top:-3px;"></div>
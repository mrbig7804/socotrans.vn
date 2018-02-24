<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="faqs.aspx.cs" Inherits="faqs" %>

<%@ Register Src="ucViewArticle.ascx" TagName="ucViewArticle" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <ul class="breadcrumbs">
        <li><a href="/">Mavach.org</a></li>
        <li>Faqs</li>
    </ul>
    <div class="main-cc view-art">
        <uc1:ucViewArticle runat="server" ID="ucViewArticle1" ArticleID="32" ShowBody="true" />
    </div>
</asp:Content>


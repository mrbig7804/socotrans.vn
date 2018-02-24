<%@ Page Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true"CodeFile="about.aspx.cs" Inherits="about" %>

<%@ Register Src="ucViewArticle.ascx" TagName="ucViewArticle" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Giới thiệu</li>
    </ul>
    <div class="main-cc view-art">
        <uc1:ucViewArticle runat="server" ID="ucViewArticle1" ArticleID="120" ShowBody="true" />
    </div>
</asp:Content>


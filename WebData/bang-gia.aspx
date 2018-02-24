<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="bang-gia.aspx.cs" Inherits="bang_gia" %>

<%@ Register Src="ucViewArticle.ascx" TagName="ucViewArticle" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" Runat="Server">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Bảng giá</li>
    </ul>
    <div class="main-cc view-art">
        <uc1:ucViewArticle runat="server" ID="ucViewArticle1" ArticleID="84" ShowBody="true" />
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="quy-dinh-doi-tra-hang.aspx.cs" Inherits="quy_dinh_doi_tra_hang" %>

<%@ Register Src="ucViewArticle.ascx" TagName="ucViewArticle" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <ul class="breadcrumbs">
        <li><a href="/">Mavach.org</a></li>
        <li>Quy định đổi trả hàng</li>
    </ul>
    <div class="main-cc view-art">
        <uc1:ucViewArticle runat="server" ID="ucViewArticle1" ArticleID="26" ShowBody="true" />
    </div>
</asp:Content>
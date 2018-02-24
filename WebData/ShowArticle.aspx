<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/TemplateHome.master"
    AutoEventWireup="true" CodeFile="ShowArticle.aspx.cs" Inherits="ShowArticle" %>

<%@ Register Src="ucPreviousArticles.ascx" TagName="ucPreviousArticles" TagPrefix="uc2" %>
<%@ Register Src="ucEditArticleBar.ascx" TagName="ucEditArticleBar" TagPrefix="uc4" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Nội dung bài viết</li>
    </ul>
    <div class="main-cc view-art">
        <uc4:ucEditArticleBar ID="UcEditArticleBar1" runat="server" />
        <h3 class="title">
            <asp:Label ID="lblTitle" runat="server" />
        </h3>
        <div class="info">
            <asp:Label ID="lblDate" runat="server" />&nbsp;&nbsp;-&nbsp;&nbsp;
            <asp:Label ID="lblView" runat="server" />
        </div>
        <div class="social">
            <script type="text/javascript">
                var purl = location.href;
                var sc_href = purl.substring(0);

                document.write('<div class="fb-like" data-href="' + sc_href + '" data-layout="button_count" data-action="like" data-show-faces="true" data-share="true"></div>');

                document.write('<div class="g-plus" data-href="' + sc_href + '" data-action="share" data-annotation="bubble"></div>');
            </script>
        </div>
        <div class="abstract">
            <asp:Label ID="lblAbstract" runat="server" />
        </div>
        <div class="body">
            <asp:Literal ID="lblBody" runat="server" />
        </div>

        <div class="relateArt">
            <span>Bài viết cùng chủ đề</span>
            <uc2:ucPreviousArticles ID="ucPreviousArticles1" runat="server" MaxRow="10" />
        </div>
    </div>

</asp:Content>

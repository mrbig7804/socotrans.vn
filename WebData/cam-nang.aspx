<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="cam-nang.aspx.cs" Inherits="cam_nang" %>

<%@ Register Src="ucViewArticle.ascx" TagName="ucViewArticle" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Cẩm nang</li>
    </ul>
    <div class="main-cc pageArticles">
        <asp:HiddenField ID="hdfCatID" runat="server" Value="101" />
        <asp:ListView ID="lvArticles" runat="server" OnPagePropertiesChanging="lvArticles_PagePropertiesChanging">
            <ItemTemplate>
            <div class="item">
                <span class="image">
                    <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>'>
                        <asp:Image ID="Image1" AlternateText='<%# Eval("Title","{0}") %>' runat="server" ImageUrl='<%# Eval("PictureUrl") %>' OnDataBinding="Image1_DataBinding" />
                    </a>
                </span>
                <h3 class="title">
                    <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' ><%# SliptString((string)Eval("Title"), 80) %></a>
                </h3>
                <span class="ifoItem">
                    <span class="date"><%# Eval("ReleaseDate", "{0:dd/MM/yyyy}") %></span>&nbsp;&nbsp;
                    <span class="view"><%# Eval("ViewCount").ToString() + " lượt xem" %></span>
                </span>
                <div class="abstract">
                    <asp:Label ID="AbstractLabel" runat="server" Text='<%# SliptString((string)Eval("Abstract"), 500) %>' />
                </div>
                <div class="more">
                    <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>''>Xem thêm...</a>
                </div>
                <div class="clearfix"></div>
            </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:Panel ID="pnlPager" runat="server" Visible="false" CssClass="pagination">
            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvArticles" PageSize="12">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowNextPageButton="false"
                    ShowPreviousPageButton="false" FirstPageText="First " PreviousPageText="Previous " ButtonCssClass="pre_pager" />
                <asp:NumericPagerField ButtonCount="10" CurrentPageLabelCssClass="crr_page" NumericButtonCssClass="num_page" NextPreviousButtonCssClass="nav_page" NextPageText="&raquo;" PreviousPageText="&laquo;" />
                <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="false" ShowNextPageButton="false"
                    ShowPreviousPageButton="false" LastPageText=" Last" NextPageText=" Next" ButtonCssClass="pre_pager" />
                </Fields>
            </asp:DataPager>
        </asp:Panel>
    </div>
</asp:Content>

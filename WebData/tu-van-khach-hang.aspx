<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="tu-van-khach-hang.aspx.cs" Inherits="tu_van_khach_hang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" Runat="Server">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Tư vấn khách hàng</li>
    </ul>
    <div class="main-cc pageArticles">
        <asp:ListView ID="lvArticles" runat="server" OnPagePropertiesChanging="lvArticles_PagePropertiesChanging">
            <ItemTemplate>
            <div class="item">
                <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' class="image">
                    <asp:Image ID="Image1" AlternateText='<%# Eval("Title","{0}") %>' runat="server" ImageUrl='<%# Eval("PictureUrl") %>' OnDataBinding="Image1_DataBinding" />
                </a>
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
        <asp:Panel ID="pnlPager" runat="server" Visible="false">
            <div class="pager artpager">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvArticles" PageSize="12">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Image" ShowFirstPageButton="false" ShowNextPageButton="false"
                            ShowPreviousPageButton="false" FirstPageText="Trang đầu" PreviousPageImageUrl="~/images/previous.png" FirstPageImageUrl="~/images/first.png" />
                        <asp:NumericPagerField ButtonCount="10" CurrentPageLabelCssClass="crr_page" NumericButtonCssClass="num_page" />
                        <asp:NextPreviousPagerField ButtonType="Image" ShowLastPageButton="false" ShowNextPageButton="false"
                            ShowPreviousPageButton="false" LastPageText="Trang cuối" NextPageImageUrl="~/images/next.png" LastPageImageUrl="~/images/last.png" />
                    </Fields>
                </asp:DataPager>
            </div>
        </asp:Panel>
    </div>
</asp:Content>


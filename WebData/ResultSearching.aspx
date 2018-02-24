<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="ResultSearching.aspx.cs" Inherits="ResultSearching" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" Runat="Server">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Kết quả tìm kiếm</li>
    </ul>

    <asp:ListView ID="lvProducts" runat="server" OnPagePropertiesChanging="lvProducts_PagePropertiesChanging" OnItemCommand="lvProducts_ItemCommand">
        <ItemTemplate>
            <div class="col-sm-3 col-xs-6">
                <div class="products-item text-center">
                    <span class="image">
                        <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                            <img src='<%# Regex.Replace(Eval("SmallPictureUrl").ToString(), "~/", "/") %>' alt='<%# Eval("Title") %>' />
                        </a>
                    </span>
                    <h3 class="title">
                        <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                            <%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 32) %>
                        </a>
                    </h3>
                    <%--<span class="desc">
                        <%# Zensoft.Website.Utils.SliptString(Eval("Description").ToString(), 65) %>
                    </span>--%>
                    <%--<a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' class="more">Chi tiết</a>--%>
                    <p class="price">
                        <%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice")), Convert.ToInt32(Eval("SalePrice")))%>
                    </p>
                    <p class="addCart">
                        <asp:LinkButton runat="server" ID="lbntAddCart" Text="Cho vào giỏ" CommandName="AddCard" CommandArgument='<%# Eval("ProductID") %>' />
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    
    <asp:Panel ID="pnlPager" runat="server" Visible="false" CssClass="pagination">
        <asp:DataPager ID="dpProducts" runat="server" PagedControlID="lvProducts" PageSize="24">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowNextPageButton="false"
                    ShowPreviousPageButton="false" FirstPageText="First " PreviousPageText="Previous " ButtonCssClass="pre_pager" />
                <asp:NumericPagerField ButtonCount="10" CurrentPageLabelCssClass="crr_page" NumericButtonCssClass="num_page" NextPreviousButtonCssClass="nav_page" NextPageText="&raquo;" PreviousPageText="&laquo;" />
                <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="false" ShowNextPageButton="false"
                    ShowPreviousPageButton="false" LastPageText=" Last" NextPageText=" Next" ButtonCssClass="pre_pager" />
            </Fields>
        </asp:DataPager>
    </asp:Panel>
</asp:Content>


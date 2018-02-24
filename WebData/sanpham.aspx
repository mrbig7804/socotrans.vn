<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/TemplateHome.master" CodeFile="sanpham.aspx.cs" Inherits="sanpham" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Sản phẩm</li>
    </ul>

    <asp:ListView ID="lvProducts" runat="server" OnPagePropertiesChanging="lvProducts_PagePropertiesChanging" OnItemCommand="lvProducts_ItemCommand">
        <ItemTemplate>
            <div class="col-sm-3 col-xs-6">
                <div class="products-item text-center">
                    <figure class="image">
                        <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                            <img src='<%# Regex.Replace(Eval("SmallPictureUrl").ToString(), "~/", "/") %>' alt='<%# Eval("Title") %>' />
                        </a>
                    </figure>
                    <h3 class="title">
                        <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                            <%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 22) %>
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
                        <asp:LinkButton runat="server" ID="lbntAddCart" Text="" CommandName="AddCard" CommandArgument='<%# Eval("ProductID") %>' >
                            <span class="glyphicon glyphicon-shopping-cart" aria-hidden="true"></span>
                        </asp:LinkButton>
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

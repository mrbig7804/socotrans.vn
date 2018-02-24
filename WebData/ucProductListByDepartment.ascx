    <%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductListByDepartment.ascx.cs"
        Inherits="ucProductListByDepartment" %>

<asp:Repeater ID="rptProduct" runat="server" OnItemCommand="rptProduct_ItemCommand">
    <HeaderTemplate></HeaderTemplate>
    <FooterTemplate></FooterTemplate>
    <ItemTemplate>
        <div class="col-sm-3 col-xs-6">
            <div class="products-item text-center">
                <figure class="image">
                    <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                        <img src='<%# Regex.Replace(Eval("SmallPictureUrl").ToString(), "~/", "/") %>' alt='<%# Eval("Title") %>' width="250" height="250" />
                    </a>
                </figure>
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
                    <asp:LinkButton runat="server" ID="lbntAddCart" Text="" CommandName="AddCard" CommandArgument='<%# Eval("ProductID") %>' >
                        <span class="glyphicon glyphicon-shopping-cart" aria-hidden="true"></span>
                    </asp:LinkButton>
                </p>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="clearfix"></div>
<p class="more">
    <asp:HyperLink runat="server" ID="hplReadmore" Visible="false">Xem thêm</asp:HyperLink>
</p>
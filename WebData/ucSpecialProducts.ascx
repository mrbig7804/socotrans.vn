<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSpecialProducts.ascx.cs" Inherits="ucSpecialProducts" %>

<asp:Repeater ID="rptProducts" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>' class="image">
                <img alt='<%# Eval("Title") %>' src='<%#  Eval("SmallPictureUrl").ToString().Replace("~/", "/") %>' />
            </a>
            <h3 class="title">
                <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                    <%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 42) %>
                </a>
                <img alt='<%# Eval("Title") %>' src="/images/hot.gif" />
            </h3>
            <%--<span class="desc"><%# Zensoft.Website.Utils.SliptString(Eval("Description").ToString(), 48) %></span>--%>
            <%--<span class="price">
                <%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice")), Convert.ToInt32(Eval("SalePrice")))%>
            </span>--%>
        </li>
    </ItemTemplate>
</asp:Repeater>

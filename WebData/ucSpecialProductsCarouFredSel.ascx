<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSpecialProductsCarouFredSel.ascx.cs" Inherits="ucSpecialProductsCarouFredSel" %>

<script type="text/javascript">
    $(function () {
        $("#foo-product").carouFredSel({
            prev: '#prev',
            next: '#next',
            auto: true,
            direction: "left",
            height: 235,
            scroll: {
                items: 1,
                duration: 500,
                pauseOnHover: 'resume',
                fx: 'scroll'
            },
        });
    });
</script>

<asp:Repeater ID="rptProducts" runat="server">
    <HeaderTemplate><ul id="foo-product"></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <figure class="image">
                <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                    <img alt='<%# Eval("Title") %>' src='<%#  Eval("SmallPictureUrl").ToString().Replace("~/", "/") %>' />
                </a>
            </figure>
            <h3 class="title">
                <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                    <%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 32) %>
                </a>
            </h3>
            <%--<span class="price">
                <%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice")), Convert.ToInt32(Eval("SalePrice")))%>
            </span>--%>
        </li>
    </ItemTemplate>
</asp:Repeater>
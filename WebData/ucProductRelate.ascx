<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductRelate.ascx.cs" Inherits="ucProductRelate" %>

<%--<script type="text/javascript">
    $(function () {
        $("#foo-relproduct").carouFredSel({
            prev: '#prevrel',
            next: '#nextrel',
            auto: false,
            direction: "left",
            height: 220,
            align: "center",
            scroll: {
                fx: 'scroll',
                duration: 900,
                pauseOnHover: 'resume'
            },
        });
    });
</script>--%>

<%--<a id="prevrel" href="javascript:void(0)" class="pre-foorelProduct" title="Previous">
    <img src="/images/lpre_icon.jpg" alt="Siêu thị hoa tươi trực tuyến" />
</a>
<a id="nextrel" href="javascript:void(0)" class="next-foorelProduct" title="Next">
    <img src="/images/lnext_icon.jpg" alt="Siêu thị hoa tươi trực tuyến" />
</a>--%>

<asp:Repeater ID="rptProducts" runat="server">
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
                    <%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 32) %>
                </a>
            </h3>
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
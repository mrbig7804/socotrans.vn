<%@ control language="C#" autoeventwireup="true" codefile="ucCommandMenu.ascx.cs" inherits="admin_ucCommandMenu" %>

<asp:panel id="panArticles" runat="server">
    <span class="ttl-left-side ttl-left-side-article">Bài viết</span>
    <ul>
        <li><asp:hyperlink id="HyperLink1" runat="server" navigateurl="~/adm/Articles.aspx?action=add" Text="Tạo bài viết mới" /></li>
        <li><asp:hyperlink id="lnkCategories" runat="server" navigateurl="~/adm/ManageArticles.aspx" Text="Quản lý bài viết" /></li>
        <%--<li><asp:hyperlink id="HyperLink5" runat="server" navigateurl="~/adm/ManageArticles.aspx" Text="Bài viết" /></li>--%>
        <%--<li><asp:hyperlink id="HyperLink11" runat="server" navigateurl="~/adm/Comments.aspx" Text="Nhận xét" /></li>--%>
        <%--<li><asp:hyperlink id="lnkArticleHighlights" runat="server" navigateurl="~/adm/ManageArticleHighlights.aspx" Text="Tin nổi bật" /></li>--%>
    </ul>
</asp:panel>
<asp:panel id="panProducts" runat="server">
    <span class="ttl-left-side ttl-left-side-product">Sản phẩm</span>
    <ul>
        <li><asp:hyperlink id="HyperLink14" runat="server" navigateurl="~/adm/product.aspx?action=add" Text="Thêm sản phẩm mới" /></li>
        <li><asp:hyperlink id="HyperLink10" runat="server" navigateurl="~/adm/ManageProducts.aspx" Text="Quản lý sản phẩm" /></li>
        <li><asp:hyperlink id="HyperLink12" runat="server" navigateurl="~/adm/ManageSpecialProducts.aspx" Text="Sản phẩm đặc biệt" /></li>
        <%--<li><asp:hyperlink id="HyperLink18" runat="server" navigateurl="~/adm/ManageProductComments.aspx" Text="Phản hồi sản phẩm" /></li>--%>
        <%--<<li>asp:hyperlink id="HyperLink13" runat="server" navigateurl="~/adm/ManageProductSpecialsEdit.aspx" Text="Danh mục nổi bật" /></li>--%>
    </ul>
</asp:panel>
<asp:panel id="panMedia" runat="server">
    <span class="ttl-left-side ttl-left-side-media">Media</span>
    <ul>
        <li><asp:hyperlink id="lnkSlideshow" runat="server" navigateurl="~/adm/ManageSlideshow.aspx" Text="Quản lý Slideshow" /></li>
        <li><asp:hyperlink id="HyperLink15" runat="server" navigateurl="~/adm/ManageImageAlbum.aspx" Text="Quản lý Album Ảnh" /></li>
        <li><asp:hyperlink id="HyperLink17" runat="server" navigateurl="~/adm/ManageVideos.aspx" Text="Quản lý Video" /></li>
    </ul>
</asp:panel>
<%--<asp:panel id="panList" runat="server">
    <span class="ttl-left-side ttl-left-side-list">Danh mục khác</span>
    <ul>
        <li><asp:hyperlink id="HyperLink16" runat="server" navigateurl="~/adm/ManageCities.aspx" Text="Danh mục thành phố" /></li>
        <li><asp:hyperlink id="HyperLink20" runat="server" navigateurl="~/adm/ManageDirection.aspx" Text="Danh mục hướng" /></li>
    </ul>
</asp:panel>
<asp:panel id="panAccounts" runat="server">
    <span class="ttl-left-side ttl-left-side-account">Tài khoản</span>
    <ul>
        <li><asp:hyperlink id="HyperLink8" runat="server" navigateurl="~/adm/RegUser.aspx" Text="Tạo tài khoản mới" /></li>
        <li><asp:hyperlink id="HyperLink7" runat="server" navigateurl="~/adm/ManageUsers.aspx" Text="Quản lý tài khoản" /></li>
    </ul>
</asp:panel>--%>
<asp:panel id="panExtensions" runat="server">
    <span class="ttl-left-side ttl-left-side-exten">Mở rộng</span>
    <ul>
        <li><asp:hyperlink id="HyperLink4" runat="server" navigateurl="~/adm/ConfigWebsite.aspx" Text="Cấu hình website" /></li>
        <li><asp:hyperlink id="HyperLink6" runat="server" navigateurl="~/adm/ManageFeedbacks.aspx" Text="Phản hồi" /></li>
        <%--<li><asp:hyperlink id="HyperLink4" runat="server" navigateurl="~/adm/ManagePolls.aspx" Text="Thăm dò" /></li>--%>
        <%--<li><asp:hyperlink id="HyperLink2" runat="server" navigateurl="~/adm/manageComments.aspx" Text="Bình luận Bài Viết" /></li>--%>
        <%--<li><asp:hyperlink id="HyperLink3" runat="server" navigateurl="~/adm/ManageAdlinks.aspx" Text="Quảng Cáo" /></li>--%>
        <li><asp:hyperlink id="HyperLink9" runat="server" navigateurl="~/adm/Statistics.aspx" Text="Thống Kê" /></li>
    </ul>
</asp:panel>
<asp:panel id="pnlOrders" runat="server">
    <span class="ttl-left-side ttl-left-side-order">Đơn hàng</span>
    <ul>
        <li><asp:hyperlink id="HyperLink21" runat="server" navigateurl="~/adm/ManageOrders.aspx" Text="Quản trị đơn hàng" /></li>
    </ul>
</asp:panel>

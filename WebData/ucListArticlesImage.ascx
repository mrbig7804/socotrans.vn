<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListArticlesImage.ascx.cs" Inherits="ucListArticlesImage" %>

<script type="text/javascript" src="/Library/jquery.simplyscroll.js"></script>
<script type="text/javascript">
    $(function () {
        $("#CusScroller").simplyScroll({
            speed: 3,
            orientation: 'horizontal'
        });
    });
</script>

<asp:Repeater ID="rptArticles" runat="server">
    <HeaderTemplate><ul id="CusScroller" class="simply-scroll-list"></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <h3 class="title">
                <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' >
                    <%# SliptString(Eval("Title").ToString()) %>
                </a>
            </h3>
            <figure class="image">
                <a href='/bai-viet/<%# Eval("ArticleID") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' >
                    <img alt='<%# Eval("Title","{0}") %>' src='<%# Regex.Replace(Eval("PictureUrl").ToString(), "~/", "/") %>'/>
                </a>
            </figure>
			<p class="desc"><%# Zensoft.Website.Utils.SliptString(Eval("Abstract").ToString(), 90) %></p>
            <%--<p class="date"><%# Eval("ReleaseDate", "{0:dd/MM/yyyy}") %></p>--%>
        </li>
    </ItemTemplate>
</asp:Repeater>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListImgByAlbumsCarouFredsel.ascx.cs" Inherits="ucListImgByAlbumsCarouFredsel" %>

<script type="text/javascript">
    $(function () {
        $("#foo_imageAlb").carouFredSel({
            prev: '#prev_imageAlb',
            next: '#next_imageAlb',
            auto: true,
            direction: "left",
            height: 220,
            scroll: {
                duration: 800,
                pauseOnHover: 'resume',
                fx: 'scroll'
            },
        });
    });
</script>

<%--
<a id="prev" href="#"><<</a>
<a id="next" href="#">>></a>
--%>

<asp:Repeater ID="rptImages" runat="server">
    <HeaderTemplate><ul id="foo_imageAlb"></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <a href='/' title='<%# Eval("Title") %>' class="image">
                <img alt='<%# Eval("Title") %>' src='<%# Eval("PreviewUrl") %>' />
            </a>
        </li>
    </ItemTemplate>
</asp:Repeater>

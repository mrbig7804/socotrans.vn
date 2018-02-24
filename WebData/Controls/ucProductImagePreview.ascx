<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductImagePreview.ascx.cs"
    Inherits="Controls_ucProductImagePreview" %>
<script type="text/javascript">
    hs.graphicsDir = '/library/highslide/graphics/';
    hs.outlineType = 'rounded-white';
    hs.outlineWhileAnimating = true;
</script>

<div class="image_show">
    <a class="imagePreviewLink" id="lnkLargePic" title="Click vào ảnh để xem kích thước lớn hơn"
        onclick="return hs.expand(this, {captionId: 'caption1'})">
        <asp:Image align="center" ID="imgImagePreview" runat="server" />
    </a>
    <br />
    <small>Click vào ảnh để xem kích thước lớn hơn</small>
</div>

<div class="images_preview">
    <div style="position: absolute; top: 30px; left: 2px">
        <a id="prevImageThumbnail" href="javascript:void(0)" title="previous">
            <img src="/images/images_sn/spre_icon.jpg" alt="Sàn nhựa Hàn Quốc" />
        </a>
    </div>
    <div style="position: absolute; top: 30px; right: 2px">
        <a id="nextImageThumbnail" href="javascript:void(0)" title="next">
            <img src="/images/images_sn/snext_icon.jpg" alt="Sàn nhựa Hàn Quốc" />
        </a>
    </div>
    <asp:Repeater ID="dlImageThumbnail" runat="server" OnLoad="dlImageThumbnail_Load">
        <HeaderTemplate><ul id="foo_ImageThumbnail"></HeaderTemplate>
        <FooterTemplate></ul></FooterTemplate>
        <ItemTemplate>
            <li id='<%# "div" + Container.ItemIndex %>'>
                <div style="text-align: center; overflow: hidden;">
                    <a href='<%# "javaScript:RollOver(" + Container.ItemIndex +", lastImage)" %>' title="Click để xem ảnh">
                        <asp:Image Height="55px" ImageUrl='<%# Eval("SmallImage") %>' ID="Image2" runat="server" /></a>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</div>

<script type="text/javascript">
    var lastImage
    function showBorder(id, last) {

        if (id == last) return;
        document.getElementById("div" + id).style.border = 'solid 1px #fe0000'; //màu đường viền
        var lst = document.getElementById("div" + last);
        if (lst != null)
            lst.style.border = 'solid 1px #aaaaaa';
        lastImage = id;

    }

    function RollOver(image) {
        showBorder(image, lastImage)
        document.getElementById('<%= imgImagePreview.ClientID %>').src = arrImagePreview[image];
        document.getElementById('lnkLargePic').href = arrLargeImagePreview[image];
    }

    $(function () {
        $("#foo_ImageThumbnail").carouFredSel({
            prev: '#prevImageThumbnail',
            next: '#nextImageThumbnail',
            auto: false,
            //auto: {
            //    pauseOnHover: 'resume'
            //},
            direction: "left",
            height: 62,
            align: "center",
            scroll: {
                //item: 1,
                fx: 'scroll',
                duration: 900
            },
        });
    });

</script>
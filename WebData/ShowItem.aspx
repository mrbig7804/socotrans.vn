<%@ Page Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="ShowItem.aspx.cs" Inherits="ShowItem" %>

<%@ Register Src="Controls/ucProductImagePreview.ascx" TagName="ucProductImagePreview" TagPrefix="uc1" %>
<%@ Register Src="ucEditProductBar.ascx" TagName="ucEditProductBar" TagPrefix="uc2" %>
<%@ Register Src="ucProductGroupProperties.ascx" TagName="ucProductGroupProperties" TagPrefix="uc3" %>
<%@ Register Src="ucProductRelate.ascx" TagName="ucProductRelate" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" runat="Server">
    <div id="fb-root"></div>
    <script>
        var purl = location.href;
        var fb_href = purl.substring(0);

        $(document).ready(function () {
            $(".tabProperty").hide(); // Hide all tab conten divs by default
            $(".tabProperty:first").show(); // Show the first div of tab content by default
            $("#tabDetailShowItem ul li a").click(function () { //Fire the click event
                var activeTab = $(this).attr("ref"); // Catch the click link
                $("#tabDetailShowItem ul li a").removeClass("active"); // Remove pre-highlighted link
                $(this).addClass("active"); // set clicked link to highlight state
                $(".tabProperty").hide(); // hide currently visible tab content div
                $(activeTab).fadeIn(); // show the target tab content div by matching clicked link.
            });
        });
    </script>

    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li><a href="/san-pham">Sản phẩm</a></li>
        <li><asp:HyperLink runat="server" ID="hplDepartment" /></li>
        <%--<li><asp:Label runat="server" ID="lblTitlePage" /></li>--%>
    </ul>
    <div class="main-cc showItem">
        <div class="col-sm-6 img_showitem" >
            <uc1:ucProductImagePreview ID="UcProductImagePreview1" runat="server" />
        </div>
        <div class="col-sm-6 inf_showitem">
            <uc2:ucEditProductBar ID="ucEditProductBar1" runat="server" />
            <h2 class="title"><asp:Label ID="lblTitle" runat="server" /><asp:Label runat="server" ID="lblSale" CssClass="sale" /></h2>
            <span class="desc"><asp:Label ID="lblDescription" runat="server" /></span>
            <span>
                Đăng ngày:&nbsp;<asp:Label ID="lblAddedDate" runat="server" /> - Lượt xem:&nbsp;<asp:Label ID="lblViews" runat="server" />
            </span>
            <span>
                Nhóm hàng:&nbsp;<asp:Label ID="lblDepartment" runat="server" />
            </span>
            <!--<span>
                Nhãn hiệu:&nbsp;<asp:Label ID="lblBrand" runat="server" />
            </span>-->
            <span class="disc">
                Tình trạng:&nbsp;<asp:Label ID="lblDis" runat="server" />
            </span>
            <!--<span>
                Mã sản phẩm:&nbsp;<asp:Label ID="lblProductCode" runat="server" />
            </span>-->
            <span>
                Giá:&nbsp;<asp:Label ID="lblPrice" runat="server" CssClass="price" />
            </span>
            <asp:Panel runat="server" ID="pnlCart" CssClass="cartItem">
                <asp:LinkButton runat="server" ID="lbntAddCart" Text="Cho vào giỏ" OnClick="lbntAddCart_Click" CssClass="add" />&nbsp;
                <asp:LinkButton runat="server" ID="lbnNowCart" Text="Mua ngay" OnClick="lbnNowCart_Click" CssClass="now" />&nbsp;&nbsp;&nbsp;
                <%--<a href="javascript:void(0)" data-toggle="modal" data-target="#myModal">Mua</a>
                <uc5:ucModalCart runat="server" ID="ucModalCart1" />--%>
                <b>Số lượng:</b>&nbsp;
                <asp:DropDownList runat="server" ID="ddlQuantity" >
                    <asp:ListItem Value="1" Text="1" />
                    <asp:ListItem Value="2" Text="2" />
                    <asp:ListItem Value="3" Text="3" />
                    <asp:ListItem Value="4" Text="4" />
                    <asp:ListItem Value="5" Text="5" />
                    <asp:ListItem Value="6" Text="6" />
                    <asp:ListItem Value="7" Text="7" />
                    <asp:ListItem Value="8" Text="8" />
                    <asp:ListItem Value="9" Text="9" />
                    <asp:ListItem Value="10" Text="10" />
                    <asp:ListItem Value="11" Text="11" />
                    <asp:ListItem Value="12" Text="12" />
                    <asp:ListItem Value="13" Text="13" />
                    <asp:ListItem Value="14" Text="14" />
                    <asp:ListItem Value="15" Text="15" />
                    <asp:ListItem Value="16" Text="16" />
                    <asp:ListItem Value="17" Text="17" />
                    <asp:ListItem Value="18" Text="18" />
                    <asp:ListItem Value="19" Text="19" />
                    <asp:ListItem Value="20" Text="20" />
                </asp:DropDownList>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlBuy" CssClass="buyItem">
                (Đã có <asp:Label runat="server" ID="lblBuyItem" /> người mua sản phẩm này)
            </asp:Panel>
            <span class="hotline"><b>HOTLINE:</b> <a href="tel:0898253302">089.825.3302</a> - <a href="tel:0898253301">089.825.3301</a></span>
        </div>
        <div class="clearfix"></div>
        <div class="col-sm-12">
            <div id="tabDetailShowItem" class="tabDetailShowItem">
                <ul>
                    <li>
                        <a href="javascript:void(0)" ref="#tabProperty1" class="active">Tổng quan sản phẩm</a>
                    </li>
                    <%--<li>
                        <a href="javascript:void(0)" ref="#tabProperty2">Thông số kỹ thuật</a>
                    </li>--%>
                    <li>
                        <a href="javascript:void(0)" ref="#tabProperty3">Đánh giá sản phẩm</a>
                    </li>
                </ul>
            </div>
            <div class="tabProperties">
                <div id="tabProperty1" class="tabProperty">
                    <asp:Localize ID="lblDetail" runat="server" />
                </div>
                <%--<div id="tabProperty2" class="tabProperty infoProperties">
                    <uc3:ucProductGroupProperties runat="server" ID="ucProductGroupProperties1" />
                </div>--%>
                <div id="tabProperty3" class="tabProperty">
                    <script type='text/javascript'>
                        document.write('<div class="fb-comments" data-href="' + fb_href + '" data-width="780" data-numposts="10" data-colorscheme="light"></div>');
                    </script>
                </div>
            </div>
        </div>
    </div>

    <div>
        <h3 class="title-module"><span>Sản phẩm liên quan</span></h3>
        <div class="relateProducts">
            <uc4:ucProductRelate ID="ucProductRelate1" runat="server" />
        </div>
    </div>

</asp:Content>

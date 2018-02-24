<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="/ucSearchProducts.ascx" TagName="ucSearchProducts" TagPrefix="uc1" %>
<%@ Register Src="/ucSpecialProductsCarouFredSel.ascx" TagName="ucSpecialProductsCarouFredSel" TagPrefix="uc2" %>
<%@ Register Src="/ucProductListByDepartment.ascx" TagName="ucProductListByDepartment" TagPrefix="uc3" %>
<%@ Register Src="/ucSlider.ascx" TagName="ucSlider" TagPrefix="uc4" %>
<%@ Register Src="~/ucProductDepartment.ascx" TagName="ucProductDepartment" TagPrefix="uc5" %>
<%@ Register Src="~/ucListArticles.ascx" TagName="ucListArticles" TagPrefix="uc6" %>
<%@ Register Src="~/ucListVideos.ascx" TagName="ucListVideos" TagPrefix="uc7" %>
<%@ Register Src="~/ucListArticlesImage.ascx" TagName="ucListArticlesImage" TagPrefix="uc8" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div class="top-home">
        <div class="col-sm-3 productMenu">
            <uc1:ucSearchProducts runat="server" ID="ucSearchProducts1" />
            <uc5:ucProductDepartment runat="server" ID="ucProductDepartment" InputID="2" />
        </div>
        <div class="col-sm-9 collapse">
            <uc4:ucSlider runat="server" ID="ucSlider1" />
        </div>
    </div>
    <div class="col-sm-12 main-cc hotProducts">
        <h3 class="title-module"><span>Hoa Tươi Nổi Bật</span></h3>
        <uc2:ucSpecialProductsCarouFredSel runat="server" ID="ucSpecialProductsCarouFredSel1" MaxItem="20" SpecialID="1" />
    </div>
    <div class="col-sm-12 main-cc">
        <h3 class="title-module"><span>Bó hoa tươi</span></h3>
        <uc3:ucProductListByDepartment runat="server" ID="ucProductListByDepartment" SuperDepartmentID="2" DepartmentID="141" MaxItem="10" />
    </div>
    <div class="col-sm-12 main-cc">
        <h3 class="title-module"><span>Hộp hoa tươi</span></h3>
        <uc3:ucProductListByDepartment runat="server" ID="ucProductListByDepartment1" SuperDepartmentID="2" DepartmentID="142" MaxItem="10" />
    </div>
    <div class="col-sm-12 main-cc">
        <h3 class="title-module"><span>Giỏ hoa tươi</span></h3>
        <uc3:ucProductListByDepartment runat="server" ID="ucProductListByDepartment2" SuperDepartmentID="2" DepartmentID="143" MaxItem="10" />
    </div>
    <div class="col-sm-12 main-cc">
        <h3 class="title-module"><span>Bình hoa tươi</span></h3>
        <uc3:ucProductListByDepartment runat="server" ID="ucProductListByDepartment3" SuperDepartmentID="2" DepartmentID="144" MaxItem="10" />
    </div>
    <div class="bottom-home">
        <div class="col-sm-4 home-news">
            <h3 class="title-module"><span>Kiến thức - Chăm sóc hoa</span></h3>
            <uc6:ucListArticles runat="server" ID="ucListArticles1" CategoryID="100" MaxItem="10" />
        </div>
        <div class="col-sm-4 collapse">
            <h3 class="title-module"><span>Kết nối với chúng tôi</span></h3>
            <div class="face">
                <div class="fb-page" data-href="https://www.facebook.com/dienhoatructuyen24hBeanFlowers/" data-tabs="timeline" data-width="500" data-height="350" data-small-header="false" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true">
                    <div class="fb-xfbml-parse-ignore">
                        <blockquote cite="https://www.facebook.com/dienhoatructuyen24hBeanFlowers/">
                            <a href="https://www.facebook.com/dienhoatructuyen24hBeanFlowers/">Điện hoa trực tuyến Hải Phòng - Bean Flowers</a>
                        </blockquote>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-4 lib-video">
            <h3 class="title-module"><span>Thư viện Video</span></h3>
            <uc7:ucListVideos runat="server" ID="ucListVideos1" CategoryID="1" MaxItem="4" Width="252" Height="150" AutoPlay="false" />
        </div>
    </div>
    <div class="col-sm-12 main-cc">
        <h3 class="title-module"><span>Khách hàng</span></h3>
        <uc8:ucListArticlesImage runat="server" ID="ucListArticlesImage1" CategoryID="104" MaxItem="20" />
    </div>
</asp:Content>

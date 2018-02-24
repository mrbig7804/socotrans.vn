<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="DepartmentExtension.aspx.cs" Inherits="adm_DepartmentExtension" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page"><asp:Literal ID="ltrTitlePage" runat="server" /></h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Quản lý nhóm hàng</li>
        </ol>
    </div>
    <div class="content">
        <ul class="function-ExtDep">
            <li><asp:HyperLink runat="server" ID="hplNavPrice" class="btn btn-green">Tạo mức giá mới</asp:HyperLink></li>
            <li><asp:HyperLink runat="server" ID="hplNavBrand" class="btn btn-green">Thêm nhà sản xuất</asp:HyperLink></li>
            <li><asp:HyperLink runat="server" ID="hplNavProperty" class="btn btn-green">Thuộc tính dòng SP</asp:HyperLink></li>
        </ul>
        <div class="col-left-50">
            <div class="box box-blue">
                <div class="top-box">
                    <h1 class="list">Bảng giá chung</h1>
                </div>
                <div class="middle-box">
                    <asp:UpdatePanel runat="server" ID="upnGvwPrice">
                        <ContentTemplate>
                            <asp:GridView id="gvwPrice" runat="server" autogeneratecolumns="False" AllowPaging="true" PageSize="20"
                                DataSourceID="objPrices" datakeynames="PriceID" CssClass="tbl-grid" OnPageIndexChanging="gvwPrice_PageIndexChanging" >
                                <columns>
                                    <asp:boundfield datafield="Title" headertext="Mức giá" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left" />
                                    <asp:templatefield headertext="">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="ckbPrice" AutoPostBack="false"
                                                Checked='<%# CheckAvailablePriceDep(int.Parse(Eval("PriceID").ToString()), int.Parse(this.Request.QueryString["depID"])) %>' />
                                        </ItemTemplate>
                                        <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                    </asp:templatefield>
                                </columns>
                                <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                                <headerstyle cssclass="tbl-gridHeader" />
                                <alternatingrowstyle cssclass="tbl-gridAlternate" />
                                <SelectedRowStyle CssClass="tbl-GridSelected" />
                                <PagerStyle CssClass="tbl-gridPager" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:objectdatasource id="objPrices" runat="server" selectmethod="GetPriceDistanceAll" typename="Zensoft.Website.BusinessLayer.BusinessFacade.PriceDistanceBF" />
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnUpdatePriceDepartment" Text="Thiết lập" OnClick="lbtnUpdatePriceDepartment_Click" CssClass="btn btn-red" />
                </div>
            </div>
        </div>
        <div class="col-right-50">
            <div class="box box-blue">
                <div class="top-box">
                    <h1 class="list">Danh sách nhà sản xuất</h1>
                </div>
                <div class="middle-box">
                    <asp:UpdatePanel runat="server" ID="upnGvwBrand">
                        <ContentTemplate>
                            <asp:GridView id="gvwBrand" runat="server" autogeneratecolumns="False" AllowPaging="true" PageSize="20"
                                datasourceid="objBrands" datakeynames="BrandID" CssClass="tbl-grid" OnPageIndexChanging="gvwBrand_PageIndexChanging" >
                                <columns>
                                    <asp:boundfield datafield="Title" headertext="Nhà sản xuất" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField headertext="">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="ckbBrand" AutoPostBack="false"
                                                Checked='<%# CheckAvailableBrandDep(int.Parse(Eval("BrandID").ToString()), int.Parse(this.Request.QueryString["depID"])) %>' />
                                        </ItemTemplate>
                                        <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                    </asp:TemplateField>
                                </columns>
                                <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                                <headerstyle cssclass="tbl-gridHeader" />
                                <alternatingrowstyle cssclass="tbl-gridAlternate" />
                                <SelectedRowStyle CssClass="tbl-GridSelected" />
                                <PagerStyle CssClass="tbl-gridPager" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:objectdatasource id="objBrands" runat="server" selectmethod="GetBrandsAll" typename="Zensoft.Website.BusinessLayer.BusinessFacade.BrandsBF" />
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnUpdateBrandDepartment" Text="Thiết lập" OnClick="lbtnUpdateBrandDepartment_Click" CssClass="btn btn-red" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


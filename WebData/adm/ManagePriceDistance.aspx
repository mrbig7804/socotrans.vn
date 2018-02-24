<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManagePriceDistance.aspx.cs" Inherits="adm_ManagePriceDistance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Thiết lập giá</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">
                <asp:HyperLink runat="server" ID="hplNavPage" >Quản lý nhóm hàng</asp:HyperLink>
            </li>
            <li class="current">Thiết lập giá</li>
        </ol>
    </div>
    <div class="content">
        <div class="col-left-50">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Thông tin mức giá</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfId" />
                    <div class="row">
                        <label class="lbl lbl-small">Giá trước:</label>
                        <asp:TextBox runat="server" ID="txtPriceFrom" CssClass="txt" width="35%" />&nbsp;(VNĐ)
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPriceFrom" 
                            ErrorMessage="Nhập giá" CssClass="err" ValidationGroup="Price" Display="Dynamic" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPriceFrom" Display="Dynamic" CssClass="err"
                            ErrorMessage="Giá không hợp lệ" SetFocusOnError="true" ValidationExpression="\d{4,9}" ValidationGroup="Price" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Giá sau:</label>
                        <asp:TextBox runat="server" ID="txtPriceTo" CssClass="txt" width="35%" />&nbsp;(VNĐ)
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPriceTo"
                            ErrorMessage="Nhập giá" CssClass="err" ValidationGroup="Price" Display="Dynamic" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPriceTo" Display="Dynamic" CssClass="err"
                            ErrorMessage="Giá không hợp lệ" SetFocusOnError="true" ValidationExpression="\d{4,9}" ValidationGroup="Price" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="btnInsert" CssClass="btn btn-blue" ValidationGroup="Price" onclick="btnInsert_Click" />
                    <asp:LinkButton runat="server" ID="btnCancel" Text="Bỏ qua" CssClass="btn btn-green" onclick="btnCancel_Click" />
                </div>
            </div>
        </div>
        <div class="col-right-50">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="list">Bảng giá chung</h1>
                </div>
                <div class="middle-box">
                    <asp:gridview id="gvwPrice" runat="server" autogeneratecolumns="False" AllowPaging="true" PageSize="10"
                        datasourceid="objPrices" datakeynames="PriceID" CssClass="tbl-grid" OnPageIndexChanging="gvwPrice_PageIndexChanging"
                        onrowdeleted="gvwPrice_RowDeleted" onrowcreated="gvwPrice_RowCreated" onselectedindexchanged="gvwPrice_SelectedIndexChanged" >
                        <columns>
                            <asp:boundfield datafield="Title" headertext="Mức giá" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left" />
                            <asp:templatefield headertext="Phê duyệt">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="ckbAllow" Checked='<%# Eval("AllowSearcch") %>' AutoPostBack="true" OnCheckedChanged="ckbAllow_CheckedChanged" />
                                </ItemTemplate>
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                            </asp:templatefield>
                            <asp:commandfield buttontype="Image" selectimageurl="/adm/images_adm/blue-edit-icon.png" selecttext="Edit poll" HeaderText="Sửa"
                                showselectbutton="True">
                                <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="8%" />
                            </asp:commandfield>
                            <asp:commandfield buttontype="Image" deleteimageurl="/adm/images_adm/red-delete-icon.png" deletetext="Delete poll" HeaderText="Xóa"
                                showdeletebutton="True">
                                <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="8%" />
                            </asp:commandfield>
                        </columns>
                        <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                        <headerstyle cssclass="tbl-gridHeader" />
                        <alternatingrowstyle cssclass="tbl-gridAlternate" />
                        <SelectedRowStyle CssClass="tbl-GridSelected" />
                        <PagerStyle CssClass="tbl-gridPager" />
                    </asp:gridview>
                    <asp:objectdatasource id="objPrices" runat="server" selectmethod="GetPriceDistanceAll" typename="Zensoft.Website.BusinessLayer.BusinessFacade.PriceDistanceBF" DeleteMethod="Delete">
                        <DeleteParameters>
                            <asp:Parameter Name="priceID" Type="Int32" />
                        </DeleteParameters>
                    </asp:objectdatasource>
                </div>
                <div class="bottom-box"></div>
            </div>
        </div>
    </div>
</asp:Content>


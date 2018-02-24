<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageCities.aspx.cs" Inherits="adm_ManageCities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Quản lý danh mục thành phố</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Danh mục thành phố</li>
        </ol>
    </div>
    <div class="content">
        <div class="col-left">
            <div class="box box-blue">
                <asp:Literal runat="server" ID="ltrCities" />
            </div>
        </div>
        <div class="col-right">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Thông tin chi tiết</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfCityID" />
                    <div class="row">
                        <label class="lbl lbl-small">Tiêu đề:</label>
                            <asp:TextBox runat="server" ID="txtName" Width="52%" CssClass="txt" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                Display="Dynamic" ErrorMessage="Bạn chưa nhập tiêu đề" ValidationGroup="Cities" CssClass="err" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Mô tả:</label>
                        <asp:TextBox runat="server" ID="txtDesc" Width="52%" CssClass="txt" TextMode="MultiLine" Rows="4" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Nhóm danh mục:</label>
                        <asp:DropDownList runat="server" ID="ddlCities" Width="53.8%" CssClass="slt" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnUpdate" ValidationGroup="Cities" onclick="lbtnUpdate_Click" CssClass="btn btn-blue" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtnCancle" Text="Bỏ qua" onclick="lbtnCancle_Click" CssClass="btn btn-green" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtnDel" Text="Xóa" onclick="lbtnDel_Click" CssClass="btn btn-red" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


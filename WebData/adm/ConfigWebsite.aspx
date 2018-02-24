<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ConfigWebsite.aspx.cs" Inherits="adm_ConfigWebsite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Thông tin cấu hình</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Cấu hình website</li>
        </ol>
    </div>

    <div class="content">
        <div class="box-tabs">
            <ul id="nav-box-tabs" class="nav-box-tabs">
                <li>
                    <a href="javascript:void(0)" ref="#tabProduct1" class="active">Thông tin chân trang</a>
                </li>
            </ul>
            <div class="middle-box">
                <div id="tabProduct1" class="pane-box-tabs tbl-form">
                    <div class="row">
                        <label class="lbl lbl-small">Tiêu đề:</label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="txt" Width="50%" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Địa chỉ:</label>
                        <asp:TextBox ID="txtAdd" runat="server" CssClass="txt" Width="50%" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Điện thoại:</label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="50%" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="50%" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Website:</label>
                        <asp:TextBox ID="txtWeb" runat="server" CssClass="txt" Width="50%" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Facebook:</label>
                        <asp:TextBox ID="txtFace" runat="server" CssClass="txt" Width="50%" />
                    </div>
                </div>
            </div>
            <div class="bottom-box">
                <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-blue" ValidationGroup="Product" OnClick="btnSubmit_Click" Text="Xác nhận" />&nbsp;
                <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-green" ValidationGroup="Product" OnClick="btnView_Click" Text="Hủy bỏ" />
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/adm/libs/processPrice.js"></script>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageDirection.aspx.cs" Inherits="adm_ManageDirection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Quản lý danh mục hướng</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Danh mục hướng</li>
        </ol>
    </div>
    <div class="content">
        <div class="col-left">
            <asp:Repeater runat="server" ID="rptDirection" DataSourceID="objDirection" >
                <HeaderTemplate><ul id="browse_tree" class="box box-blue"></HeaderTemplate>
                <FooterTemplate></ul></FooterTemplate>
                <ItemTemplate>
                    <li style="position: relative">
                        <div class="treeNode">
                            <a href='/adm/ManageDirection.aspx?dirID=<%# Eval("DirectionID").ToString() %>' ><%# Eval("Title") %></a>
                            <span class="important">
                                <a href='/adm/ManageDirection.aspx?dirID=<%# Eval("DirectionID").ToString() %>&i=up' title="Up"><span class="up_btn" /></a>
                                <a href='/adm/ManageDirection.aspx?dirID=<%# Eval("DirectionID").ToString() %>&i=down' title="Down"><span class="down_btn" /></a>
                            </span>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="objDirection" runat="server" SelectMethod="GetDirectionAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.DirectionBF">
            </asp:ObjectDataSource>
        </div>
        <div class="col-right">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Thông tin chi tiết</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfDirID" />
                    <div class="row">
                        <label class="lbl lbl-small">Tiêu đề:</label>
                        <asp:TextBox runat="server" ID="txtTitle" Width="52%" CssClass="txt" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            Display="Dynamic" ErrorMessage="Bạn chưa nhập tiêu đề" CssClass="err" ValidationGroup="Direction" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Mô tả:</label>
                        <asp:TextBox runat="server" ID="txtDesc" Width="52%" CssClass="txt" TextMode="MultiLine" Rows="4" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnUpdate" ValidationGroup="Direction" onclick="lbtnUpdate_Click" CssClass="btn btn-blue" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtnCancle" Text="Bỏ qua" onclick="lbtnCancle_Click"  CssClass="btn btn-green" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtnDel" Text="Xóa" onclick="lbtnDel_Click"  CssClass="btn btn-red" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


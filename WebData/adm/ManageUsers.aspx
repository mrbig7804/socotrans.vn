<%@ Page Language="C#" Title="" AutoEventWireup="true"  MasterPageFile="~/adm/AdminTemplate.master" CodeFile="ManageUsers.aspx.cs" Inherits="admin_ListUsers" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphAdmin">
    <div class="content-header">
        <h1 class="title-page">Quản lý tài khoản quản trị</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Tài khoản quản trị</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-blue">
            <div class="top-box">
                <h1 class="info">
                    Tổng số tài khoản: <asp:Literal runat="server" ID="lblTotUsers" />&nbsp;-&nbsp;
                    Số người đang online: <asp:Literal runat="server" ID="lblOnlineUsers" />&nbsp;&nbsp;
                    <a href="RegUser.aspx" class="btn btn-blue">Tạo tài khoản mới</a>
                </h1>
            </div>
        </div>
        <div class="col-left">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="info">Tìm kiếm</h1>
                </div>
                <div class="middle-box">
                    <asp:DropDownList runat="server" ID="ddlSearchTypes" CssClass="slt">
                        <asp:ListItem Text="UserName" Selected="True" />
                        <asp:ListItem Text="E-mail" />
                    </asp:DropDownList>&nbsp;
                    <asp:TextBox runat="server" ID="txtSearchText" CssClass="inputCommand" /> 
                    <asp:Button runat="server" ID="btnSearch" Text="Tìm" OnClick="btnSearch_Click" CssClass="inputCommand" Width="48px" /><br />
                    Tìm theo ký tự đầu tiên của tên tài khoản<br />
                    <asp:Repeater runat="server" ID="rptAlphabet" OnItemCommand="rptAlphabet_ItemCommand">
                        <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Container.DataItem %>'
                            CommandArgument='<%# Container.DataItem %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:Repeater><br />
                    Tìm theo quyền<br />
                    <asp:Repeater runat="server" ID="rptRoles" OnItemCommand="rptRoles_ItemCommand">
                        <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Container.DataItem %>'
                            CommandArgument='<%# Container.DataItem %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:Repeater><br />
                    <asp:TextBox ID="txtAddRole" runat="server"></asp:TextBox>
                    <asp:Button ID="btnAddRole" runat="server" OnClick="btnAddRole_Click" Text="Thêm quyền" />
                </div>
                <div class="bottom-box"></div>
            </div>
        </div>
        <div class="col-right">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="list">Danh sách tài khoản</h1>
                </div>
                <div class="middle-box">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvwUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserName"
                                OnRowCreated="gvwUsers_RowCreated" OnRowDeleting="gvwUsers_RowDeleting" CssClass="tbl-grid" >
                                <Columns>
                                    <asp:BoundField HeaderText="Tài khoản" DataField="UserName" ItemStyle-Width="15%" />
                                    <asp:BoundField HeaderText="E-mail" DataField="Email"  />
                                    <asp:TemplateField HeaderText="Ngày tạo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="15%">
                                        <ItemTemplate><%# Eval("CreationDate", "{0:dd/MM/yyyy}")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hoạt động cuối" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="20%">
                                        <ItemTemplate><%# Eval("LastActivityDate", "{0:dd/MM/yyyy hh:mm tt}")%>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CheckBoxField HeaderText="Online" DataField="IsOnline" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="8%" />
                                    <asp:HyperLinkField Text="&lt;img src='/adm/images_adm/red-edit-icon.png' /&gt;" DataNavigateUrlFormatString="Edit_User.aspx?UserName={0}" DataNavigateUrlFields="UserName" 
                                        HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="8%"/>
                                    <asp:ButtonField CommandName="Delete" ButtonType="Image" ImageUrl="/adm/images_adm/red-delete-icon.png" HeaderText="Xóa" 
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="8%" />
                                </Columns>
                                <EmptyDataTemplate><b>Không có dữ liệu</b></EmptyDataTemplate>
                                <HeaderStyle CssClass="tbl-gridHeader" />
                                <AlternatingRowStyle CssClass="tbl-gridAlternate" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="rptRoles" EventName="ItemCommand" />
                            <asp:AsyncPostBackTrigger ControlID="rptAlphabet" EventName="ItemCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="bottom-box"></div>
            </div>
        </div>
    </div>
</asp:Content>

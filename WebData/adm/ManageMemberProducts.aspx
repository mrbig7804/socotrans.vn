<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageMemberProducts.aspx.cs" Inherits="adm_ManageMemberProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Quản lý sản phẩm của thành viên</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Sản phẩm của thành viên</li>
        </ol>
    </div>

    <div class="content">
        <div class="box box-red">
            <div class="top-box">
                <h1 class="list"><asp:Label runat="server" ID="lblTitleGridProduct" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountProduct" CssClass="badge" /></h1>
            </div>
            <div class="middle-box">
                <asp:gridview id="gvwProducts" runat="server" DataKeyNames="ProductID"
                     AllowPaging="True" PageSize="10" CssClass="tbl-grid" autogeneratecolumns="False" OnRowDeleting="gvwProducts_RowDeleting"
                     onrowdeleted="gvwProducts_RowDeleted" onrowcreated="gvwProducts_RowCreated" OnPageIndexChanging="gvwProducts_PageIndexChanging" >
                    <columns>
                        <asp:templatefield headertext="Hình ảnh">
                            <itemtemplate>
                                <asp:Image runat="server" ID="img" Width="105px" Height="80px" ImageUrl='<%# Eval("SmallPictureUrl") %>' CssClass="image" />
                            </itemtemplate>
                            <itemstyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                        </asp:templatefield>
                        <asp:templatefield headertext="Tiêu đề">
                            <itemtemplate>
                                <a href='/adm/product.aspx?action=edit&productID=<%# Eval("ProductID") %>' title='Xem chi tiết: <%# Eval("Title") %>'><%# Eval("Title")%></a>
                            </itemtemplate>
                            <itemstyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                        </asp:templatefield>
                        <asp:templatefield headertext="Ngày gửi">
                            <itemtemplate>
                                <%# Eval("AddedDate", "{0:dd/MM/yyyy}")%>
                            </itemtemplate>
                            <itemstyle width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:templatefield>
                        <asp:BoundField DataField="AddedBy" HeaderText="Người gửi" SortExpression="AddedBy" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                        <asp:templatefield headertext="Kiểm duyệt">
                            <itemtemplate>
                                <asp:CheckBox runat="server" ID="ckbListed" Checked='<%# Eval("Listed") %>' AutoPostBack="true" OnCheckedChanged="ckbListed_CheckedChanged" />
                            </itemtemplate>
                            <itemstyle width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:templatefield>
                        <asp:commandfield buttontype="Image" deleteimageurl="/adm/images_adm/red-delete-icon.png" deletetext="Delete poll" HeaderText="Xóa" showdeletebutton="True">
                            <itemstyle horizontalalign="Center" width="5%" />
                        </asp:commandfield>
                    </columns>
                    <emptydatatemplate>
                        <b>Không có dữ liệu</b>
                    </emptydatatemplate>
                    <headerstyle CssClass="tbl-gridHeader" />
                    <alternatingrowstyle CssClass="tbl-gridAlternate" />
                    <PagerStyle CssClass="tbl-gridPager" />
                </asp:gridview>
            </div>
            <div class="bottom-box"></div>
        </div>
    </div>
</asp:Content>


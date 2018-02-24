<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageImageAlbum.aspx.cs" Inherits="adm_ManageImageAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <div class="content-header">
        <h1 class="title-page">Quản lý Album ảnh</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Album ảnh</li>
        </ol>
    </div>
    <div class="content">
        <div class="col-left-50">
            <div class="box box-blue">
                <div class="top-box">
                    <h1 class="list">Danh sách Album ảnh</h1>
                </div>
                <div class="middle-box">
                    <asp:gridview id="grvAlbums" runat="server" DataSourceID="odsAlbums" allowpaging="True" PageSize="3" autogeneratecolumns="False" datakeynames="AlbumId" CssClass="tbl-grid"
                        OnPageIndexChanging="grvAlbums_PageIndexChanging" onrowcreated="grvAlbums_RowCreated" onselectedindexchanged="grvAlbums_SelectedIndexChanged" OnRowDeleting="grvAlbums_RowDeleting" >
                        <columns>
                            <asp:templatefield headertext="Ảnh đại diện">
                                <itemtemplate>
                                    <asp:Image runat="server" ID="img" Width="50px" Height="38px" ImageUrl='<%# Eval("PictureUrl") %>' CssClass="image" />
                                </itemtemplate>
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:templatefield>
                            <asp:boundfield datafield="Title" headertext="Tiêu đề" sortexpression="Title" ItemStyle-HorizontalAlign="Left" />
                            <asp:boundfield applyformatineditmode="True" datafield="AddedDate" dataformatstring="{0:dd/MM/yyyy}"
                                headertext="Ngày tạo" sortexpression="AddedDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="18%" />
                            <asp:templatefield headertext="Hiển thị">
                                <itemtemplate>
                                    <asp:CheckBox runat="server" ID="ckbListed" Checked='<%# Eval("Listed") %>' AutoPostBack="true" OnCheckedChanged="ckbPublished_CheckedChanged" />
                                </itemtemplate>
                                <itemstyle width="12%" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:templatefield>
                            <asp:commandfield buttontype="Image" selectimageurl="/adm/images_adm/red-edit-icon.png" selecttext="Edit poll" HeaderText="Sửa"
                                showselectbutton="True">
                                <itemstyle horizontalalign="Center" width="8%" />
                            </asp:commandfield>
                            <asp:commandfield buttontype="Image" deleteimageurl="/adm/images_adm/red-delete-icon.png" deletetext="Delete poll" HeaderText="Xóa"
                                showdeletebutton="True">
                                <itemstyle horizontalalign="Center" width="8%" />
                            </asp:commandfield>
                        </columns>
                        <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                        <headerstyle cssclass="tbl-gridHeader" />
                        <alternatingrowstyle cssclass="tbl-gridAlternate" />
                        <SelectedRowStyle CssClass="tbl-GridSelected" />
                        <PagerStyle CssClass="tbl-gridPager" />
                    </asp:gridview>
                    <asp:ObjectDataSource ID="odsAlbums" runat="server" DeleteMethod="Delete" SelectMethod="GetAlbumAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.AlbumBF">
                        <DeleteParameters>
                            <asp:Parameter Name="albumId" Type="Int32" />
                        </DeleteParameters>
                    </asp:ObjectDataSource>
                </div>
                <div class="bottom-box"></div>
            </div>
        </div>
        <div class="col-right-50">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info"><asp:Label runat="server" ID="lblTitleAlbum" /></h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfAlbumID" />
                    <div class="row">
                        <label class="lbl lbl-small">Tiêu đề:</label>
                        <asp:TextBox runat="server" ID="txtTitleAlbum" CssClass="txt" Width="52%" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitleAlbum"
                            Display="Dynamic" ErrorMessage="Nhập tiêu đề" CssClass="err" ValidationGroup="Album" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Mô tả:</label>
                        <asp:TextBox runat="server" ID="txtDescAlbum" CssClass="txt" Width="52%" TextMode="MultiLine" Rows="8" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnUpdateAlbum" OnClick="lbtnUpdateAlbum_Click" ValidationGroup="Album" CssClass="btn btn-blue" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtnCancleAlbum" Text="Bỏ qua" OnClick="lbtnCancleAlbum_Click" CssClass="btn btn-green" />
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <asp:Panel runat="server" ID="pnlGridImage" class="col-left-50">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="list">Danh sách ảnh<asp:Label runat="server" ID="lblTitleGridAlbumImage" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountAlbumImage" CssClass="badge" /></h1>
                </div>
                <div class="middle-box">
                    <asp:gridview id="gvwImages" runat="server" allowpaging="True" PageSize="5" autogeneratecolumns="False" datakeynames="ImageId" CssClass="tbl-grid"
                        OnPageIndexChanging="gvwImages_PageIndexChanging" onrowcreated="gvwImages_RowCreated" onselectedindexchanged="gvwImages_SelectedIndexChanged" OnRowDeleting="gvwImages_RowDeleting" >
                        <columns>
                            <asp:templatefield headertext="Hình ảnh">
                                <itemtemplate>
                                    <asp:Image runat="server" ID="img" Width="80px" Height="60px" ImageUrl='<%# Eval("PreviewUrl") %>' CssClass="image" />
                                </itemtemplate>
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                            </asp:templatefield>
                            <asp:boundfield datafield="Title" headertext="Tiêu đề" sortexpression="Title" ItemStyle-HorizontalAlign="Left" />
                            <asp:templatefield headertext="Ảnh đại diện">
                                <itemtemplate>
                                    <asp:CheckBox runat="server" ID="ckbListed" Checked='<%# Eval("IsMain") %>' AutoPostBack="true" OnCheckedChanged="ckbListed_CheckedChanged" />
                                </itemtemplate>
                                <itemstyle width="20%" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:templatefield>
                            <asp:commandfield buttontype="Image" selectimageurl="/adm/images_adm/red-edit-icon.png" selecttext="Edit poll" HeaderText="Sửa"
                                showselectbutton="True">
                                <itemstyle horizontalalign="Center" width="8%" />
                            </asp:commandfield>
                            <asp:commandfield buttontype="Image" deleteimageurl="/adm/images_adm/red-delete-icon.png" deletetext="Delete poll" HeaderText="Xóa"
                                showdeletebutton="True">
                                <itemstyle horizontalalign="Center" width="8%" />
                            </asp:commandfield>
                        </columns>
                        <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                        <headerstyle cssclass="tbl-gridHeader" />
                        <alternatingrowstyle cssclass="tbl-gridAlternate" />
                        <SelectedRowStyle CssClass="tbl-GridSelected" />
                        <PagerStyle CssClass="tbl-gridPager" />
                    </asp:gridview>
                </div>
                <div class="bottom-box"></div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlInfoImage" class="col-right-50">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Thông tin ảnh</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfImageId" />
                    <div class="row">
                        <label class="lbl lbl-small">Tiêu đề:</label>
                            <asp:TextBox runat="server" ID="txtTitleImage" Width="52%" CssClass="txt" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitleImage"
                                Display="Dynamic" ErrorMessage="Nhập tiêu đề" CssClass="err" ValidationGroup="Image" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Mô tả:</label>
                        <asp:TextBox runat="server" ID="txtDescImage" Width="52%" CssClass="txt" TextMode="MultiLine" Rows="8" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-small">Kích thước:</label>
                        <asp:TextBox ID="txtImageWidth" runat="server" CssClass="txt txt-disabled" Width="10%" Enabled="false" /> x <asp:TextBox ID="txtImageHeight" runat="server" CssClass="txt txt-disabled" Width="10%" Enabled="false" />
                    </div>
                    <div>
                    <asp:Panel runat="server" ID="pnlImageUrl" CssClass="row">
                        <label class="lbl lbl-small">Đường dẫn:</label>
                            <asp:FileUpload runat="server" ID="fuImage" CssClass="txt txt-file" Width="54.5%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="Chọn ảnh" ToolTip="" CssClass="err" ValidationGroup="Image" 
                                ControlToValidate="fuImage" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="fuImage" Display="Dynamic" 
                                ErrorMessage="Định dạng ảnh" CssClass="err" 
                                ValidationExpression="^([0-9a-zA-Z_\-~ :\\(). ])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$" 
                                ValidationGroup="Image" />
                    </asp:Panel>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnUpdateImage" OnClick="lbtnUpdateImage_Click" ValidationGroup="Image" CssClass="btn btn-blue" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtnCancleImage" Text="Bỏ qua" OnClick="lbtnCancleImage_Click" CssClass="btn btn-green" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

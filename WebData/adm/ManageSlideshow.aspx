<%@ Page Title="" validaterequest="false" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageSlideshow.aspx.cs" Inherits="adm_ManageSlideshow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Quản lý ảnh slideshow</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Ảnh slideshow</li>
        </ol>
    </div>
    
    <div class="content">
        <div class="col-left-50">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="list">Danh sách ảnh</h1>
                </div>
                <div class="middle-box">
                    <asp:gridview id="gvwArticleHighlights" runat="server" autogeneratecolumns="False"
                        datasourceid="objArticleHighlights" datakeynames="ArticleHighlightID" CssClass="tbl-grid"
                        onrowdeleted="gvwArticleHighlights_RowDeleted" onrowcreated="gvwArticleHighlights_RowCreated" onselectedindexchanged="gvwArticleHighlights_SelectedIndexChanged" >
                        <columns>
                            <asp:templatefield headertext="Hình ảnh">
                                <itemtemplate>
                                    <asp:Image runat="server" ID="img" Width="135px" Height="55px" ImageUrl='<%# Eval("PictureUrl") %>' CssClass="image" />
                                </itemtemplate>
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:templatefield>
                            <%--<asp:boundfield datafield="Title" headertext="Tiêu đề" ItemStyle-VerticalAlign="Top" />--%>
                            <asp:templatefield headertext="Ngày tạo">
                                <itemtemplate><%# Eval("AddedDate", "{0:dd/MM/yyyy}")%></itemtemplate>
                                <itemstyle width="20%" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:templatefield>
                            <asp:templatefield headertext="Hiển thị">
                                <itemtemplate>
                                    <asp:CheckBox runat="server" ID="ckbListed" Checked='<%# Eval("Listed") %>' AutoPostBack="true" OnCheckedChanged="ckbListed_CheckedChanged" />
                                </itemtemplate>
                                <itemstyle width="20%" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                    <asp:objectdatasource id="objArticleHighlights" runat="server" selectmethod="GetArticleHighlightsAll" typename="Zensoft.Website.BusinessLayer.BusinessFacade.ArticleHighlightsBF" deletemethod="Delete">
                        <deleteparameters>
                            <asp:parameter name="articleHighlightID" type="Int32" />
                        </deleteparameters>
                    </asp:objectdatasource>
                </div>
                <div class="bottom-box"></div>
            </div>
        </div>
        <div class="col-right-50">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Thông tin chi tiết</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfId" />
                    <div class="row">
                        <label class="lbl lbl-medium">Tiêu đề:</label>
                        <asp:TextBox runat="server" ID="txtTitle" CssClass="txt" width="52%" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Đường dẫn URL:</label>
                        <asp:TextBox runat="server" ID="txtUrl" CssClass="txt" width="52%" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Kích thước:</label>
                        <asp:TextBox ID="txtSlideWidth" runat="server" CssClass="txt txt-disabled" Width="10%" Enabled="false" /> x <asp:TextBox ID="txtSlideHeight" runat="server" CssClass="txt txt-disabled" Width="10%" Enabled="false" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Đường dẫn ảnh:</label>
                        <asp:Panel runat="server" ID="pnImage">
                            <asp:FileUpload runat="server" ID="fuImage" CssClass="txt txt-file" Width="54.5%" />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnChangeImage">
                            <asp:TextBox runat="server" ID="lblLink" CssClass="txt txt-disabled" Width="36.5%" Enabled="false" />
                            <asp:LinkButton runat="server" ID="hplChange" Text="Xóa ảnh" onclick="hplChange_Click" CssClass="btn btn-blue" />
                        </asp:Panel>
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium"></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fuImage" 
                            ErrorMessage="Bạn chưa chọn ảnh" CssClass="err" ValidationGroup="Slideshow" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="fuImage" Display="Dynamic" 
                            ErrorMessage="Chọn đúng định dạng ảnh" CssClass="err" ValidationGroup="Slideshow"
                            ValidationExpression="^([0-9a-zA-Z_\-~ :\\(). ])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="btnInsert" CssClass="btn btn-blue" ValidationGroup="Slideshow" onclick="btnInsert_Click" />
                    <asp:LinkButton runat="server" ID="btnCancel" Text="Bỏ qua" CssClass="btn btn-green" onclick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


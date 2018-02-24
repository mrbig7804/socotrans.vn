<%@ page language="C#" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true"
    codefile="ManageArticles.aspx.cs" inherits="admin_ManageArticles" %>

<asp:content id="Content1" contentplaceholderid="cphAdmin" runat="Server">
    <script type="text/javascript">
        function showhideToggle() {
            if (document.getElementById("linkShowHide").innerHTML != 'Close') {
                document.getElementById("linkShowHide").innerHTML = 'Close';
                document.getElementById("linkShowHide").className = 'breadcrumbClose';
            }
            else {
                document.getElementById("linkShowHide").innerHTML = 'Open';
                document.getElementById("linkShowHide").className = 'breadcrumbOpen';
            }
            return false;
        }
    </script>

    <div class="content-header">
        <h1 class="title-page">Quản lý bài viết</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Quản lý bài viết</li>
        </ol>
    </div>

    <div class="content">
        <div class="col-left">
            <asp:Repeater runat="server" ID="rptSuperCat" DataSourceID="odsSuperCategory" onitemdatabound="rptSuperCat_ItemDataBound">
                <HeaderTemplate><ul id="browse_tree" class="box box-blue"></HeaderTemplate>
                <FooterTemplate></ul></FooterTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" ID="hplSuperCat" NavigateUrl="/adm/ManageArticles.aspx"><%# Eval("Title") %></asp:HyperLink>
                        <asp:Literal runat="server" ID="ltrCat" />
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsSuperCategory" runat="server" SelectMethod="GetSuperCategoriesAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.SuperCategoriesBF" />
        </div>
        <div class="col-right">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info"><asp:Label runat="server" ID="lblTitleCat" /></h1>
                    <a id="linkShowHide" onclick="return showhideToggle()" class="breadcrumbClose" href="javascript:void(0)">Close</a>
                </div>
                <div id="showHide">
                    <div class="middle-box tbl-form">
                        <asp:HiddenField runat="server" ID="hdfCat" />
                        <div class="row">
                            <label class="lbl lbl-small">Tiêu đề:</label>
                            <asp:TextBox runat="server" ID="txtTitle" CssClass="txt" Width="52%" />
                            <asp:RequiredFieldValidator ID="rfvtitle" runat="server" ControlToValidate="txtTitle"
                                Display="Dynamic" ErrorMessage="Bạn chưa nhập tiêu đề" CssClass="err" ValidationGroup="Category" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Mô tả:</label>
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="txt" Width="52%" TextMode="MultiLine" Rows="6" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Thư mục:</label>
                            <asp:DropDownList runat="server" ID="ddlChildren" CssClass="slt" Width="53.8%" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Kích thước ảnh:</label>
                            <asp:TextBox ID="txtCatWidth" runat="server" CssClass="txt txt-disabled" Width="8%" Enabled="false" /> x <asp:TextBox ID="txtCateHeight" runat="server" CssClass="txt txt-disabled" Width="8%" Enabled="false" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Đường dẫn ảnh:</label>
                            <asp:Panel runat="server" ID="pnImage">
                                <asp:FileUpload runat="server" ID="fuImage" CssClass="txt txt-file" Width="53.8%" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  CssClass="err"
                                    ControlToValidate="fuImage" Display="Dynamic" ErrorMessage="Chọn đúng định dạng ảnh" ValidationGroup="Department"
                                    ValidationExpression="^([0-9a-zA-Z_\-~ :\\(). ])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnChangeImage">
                                <asp:TextBox runat="server" ID="txtImageUrl" Width="52%" CssClass="txt txt-disabled" Enabled="false" />
                                <asp:LinkButton runat="server" ID="hplChange" Text="Xóa ảnh" onclick="hplChange_Click" CssClass="btn btn-blue" />
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="bottom-box">
                        <asp:LinkButton runat="server" ID="lbtnUpdate" ValidationGroup="Category" onclick="lbtnUpdate_Click" CssClass="btn btn-blue" />&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="lbtnCancle" Text="Bỏ qua" onclick="lbtnCancle_Click" CssClass="btn btn-green" />&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="lbtnDel" Text="Xóa" onclick="lbtnDel_Click" CssClass="btn btn-red" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa thư mục này?') == false) return false;" />
                    </div>
                </div>
            </div>
            
            <asp:UpdatePanel runat="server" ID="udpArticles">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlArticles" CssClass="box box-green">
                        <div class="top-box">
                            <h1 class="list">Danh sách bài viết&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountArticle" CssClass="badge" /></h1>
                        </div>
                        <div class="middle-box">
                            <asp:gridview id="grvArticles" runat="server" allowpaging="True" PageSize="10" autogeneratecolumns="False"
                                CssClass="tbl-grid" datakeynames="ArticleID"
                                gridlines="Vertical" width="100%" OnPageIndexChanging="grvArticles_PageIndexChanging" OnRowDeleting="grvArticles_RowDeleting" >
                                <columns>
                                    <asp:templatefield headertext="Hình ảnh">
                                        <itemtemplate>
                                            <asp:Image runat="server" ID="img" Width="70px" Height="55px" ImageUrl='<%# Eval("PictureUrl") %>' CssClass="image" />
                                        </itemtemplate>
                                        <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:templatefield>
                                    <asp:hyperlinkfield datanavigateurlfields="ArticleID" datanavigateurlformatstring="Articles.aspx?Action=edit&amp;ArticleID={0}" datatextfield="Title" headertext="Tiêu đề" sortexpression="Title">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="45%" Font-Bold="true" />
                                    </asp:hyperlinkfield>
                                    <asp:boundfield datafield="ViewCount" headertext="Lượt xem" sortexpression="ViewCount">
                                        <ItemStyle width="10%" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </asp:boundfield>
                                    <asp:boundfield datafield="AddedBy" headertext="Người tạo" sortexpression="AddedBy">
                                        <ItemStyle width="12%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:boundfield>
                                    <asp:boundfield datafield="AddedDate" dataformatstring="{0:dd/MM/yyyy}" headertext="Ngày tạo" sortexpression="AddedDate">
                                        <ItemStyle width="12%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:boundfield>
                                    <asp:templatefield HeaderText="Xóa" >
                                        <itemtemplate>
                                            <asp:linkbutton id="btnDelete" runat="server" commandname="Delete" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa bài viết này?') == false) return false;">
                                                <img src="/adm/images_adm/red-delete-icon.png" alt="Administrator MB" />
                                            </asp:linkbutton>
                                        </itemtemplate>
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="5%" />
                                    </asp:templatefield>
                                </columns>
                                <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                                <headerstyle cssclass="tbl-gridHeader" />
                                <alternatingrowstyle cssclass="tbl-gridAlternate" />
                                <SelectedRowStyle CssClass="tbl-GridSelected" />
                                <PagerStyle CssClass="tbl-gridPager" />
                            </asp:gridview>
                        </div>  
                        <div class="bottom-box"></div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:content>

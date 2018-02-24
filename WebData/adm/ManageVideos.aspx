<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageVideos.aspx.cs" Inherits="adm_ManageVideos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <script type="text/javascript">
        function showhideToggle() {
            if (document.getElementById("linkShowHide").innerHTML != 'Hide') {
                document.getElementById("linkShowHide").innerHTML = 'Hide';
                document.getElementById("linkShowHide").className = 'breadcrumbClose';
            }
            else {
                document.getElementById("linkShowHide").innerHTML = 'Show';
                document.getElementById("linkShowHide").className = 'breadcrumbOpen';
            }
            return false;
        }
    </script>

    <div class="content-header">
        <h1 class="title-page">Quản lý Video</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Quản lý video</li>
        </ol>
    </div>

    <div class="content">
        <div class="col-left">
            <div class="box box-blue">
                <asp:Literal runat="server" ID="ltrCat" />
            </div>
        </div>
        <div class="col-right">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info"><asp:Label runat="server" ID="lblTitleCVideo" /></h1>
                    <a id="linkShowHide" onclick="return showhideToggle()" class="breadcrumbClose" href="javascript:void(0)">Hide</a>
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
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="txt" Width="52%" TextMode="MultiLine" Rows="4" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Thư mục:</label>
                            <asp:DropDownList runat="server" ID="ddlParent" CssClass="slt" Width="53.8%" DataTextField="Title" DataValueField="CategoryID" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Đường dẫn ảnh:</label>
                            <asp:TextBox runat="server" ID="txtImageUrl" CssClass="txt txt-disabled" Width="52%" Enabled="false" />
                        </div>
                    </div>
                    <div class="bottom-box">
                        <asp:LinkButton runat="server" ID="lbtnUpdate" ValidationGroup="Category" onclick="lbtnUpdate_Click" CssClass="btn btn-blue" />&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="lbtnCancle" Text="Bỏ qua" onclick="lbtnCancle_Click" CssClass="btn btn-green" />&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="lbtnDel" Text="Xóa" onclick="lbtnDel_Click" CssClass="btn btn-red" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa danh mục này?') == false) return false;" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <asp:Panel runat="server" ID="pnlGridVideos" class="col-left-50">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="list">Video<asp:Label runat="server" ID="lblTitleGridVideo" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountVideo" CssClass="badge" /></h1>
                </div>
                <div class="middle-box">
                    <asp:gridview id="grvVideos" runat="server" allowpaging="True" PageSize="6" autogeneratecolumns="False" datakeynames="VideoID" CssClass="tbl-grid"
                        OnPageIndexChanging="grvVideos_PageIndexChanging" onrowcreated="grvVideos_RowCreated" onselectedindexchanged="grvVideos_SelectedIndexChanged" OnRowDeleting="grvVideos_RowDeleting" >
                        <columns>
                            <asp:boundfield datafield="Title" headertext="Tiêu đề" sortexpression="Title" ItemStyle-HorizontalAlign="Left" />
                            <asp:boundfield datafield="ViewCount" headertext="Lượt xem" sortexpression="ViewCount" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" />
                            <asp:boundfield applyformatineditmode="True" datafield="AddedDate" dataformatstring="{0:dd/MM/yyyy}"
                                headertext="Ngày tạo" sortexpression="AddedDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25%" />
                            <asp:templatefield headertext="Hiển thị">
                                <itemtemplate>
                                    <asp:CheckBox runat="server" ID="ckbPublished" Checked='<%# Eval("Published") %>' AutoPostBack="true" OnCheckedChanged="ckbPublished_CheckedChanged" />
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
                </div>
                <div class="bottom-box"></div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlInfoVideo" class="col-right-50">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Thông tin Video</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfVideo" />
                    <div class="row">
                        <label class="lbl lbl-medium">Tiêu đề video:</label>
                        <asp:TextBox runat="server" ID="txtTitleVideo" CssClass="txt" Width="52%" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitleVideo"
                            Display="Dynamic" ErrorMessage="Bạn chưa nhập tiêu đề" CssClass="err" ValidationGroup="Video" />
                    </div>
                    <div class="row">
                        <label  class="lbl lbl-medium">Mô tả:</label>
                        <asp:TextBox runat="server" ID="txtDescVideo" CssClass="txt" Width="52%" TextMode="MultiLine" Rows="4" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Đường dẫn video:</label>
                        <asp:TextBox runat="server" ID="txtVideoUrl" CssClass="txt" Width="52%" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVideoUrl"
                            Display="Dynamic" ErrorMessage="Bạn chưa nhập đường dẫn" CssClass="err" ValidationGroup="Video" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Thư mục:</label>
                        <asp:DropDownList runat="server" ID="ddlCatVideo" CssClass="slt" Width="54.7%" DataTextField="Title" DataValueField="CategoryID" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnUpdateVideo" ValidationGroup="Video" onclick="lbtnUpdateVideo_Click" CssClass="btn btn-blue" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtnCancleVideo" Text="Bỏ qua" onclick="lbtnCancleVideo_Click" CssClass="btn btn-green" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>


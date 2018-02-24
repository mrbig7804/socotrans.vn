<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucArticleDetail.ascx.cs" Inherits="admin_ucArticleDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div id="tabArticle1" class="pane-box-tabs tbl-form">
    <div class="row">
        <label class="lbl lbl-small">Tiêu đề:</label>
        <asp:TextBox ID="txtTitle" runat="server" Width="52%" CssClass="txt" />
        <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" SetFocusOnError="true"
            ErrorMessage="Tiêu đề bài viết" ValidationGroup="Article" CssClass="err" />
    </div>
    <div class="row">
        <label class="lbl lbl-small">Thuộc mục:</label>
        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="slt" Width="53.3%" />
    </div>
    <div class="row">
        <label class="lbl lbl-small">Ảnh minh họa:</label>
        <script type="text/javascript">
            function uploadComplete(sender, args) {

                var img = document.getElementById("<%= imgPreview.ClientID %>");
                var txt = document.getElementById("<%= hiddenPictureUrl.ClientID %>");

                img.setAttribute("src", '<%= GetSavePath().Replace("~/","/") %>preview_' + args.get_fileName());
                txt.setAttribute("value", '<%= GetSavePath().Replace("~/","/") %>preview_' + args.get_fileName());
            }
        </script>
        <asp:Label runat="server" ID="myThrobber" Style="display: none;">
            <img align="absmiddle" alt="" src="/adm/images_adm/indicator.gif" />
        </asp:Label>
        <asp:Image ID="imgPreview" runat="server" />
        <ajaxToolkit:AsyncFileUpload runat="server" ID="AsyncFileUpload1" Width="65%" UploaderStyle="Traditional" CssClass="txt txt-file" style="margin-left: 17.6%"
            OnClientUploadComplete="uploadComplete" UploadingBackColor="#CCFFFF" ThrobberID="myThrobber" />
        <asp:HiddenField runat="server" ID="hiddenPictureUrl" />
    </div>
    <div class="row">
        <label class="lbl lbl-small"></label>
        <asp:CheckBox ID="chkResize" Text="Resize ảnh" Checked="true" runat="server" CssClass="chk" />&nbsp;:&nbsp;
        <asp:TextBox ID="txtWitdh" onkeypress="javascript:keypress(event)" CssClass="txt txt-disabled" Width="5%" runat="server" Enabled="false" />&nbsp;x&nbsp;
        <asp:TextBox ID="txtHeight" onkeypress="javascript:keypress(event)" CssClass="txt txt-disabled" Width="5%" runat="server" Enabled="false" />
    </div>
    <div class="row">
        <label class="lbl lbl-small">Tóm tắt:</label>
        <asp:TextBox ID="txtAbstract" runat="server" TextMode="MultiLine" Width="52%" Rows="8" CssClass="txt" />
    </div>
    <div class="row">
        <CKEditor:CKEditorControl ID="fckBody" BasePath="~/ckeditor"  runat="server" UIColor="#BFEE62" Language="en" />
    </div>
</div>
<div id="tabArticle2" class="pane-box-tabs tbl-form">
    <div class="row">
        <label class="lbl lbl-small">Ngày tạo:</label>
        <asp:TextBox ID="txtAddedDate" runat="server" Enabled="False" CssClass="txt txt-disabled" />
    </div>
    <div class="row">
        <label class="lbl lbl-small">Tạo bởi:</label>
        <asp:TextBox ID="txtAddedBy" runat="server" Enabled="False" CssClass="txt txt-disabled" />
    </div>
    <div class="row">
        <label class="lbl lbl-small">Ngày xuất bản:</label>
        <asp:TextBox ID="txtReleaseDate" runat="server" CssClass="txt txt-datetime" />
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy HH:mm" TargetControlID="txtReleaseDate" />
    </div>
    <div class="row">
        <label class="lbl lbl-small">Ngày hết hạn:</label>
        <asp:TextBox ID="txtExpireDate" runat="server" CssClass="txt txt-datetime" />
        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy HH:mm" TargetControlID="txtExpireDate" />
    </div>
    <div class="row">
        <label class="lbl lbl-small"></label>
        <asp:CheckBox ID="chkListed" runat="server" Checked="True" CssClass="chk" Text="Được hiển thị" />
    </div>
    <div class="row">
        <label class="lbl lbl-small"></label>
        <asp:CheckBox ID="chkApproved" runat="server" Checked="True" CssClass="chk" Text="Đã được duyệt" />
    </div>    
    <div class="row">
        <label class="lbl lbl-small"></label>
        <asp:CheckBox ID="chkMemberOnly" runat="server" Checked="True" CssClass="chk" Text="Bài viết nổi bật" />
    </div>
    <div class="row">
        <label class="lbl lbl-small"></label>
        <asp:CheckBox ID="chkCommentEnable" runat="server" Checked="True" CssClass="chk" Text="Cho phép bình luận" />
    </div>
</div>
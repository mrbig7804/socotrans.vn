<%@ Page Language="C#" Title="" ValidateRequest="false"
    MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="Articles.aspx.cs"
    Inherits="admin_Articles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controls/ucFileUploader.ascx" TagName="ucFileUploader" TagPrefix="uc2" %>
<%@ Register Src="~/adm/ucArticleDetail.ascx" TagName="ucArticleDetail" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphAdmin">
    <div class="content-header">
        <h1 class="title-page">Bài viết</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Bài viết</li>
        </ol>
    </div>
    <div class="content">
        <div class="box-tabs">
            <ul id="nav-box-tabs" class="nav-box-tabs">
                <li>
                    <a href="javascript:void(0)" ref="#tabArticle1" class="active">Biên tập</a>
                </li>
                <li>
                    <a href="javascript:void(0)" ref="#tabArticle2" >Xuất bản</a>
                </li>
            </ul>
            <div class="middle-box">
                <uc1:ucArticleDetail ID="ucArticleDetail1" runat="server" />
            </div>
            <div class="bottom-box">
                <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Lưu bài viết" CssClass="btn btn-blue" ValidationGroup="Article" />&nbsp;&nbsp;
                <asp:LinkButton ID="btnView" runat="server" OnClick="btnView_Click" Text="Xem bài viết" CssClass="btn btn-green" />&nbsp;&nbsp;
                <asp:Label ID="lblUploadMessage" runat="server" Text="Lưu bài viết để có thể gửi file đính kèm" CssClass="err" />
                <asp:Label ID="lblViewMassage" runat="server" Text="Bạn hãy lưu bài viết trước khi xem để tránh mất dữ liệu đang biên tập" CssClass="err" />
            </div>
        </div>
        <asp:Panel ID="panUpload" runat="server" CssClass="box box-green">
            <div class="top-box">
                <h1 class="list">Ảnh đính kèm bài viết</h1>
            </div>
            <div class="middle-box">
                <asp:Panel ID="panDownloadImage" runat="server">
                    <asp:LinkButton ID="btnGenUrl" runat="server" CssClass="btn btn-blue" Text="Lẫy link ảnh" OnClick="btnGenUrl_Click" />&nbsp;&nbsp;
                    <asp:LinkButton ID="btnCopyImageToServer" runat="server" Visible="false" CssClass="btn btn-red" OnClick="btnCopyImageToServer_Click" Text="Tải về server" />
                    <asp:Repeater ID="rptUrlCopy" runat="server" >
                        <HeaderTemplate><ul class="listImgCopy-Article"></HeaderTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                        <ItemTemplate>
                            <li>
                                <div>
                                    <asp:CheckBox ID="chkCopy" Checked="true" runat="server" />
                                </div>
                                <img src='<%# ((DictionaryEntry)Container.DataItem).Key %>' class="image" alt="Administrator MB" />
                                <div>
                                    <span>
                                        <b>Tên file: </b><asp:TextBox ID="txtFile" CssClass="txt txt-disabled" runat="server" Text='<%# ((DictionaryEntry)Container.DataItem).Value %>' Width="50%" />
                                    </span>
                                    <span>
                                        <b>Url: </b><asp:Label ID="lblUrl" runat="server" Text='<%# ((DictionaryEntry)Container.DataItem).Key %>' />
                                    </span>
                                    <span>
                                        <asp:Label ID="lblMessage" runat="server" />
                                    </span>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
                <fieldset class="listImgAttach-Article">
                    <iframe src='<%# UploadUrl %>' frameborder="0" marginwidth="0" marginheight="0" scrolling="no" class="ifrUpload-Article"></iframe>
                    <iframe src='<%# AttachedUrl %>' frameborder="0" marginwidth="0" marginheight="0" id="articlePictureList" class="ifrAttach-Article"></iframe>
                </fieldset>
            </div>
            <div class="bottom-box"></div>
        </asp:Panel>
    </div>
</asp:Content>

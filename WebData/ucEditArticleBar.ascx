<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucEditArticleBar.ascx.cs" Inherits="ucEditArticleBar" %>

<span class="edit-productBar">
    <asp:HyperLink ID="lnkEdit" runat="server" CssClass="edit">Sửa</asp:HyperLink>&nbsp;&nbsp;|&nbsp;&nbsp;
    <asp:LinkButton ID="lnkDelete" OnClientClick="if (confirm('Bạn có chắc chắn muốn xóa thư mục này?') == false) return false;" runat="server" OnClick="lnkDelete_Click" CssClass="del">Xóa</asp:LinkButton>
</span>

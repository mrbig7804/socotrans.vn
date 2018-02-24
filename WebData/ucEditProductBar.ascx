<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucEditProductBar.ascx.cs" Inherits="ucEditProductBar" %>

<span class="edit-productBar">
    <asp:hyperlink ID="lnkEdit" runat="server" CssClass="edit">Sửa</asp:hyperlink>&nbsp;&nbsp;|&nbsp;&nbsp;
    <asp:linkbutton ID="lnkDelete" runat="server" OnClientClick="if (confirm('Bạn có chắc chắn muốn xóa?') == false) return false;" OnClick="lnkDelete_Click" CssClass="del">Xóa</asp:linkbutton>
</span>

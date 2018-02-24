<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAdminLogin.ascx.cs"
    Inherits="ucAdminLogin" %>
   <div style="position:fixed; border-top:1px solid #aaa; padding-top:5px; bottom:0px; height: 60px; left:0px; right:0px; text-align:center; background-image:url(/images/bgOpacity80.png);">
   <strong>QUẢN TRỊ</strong><br />
<%--   <hr style="margin-bottom:10px;" />--%>
<strong>
    <img src="/images/diamond.gif" alt="" />&nbsp;<asp:HyperLink ID="lnkAdmin" runat="server"
        NavigateUrl="~/adm"><span style="color:#a4080f">Trang quản trị</span></asp:HyperLink>
</strong>&nbsp;&nbsp;&nbsp;
<%--<img src="/images/diamond.gif" alt="" />&nbsp;<asp:HyperLink ID="lnkProfile" runat="server"
    Text="Thay đổi thông tin tài khoản" NavigateUrl="~/adm/Edit_Profile.aspx" />
&nbsp;&nbsp;&nbsp;--%>
<img src="/images/diamond.gif" alt="" />&nbsp;
<asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click"><span style="color:#a4080f">Đăng xuất</span></asp:LinkButton>
</div>
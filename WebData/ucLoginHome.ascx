<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucLoginHome.ascx.cs" Inherits="ucLoginHome" %>

<asp:loginview id="LoginView1" runat="server" >
    <anonymoustemplate>
        <ul>
            <li><a href="javascript:void{0}">Đăng ký</a></li>
            <li><a href="/dang-nhap">Đăng nhập</a></li>
        </ul>
    </anonymoustemplate>
    <loggedintemplate>
        <asp:loginname id="LoginName1" runat="server" formatstring="Chào mừng <a style='cursor: pointer' title='Đi tới trang quản trị' href='/adm'><b style='color: #ED2F2F;'>{0}</b></a>.&nbsp;" />
        <asp:loginstatus id="LoginStatus1" runat="server" logouttext="Đăng xuất" OnLoggedOut="LoginStatus1_LoggedOut" />
    </loggedintemplate>
</asp:loginview>

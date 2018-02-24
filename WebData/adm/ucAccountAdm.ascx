<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAccountAdm.ascx.cs" Inherits="adm_ucAccountAdm" %>

<div class="ttl">Xin chào, <%= this.Profile.UserName %></div>
<div class="img">
    <img alt="Administrator MB" src='<%= GetAvatarUrl(this.Profile.UserName) %>' title='Tài khoản: <%= this.Profile.UserName %>' />
    <ul class="nav">
        <li>
            <asp:HyperLink ID="hplEditProfile" runat="server" NavigateUrl="~/adm/EditProfile.aspx" Text="Thay đổi thông tin" />
        </li>
        <li>
            <asp:LinkButton ID="lbtnSignOut" runat="server" OnClick="lbtnSignOut_Click" Text="Đăng xuất" />
        </li>
    </ul>
</div>
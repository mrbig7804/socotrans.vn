<%@ Page Language="C#" MasterPageFile="~/person/LoginTemplate.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphLogin">
    <asp:Login ID="Login1" runat="server" Width="100%"
         FailureText='<span class="mss-err">Tài khoản hoặc mật khẩu không hợp lệ.</span>' >
        <LayoutTemplate>        
            <div class="admLogin-Header">Administrator</div>
            <table class="admLogin-Form">
                <tr>
                    <td class="ttl_table">
                        <asp:Label runat="server" ID="lblUserName" AssociatedControlID="UserName" Text="Tài khoản" />
                    </td>
                    <td class="ctl_table">
                        <asp:textbox id="UserName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="ttl_table">
                        <asp:Label runat="server" ID="lblPass" AssociatedControlID="Password" Text="Mật khẩu" />
                    </td>
                    <td>
                        <asp:textbox id="Password" runat="server" textmode="Password" />
                    </td>
                </tr>
                <tr>
                    <td class="ttl_table"></td>
                    <td class="ctl_table">
                        <asp:checkbox id="RememberMe" runat="server" text="Nhớ thông tin của tôi." />&nbsp;
                        <asp:hyperlink id="lnkPasswordRecovery" runat="server" navigateurl="/quen-mat-khau">Quên mật khẩu</asp:hyperlink>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:requiredfieldvalidator id="valRequireUserName" runat="server" setfocusonerror="True" CssClass="mss-err"
                            controltovalidate="UserName" validationgroup="Login" Text="" ErrorMessage="" Display="Dynamic" />
                        <asp:requiredfieldvalidator id="valRequirePassword" runat="server" setfocusonerror="True" CssClass="mss-err"
                            controltovalidate="Password" validationgroup="Login" Text="" ErrorMessage="" Display="Dynamic" />
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                    </td>
                </tr>
            </table>
            <div class="admLogin-btn">
                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Đăng nhập" ValidationGroup="Login" OnClick="LoginButton_Click" />
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>

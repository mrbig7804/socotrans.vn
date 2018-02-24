<%@ control language="C#" autoeventwireup="true" codefile="ucLogin.ascx.cs" inherits="ucLogin" %>

<asp:Login ID="Login1" runat="server" FailureText='<span class="mss">Tài khoản hoặc mật khẩu không hợp lệ.</span>' Width="100%" >
    <LayoutTemplate>
        <table width="100%">
            <tr>
                <td><b><asp:Label runat="server" ID="lblUserName" AssociatedControlID="UserName">Tài khoản</asp:Label></b></td>
            </tr>
            <tr>                
                <td>                    
                    <asp:textbox id="UserName" runat="server" Width="78%" />
                    <asp:requiredfieldvalidator id="valRequireUserName" runat="server" setfocusonerror="True" CssClass="mss_err_blue"
                        controltovalidate="UserName" validationgroup="Login" Text="*" ToolTip="Vui lòng nhập tài khoản" Display="Dynamic" />
                </td>
            </tr>
            <tr>                
                <td><br /><b><asp:Label runat="server" ID="lblPass" AssociatedControlID="Password">Mật khẩu</asp:Label></b></td>
            </tr>
            <tr>
                <td>
                    <asp:textbox id="Password" runat="server" Width="78%" textmode="Password" />
                    <asp:requiredfieldvalidator id="valRequirePassword" runat="server" setfocusonerror="True" CssClass="mss_err_blue"
                        controltovalidate="Password" validationgroup="Login" Text="*" ToolTip="Vui lòng nhập mật khẩu" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>
                    <br /><asp:checkbox id="RememberMe" runat="server" text="Nhớ thông tin của tôi."></asp:checkbox>&nbsp;
                    <asp:hyperlink id="lnkPasswordRecovery" runat="server" navigateurl="javascript:void{0}">Quên mật khẩu</asp:hyperlink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                </td>
            </tr>
        </table>
        <div style="border-top: #ddd 1px dashed; padding-top: 10px; margin-top: 10px; margin-left: 4px">
            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Đăng nhập" ValidationGroup="Login" OnClick="LoginButton_Click" />
        </div>
    </LayoutTemplate>
</asp:Login>

<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="admin_EditProfile" Title=""  %>

<%@ Register Src="ucUserProfile.ascx" TagName="ucUserProfile" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Tài khoản: <%= this.Profile.UserName %></h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Thay đổi thông tin tài khoản</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-red">
            <div class="top-box">
                <h1 class="info">Thay đổi mật khẩu</h1>
            </div>
            <asp:ChangePassword ID="ChangePassword" runat="server" Width="100%">
            <%--<MailDefinition BodyFileName="~/adm/ChangePasswordMail.txt" From="tiennq@mbsoft.vn" Subject="Administrator MB: Mật khẩu đã được thay đổi" />--%>
                <ChangePasswordTemplate>
                    <div class="middle-box tbl-form">
                        <div class="row">
                            <asp:Label ID="lblCurrentPassword" runat="server" AssociatedControlID="CurrentPassword" Text="Mật khẩu hiện tại:" CssClass="lbl lbl-small" />
                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Width="25%" CssClass="txt" />
                            <asp:RequiredFieldValidator ID="valRequireCurrentPassword" runat="server" ControlToValidate="CurrentPassword"
                                Display="Dynamic" ErrorMessage="Xác nhận mật khẩu cũ" SetFocusOnError="true"  ValidationGroup="passGroup" CssClass="err" />
                        </div>
                        <div class="row">
                            <asp:Label ID="lblNewPassword" runat="server" AssociatedControlID="NewPassword" Text="Mật khẩu mới:" CssClass="lbl lbl-small" />
                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="25%" CssClass="txt" />
                            <asp:RequiredFieldValidator ID="valRequireNewPassword" runat="server" ControlToValidate="NewPassword"
                                Display="Dynamic" ErrorMessage="Nhập mật khẩu mới" SetFocusOnError="true" ValidationGroup="passGroup" CssClass="err" />
                        </div>
                        <div class="row">
                            <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="ConfirmNewPassword" Text="Nhập lại mật khẩu:"  CssClass="lbl lbl-small" />
                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"  Width="25%" CssClass="txt" />
                            <asp:RequiredFieldValidator ID="valRequireConfirmNewPassword" runat="server" ControlToValidate="ConfirmNewPassword"
                                Display="Dynamic" ErrorMessage="Xác nhận mật khẩu mới" SetFocusOnError="true" ValidationGroup="passGroup" CssClass="err" />
                            <asp:CompareValidator ID="valComparePasswords" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                Display="Dynamic" ErrorMessage="Mật khẩu không khớp" SetFocusOnError="true" ValidationGroup="passGroup" CssClass="err" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small"></label>
                            <asp:LinkButton ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                Text="Đổi mật khẩu" ValidationGroup="passGroup" CssClass="btn btn-blue" />
                        </div>
                    </div>
                </ChangePasswordTemplate>
                <SuccessTemplate>
                    <div class="middle-box tbl-form">
                        <div class="row">
                            <asp:Label ID="lblSuccess" runat="server" Text="Mật khẩu của bạn đã được thay đổi" CssClass="err" />
                        </div>
                    </div>
                </SuccessTemplate>
            </asp:ChangePassword>
        </div>

        <div class="box box-blue">
            <div class="top-box">
                <h1 class="info">Thay đổi thông tin cá nhân</h1>
            </div>
            <div class="middle-box tbl-form">
                <uc1:ucUserProfile ID="UcUserProfile1" runat="server" />
            </div>
            <div class="bottom-box">
                <asp:LinkButton ID="lbtnUpdate" runat="server" OnClick="lbtnUpdate_Click" Text="Cập nhật" ValidationGroup="EditProfile" CssClass="btn btn-blue" />
                <%--<asp:Label ID="lblFeedbackUp" runat="server" Text="Cập nhật thành công" Visible="False" CssClass="err" />--%>
            </div>
        </div>
    </div>
</asp:Content>


<%@ page language="C#" autoeventwireup="true" masterpagefile="~/adm/AdminTemplate.master"
    codefile="Edit_User.aspx.cs" inherits="admin_Edit_User" %>

<%@ register src="ucUserProfile.ascx" tagname="ucUserProfile" tagprefix="uc1" %>
<asp:content id="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="headerText">
        CHI TIẾT TÀI KHOẢN
    </div>
    <br />
    <div class="sectionTitle">
        Thông tin chung</div>
    <p>
    </p>
    <table cellpadding="2">
        <tr>
            <td style="width: 140px;" class="fieldname">
                UserName:
            </td>
            <td style="width: 390px;">
                <asp:literal runat="server" id="lblUserName" />
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                E-mail:
            </td>
            <td style="width: 390px">
                &nbsp;<asp:textbox id="txtEmail" runat="server"></asp:textbox><asp:requiredfieldvalidator
                    id="valRequireEmail" runat="server" controltovalidate="txtEmail" display="Dynamic"
                    errormessage="E-mail is required." setfocusonerror="true" tooltip="E-mail is required."
                    validationgroup="txtEmail">*</asp:requiredfieldvalidator><asp:button id="btnUpdateEmail"
                        runat="server" onclick="btnUpdateEmail_Click" text="Cập nhật" tooltip="Cập nhật email mới"
                        validationgroup="txtEmail" />
                <asp:hyperlink runat="server" id="lnkEmail">Gửi thư</asp:hyperlink>
                <asp:label runat="server" id="lblEmailFeedbackOK" text="<br/>Cập nhật thành công"
                    visible="False" />
                <asp:label runat="server" id="lblEmailErr" text="<br />Đã tồn tại email này hoặc có lỗi trong quá trình cập nhật..."
                    visible="False" forecolor="Red" />
                <asp:regularexpressionvalidator id="valEmailPattern" runat="server" controltovalidate="txtEmail"
                    display="Dynamic" errormessage="Chưa đúng định dạng email" setfocusonerror="true"
                    validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" validationgroup="txtEmail"><br/>Chưa đúng định dạng email</asp:regularexpressionvalidator>
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                Ngày đăng ký:
            </td>
            <td style="width: 390px">
                <asp:literal runat="server" id="lblRegistered" />
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                Đăng nhập lần cuối:
            </td>
            <td style="width: 390px">
                <asp:literal runat="server" id="lblLastLogin" />
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                Last Activity:
            </td>
            <td style="width: 390px">
                <asp:literal runat="server" id="lblLastActivity" />
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                <asp:label runat="server" id="lblOnlineNow" associatedcontrolid="chkOnlineNow" text="Online Now:" />
            </td>
            <td style="width: 390px">
                <asp:checkbox runat="server" id="chkOnlineNow" enabled="false" />
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                <asp:label runat="server" id="lblApproved" associatedcontrolid="chkApproved" text="Approved:" />
            </td>
            <td style="width: 390px">
                <asp:checkbox runat="server" id="chkApproved" autopostback="true" oncheckedchanged="chkApproved_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                <asp:label runat="server" id="lblLockedOut" associatedcontrolid="chkLockedOut" text="Locked Out:" />
            </td>
            <td style="width: 390px">
                <asp:checkbox runat="server" id="chkLockedOut" autopostback="true" oncheckedchanged="chkLockedOut_CheckedChanged" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div class="sectionTitle">
        Đổi mật khẩu
    </div>
    <table cellpadding="2">
        <tr>
            <td class="fieldname" style="width: 140px">
                Mật khẩu mới:
                <br />
            </td>
            <td style="width: 390px">
                <asp:textbox id="txtNewPassword" runat="server" width="272px" textmode="Password"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="fieldname" style="width: 140px">
                Nhập lại mật khẩu:
            </td>
            <td style="width: 390px">
                <asp:textbox id="txtRepassword" runat="server" textmode="Password" width="272px"></asp:textbox>
                <asp:comparevalidator id="valComparePasswords" runat="server" controltocompare="txtNewPassword"
                    controltovalidate="txtRepassword" display="Dynamic" errormessage="Password chưa chính xác"
                    setfocusonerror="true" validationgroup="ResetPassword">*</asp:comparevalidator>
            </td>
        </tr>
    </table>
    <table cellpadding="2" style="width: 450px;">
        <tr>
            <td style="text-align: right; height: 16px;">
                <asp:label runat="server" id="lblProfileResetPasswordOK" skinid="FeedbackOK" text="Cập nhật thành công"
                    visible="False" />
                <asp:button runat="server" id="btnUpdatePassword" validationgroup="EditProfile" text="Cập nhật"
                    onclick="btnUpdatePassword_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div class="sectionTitle">
        Thay đổi quyền
    </div>
    <asp:checkboxlist runat="server" id="chklRoles" repeatcolumns="5" cellspacing="4" />
    <asp:label runat="server" id="lblRolesFeedbackOK" text="Cập nhật thành công" visible="False" />
    <asp:button runat="server" id="btnUpdateRoles" validationgroup="EditProfile" text="Cập nhật"
        onclick="btnUpdateRoles_Click" />
    <asp:panel id="Panel1" runat="server" height="33px" visible="False" width="429px">
        Tạo nhóm mới:
        <asp:textbox runat="server" id="txtNewRole" />
        <asp:requiredfieldvalidator id="valRequireNewRole" runat="server" controltovalidate="txtNewRole"
            setfocusonerror="true" errormessage="Role name is required." tooltip="Role name is required."
            validationgroup="CreateRole">*</asp:requiredfieldvalidator>
        <asp:button runat="server" id="btnCreateRole" text="Create" validationgroup="CreateRole"
            onclick="btnCreateRole_Click" /></asp:panel>
    <div class="sectionTitle">
        Thay đổi thông tin cá nhân</div>
    <uc1:ucuserprofile id="UcUserProfile1" runat="server" />
    <table cellpadding="2" style="width: 450px;">
        <tr>
            <td style="text-align: right; height: 16px;">
                <asp:label runat="server" id="lblProfileFeedbackOK" skinid="FeedbackOK" text="Cập nhật thành công"
                    visible="False" />
                <asp:button runat="server" id="btnUpdateProfile" validationgroup="EditProfile" text="Cập nhật"
                    onclick="btnUpdateProfile_Click" />
            </td>
        </tr>
    </table>
</asp:content>

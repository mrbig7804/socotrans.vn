<%@ page language="C#" masterpagefile="~/TemplateHome.master" autoeventwireup="true"
    codefile="PasswordRecovery.aspx.cs" inherits="admin_PasswordRecovery" %>

<asp:content id="Content1" contentplaceholderid="cphHomePage" runat="Server">

    <div class="c_container c_container_right">
        <div class="c_right_hoavan_bl"></div>
        <div class="c_right_hoavan_br"></div>
        <div class="c_right_tl">
            <div class="c_right_tr">
                <div class="c_right_tc">
                    <h2 class="title">Khôi phục lại mật khẩu</h2>
                </div>
            </div>
        </div>
        <div class="c_right_ml">
            <div class="c_right_mr">
                <div class="c_right_mc">
                    <asp:passwordrecovery id="PasswordRecovery1" runat="server" generalfailuretext="Chúng tôi đã giử thông tin mật khẩu về cho bạn nhưng không thành công. Bạn hãy thử lại lần nữa."
                        questionfailuretext="Câu trả lời của bạn không được chấp nhận."
                        usernamefailuretext="Không tìm thấy thông tin tài khoản. Bạn hãy thử lại">
                        <usernametemplate>
                            <div class="sectionSubTitle">
                                Bước 1: Nhập Tên tài khoản</div>
                            <p>
                            </p>
                            <table cellpadding="2">
                                <tr>
                                    <td style="width: 100px;">
                                        <asp:label runat="server" id="lblUsername" associatedcontrolid="UserName" text="Tài khoản:" />
                                    </td>
                                    <td style="width: 350px;">
                                        <asp:textbox id="UserName" runat="server" width="100%" cssclass="inputCommand"></asp:textbox>
                                    </td>
                                    <td>
                                        <asp:requiredfieldvalidator id="valRequireUserName" runat="server" controltovalidate="UserName"
                                            setfocusonerror="true" display="Dynamic" errormessage="Username is required."
                                            tooltip="Tài khoản không được để trống." validationgroup="PasswordRecovery1">*</asp:requiredfieldvalidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: right;">
                                        <asp:label id="FailureText" runat="server" enableviewstate="False" />
                                        <asp:button id="SubmitButton" runat="server" commandname="Submit" text="Tiếp tục"
                                            validationgroup="PasswordRecovery1" cssclass="inputCommand" />
                                    </td>
                                </tr>
                            </table>
                        </usernametemplate>
                        <questiontemplate>
                            <div class="sectionSubTitle">
                                Bước 2: Trả lời câu hỏi bí mật</div>
                            <p>
                            </p>
                            <table cellpadding="2">
                                <tr>
                                    <td style="width: 100px;">
                                        Tài khoản:
                                    </td>
                                    <td style="width: 350px;">
                                        <asp:literal id="UserName" runat="server"></asp:literal>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:label runat="server" id="lblQuestion" associatedcontrolid="Question" text="Câu hỏi bí mật:" />
                                    </td>
                                    <td>
                                        <asp:literal id="Question" runat="server"></asp:literal>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:label runat="server" id="lblAnswer" associatedcontrolid="Answer" text="Trả lời:" />
                                    </td>
                                    <td>
                                        <asp:textbox id="Answer" runat="server" cssclass="inputCommand" width="100%"></asp:textbox>
                                    </td>
                                    <td>
                                        <asp:requiredfieldvalidator id="valRequireAnswer" runat="server" controltovalidate="Answer"
                                            setfocusonerror="true" display="Dynamic" errormessage="Bạn chưa trả lời câu hỏi bí mật."
                                            tooltip="Không được để trống phần trả lời." validationgroup="PasswordRecovery1">*</asp:requiredfieldvalidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: right;">
                                        <asp:label id="FailureText" runat="server" enableviewstate="False" />
                                        <asp:button id="SubmitButton" runat="server" commandname="Submit" text="Tiếp tục"
                                            cssclass="inputCommand" validationgroup="PasswordRecovery1" />
                                    </td>
                                </tr>
                            </table>
                        </questiontemplate>
                        <successtemplate>
                            <asp:label runat="server" id="lblSuccess" text="Mật khẩu đã được gửi tới email của bạn." />
                        </successtemplate>
                        <maildefinition bodyfilename="~/PasswordRecoveryMail.txt" from="thongbao@tinnghiajsc.Com"
                            subject="Kh&#244;i phục m&#226;̣t kh&#226;̉u" isbodyhtml="true">
                        </maildefinition>
                    </asp:passwordrecovery>
                    <div class="clear_this"></div>
                </div>
            </div>
        </div>
        <div class="c_right_bl">
            <div class="c_right_br">
                <div class="c_right_bc"></div>
            </div>
        </div>
    </div>
</asp:content>

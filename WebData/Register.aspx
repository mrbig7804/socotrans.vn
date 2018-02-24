<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" Runat="Server">
    <div class="white_cont">
        <span class="ttl">Đăng ký</span>
        <div class="ctnPad">
            <asp:createuserwizard id="CreateUserWizard1" runat="server" finishdestinationpageurl="~/" 
                onfinishbuttonclick="CreateUserWizard1_FinishButtonClick" oncreateduser="CreateUserWizard1_CreatedUser" createuserbuttontext="Đăng ký"
                unknownerrormessage="Không thể tạo được tài khoản. Hãy thử lại lần nữa."
                duplicateemailerrormessage="Email bạn dùng đã được đăng ky. Hãy dùng địa chỉ email khác"
                duplicateusernameerrormessage="Tên đăng nhập của bạn đã được sử dụng. Hãy dụng tên đăng nhập khác"
                invalidanswererrormessage="Hãy điền câu trả lời khác." invalidemailerrormessage="Hãy điền địa chỉ hòm thư khác."
                invalidquestionerrormessage="Hãy điền câu hỏi bí mật khác.">
                <wizardsteps>
                    <asp:createuserwizardstep runat="server" id="CreateUserWizardStep1">
                        <contenttemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <b>Tên đăng nhập</b>&nbsp;<b style="color: #f80b00">*</b>&nbsp;<i style="font-size: 11px">( Tên đăng nhập phải lớn hơn 4 ký tự và không dùng ký tự đặc biệt. )</i><br />
                                            <asp:textbox id="UserName" runat="server" Width="320px" CssClass="inputText" />
                                        </td>
                                        <td class="err">
                                            <asp:requiredfieldvalidator id="UserNameRequired" runat="server" controltovalidate="UserName" ForeColor="#f80b00" Display="Dynamic"
                                                errormessage="Tên đăng nhập không được để trống." tooltip="Tên đăng nhập không được để trống." Text="*" validationgroup="CreateUserWizard1" />
                                            <asp:regularexpressionvalidator id="valUserNameLength" runat="server" controltovalidate="UserName" ForeColor="#f80b00" Display="Dynamic"
                                                errormessage="Tên đăng nhập phải lớn hơn 4 ký tự và không dùng ký tự đặc biệt." setfocusonerror="true" Text="*"
                                                tooltip="Tên đăng nhập phải lớn hơn 4 ký tự và không dùng ký tự đặc biệt." validationexpression="\w{4,}" validationgroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Mật khẩu</b>&nbsp;<b style="color: #f80b00">*</b>&nbsp;<i style="font-size: 11px">( Nhập mật khẩu của bạn. )</i><br />
                                            <asp:textbox id="Password" runat="server" textmode="Password" Width="320px" CssClass="inputText" />
                                        </td>
                                        <td  class="err">
                                            <asp:requiredfieldvalidator id="PasswordRequired" runat="server" controltovalidate="Password" Text="*" ForeColor="#f80b00" Display="Dynamic"
                                                errormessage="Mật khẩu không được để trống." tooltip="Mật khẩu không được để trống." validationgroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Xác nhận mật khẩu</b>&nbsp;<b style="color: #f80b00">*</b>&nbsp;<i style="font-size: 11px">( Xác nhận lại mật khẩu của bạn. )</i><br />
                                            <asp:textbox id="ConfirmPassword" runat="server" textmode="Password" Width="320px" CssClass="inputText" />
                                        </td>
                                        <td  class="err">
                                            <asp:comparevalidator id="PasswordCompare" runat="server" controltovalidate="ConfirmPassword" Text="*" ForeColor="#f80b00" display="Dynamic"
                                                errormessage="Xác nhận mật khẩu không khớp." ToolTip="Xác nhận mật khẩu không khớp." validationgroup="CreateUserWizard1" controltocompare="Password"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Địa chỉ email</b>&nbsp;<b style="color: #f80b00">*</b>&nbsp;<i style="font-size: 11px">( Nhập địa chỉ email của bạn. )</i><br />
                                            <asp:textbox id="Email" runat="server" cssclass="inputText" text="<%# Email %>" Width="320px" />
                                        </td>
                                        <td  class="err">
                                            <asp:requiredfieldvalidator id="EmailRequired" runat="server" controltovalidate="Email" Text="*"  ForeColor="#f80b00" Display="Dynamic"
                                                errormessage="E-mail không được để trống." tooltip="E-mail không được để trống." validationgroup="CreateUserWizard1" />
                                            <asp:regularexpressionvalidator id="valEmailPattern" runat="server" controltovalidate="Email" Text="*"  ForeColor="#f80b00" Display="Dynamic"
                                                errormessage="E-mail không đúng định dạng." ToolTip="E-mail không đúng định dạng." validationgroup="CreateUserWizard1"
                                                setfocusonerror="true" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Câu hỏi bí mật</b>&nbsp;<b style="color: #f80b00">*</b>&nbsp;<i style="font-size: 11px">( Vui lòng chọn câu hỏi bí mật của bạn. )</i><br />
                                            <asp:dropdownlist id="Question" runat="server" Width="332px" Height="32px" CssClass="inputText">
                                                <asp:listitem value="">-- Chọn câu hỏi --</asp:listitem>
                                                <asp:listitem value="Tên đệm của cha của bạn là gì?">Tên đệm của cha của bạn là gì?</asp:listitem>
                                                <asp:listitem value="Tên của ngôi trường đầu tiên của bạn là gì?">Tên của ngôi trường đầu tiên của bạn là gì?</asp:listitem>
                                                <asp:listitem value="Người anh hùng thời niên thiếu của bạn là ai?">Người anh hùng thời niên thiếu của bạn là ai?</asp:listitem>
                                                <asp:listitem value="Bạn thường thích làm gì trong thời gian rảnh rỗi?">Bạn thường thích làm gì trong thời gian rảnh rỗi?</asp:listitem>
                                                <asp:listitem value="Đội thể thao mà bạn ưa thích nhất là đội nào?">Đội thể thao mà bạn ưa thích nhất là đội nào?</asp:listitem>
                                                <asp:listitem value="Tên trường tiểu học của bạn là gì?">Tên trường tiểu học của bạn là gì?</asp:listitem>
                                                <asp:listitem value="Xe đạp đầu tiên của bạn hiệu gì?">Xe đạp đầu tiên của bạn hiệu gì?</asp:listitem>
                                                <asp:listitem value="Lần đầu tiên bạn gặp vợ (chồng) của mình là ở đâu?">Lần đầu tiên bạn gặp vợ (chồng) của mình là ở đâu?</asp:listitem>
                                                <asp:listitem value="Tên của con vật nuôi trong nhà?">Tên của con vật nuôi trong nhà?</asp:listitem>
                                            </asp:dropdownlist>
                                        </td>
                                        <td  class="err">
                                            <asp:requiredfieldvalidator id="QuestionRequired" runat="server" controltovalidate="Question" ForeColor="#f80b00" Display="Dynamic"
                                                errormessage="Chưa chọn câu hỏi bí mật." tooltip="Chưa chọn câu hỏi bí mật." Text="*" validationgroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Câu trả lời</b>&nbsp;<b style="color: #f80b00">*</b>&nbsp;<i style="font-size: 11px">( Trả lời cho câu hỏi bí mật của bạn. )</i><br />
                                            <asp:textbox id="Answer" runat="server" Width="320px" CssClass="inputText" />
                                        </td>
                                        <td  class="err">
                                            <asp:requiredfieldvalidator id="AnswerRequired" runat="server" controltovalidate="Answer" ForeColor="#f80b00" Display="Dynamic" Text="*"
                                                errormessage="Chưa nhập trả lời cho câu hỏi bí mật." tooltip="Chưa nhập trả lời cho câu hỏi bí mật." validationgroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="font-weight: bold; font-size: 11px; line-height: 16px; padding-bottom: 8px; float: left">
                                            <asp:CheckBox runat="server" ID="chkAgreement" OnCheckedChanged="chkAgreement_CheckedChanged" Checked="true" Text='Tôi cam kết đồng ý với các <a href="http://quangcaothuongmai.vn/" target="_blank">điều khoản và chính sách</a> của quangcaothuongmai.vn.' />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 11px; line-height: 16px; float: left">
                                            <asp:CheckBox runat="server" ID="chkMailing" Checked="true" Text="Gửi mail thông báo các cập nhật mới nhất từ quangcaothuongmai.vn tới tôi." />
                                        </td>
                                        <td></td>
                                    </tr>--%>
                                    <%--<tr>
                                        <td colspan="2">
                                            <asp:Literal runat="server" ID="ltrAgreement" Visible="false" />
                                        </td>
                                    </tr>--%>
                                </tbody>
                            </table>
                        </contenttemplate>
                    </asp:createuserwizardstep>
                    <asp:completewizardstep runat="server" id="CompleteWizardStep1">
                        <contenttemplate>
                            <span style="line-height: 30px; font-weight: bold; color: #e10a00">Tài khoản của bạn đã được đăng ký thành công.</span><br />
                            <span style="line-height: 18px">Click <a href="/" title="Trang chủ" style="color: #006c95">vào đây</a> để quay về trang chủ.<%--Hoặc click <a href="/" title="Trang cá nhân">vào đây</a> để tới trang cá nhân của bạn.</span>--%>
                        </contenttemplate>
                    </asp:completewizardstep>
                </wizardsteps>
            </asp:createuserwizard>
        </div>
    </div>

</asp:Content>


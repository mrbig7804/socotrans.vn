<%@ Page Language="C#" Title="" AutoEventWireup="true" MasterPageFile="~/adm/AdminTemplate.master" CodeFile="RegUser.aspx.cs" Inherits="admin_RegUser" %>

<%@ Register Src="ucUserProfile.ascx" TagName="ucUserProfile" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphAdmin">
    <div class="content-header">
        <h1 class="title-page">Đăng ký tài khoản</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Đăng ký tài khoản</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-red box-regUser">
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" AutoGeneratePassword="False" Width="100%" LoginCreatedUser="False" 
                ContinueDestinationPageUrl="~/adm/ManageUsers.aspx" FinishDestinationPageUrl="~/adm/ManageUsers.aspx"
                OnCreatedUser="CreateUserWizard1_CreatedUser" OnFinishButtonClick="CreateUserWizard1_FinishButtonClick" 
                CancelButtonText="Bỏ qua" CreateUserButtonText="Tạo tài khoản"  FinishCompleteButtonText="Hoàn thành" FinishPreviousButtonText="Quay lại">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="Tạo t&#224;i khoản mới">
                        <ContentTemplate>
                            <div class="top-box">
                                <h1 class="info">Tạo mới tài khoản quản trị</h1>
                            </div>
                            <div class="middle-box tbl-form">
                                <div class="row">
                                    <asp:Label ID="lblUserName" runat="server" AssociatedControlID="UserName" Text="Tên đăng nhập:" CssClass="lbl lbl-small" />
                                    <asp:TextBox ID="UserName" runat="server" Width="35%" CssClass="txt" />
                                    <asp:RequiredFieldValidator ID="valRequireUserName" runat="server" ControlToValidate="UserName" CssClass="err"
                                        Display="Dynamic" ErrorMessage="Tên đăng nhập không được để trống" SetFocusOnError="true" ValidationGroup="CreateUserWizard1" />
                                    <asp:regularexpressionvalidator id="valUserNameLength" runat="server" controltovalidate="UserName" Display="Dynamic" CssClass="err"
                                        errormessage="Tên đăng nhập phải lớn hơn 4 ký tự (không bao gồm ký tự đặc biệt: !@#$...)" setfocusonerror="true" validationexpression="\w{4,}" validationgroup="CreateUserWizard1" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="lblPassword" runat="server" AssociatedControlID="Password" Text="Mật khẩu:" CssClass="lbl lbl-small" />
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="35%" CssClass="txt" />
                                    <asp:RequiredFieldValidator ID="valRequirePassword" runat="server" ControlToValidate="Password" CssClass="err"
                                        Display="Dynamic" ErrorMessage="Mật khẩu không được để trống" SetFocusOnError="true" ValidationGroup="CreateUserWizard1" />
                                    <asp:RegularExpressionValidator ID="valPasswordLength" runat="server" ControlToValidate="Password" Display="Dynamic" CssClass="err"
                                        ErrorMessage="Mật khẩu phải lớn hơn 5 ký tự (bao gồm cả ký tự đặc biệt: !@#$...)" SetFocusOnError="true" ValidationExpression="[\w\W]{5,}" ValidationGroup="CreateUserWizard1" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="ConfirmPassword" Text="Xác nhận mật khẩu:" CssClass="lbl lbl-small" />
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="35%" CssClass="txt" />
                                    <asp:RequiredFieldValidator ID="valRequireConfirmPassword" runat="server" ControlToValidate="ConfirmPassword" CssClass="err"
                                         Display="Dynamic" ErrorMessage="Xác nhận mật khẩu" SetFocusOnError="true" ValidationGroup="CreateUserWizard1" />
                                    <asp:CompareValidator ID="valComparePasswords" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="err"
                                        Display="Dynamic" ErrorMessage="Mật khẩu không khớp" SetFocusOnError="true" ValidationGroup="CreateUserWizard1" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="Email" Text="E-mail:" CssClass="lbl lbl-small" />
                                    <asp:TextBox ID="Email" runat="server" Text='<%# Email %>' Width="35%" CssClass="txt" />
                                    <asp:RequiredFieldValidator ID="valRequireEmail" runat="server" ControlToValidate="Email" CssClass="err"
                                        Display="Dynamic" ErrorMessage="Email không được để trống" SetFocusOnError="true" ValidationGroup="CreateUserWizard1" />
                                    <asp:RegularExpressionValidator ID="valEmailPattern" runat="server" ControlToValidate="Email" Display="Dynamic" SetFocusOnError="true" CssClass="err"
                                        ErrorMessage="Email không hợp lệ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="CreateUserWizard1" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="lblQuestion" runat="server" AssociatedControlID="Question" Text="Câu hỏi bảo mật:" CssClass="lbl lbl-small" />
                                    <asp:TextBox ID="Question" runat="server" Width="35%" CssClass="txt" />
                                    <asp:RequiredFieldValidator ID="valRequireQuestion" runat="server" ControlToValidate="Question" Display="Dynamic"  CssClass="err"
                                        ErrorMessage="Câu hỏi bảo mật không được để trống" SetFocusOnError="true" ValidationGroup="CreateUserWizard1" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="lblAnswer" runat="server" AssociatedControlID="Answer" Text="Câu trả lời:" CssClass="lbl lbl-small" />
                                    <asp:TextBox ID="Answer" runat="server" Width="35%" CssClass="txt" />
                                    <asp:RequiredFieldValidator ID="valRequireAnswer" runat="server" ControlToValidate="Answer" Display="Dynamic" CssClass="err"
                                        ErrorMessage="Câu trả lời không được để trống" SetFocusOnError="true" ValidationGroup="CreateUserWizard1" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="ErrorMessage" runat="server" EnableViewState="False" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:WizardStep ID="WizardStep1" runat="server" Title="Th&#244;ng tin c&#225; nh&#226;n">
                        <div class="top-box">
                            <h1 class="info">Thông tin cá nhân</h1>
                        </div>
                        <div class="middle-box tbl-form">
                            <uc1:ucUserProfile id="UserProfile1" runat="server" />
                        </div>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep2" runat="server" Title="Thay đổi quyền">
                        <div class="top-box">
                            <h1 class="info">Phân quyền</h1>
                        </div>
                        <div class="middle-box">
                            <asp:CheckBoxList id="chklRoles" runat="server" CellSpacing="4" RepeatColumns="5" />
                        </div>
                    </asp:WizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </div>
    </div>
</asp:Content>


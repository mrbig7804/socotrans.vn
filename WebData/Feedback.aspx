<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/TemplateHome.master"
    CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<%@ Register Src="~/ucViewArticle.ascx" TagName="ucViewArticle" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Phản hồi khách hàng</li>
    </ul>
    <div class="main-cc feedPage">
        <div class="info">
            <uc1:ucViewArticle runat="server" ID="ucViewArticle1" ArticleID="73" ShowBody="true" />
        </div>
        <asp:Panel ID="panelSuccessMsg" runat="server" Visible="False">
            <p class="text-center">
                <b>Thông tin của bạn đã được gửi</b>. Chúng tôi sẽ phản hồi lại cho bạn ngay sau khi nhận được thông tin này. Cảm ơn bạn đã ghé thăm website của chúng tôi.
            </p>
        </asp:Panel>
        <asp:Panel ID="panelFeedBack" runat="server">
            <div class="form-horizontal" role="form" novalidate>
                <div class="form-group">
                    <label class="control-label col-sm-2">Họ tên:</label>
                    <div class="col-sm-6">
                        <asp:TextBox class="form-control" autocomplete="off" ID="txtFullName" runat="server" onkeyup="initTyper(this);" />
                        <asp:RequiredFieldValidator ID="valRequireName" runat="server" ControlToValidate="txtFullName" Display="Dynamic" 
                            ErrorMessage="Chưa nhập mục họ tên" SetFocusOnError="true" ToolTip="Mục họ tên không được để trống" ValidationGroup="Feedback">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Điện thoại:</label>
                    <div class="col-sm-6">
                        <asp:TextBox class="form-control" autocomplete="off" ID="txtTel" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">E-mail:</label>
                    <div class="col-sm-6">
                        <asp:TextBox class="form-control" autocomplete="off" ID="txtEmail" runat="server" />
                        <asp:RequiredFieldValidator ID="valRequireEmail" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="Chưa nhập email" SetFocusOnError="true" ToolTip="Email không được để trống"
                            ValidationGroup="Feedback">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valEmailPattern" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="Chưa đúng định dạng email" SetFocusOnError="true"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Feedback">*</asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Tiêu đề:</label>
                    <div class="col-sm-6">
                        <asp:TextBox class="form-control" autocomplete="off" ID="txtTitle" runat="server" Text='<%# FeedbackTitle %>' />
                        <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle"
                            Display="Dynamic" ErrorMessage="Chưa nhập mục tiêu đề." SetFocusOnError="true"
                            ToolTip="Mục tiêu đề không được để trống" ValidationGroup="Feedback">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Nội dung:</label>
                    <div class="col-sm-6">
                        <asp:TextBox class="form-control" autocomplete="off" ID="txtDetail" runat="server" Rows="8" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDetail"
                            Display="Dynamic" ErrorMessage="Chưa nhập nội dung" SetFocusOnError="true" ToolTip="Nội dung không được để trống"
                            ValidationGroup="Feedback">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2">Mã bảo vệ:</label>
                    <div class="col-sm-6">
                        <asp:Image ID="Image1" runat="server" AlternateText="Bạn phải nhập mã bảo vệ trước khi gửi đi" ImageUrl="/GenImage.ashx" /><br />
                        <asp:TextBox class="form-control" autocomplete="off" ID="txtVerify" runat="server"></asp:TextBox>
                        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="#ed1c24" Text="Bạn chưa nhập đúng mã bảo mật" Visible="False" /><br />
                        Chú ý: phân biệt chữ hoa chữ thường
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-6">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Feedback" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-6">
                    <asp:Button class="btn btn-primary" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Phản hồi" ValidationGroup="Feedback" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

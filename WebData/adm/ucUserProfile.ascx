<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUserProfile.ascx.cs" Inherits="admin_ucUserProfile" %>

<div class="row">
    <asp:Label runat="server" ID="lblFullName" AssociatedControlID="txtFullName" Text="Họ tên:" CssClass="lbl lbl-small" />
    <asp:TextBox ID="txtFullName" runat="server" Width="35%" CssClass="txt" />
</div>
<div class="row">
    <asp:Label runat="server" ID="lblGender" AssociatedControlID="ddlGenders" Text="Giới tính:"  CssClass="lbl lbl-small" />
    <asp:DropDownList runat="server" ID="ddlGenders" Width="36.3%" CssClass="txt">
        <asp:ListItem Text="Chọn giới t&#237;nh..." Selected="True" />
        <asp:ListItem Text="Nam" Value="M" />
        <asp:ListItem Text="Nữ" Value="F" />
    </asp:DropDownList>
</div>
<div class="row">
    <asp:Label runat="server" ID="lblBirthDate" AssociatedControlID="txtBirthDate" Text="Ngày sinh:"  CssClass="lbl lbl-small" />
    <asp:TextBox ID="txtBirthDate" runat="server" Width="35%" CssClass="txt" />
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtBirthDate" />
</div>
<div class="row">
    <asp:Label runat="server" ID="lblOccupation" AssociatedControlID="ddlOccupations" Text="Nghề nghiệp:"  CssClass="lbl lbl-small" />
    <asp:DropDownList ID="ddlOccupations" runat="server" Width="36.3%" CssClass="txt">
        <asp:ListItem Text="H&#227;y chọn lĩnh vực c&#244;ng t&#225;c..." Selected="True" />
        <asp:ListItem Text="Tin học, viễn th&#244;ng" />
        <asp:ListItem Text="Ng&#226;n h&#224;ng, t&#224;i ch&#237;nh" />
        <asp:ListItem Text="Khoa học kỹ thuật" />
        <asp:ListItem Text="Thương mại dịch vụ" />
        <asp:ListItem Text="H&#224;nh ch&#237;nh sự nghiệp" />
        <asp:ListItem Text="(Kh&#225;c)" />
    </asp:DropDownList>
</div>
<div class="row">
    <asp:Label runat="server" ID="lblWebsite" AssociatedControlID="txtWebsite" Text="Website:" CssClass="lbl lbl-small" />
    <asp:TextBox ID="txtWebsite" runat="server" Width="35%" CssClass="txt" />
</div>
<div class="row">
    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtAddress" Text="Địa chỉ" CssClass="lbl lbl-small" />
    <asp:TextBox ID="txtAddress" runat="server" Width="35%" CssClass="txt" />
</div>
<div class="row">
    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtPhone" Text="Điện thoại:" CssClass="lbl lbl-small" />
    <asp:TextBox ID="txtPhone" runat="server" Width="35%" CssClass="txt" />
</div>
<div class="row">
    <label class="lbl lbl-small">Avatar:</label>
    <asp:Image ID="imgAvatar" runat="server" />
    <asp:LinkButton ID="btnChangeAvatar" runat="server" OnClick="btnChangeAvatar_Click" Text="Thay đổi" CssClass="btn btn-red" />
</div>

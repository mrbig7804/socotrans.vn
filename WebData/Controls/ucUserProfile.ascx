<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUserProfile.ascx.cs" Inherits="Controls_ucUserProfile" %>

<table cellpadding="2">
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Họ tên:
        </td>
        <td style="width: 400px">
            <asp:textbox id="txtFullName" cssclass="inputCommand" runat="server" width="90%"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Giới tính:
        </td>
        <td>
            <asp:dropdownlist runat="server" cssclass="inputCommand" id="ddlGenders">
                <asp:listitem text="Chọn giới t&#237;nh..." selected="True" />
                <asp:listitem text="Nam" value="M" />
                <asp:listitem text="Nữ" value="F" />
            </asp:dropdownlist>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Ngày sinh:
        </td>
        <td>
            <asp:textbox id="txtBirthDate" cssclass="inputCommand" runat="server" width="90%"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Nghề nghiệp:
        </td>
        <td>
            <asp:dropdownlist id="ddlOccupations" runat="server" cssclass="inputCommand" width="90%">
                <asp:listitem text="H&#227;y chọn lĩnh vực c&#244;ng t&#225;c..." selected="True" />
                <asp:listitem text="Tin học, viễn th&#244;ng" />
                <asp:listitem text="Ng&#226;n h&#224;ng, t&#224;i ch&#237;nh" />
                <asp:listitem text="Khoa học kỹ thuật" />
                <asp:listitem text="Thương mại dịch vụ" />
                <asp:listitem text="H&#224;nh ch&#237;nh sự nghiệp" />
                <asp:listitem text="(Kh&#225;c)" />
            </asp:dropdownlist>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Website:
        </td>
        <td>
            <asp:textbox id="txtWebsite" cssclass="inputCommand" runat="server" width="90%"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Địa chỉ:
        </td>
        <td>
            <asp:textbox id="txtAddress" cssclass="inputCommand" runat="server" width="90%"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Tỉnh/thành:
        </td>
        <td>
            <asp:dropdownlist id="ddlCities" cssclass="inputCommand" runat="server">
            </asp:dropdownlist>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Điện thoại:
        </td>
        <td>
            <asp:textbox id="txtPhone" cssclass="inputCommand" runat="server" width="90%"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Đi động:
        </td>
        <td>
            <asp:textbox id="txtMobile" cssclass="inputCommand" runat="server" width="90%"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            YM:
        </td>
        <td>
            <asp:textbox id="txtYM" cssclass="inputCommand" runat="server" width="90%"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td style="width: 128px; font-weight: bold; padding: 8px 0" align="right">
            Avatar <asp:button id="btnChangeAvatar" runat="server"  onclick="btnChangeAvatar_Click" text="Thay đổi..."
                cssclass="btnCommand" />
        </td>
        <td>
            <asp:image id="imgAvatar" width="100px" runat="server" />
        </td>
    </tr>
</table>

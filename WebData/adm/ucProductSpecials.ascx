<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductSpecials.ascx.cs"
    Inherits="adm_ucProductSpecials" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:CheckBoxList ID="chklProductSpecials" RepeatDirection="Horizontal" runat="server"
            AutoPostBack="True" OnSelectedIndexChanged="chklProductSpecials_SelectedIndexChanged">
        </asp:CheckBoxList>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"
            Enabled="False" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="chklProductSpecials" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

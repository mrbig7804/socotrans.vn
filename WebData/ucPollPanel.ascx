<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPollPanel.ascx.cs" Inherits="ucPollPanel" %>
<div class="dot">
</div>
<div>
    <img src="images/spacer.gif" height="1" width="22" alt="" />THĂM DÒ Ý KIẾN
</div>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="text-align:left" >
            •
            <asp:Label runat="server" ID="lblQuestion" ></asp:Label>
            <asp:Panel runat="server" ID="panVote">
                <div>
                    <asp:RadioButtonList runat="server" ID="optlOptions" DataTextField="OptionText" DataValueField="PollOptionID" />
                    <asp:RequiredFieldValidator ID="valRequireOption" runat="server" ControlToValidate="optlOptions"
                        SetFocusOnError="True" Text="Bạn phại chọn một mục" ToolTip="Bạn phại chọn một mục"
                        Display="Dynamic" ValidationGroup="PollVote">
                    </asp:RequiredFieldValidator>
                </div>
                <img height="1" src="images/spacer.gif" alt="" style="width: 8px" />
                <asp:Button CssClass="inputCommand" runat="server" ID="btnVote" ValidationGroup="PollVote"
                    Text="Bình chọn" OnClick="btnVote_Click" />
            </asp:Panel>
            <asp:Panel runat="server" ID="panResults">
                <div>
                    <asp:Repeater runat="server" ID="rptOptions">
                        <ItemTemplate>
                            <%# Eval("OptionText") %>
                            <small>(<%# Eval("Percentage", "{0:N1}") %>%)</small>
                            <br />
                            <div class="pollBar" style="width: <%# GetFixedPercentage(Eval("Percentage")) %>%">
                            </div>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <asp:Image runat="server" ID="imgSeparator" ImageUrl="~/Images/spacer.gif" Height="5px" /><br />
                        </SeparatorTemplate>
                    </asp:Repeater>
                    <asp:Image runat="server" ID="imgSeparator" ImageUrl="~/Images/spacer.gif" Height="10px" /><br />
                    <b>
                        <asp:Localize runat="server" ID="locTotVotes" Text="Tổng số:">
                        </asp:Localize>
                        <asp:Label runat="server" ID="lblTotalVotes" /></b>
                </div>
            </asp:Panel>
            </div>
    </ContentTemplate>
</asp:UpdatePanel>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductComment.ascx.cs"
    Inherits="ucProductComment" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvwComments" runat="server" AllowPaging="False" AutoGenerateColumns="False"
            Width="100%" OnRowDataBound="GridView1_RowDataBound" GridLines="None" OnRowCommand="gvwComments_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td valign="top">
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/"+ Eval("UserName").ToString()%>'
                                        Visible='<%#  Eval("UserName").ToString() != "" %>'>
                                        <asp:Image BorderColor="#996633" BorderWidth="1px" Width="60px" ID="imgAvatar" runat="server"
                                            Visible='<%#  Eval("UserName").ToString() != "" %>' ImageUrl='<%# GetAvatarUrl(Eval("UserName").ToString()) %>' />
                                    </asp:HyperLink>
                                </td>
                                <td width="100%" valign="top">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td width="50%" valign="bottom" align="left">
                                                <%--                                                <asp:hyperlink tooltip='Gửi tin nhắn' id="lnkSendMessage" runat="server" navigateurl='<%# "~/Person/SendMessage.aspx?to=" + Eval("UserName").ToString() %>'><img  alt="" src="/images/pm_new.gif" /></asp:hyperlink>
                                                --%>
                                                <asp:Label ID="lblFullName" runat="server" Text='<%# Eval("FullName").ToString() + " (Email: "+  Eval("Email").ToString() + ")" %>'></asp:Label>
                                                <span style="text-transform: uppercase; font-weight: bold">
                                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label></span>
                                            </td>
                                            <td width="50%" align="right">
                                                <small>
                                                    <asp:Label ID="lblAddedDate" runat="server" ForeColor="#aaaaaa" Text='<%# Eval("AddedDate", "{0:dd/MM/yy hh:mm tt}") %>'></asp:Label></small>
                                                <asp:ImageButton ID="btnDelete" Visible='<%# AllowEditComment %>' runat="server"
                                                    OnClientClick="if (confirm('Bạn có chắc chắn muốn xóa bình luận này?') == false) return false;"
                                                    ImageUrl="~/images/Delete.gif" CommandName="DeleteComment" CommandArgument='<%# Eval("ProductCommentID")%>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" style="color: #666666; border-top: dotted 1px #CCCCCC;
                                                margin: 5 5 5 5;" colspan="2">
                                                <asp:Label ID="lblBody" runat="server" Text='<%# Zensoft.Website.Utils.Text2Html(Eval("Body").ToString()) %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblResults" runat="server" CssClass="mes_cmd"></asp:Label>
        <div style="font-size: 14px; font-weight: bold; color: #eb4900">Bình luận:</div>
        <div class="dot" style="width: 706px; margin-bottom: 5px">
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Comment"
            CssClass="validationSummary" DisplayMode="List" />
        <asp:Panel ID="pnComments" runat="server" Width="100%">
            <table style="background-color: #f7f7f7; width: 706px; padding-top: 5px; padding-left: 5px;">
                <tr>
                    <td valign="top">
                        <asp:TextBox ID="txtHoTen" onfocus="this.className='inputCommandFocus';if (this.value=='Họ tên'){ this.value=''; }"
                            onblur="this.className='inputCommand';if (this.value==''){ this.value='Họ tên';}"
                            CssClass="inputCommand" runat="server" Columns="30" Width="48%">Họ tên</asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtNameValidator" ValidationGroup="Comment" runat="server"
                            ControlToValidate="txtHoTen" Display="Dynamic" ErrorMessage="Chưa Có Tên Người Gửi"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_Email" onfocus="this.className='inputCommandFocus';if (this.value=='Email'){ this.value=''; }"
                            onblur="this.className='inputCommand';if (this.value==''){ this.value='Email';}"
                            CssClass="inputCommand" runat="server" Columns="40" Width="48%">Email</asp:TextBox>
                        <asp:RequiredFieldValidator ID="valThua" runat="server" ValidationGroup="Comment"
                            ControlToValidate="txt_Email" Display="Dynamic" ErrorMessage="Chưa có Email"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valThuaExpression" ValidationGroup="Comment"
                            runat="server" ControlToValidate="txt_Email" Display="Dynamic" ErrorMessage="Email không hợp Lệ"
                            SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:TextBox ID="txtContents" CssClass="inputCommand" runat="server" Rows="3" TextMode="MultiLine"
                            MaxLength="150" onfocus="this.className='inputCommandFocus';checkLen(this,3500*document.getElementById('chargeFlg').value)"
                            onchange="checkLen(this,3500*document.getElementById('chargeFlg').value)" onkeyup="checkLen(this,3500*document.getElementById('chargeFlg').value)"
                            onblur="this.className='inputCommand'" Width="97.5%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="BodyValidator" ValidationGroup="Comment" runat="server"
                            ControlToValidate="txtContents" Display="Dynamic" ErrorMessage="Chưa Có Nội Dung"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <br />
                        <table width="98%">
                            <tr>
                                <td width="200px" valign="top">
                                    <small>Số ký tự còn lại: <span id="remain">3500</span></small>
                                </td>
                                <td width="220px" align="right">
                                </td>
                                <td align="right">
                                    <asp:Button ValidationGroup="Comment" CssClass="btnCommand" ID="btnSend" runat="server"
                                        Text="Gửi bình luận" OnClick="btnSend_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 26px">
                        <input name="chargeFlg" id="chargeFlg" value="1" type="hidden" />
                    </td>
                    <td valign="top" style="height: 26px">
                    </td>
                </tr>
            </table>
            <script language="javascript" type="text/javascript">
                function checkLen(Target, num) {
                    StrLen = Target.value.length;
                    if (StrLen > num) {
                        Target.value = Target.value.substring(0, num);
                        charsLeft = 0;
                    }
                    else {
                        charsLeft = num - StrLen;
                    }
                    document.getElementById("remain").innerHTML = charsLeft;

                }

            </script>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>

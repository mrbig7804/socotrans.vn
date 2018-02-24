<%@ control language="C#" autoeventwireup="true" codefile="ucComments.ascx.cs" inherits="ucComments" %>
<asp:updatepanel id="UpdatePanel1" runat="server">
    <contenttemplate>
        <asp:gridview id="gvwComments" runat="server" allowpaging="False" autogeneratecolumns="False"
            width="100%" onrowdatabound="GridView1_RowDataBound" gridlines="None">
            <columns>
                <asp:templatefield>
                    <itemtemplate>
                        <table width="100%">
                            <tr>
                                <td valign="top">
                                    <div style="padding: 1px; border: 1px solid #996633">
                                        <asp:hyperlink id="HyperLink2" runat="server" navigateurl='<%# "~/memberArticle.aspx?uid="+ Eval("UserName").ToString()%>'
                                            visible='<%#  Eval("UserName").ToString() != "" %>'>
                                            <asp:image bordercolor="#888888" borderwidth="1px" width="60px" id="imgAvatar" runat="server"
                                                visible='<%#  Eval("UserName").ToString() != "" %>' imageurl='<%# GetAvatarUrl(Eval("UserName").ToString()) %>' />
                                        </asp:hyperlink></div>
                                </td>
                                <td width="100%" valign="top">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td width="50%" valign="bottom" style="text-transform: uppercase;" align="left">
<%--                                                <asp:hyperlink tooltip='Gửi tin nhắn' id="lnkSendMessage" runat="server" navigateurl='<%# "~/Person/SendMessage.aspx?to=" + Eval("UserName").ToString() %>'><img  alt="" src="images/pm_new.gif" /></asp:hyperlink>
--%>                                                <asp:label id="lblFullName" runat="server" text='<%# Eval("FullName") %>'></asp:label>
                                                <asp:label id="lblUserName" runat="server" text='<%# Eval("UserName") %>'></asp:label>
                                            </td>
                                            <td width="50%" align="right">
                                                <small>
                                                    <asp:label id="lblAddedDate" runat="server" forecolor="#aaaaaa" text='<%# Eval("AddedDate", "{0:dd/MM/yy hh:mm tt}") %>'></asp:label></small>
                                                <asp:hyperlink id="HyperLink1" visible='<%# AllowEditComment %>' navigateurl='<%# "~/adm/ManageCommentsSpecied.aspx?editID=" + Eval("CommentID").ToString() %>'
                                                    runat="server"><img alt="" src="images/Edit.gif" /></asp:hyperlink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" style="color: #aaaaaa; border-top: dotted 1px #CCCCCC;
                                                margin: 5 5 5 5;" colspan="2">
                                                <asp:label id="lblBody" runat="server" text='<%# ConvertToHTMLTag(Eval("Body").ToString()) %>'></asp:label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </itemtemplate>
                </asp:templatefield>
            </columns>
        </asp:gridview>
        <asp:label id="lblResults" runat="server" CssClass="mes_cmd"></asp:label>
    </contenttemplate>
    <triggers>
        <asp:asyncpostbacktrigger controlid="btnSend" eventname="Click" />
    </triggers>
</asp:updatepanel>

<div class="title">Bình luận của bạn</div>
<div class="dot" style="width:250px; margin-bottom:5px"></div>
<asp:panel id="pnComments" runat="server" width="100%">
    <table style="background-color: #f7f7f7; width: 710px; padding: 5px">
        <tr>
            <td valign="top" style="font-weight: bold">
                Họ Tên:
            </td>
            <td valign="top">
                <asp:textbox id="txtHoTen" cssclass="inputCommand" runat="server" columns="50"></asp:textbox>
                <asp:requiredfieldvalidator id="txtNameValidator" validationgroup="Comment" runat="server"
                    controltovalidate="txtHoTen" display="Dynamic" errormessage="Chưa Có Tên Người Gửi"
                    setfocusonerror="True">*</asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr>
            <td valign="top" style="font-weight: bold">
                Hòm thư:
            </td>
            <td valign="top">
                <asp:textbox id="txt_Thua" cssclass="inputCommand" runat="server" columns="50"></asp:textbox>
                <asp:requiredfieldvalidator id="valThua" runat="server" validationgroup="Comment"
                    controltovalidate="txt_Thua" display="Dynamic" errormessage="Chưa có Email" setfocusonerror="True">*</asp:requiredfieldvalidator>
                <asp:regularexpressionvalidator id="valThuaExpression" validationgroup="Comment"
                    runat="server" controltovalidate="txt_Thua" display="Dynamic" errormessage="Email không hợp Lệ"
                    setfocusonerror="True" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator>
            </td>
        </tr>
        <tr>
            <td valign="top" style="font-weight: bold">
                Nội Dung:
            </td>
            <td valign="top">
                <asp:textbox id="txtContents" cssclass="inputCommand" runat="server" rows="6" columns="45"
                    textmode="MultiLine" width="95%" maxlength="150" onfocus="checkLen(this,3500*document.getElementById('chargeFlg').value)"
                    onchange="checkLen(this,3500*document.getElementById('chargeFlg').value)" onkeyup="checkLen(this,3500*document.getElementById('chargeFlg').value)">
                </asp:textbox><asp:requiredfieldvalidator id="BodyValidator" validationgroup="Comment"
                    runat="server" controltovalidate="txtContents" display="Dynamic" errormessage="Chưa Có Nội Dung"
                    setfocusonerror="True">*</asp:requiredfieldvalidator>
                <br />
                <small>Số ký tự còn lại: <span id="remain">3500</span></small>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 26px">
                <input name="chargeFlg" id="chargeFlg" value="1" type="hidden" />
            </td>
            <td valign="top" style="height: 26px">
                <table>
                    <tr>
                        <td>
                            <asp:button validationgroup="Comment" cssclass="btnCommand" id="btnSend" runat="server"
                                text="Gửi" onclick="btnSend_Click" width="60px" />
                        </td>
                        <td>
                            <asp:updateprogress id="UpdateProgress1" runat="server" dynamiclayout="true">
                                <progresstemplate>
                                    <img src="/images/indicator.gif" />
                                </progresstemplate>
                            </asp:updateprogress>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        function checkLen(Target, num) {	
	        StrLen = Target.value.length;
	        if (StrLen > num){
		        Target.value = Target.value.substring(0,num);
		        charsLeft = 0;
            }
            else {
		        charsLeft = num - StrLen;
	        }
	        document.getElementById("remain").innerHTML =charsLeft;
	        
        }

    </script>

    <asp:validationsummary id="ValidationSummary1" runat="server" validationgroup="Comment"
        displaymode="List" />
</asp:panel>

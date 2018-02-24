<%@ page language="C#" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true"
    codefile="ManageProductComments.aspx.cs" inherits="adm_ManageProductCommnets"
    title="Untitled Page" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Phản hồi về sản phẩm<asp:scriptmanager id="ScriptManager1" runat="server">
        </asp:scriptmanager>
    </div>
<%--   <asp:updatepanel id="UpdatePanel1" runat="server">
        <contenttemplate>
--%>            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
               <asp:linkbutton id="lnkUnapprovedComment" runat="server" onclick="lnkUnapprovedComment_Click">Phản 
            hồi chưa được duyệt</asp:linkbutton>
                &nbsp;&nbsp; |&nbsp;&nbsp;
                <asp:linkbutton id="lnkAllComment" runat="server" onclick="lnkAllComment_Click">Tất 
            cả phản hồi </asp:linkbutton></strong>
            <asp:gridview id="gvwComments" runat="server" autogeneratecolumns="False" width="95%"
                onrowdatabound="GridView1_RowDataBound" allowpaging="True" 
                gridlines="None" onrowcommand="gvwComments_RowCommand" 
                datasourceid="ObjectDataSource1">
                <columns>
                    <asp:templatefield>
                        <itemtemplate>
                            <table width="100%">
                                <tr>
                                    <td valign="top">
                                        <asp:hyperlink id="HyperLink2" runat="server" navigateurl='<%# "~/"+ Eval("UserName").ToString()%>'
                                            visible='<%#  Eval("UserName").ToString() != "" %>'>
                                            <asp:image bordercolor="#888888" borderwidth="1px" width="40px" id="imgAvatar" runat="server"
                                                visible='<%#  Eval("UserName").ToString() != "" %>' imageurl='<%# GetAvatarUrl(Eval("UserName").ToString()) %>' />
                                        </asp:hyperlink>
                                    </td>
                                    <td width="100%" valign="top">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td width="50%" valign="bottom" style="text-transform: uppercase;" align="left">
                                                    <asp:label id="lblFullName" runat="server" text='<%# Eval("FullName") %>'></asp:label>
                                                    <asp:label id="lblUserName" runat="server" text='<%# Eval("UserName") %>'></asp:label>
                                                </td>
                                                <td width="50%" align="right">
                                                    <small>
                                                        <asp:label id="lblAddedDate" runat="server" forecolor="#aaaaaa" text='<%# Eval("AddedDate", "Ngày {0:dd/MM/yyyy hh:mm tt}") %>'></asp:label></small>
                                                    <asp:image id="Image1" runat="server" tooltip="Phải hồi chưa được duyệt"
                                                        visible='<%# !Convert.ToBoolean(Eval("Approved")) %>' imageurl="~/images/attention1_16x16.gif" />
                                                    <asp:imagebutton id="btnDelete" runat="server" imageurl="~/images/Delete.gif" commandname="DeleteComment" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa bình luận này?') == false) return false;"
                                                        commandargument='<%# Eval("ProductCommentID")%>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left" style="color: #aaaaaa; border-top: solid 1px #999999;
                                                    margin: 5 5 5 5" colspan="2">
                                                    <a href='/san-pham/<%# Eval("Product.UniqueTitle") %>' target="_blank">
                                                        <%# Eval("Product.Title")%></a>
                                                    <br />
                                                    <asp:label id="lblBody" runat="server" text='<%# Eval("Body") %>'></asp:label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </itemtemplate>
                    </asp:templatefield>
                </columns>
            </asp:gridview>
            <asp:gridview id="gvwUnapprovedComments" runat="server" autogeneratecolumns="False" width="95%"
                onrowdatabound="GridView1_RowDataBound" allowpaging="True" 
                gridlines="None" onrowcommand="gvwComments_RowCommand" 
                datasourceid="ObjectDataSource2" visible="False">
                <columns>
                    <asp:templatefield>
                        <itemtemplate>
                            <table width="100%">
                                <tr>
                                    <td valign="top">
                                        <asp:hyperlink id="HyperLink2" runat="server" navigateurl='<%# "~/"+ Eval("UserName").ToString()%>'
                                            visible='<%#  Eval("UserName").ToString() != "" %>'>
                                            <asp:image bordercolor="#888888" borderwidth="1px" width="40px" id="imgAvatar" runat="server"
                                                visible='<%#  Eval("UserName").ToString() != "" %>' imageurl='<%# GetAvatarUrl(Eval("UserName").ToString()) %>' />
                                        </asp:hyperlink>
                                    </td>
                                    <td width="100%" valign="top">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td width="50%" valign="bottom" style="text-transform: uppercase;" align="left">
                                                    <asp:label id="lblFullName" runat="server" text='<%# Eval("FullName") %>'></asp:label>
                                                    <asp:label id="lblUserName" runat="server" text='<%# Eval("UserName") %>'></asp:label>
                                                </td>
                                                <td width="50%" align="right">
                                                    <small>
                                                        <asp:label id="lblAddedDate" runat="server" forecolor="#aaaaaa" text='<%# Eval("AddedDate", "Ngày {0:dd/MM/yyyy hh:mm tt}") %>'></asp:label></small>
                                                    <asp:image id="Image1" runat="server" tooltip="Phải hồi chưa được duyệt"
                                                        visible='<%# !Convert.ToBoolean(Eval("Approved")) %>' imageurl="~/images/attention1_16x16.gif" />
                                                    <asp:imagebutton id="btnDelete" runat="server" imageurl="~/images/Delete.gif" commandname="DeleteComment" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa bình luận này?') == false) return false;"
                                                        commandargument='<%# Eval("ProductCommentID")%>' />
                                                    <asp:imagebutton id="btnApproved" runat="server" imageurl="~/images/ok_16x16.gif" commandname="ApprovedComment"
                                                        commandargument='<%# Eval("ProductCommentID")%>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left" style="color: #aaaaaa; border-top: solid 1px #999999;
                                                    margin: 5 5 5 5" colspan="2">
                                                    <a href='/san-pham/<%# Eval("Product.UniqueTitle") %>' target="_blank">
                                                        <%# Eval("Product.Title") %></a>
                                                    <br />
                                                    <asp:label id="lblBody" runat="server" text='<%# Eval("Body") %>'></asp:label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </itemtemplate>
                    </asp:templatefield>
                </columns>
            </asp:gridview>
<%--        </contenttemplate>
    </asp:updatepanel>
    <asp:updateprogress id="UpdateProgress1" runat="server">
        <progresstemplate>
            <img src="../images/indicator.gif" />
        </progresstemplate>
    </asp:updateprogress>
--%>    <br />
    <asp:objectdatasource id="ObjectDataSource1" runat="server" selectmethod="GetProductCommentsAll"
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.ProductCommentsBF"></asp:objectdatasource>
    <asp:objectdatasource id="ObjectDataSource2" runat="server" selectmethod="GetProductCommentsUnapproved"
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.ProductCommentsBF"></asp:objectdatasource>
</asp:content>

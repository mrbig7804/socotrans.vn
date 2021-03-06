﻿<%@ page language="C#" title=": : Zensoft Admin - Bình luận bài viết - Danh sách các nhận xét chưa được xác nhận : :"
    masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true" validaterequest="false"
    codefile="ManageComments.aspx.cs" inherits="adm_ManageComments" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Bình luận bài viết</div>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; + <a href="ManageCommentsSpecied.aspx">Những Comments
        Đã xác nhận</a><br />
    <br />

    <script type="text/javascript">
      function toggleDivState(divName)
      {
         var ctl = window.document.getElementById(divName);
         if (ctl.style.display == "none")
            ctl.style.display = "";
         else
            ctl.style.display = "none";
      }
    </script>

    <p class="sectionTitle">
        Danh sách các Comment chưa xác nhận</p>
    <asp:gridview id="GridView1" runat="server" allowpaging="True" autogeneratecolumns="False"
        datasourceid="ObjectDataSource1" datakeynames="CommentID" width="100%" onrowcreated="GridView1_RowCreated"
        onrowdeleted="GridView1_RowDeleted" bordercolor="#999999" borderstyle="Solid"
        borderwidth="1px" cellpadding="3" gridlines="Vertical" onselectedindexchanged="GridView1_SelectedIndexChanged"
        showheader="False" onrowcommand="GridView1_RowCommand">
        <columns>
            <asp:templatefield>
                <itemtemplate>
                    <a href="javascript:toggleDivState('comment<%# Eval("CommentID") %>');">
                        <img src="../images/ArrowR2.gif" alt="" style="vertical-align: middle; border-width: 0px;" /><%# Eval("FullName") %></a>
                    - <small>
                        <%# Eval("Email")%>(<%# Eval("AddedDate", "{0:dd/MM/yyyy hh:mm tt}")%>)</small>
                    <div style="display: none;" id="comment<%# Eval("CommentID") %>">
                        <strong>Bài Viết: </strong><a href='../ShowArticle.aspx?ID=<%# Eval("ArticleID") %>'
                            target="_blank">
                            <%# Eval("ArticleTitle") %></a>
                        <br />
                        <strong>UserName: </strong>
                        <%# Eval("UserName") %>
                        <br />
                        <strong>Email: </strong>
                        <%# Eval("Email") %>
                        <br />
                        <strong>Họ tên: </strong>
                        <%# Eval("FullName") %>
                        <br />
                        <strong>Thời Gian: </strong>
                        <%# Eval("AddedDate") %>
                        <br />
                        <asp:localize id="Localize1" runat="server" text='<%# Eval("Body").ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n","<br/>") %>'></asp:localize>
                    </div>
                </itemtemplate>
            </asp:templatefield>
            <asp:commandfield buttontype="Image" selectimageurl="Images/Edit.gif" selecttext="Edit Comment"
                showselectbutton="True">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:commandfield>
            <asp:buttonfield buttontype="Image" imageurl="Images/ok_16x16.gif" commandname="Comments">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:buttonfield>
            <asp:commandfield buttontype="Image" deleteimageurl="Images/Delete.gif" deletetext="Xóa nhận xet"
                showdeletebutton="True">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:commandfield>
        </columns>
        <selectedrowstyle cssclass="gridViewSelectedRow" />
        <headerstyle cssclass="gridViewHeader" />
        <alternatingrowstyle cssclass="gridViewAlternatingRow" />
    </asp:gridview>
    <br />
    <asp:objectdatasource id="ObjectDataSource1" runat="server" selectmethod="GetCommentsNotSpecied"
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.CommentsBF" deletemethod="Delete">
        <deleteparameters>
            <asp:parameter name="commentID" type="Int64" />
        </deleteparameters>
    </asp:objectdatasource>
    <asp:detailsview id="DetailsView1" runat="server" autogeneraterows="False" datasourceid="ObjectDataSource2"
        width="100%" defaultmode="Edit" onitemcommand="DetailsView1_ItemCommand" onitemupdated="DetailsView1_ItemUpdated"
        onitemcreated="DetailsView1_ItemCreated" datakeynames="CommentID">
        <fieldheaderstyle width="120px" cssclass="gridViewHeader" />
        <fields>
            <asp:boundfield datafield="CommentID" headertext="M&#227;" sortexpression="CommentID"
                readonly="True" />
            <asp:templatefield headertext="Nội Dung">
                <itemtemplate>
                    <asp:textbox id="Body" width="97%" cssclass="inputCommand" runat="server" text='<%# Bind("Body") %>'
                        rows="8" textmode="MultiLine"></asp:textbox>
                </itemtemplate>
            </asp:templatefield>
            <asp:checkboxfield datafield="Approved" headertext="X&#225;c Nhận" sortexpression="Approved" />
            <asp:commandfield showeditbutton="True" />
        </fields>
    </asp:detailsview>
    <br />
    <asp:objectdatasource id="ObjectDataSource2" runat="server" selectmethod="GetCommentsBF"
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.CommentsBF" updatemethod="Update">
        <updateparameters>
            <asp:parameter name="commentID" type="Int64" />
            <asp:parameter name="body" type="String" />
            <asp:parameter name="approved" type="Boolean" />
        </updateparameters>
        <selectparameters>
            <asp:controlparameter controlid="GridView1" name="commentID" propertyname="SelectedValue"
                type="Int64" />
        </selectparameters>
    </asp:objectdatasource>
</asp:content>

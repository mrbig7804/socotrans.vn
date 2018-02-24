<%@ page language="C#" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true"
    codefile="Comments.aspx.cs" inherits="adm_Comments" title=".: Zensoft Website - Nhận xét về bài viết :." %>

<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Nhận xét bài viết</div>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; + <a href="MyComments.aspx">Những nhận xét của
        tôi</a>.<br />
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
        Những nhận xét gần đây.</p>
    <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" datasourceid="ObjectDataSource1"
        datakeynames="CommentID" width="100%" bordercolor="#999999" borderstyle="Solid"
        borderwidth="1px" cellpadding="3" gridlines="Vertical" showheader="False" allowpaging="True">
        <columns>
            <asp:templatefield>
                <itemtemplate>
                    <a href="javascript:toggleDivState('comment<%# Eval("CommentID") %>');">
                        <img src="../images/ArrowR2.gif" alt="" style="vertical-align: middle; border-width: 0px;" /><%# Eval("UserName") %>
                        (<%# Eval("FullName") %>)</a> - <small>
                            <%# Eval("AddedDate", "{0:dd/MM/yyyy hh:mm tt}")%></small>
                    <div style="display: none;" id="comment<%# Eval("CommentID") %>">
                        <strong>Bài Viết: </strong><a href='../ShowArticle.aspx?ID=<%# Eval("ArticleID") %>'>
                            <%# Eval("ArticleTitle") %></a>
                        <br />
                        <asp:localize id="Localize1" runat="server" text='<%# Eval("Body").ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n","<br/>") %>'></asp:localize>
                    </div>
                </itemtemplate>
            </asp:templatefield>
        </columns>
        <selectedrowstyle cssclass="gridViewSelectedRow" />
        <headerstyle cssclass="gridViewHeader" />
        <alternatingrowstyle cssclass="gridViewAlternatingRow" />
        <pagersettings mode="NextPrevious" nextpagetext=" Trang ti&#234;́p &amp;gt;" previouspagetext="&amp;lt; Trang trước " />
    </asp:gridview>
    <br />
    <asp:objectdatasource id="ObjectDataSource1" runat="server" selectmethod="GetCommentsSpecied"
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.CommentsBF"></asp:objectdatasource>
    &nbsp;&nbsp;<br />
</asp:content>

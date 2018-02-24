<%@ page language="C#" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true"
    codefile="ArchivedPolls.aspx.cs" inherits="admin_ArchivedPolls" %>

<%@ register src="../ucPollPanel.ascx" tagname="ucPollPanel" tagprefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">

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

    <div class="headerText">
        Danh sách các bình chọn.</div>
    <asp:gridview id="gvwPolls" runat="server" autogeneratecolumns="False" datasourceid="objPolls"
        width="100%" datakeynames="PollID" onrowcreated="gvwPolls_RowCreated" showheader="False">
        <columns>
            <asp:templatefield>
                <itemtemplate>
                    <img src="../images/ArrowR2.gif" alt="" style="vertical-align: middle; border-width: 0px;" />
                    <a href="javascript:toggleDivState('poll<%# Eval("PollID") %>');">
                        <%# Eval("QuestionText") %></a> <small>(Lưu trữ ngày
                            <%# Eval("ArchivedDate", "{0:dd/MM/yyyy}") %>)</small>
                    <div style="display: none;" id="poll<%# Eval("PollID") %>">
                    </div>
                </itemtemplate>
            </asp:templatefield>
            <asp:commandfield buttontype="Image" deleteimageurl="~/Images/Delete.gif" deletetext="Delete poll"
                showdeletebutton="True">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:commandfield>
        </columns>
        <emptydatatemplate>
            <b>Không có bình chọn nào</b></emptydatatemplate>
    </asp:gridview>
    <asp:objectdatasource id="objPolls" runat="server" selectmethod="GetPollsArchived"
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.PollsBF" deletemethod="Delete">
        <deleteparameters>
            <asp:parameter name="pollID" type="Int32" />
        </deleteparameters>
    </asp:objectdatasource>
    </td>
</asp:content>

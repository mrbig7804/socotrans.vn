<%@ page language="C#" title=": : Zensoft Admin - Bài viết - Các bài viết chưa được duyệt : :"
    masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true" codefile="ManageArtilceUnapproved.aspx.cs"
    inherits="admin_ManageArtilceUnapproved" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Quan trị bài viết</div>
    <asp:panel id="panApproval" runat="server" width="100%">
        <ul style="list-style-type: square">
            <li>
                <asp:hyperlink id="lnkUnapproval" runat="server" navigateurl="ManageArtilceUnapproved.aspx">Các bài viết chưa được duyệt</asp:hyperlink>
            </li>
            <li>
                <asp:hyperlink id="lnkUnlisted" runat="server" navigateurl="ManageArtilceUnlisted.aspx">Các bài viết không được hiển thị</asp:hyperlink></li>
        </ul>
    </asp:panel>
    <br />
    <p class="sectionTitle">
        Danh sách các bài viết chưa được xác nhận</p>
    <asp:gridview id="GridView1" runat="server" allowpaging="True" autogeneratecolumns="False"
        cellpadding="3" datakeynames="ArticleID" datasourceid="ObjectDataSource1" gridlines="Vertical"
        width="100%" onrowcommand="GridView1_RowCommand" onrowcreated="GridView1_RowCreated"
        bordercolor="Gray" borderstyle="Dotted" borderwidth="1px">
        <footerstyle backcolor="#CCCCCC" />
        <columns>
            <asp:hyperlinkfield datanavigateurlfields="ArticleID" datanavigateurlformatstring="~/ShowArticle.aspx?ID={0}"
                datatextfield="Title" headertext="Ti&#234;u đề" sortexpression="Title">
                <controlstyle width="100%" />
            </asp:hyperlinkfield>
            <asp:boundfield datafield="ViewCount" headertext="Lượt xem" sortexpression="ViewCount">
                <controlstyle width="60px" />
            </asp:boundfield>
            <asp:boundfield datafield="AddedBy" headertext="Người tạo" sortexpression="AddedBy">
                <controlstyle width="70px" />
            </asp:boundfield>
            <asp:boundfield applyformatineditmode="True" datafield="AddedDate" dataformatstring="{0:d}"
                headertext="Ng&#224;y tạo" sortexpression="AddedDate">
                <controlstyle width="100px" />
            </asp:boundfield>
            <asp:buttonfield buttontype="Image" imageurl="Images/OK.gif" commandname="Approved"
                text="Duyệt b&#224;i viết">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:buttonfield>
            <asp:commandfield buttontype="Image" deleteimageurl="Images/Delete.gif" deletetext="X&#243;a b&#224;i viết"
                showdeletebutton="True">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:commandfield>
        </columns>
        <selectedrowstyle cssclass="gridViewSelectedRow" />
        <headerstyle cssclass="gridViewHeader" />
        <alternatingrowstyle cssclass="gridViewAlternatingRow" />
    </asp:gridview>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" deletemethod="Delete"
        selectmethod="GetArticlesUnApproved" typename="Zensoft.Website.BusinessLayer.BusinessFacade.ArticlesBF">
        <deleteparameters>
            <asp:parameter name="articleID" type="Int32" />
        </deleteparameters>
    </asp:objectdatasource>
</asp:content>

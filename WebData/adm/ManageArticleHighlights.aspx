<%@ page language="C#" title="" validaterequest="false"
    masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true" codefile="ManageArticleHighlights.aspx.cs"
    inherits="admin_ManageArticleHighlights" %>

<%@ register src="../Controls/ucFileUploader.ascx" tagname="ucFileUploader" tagprefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Tin nổi bật
    </div>
    <br />
    <asp:gridview id="gvwArticleHighlights" runat="server" autogeneratecolumns="False"
        datasourceid="objArticleHighlights" width="100%" datakeynames="ArticleHighlightID"
        bordercolor="#999999" borderstyle="Solid" borderwidth="1px" cellpadding="3" gridlines="Vertical"
        onrowdeleted="gvwArticleHighlights_RowDeleted" onselectedindexchanged="gvwArticleHighlights_SelectedIndexChanged"
        onrowcreated="gvwArticleHighlights_RowCreated" allowpaging="True">
        <columns>
            <asp:templatefield headertext="Ng&#224;y">
                <itemtemplate>
                    <%# Eval("AddedDate", "{0:dd/MM/yyyy}")%>
                </itemtemplate>
                <itemstyle width="100px" />
            </asp:templatefield>
            <asp:boundfield datafield="Title" headertext="Ti&#234;u đề">
                <headerstyle horizontalalign="Left" />
            </asp:boundfield>
            <asp:boundfield datafield="Link" readonly="True" headertext="URL">
                <itemstyle width="180px" horizontalalign="Center" />
            </asp:boundfield>
            <asp:templatefield headertext="Hiện tại">
                <itemtemplate>
                    <asp:image runat="server" id="imgIsCurrent" imageurl="Images/Checkmark.gif" visible='<%# Eval("IsCurrent") %>' />
                </itemtemplate>
                <itemstyle width="50px" horizontalalign="Center" />
            </asp:templatefield>
            <asp:commandfield buttontype="Image" selectimageurl="Images/Edit.gif" selecttext="Edit poll"
                showselectbutton="True">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:commandfield>
            <asp:commandfield buttontype="Image" deleteimageurl="Images/Delete.gif" deletetext="Delete poll"
                showdeletebutton="True">
                <itemstyle horizontalalign="Center" width="20px" />
            </asp:commandfield>
        </columns>
        <emptydatatemplate>
            <b>Không có dữ liệu</b></emptydatatemplate>
        <selectedrowstyle cssclass="gridViewSelectedRow" />
        <alternatingrowstyle cssclass="gridViewAlternatingRow" />
        <headerstyle cssclass="gridViewHeader" />
    </asp:gridview>
    <asp:objectdatasource id="objArticleHighlights" runat="server" selectmethod="GetArticleHighlightsAll"
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.ArticleHighlightsBF" deletemethod="Delete">
        <deleteparameters>
            <asp:parameter name="articleHighlightID" type="Int32" />
        </deleteparameters>
    </asp:objectdatasource>
    <br />
    <asp:detailsview id="dvwArticleHighlight" runat="server" autogeneraterows="False"
        datasourceid="objCurrArticleHighlight" width="100%" autogenerateeditbutton="True"
        autogenerateinsertbutton="True" headertext="CHI TIẾT" datakeynames="ArticleHighlightID"
        defaultmode="Insert" bordercolor="#312a2d" borderstyle="Dotted" borderwidth="1px"
        onitemdeleted="dvwArticleHighlight_ItemDeleted" onitemupdated="dvwArticleHighlight_ItemUpdated"
        oniteminserted="dvwArticleHighlight_ItemInserted" onitemcommand="dvwArticleHighlight_ItemCommand"
        onitemcreated="dvwArticleHighlight_ItemCreated">
        <headerstyle cssclass="gridViewHeader" />
        <fieldheaderstyle width="130px" cssclass="gridViewHeader" />
        <fields>
            <asp:boundfield datafield="ArticleHighlightID" headertext="ID" readonly="True" insertvisible="False" />
            <asp:templatefield insertvisible="False" headertext="Tạo ng&#224;y">
                <itemtemplate>
                    <asp:label id="lblTitle" runat="server" text='<%# Eval("AddedDate","{0:dd/MM/yyyy hh:mm tt}") %>'></asp:label>
                </itemtemplate>
            </asp:templatefield>
            <asp:boundfield datafield="AddedBy" headertext="AddedBy" insertvisible="False" readonly="True" />
            <asp:boundfield datafield="Link" headertext="Url" controlstyle-cssclass="inputCommand" />
            <asp:boundfield datafield="SmallPictureUrl" headertext="Ảnh minh họa nhỏ" controlstyle-cssclass="inputCommand" />
            <asp:boundfield datafield="PictureUrl" headertext="Ảnh minh họa" controlstyle-cssclass="inputCommand" />
            <asp:templatefield headertext="Ti&#234;u đề">
                <itemtemplate>
                    <asp:label id="lblTitle" runat="server" text='<%# Eval("Title") %>'></asp:label>
                </itemtemplate>
                <edititemtemplate>
                    <asp:textbox cssclass="inputCommand" id="txtTitle" runat="server" text='<%# Bind("Title") %>'
                        maxlength="250" width="100%"></asp:textbox>
                    <asp:requiredfieldvalidator id="valRequireTitle" runat="server" controltovalidate="txtTitle"
                        setfocusonerror="true" text="Bạn chưa nhập tiêu đề." tooltip="Tiêu đề không được để trống."
                        display="Dynamic" validationgroup="ArticleHighlight">
                    </asp:requiredfieldvalidator>
                </edititemtemplate>
            </asp:templatefield>
            <asp:templatefield headertext="Nội dung">
                <itemtemplate>
                    <asp:label id="lblDescription" runat="server" text='<%# Eval("Description") %>'></asp:label>
                </itemtemplate>
                <edititemtemplate>
                    <asp:textbox id="txtDescription" runat="server" text='<%# Bind("Description") %>'
                        maxlength="500" width="100%" textmode="MultiLine" cssclass="inputCommand"></asp:textbox>
                    <asp:requiredfieldvalidator id="valRequireDescription" runat="server" controltovalidate="txtDescription"
                        setfocusonerror="true" text="Bạn chưa nhập nội dung." tooltip="Nội dung không được để trống."
                        display="Dynamic" validationgroup="ArticleHighlight">
                    </asp:requiredfieldvalidator>
                </edititemtemplate>
            </asp:templatefield>
            <asp:checkboxfield datafield="IsCurrent" headertext="Nổi bật nhất" />
            <asp:checkboxfield datafield="Listed" headertext="Được hiển thị" />
        </fields>
    </asp:detailsview>
    <asp:objectdatasource id="objCurrArticleHighlight" runat="server" insertmethod="Insert"
        selectmethod="GetArticleHighlightsBF" typename="Zensoft.Website.BusinessLayer.BusinessFacade.ArticleHighlightsBF"
        updatemethod="Update" deletemethod="Delete">
        <selectparameters>
            <asp:controlparameter controlid="gvwArticleHighlights" name="articleHighlightID"
                propertyname="SelectedValue" type="Int32" />
        </selectparameters>
        <updateparameters>
            <asp:parameter name="articleHighlightID" type="Int32" />
            <asp:parameter name="addedDate" type="DateTime" />
            <asp:parameter name="addedBy" type="String" />
            <asp:parameter name="title" type="String" />
            <asp:parameter name="description" type="String" />
            <asp:parameter name="smallPictureUrl" type="String" defaultvalue="A" />
            <asp:parameter name="pictureUrl" type="String" />
            <asp:parameter name="link" type="String" />
            <asp:parameter name="isCurrent" type="Boolean" />
            <asp:parameter name="listed" type="Boolean" />
        </updateparameters>
        <insertparameters>
            <asp:parameter name="title" type="String" />
            <asp:parameter name="description" type="String" />
            <asp:parameter name="smallPictureUrl" type="String" />
            <asp:parameter name="pictureUrl" type="String" />
            <asp:parameter name="link" type="String" />
            <asp:parameter name="isCurrent" type="Boolean" />
            <asp:parameter name="listed" type="Boolean" />
        </insertparameters>
        <deleteparameters>
            <asp:parameter name="articleHighlightID" type="Int32" />
        </deleteparameters>
    </asp:objectdatasource>
    <br />
    <div style="width: 100%;" class="gridViewHeader">
        Upload file
    </div>
    <iframe src="uploadfile.aspx" frameborder="0" marginwidth="0" marginheight="0" hspace="0"
        vspace="0" allowtransparency="true" style="width: 100%; height: 159px; border-top-style: none;
        border-right-style: none; border-left-style: none; border-bottom-style: none;">
    </iframe>
</asp:content>

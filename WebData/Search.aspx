<%@ page language="C#" autoeventwireup="true" codefile="Search.aspx.cs" masterpagefile="~/TemplateHome.master"
    inherits="Search" title="Tìm kiếm" %>

<%--<%@ register src="ucAdvanceSearch.ascx" tagname="ucAdvanceSearch" tagprefix="uc1" %>--%>
<asp:content id="Content1" runat="server" contentplaceholderid="cphHomePage">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div class="pageHeaderText">
                    Tìm Kiếm</div>
                <div class="dot" style="width: 175px">
                </div>
                <br />
                <%--<uc1:ucadvancesearch id="UcAdvanceSearch1" runat="server" />--%>
                <br />
                &nbsp;&nbsp;<asp:label id="lblNote" runat="server" text="*Gợi ý: Để tìm kiếm một cụm từ bạn hãy để cụm từ đó trong ngoặc kép"
                    font-italic="True"></asp:label><asp:label id="lblMessage" runat="server" font-bold="False"></asp:label><br />
                <br />
                <asp:gridview id="gvArticles" runat="server" width="100%" autogeneratecolumns="False"
                    datakeynames="ArticleID" showheader="False" allowpaging="True" ondatabound="gvArticles_DataBound"
                    onpageindexchanging="gvArticles_PageIndexChanging" cellpadding="0" editindex="0"
                    borderstyle="None" borderwidth="0px" gridlines="None" selectedindex="0">
                    <columns>
                        <asp:templatefield>
                            <itemtemplate>
                                <a class="titleLink" href='ShowArticle.aspx?Mark=<%=Keyword%>&ID=<%# Eval("ArticleID") %>'>
                                    <%#Zensoft.Website.Utilities.SearchUtility.MarkKeyword(Eval("Title").ToString(),Keyword) %>
                                </a>
                                <br />
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 65px" valign="top">
                                            <a href='ShowArticle.aspx?Mark=<%=Keyword%>&ID=<%# Eval("ArticleID") %>'>
                                                <asp:image id="Image1" width="100px" runat="server" imageurl='<%# Eval("PictureUrl") %>'
                                                    ondatabinding="Image1_DataBinding1" />
                                            </a>
                                        </td>
                                        <td style="width: 100%" valign="top">
                                            <%# Zensoft.Website.Utilities.SearchUtility.MarkKeyword(Eval("Abstract").ToString(),Keyword) %>
                                        </td>
                                    </tr>
                                </table>
                                <div style="text-align: right;">
                                    <a href='ShowArticle.aspx?ID=<%# Eval("ArticleID") %>'>Chi tiết</a></div>
                                <div class="dot">
                                </div>
                            </itemtemplate>
                            <itemstyle borderwidth="0px" />
                        </asp:templatefield>
                    </columns>
                    <pagersettings firstpagetext="Trang đầu" lastpagetext="Trang cuối" mode="NumericFirstLast"
                        nextpagetext="Trang tiếp" previouspagetext="Trang trước" />
                    <rowstyle borderwidth="0px" />
                </asp:gridview>
                &nbsp;
                <asp:label id="lblQuery" runat="server" visible="False"></asp:label>
            </td>
        </tr>
    </table>
</asp:content>

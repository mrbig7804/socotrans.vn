<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucLastestArticleByCategory.ascx.cs"
    Inherits="ucLastestArticleByCategory" %>
<%@ Register Src="ucPreviousArticles.ascx" TagName="ucPreviousArticles" TagPrefix="uc2" %>
<asp:DataList ID="dlArticles" runat="server" Width="100%">
    <ItemTemplate>
        <table width="100%">
            <tr>
                <td>
                    <div class="imageLink">
                        <a href='ShowArticle.aspx?ID=<%# Eval("ArticleID") %>'>
                            <asp:Image ID="Image1" hspace="5" AlternateText='<%# Eval("Title","{0}") %>' runat="server" ImageUrl='<%# Eval("PictureUrl") %>' OnDataBinding="Image1_DataBinding1"/>
                        </a>
                    </div>
                    <div class="titleLink">
                        <a href='ShowArticle.aspx?ID=<%# Eval("ArticleID") %>'><%# Eval("Title") %></a>
                    </div>
                    <div class="abstractNews">
                        <asp:Label ID="AbstractLabel" runat="server" Text='<%# SliptString((string)Eval("Abstract")) %>'></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="border-top: 1px solid #e0dede; margin: 5px 0; padding-top: 3px; font-weight: bold; font-style: italic; color: #333333">Các tin khác</div>
                    <div class="news_other">
                        <uc2:ucPreviousArticles ID="UcPreviousArticles1" PreviousArticleID='<%# Eval("ArticleID") %>'
                            MaxRow="100" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListArticlesBySuperCategory.ascx.cs" Inherits="ucListArticlesBySuperCategory" %>
<%@ Register Src="ucPreviousArticles.ascx" TagName="ucPreviousArticles" TagPrefix="uc2" %>
<asp:DataList ID="dlArticles" runat="server" Width="100%">
    <ItemTemplate>
        <div class="superCategoryTitle">
            <img alt="" height="1" src="images/spacer.gif" width="15" /><a href='GetRSS.aspx?CategoryID=<%# Eval("CategoryID") %>'><img alt="" src="images/rss.gif" /></a>
            <a href='ShowCategory.aspx?ID=<%# Eval("CategoryID") %>'>
                <%# Eval("Category.Title") %>
            </a>
        </div>
        <div style="background: transparent url(images/dot_horizontal.gif) repeat-x scroll left top;
            -moz-background-clip: -moz-initial; -moz-background-origin: -moz-initial; -moz-background-inline-policy: -moz-initial;
            height: 1px; margin-top:-2px;">
        </div>        
        <table width="100%">
            <tr>
             <td>
                   <a href='ShowArticle.aspx?ID=<%# Eval("ArticleID") %>'>
                        <asp:Image ID="Image1" hspace="5" align="left"   AlternateText='<%# Eval("Title","{0}") %>' Width="100px" runat="server" ImageUrl='<%# Eval("PictureUrl") %>' OnDataBinding="Image1_DataBinding1"  BorderColor="#aaaaaa" BorderStyle="Ridge" BorderWidth="1px" />
                    </a>
                    <a class="titleLink" href='ShowArticle.aspx?ID=<%# Eval("ArticleID") %>'>
                        <%# Eval("Title") %>
                    </a>
                    <br />
                    <asp:Label ID="AbstractLabel" runat="server" Text='<%# SliptString((string)Eval("Abstract")) %>'></asp:Label>
                </td>
            </tr>       
            <tr>
                <td>
                    <uc2:ucPreviousArticles ID="UcPreviousArticles1" PreviousArticleID='<%# Eval("ArticleID") %>' MaxRow="2"  runat="server" />
                </td>
            </tr>
        </table>         
    </ItemTemplate>
</asp:DataList>
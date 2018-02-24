<%@ Page Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true"
    CodeFile="ShowSuperCategory.aspx.cs" Inherits="ShowSuperCategory" %>

<%@ Register Src="ucListArticlesBySuperCategory.ascx" TagName="ucListArticlesBySuperCategory"
    TagPrefix="uc3" %>

<%@ Register Src="ucListArticles.ascx" TagName="ucListArticles" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <div class="wrapper_leftmain">
        <div style="border-bottom: 2px solid #bfbfbf; padding: 0 10px; color: #a4080f; font-size: 18px;
            font-style: italic; font-weight: bold; line-height: 30px">
            <asp:Label runat="server" ID="lblNavigate" />
        </div>
        <div class="wrapper_content">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <uc3:ucListArticlesBySuperCategory ID="UcListArticlesBySuperCategory1" runat="server"
                            AbstractLength="500" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

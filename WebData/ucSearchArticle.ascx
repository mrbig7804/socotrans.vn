<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearchArticle.ascx.cs"
    Inherits="ucSearchArticle" %>
<asp:panel ID="Panel1" runat="server" DefaultButton="ImageButton1" Width="100%">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="100%">
                <input type="text" runat="server" onfocus="this.className='searchBox_Active';if (this.value=='Nhập từ khóa để tìm kiếm'){ this.value=''; }"
                    onblur="if (this.value==''){ this.value='Nhập từ khóa để tìm kiếm';this.className='searchBox';}"
                    id="txtSearch" class="searchBox" value="Nhập từ khóa để tìm kiếm" title="Tìm kiếm"
                    onkeyup="initTyper(this);" /></td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" tooltip=""  alternatetext="" ImageUrl="images/search_button.gif"
                    OnClick="ImageButton1_Click" /></td>
        </tr>
    </table>
</asp:panel>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearchProducts.ascx.cs" Inherits="ucSearchProducts" %>

<asp:Panel runat="server" ID="pnlSerachProduct" DefaultButton="btnSearch" CssClass="frm-search">
    <div>
        <input type="text" runat="server" id="txtKey" onfocus="this.className='searchBoxAtv';if (this.value!=''){ this.value=''; }"
            onblur="if (this.value==''){ this.value='Nhập từ khóa';this.className='searchBox';}" onkeyup="initTyper(this);"
            class="searchBox" value="Nhập từ khóa" />
    </div>
    <div>
        <asp:LinkButton runat="server" ID="btnSearch" ToolTip="Search" Text="Search" onclick="btnSearch_Click" CssClass="searchBtn" />
    </div>
</asp:Panel>
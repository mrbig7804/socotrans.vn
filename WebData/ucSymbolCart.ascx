<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSymbolCart.ascx.cs" Inherits="ucSymbolCart" %>

<%@ Register Src="ucSymbolShowCart.ascx" TagName="ucSymbolShowCart" TagPrefix="uc1" %>


<a class="symbolCart" data-toggle="collapse"  href="#symbolShowCart">
    <asp:Label runat="server" ID="lblTotalCard" CssClass="num" Visible="false" />
    <span class="word">Giỏ hàng</span>
</a>

<div class="collapse symbolShowCart" id="symbolShowCart">
    <uc1:ucSymbolShowCart runat="server" ID="ucSymbolShowCart1" />
</div>

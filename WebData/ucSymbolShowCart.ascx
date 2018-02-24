<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSymbolShowCart.ascx.cs" Inherits="ucSymbolShowCart" %>

<asp:Panel ID="pnlShowcart" runat="server" Visible="false">
    <span class="headTtl">Giỏ hàng của bạn</span>
    <asp:Repeater runat="server" ID="rptCart" OnItemDataBound="rptCart_ItemDataBound" OnItemCommand="rptCart_ItemCommand">
        <HeaderTemplate><ul></HeaderTemplate>
        <FooterTemplate></ul></FooterTemplate>
        <ItemTemplate>
            <li>
                <asp:HiddenField runat="server" ID="hdfCartID" Value='<%# Eval("ID") %>' Visible="false" />
                <span class="image">
                    <img src='<%# Regex.Replace(Eval("SmallPictureUrl").ToString(), "~/", "/")%>' alt='<%# Eval("Title") %>' />
                </span>
                <h3 class="title">
                    <asp:HyperLink runat="server" ID="hplProduct" ToolTip='<%# Eval("Title") %>'><%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 45) %></asp:HyperLink>
                </h3>
                <span class="price">
                    (<%# Eval("Quantity")%>&nbsp;x
                    <%# Zensoft.Website.Configuration.Helpers.PriceFormat(int.Parse(Eval("UnitPrice").ToString())) %>&nbsp;=
                    <%# Zensoft.Website.Configuration.Helpers.PriceFormat(int.Parse(Eval("TotalItem").ToString())) %>)
                </span>
                <span class="qty">
                    <b>Số lượng:</b>
                    <asp:DropDownList runat="server" ID="ddlQuantity" >
                        <asp:ListItem Value="1" Text="1" />
                        <asp:ListItem Value="2" Text="2" />
                        <asp:ListItem Value="3" Text="3" />
                        <asp:ListItem Value="4" Text="4" />
                        <asp:ListItem Value="5" Text="5" />
                        <asp:ListItem Value="6" Text="6" />
                        <asp:ListItem Value="7" Text="7" />
                        <asp:ListItem Value="8" Text="8" />
                        <asp:ListItem Value="9" Text="9" />
                        <asp:ListItem Value="10" Text="10" />
                        <asp:ListItem Value="11" Text="11" />
                        <asp:ListItem Value="12" Text="12" />
                        <asp:ListItem Value="13" Text="13" />
                        <asp:ListItem Value="14" Text="14" />
                        <asp:ListItem Value="15" Text="15" />
                        <asp:ListItem Value="16" Text="16" />
                        <asp:ListItem Value="17" Text="17" />
                        <asp:ListItem Value="18" Text="18" />
                        <asp:ListItem Value="19" Text="19" />
                        <asp:ListItem Value="20" Text="20" />
                    </asp:DropDownList>
                </span>
                <span class="del">
                    <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="/images/blue_delete_icon.png" AlternateText="Delete" ToolTip="Xóa sản phẩm này" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('Bạn thực sự muốn xóa sản phẩm này trong giỏ hàng?') == false) return false;" ></asp:ImageButton>
                </span>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <span class="amountCart">Tổng đơn hàng: <b><asp:Label runat="server" ID="lblAmount" /></b></span>
    <span class="actCart">
        <asp:LinkButton runat="server" ID="lbtnUpdateCart" Text="Cập nhật giỏ hàng" CssClass="linkUdt" OnClick="lbtnUpdateCart_Click" />
        <a href="/thanh-toan-don-hang" class="liquidate">Thanh toán</a>
    </span>
</asp:Panel>

<asp:Panel ID="pnlMss" runat="server" Visible="false">
    <span class="castMss">Chưa có sản phẩm nào trong giỏ hàng</span>
</asp:Panel>

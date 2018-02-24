<%@ Page Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="MyOrder.aspx.cs" Inherits="MyOrder" Title="Đơn hàng" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphHomePage" Runat="Server">
   <div class="headerText">Đơn hàng</div>
   <p></p>
   Danh sách các đơn hàng của bạn
   <p></p>
   <asp:DataList Width="100%" runat="server" ID="dlstOrders">
      <ItemTemplate>
         <div ><b>Đơn hàng #<%# Eval("OrderID") %></b> - <%# Eval("AddedDate", "{0:dd/MM/yyyy hh:mm tt}")%></div>
         <br />
         <img src="Images/ArrowR4.gif" border="0" alt="" /> <u>Tổng tiền:</u> <%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("Total"))) %> VNĐ<br />
         <img src="Images/ArrowR4.gif" border="0" alt="" /> <u>Trạng thái:</u> <%# Eval("OrderStatusTitle")%> 
         &nbsp;&nbsp;&nbsp;
         <asp:HyperLink runat="server" ID="lnkPay" Font-Bold="true" Text="Thông báo đã thanh toán"
            NavigateUrl=''
            Visible = '<%# ((int)Eval("StatusID")) == -1 %>' />
         <p></p>         
         <b>Chi tiết</b><br />
         <asp:Repeater runat="server" ID="repOrderItems" DataSource='<%# Eval("OrderItems") %>'>
            <ItemTemplate>
               • <%# Eval("Title") %> - <%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice"))) %> VNĐ &nbsp;&nbsp;<small>(số lượng = <%# Eval("Quantity") %>)</small>
               <br />
            </ItemTemplate>
         </asp:Repeater>
      </ItemTemplate>
      <SeparatorTemplate>
        <div class="dot" style="margin-top:10px;  margin-bottom:10px;"></div>
      </SeparatorTemplate>
   </asp:DataList>
</asp:Content>


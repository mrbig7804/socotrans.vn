<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSpecialProduct.ascx.cs" Inherits="adm_ucSpecialProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:CheckBox runat="server" ID="ckbSpecial" CssClass="chk" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<b>Từ ngày:</b> <asp:TextBox ID="txtReleaseDate" runat="server" CssClass="txt txt-datetime" Width="15%" />&nbsp;&nbsp;
<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy HH:mm" TargetControlID="txtReleaseDate" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<b>Đến ngày:</b> <asp:TextBox ID="txtExpireDate" runat="server" CssClass="txt txt-datetime"  Width="15%" />&nbsp;&nbsp;
<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy HH:mm" TargetControlID="txtExpireDate" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:CheckBox runat="server" ID="ckbListed" Checked="true" Text="Hoạt động" CssClass="chkbox" />


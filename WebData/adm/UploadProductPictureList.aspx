<%@ page language="C#" autoeventwireup="true" codefile="UploadProductPictureList.aspx.cs"
    inherits="adm_UploadProductPictureList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
        <div id="productPictureList">
            <asp:objectdatasource id="objProductImages" runat="server" deletemethod="Delete"
                selectmethod="GetProductImagesByProductID" typename="Zensoft.Website.BusinessLayer.BusinessFacade.ProductImagesBF">
                <deleteparameters>
                    <asp:parameter name="productImageID" type="Int32" />
                </deleteparameters>
                <selectparameters>
                    <asp:querystringparameter name="productID" querystringfield="ProductID" type="Int32" />
                </selectparameters>
            </asp:objectdatasource>
            <asp:datalist id="DataList1" runat="server" datasourceid="objProductImages" repeatdirection="Horizontal"
                datakeyfield="ProductImageID" onitemcommand="DataList1_ItemCommand">
                <itemtemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 70px; height: 60px" valign="bottom" align="center">
                                <a href='<%# Eval("FullImage").ToString().Replace("~","") %>' onclick="return  parent.hs.expand(this, {captionId: 'caption1'})"
                                    target="_blank">
                                    <asp:image width="70px" id="Image1" runat="server" imageurl='<%# Eval("SmallImage") %>' />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center">
                                <asp:imagebutton id="ImageButton1" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa ảnh minh họa này?') == false) return false;"
                                    runat="server" commandargument='<%# Eval("ProductImageID") %>' commandname="DeleteImage"
                                    imageurl="Images/Delete.gif" />
                            </td>
                        </tr>
                    </table>
                </itemtemplate>
            </asp:datalist></div>
        <asp:repeater id="rptAttachedFiles" runat="server" onitemcommand="rptAttachedFiles_ItemCommand">
            <headertemplate>
                <table border="0">
                    <tr>
            </headertemplate>
            <itemtemplate>
                <td width="70px">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 70px; height: 60px" valign="bottom" align="center">
                                <a href='<%# GetFullUrl(FileUrl + ((DictionaryEntry)Container.DataItem).Key) %>'
                                    onclick="return  parent.hs.expand(this, {captionId: 'caption1'})" target="_blank">
                                    <asp:image id="Image2" runat="server" imageurl='<%# FileUrl + ((DictionaryEntry)Container.DataItem).Key %>'
                                        width="70px" borderwidth="1" bordercolor="ActiveBorder" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center">
                                <asp:imagebutton id="LinkButton1"  imageurl="Images/Delete.gif" runat="server" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa file đính kèm này không?') == false) return false;"
                                    commandname="DeleteAttachedFile" commandargument='<%# FileUrl+ ((DictionaryEntry)Container.DataItem).Key.ToString() %>' />
                            </td>
                        </tr>
                    </table>
                </td>
            </itemtemplate>
            <footertemplate>
                </tr> </table>
            </footertemplate>
        </asp:repeater>
    </form>
</body>
</html>

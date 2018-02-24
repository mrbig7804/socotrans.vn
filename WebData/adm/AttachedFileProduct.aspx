<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttachedFileProduct.aspx.cs" Inherits="adm_AttachedFileProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/adm/AdminStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="/Library/lightbox/jquery.lightbox-0.5.js"></script>
    <link rel="stylesheet" type="text/css" href="/Library/lightbox/jquery.lightbox-0.5.css" media="screen" />
</head>
<body>
    <script type="text/javascript">
        $(function () {
            $('a.lightbox').lightBox(); // Select all links with lightbox class
        });
    </script>

    <form runat="server">
        <h3 class="iaA1">Có tổng số: <asp:label id="lblTotalFile" runat="server" /></h3>

        <asp:repeater id="rptAttachedFiles" runat="server" onitemcreated="rptAttachedFiles_ItemCreated"
            onitemdatabound="rptAttachedFiles_ItemDataBound" onitemcommand="rptAttachedFiles_ItemCommand">
            <headertemplate><ul class="iaA2"></headertemplate>
            <footertemplate></ul></footertemplate>
            <itemtemplate>
                <li>
                    <div class="image">
                        <a href='<%# GetFullUrl(FileUrl + ((DictionaryEntry)Container.DataItem).Key) %>' class="lightbox">
                            <asp:image id="imgPreview" runat="server" imageurl='<%# FileUrl + ((DictionaryEntry)Container.DataItem).Key %>' />
                        </a>
                        <asp:image id="imgUnknowFile" runat="server" imageurl="~/adm/images_adm/fileCommon.png" />
                    </div>
                    <div class="info">
                        <span>
                            <asp:label id="lblFileName" runat="server" text='<%# GetFullUrl(FileUrl + ((DictionaryEntry)Container.DataItem).Key) %>' />
                        </span>
                        <span>
                            <b>Dung lương: </b><%# string.Format("{0:###,###}", long.Parse(((DictionaryEntry)Container.DataItem).Value.ToString()))%> byte
                        </span>
                        <span>
                            <asp:linkbutton id="LinkButton2" runat="server" Text="Xóa" CssClass="btn btn-red"
                                onclientclick="if (confirm('Bạn có chắc chắn muốn xóa file đính kèm này không?') == false) return false;"
                                commandname="DeleteAttachedFile" commandargument='<%# FileUrl+ ((DictionaryEntry)Container.DataItem).Key.ToString() %>' />
                        </span>
                    </div>
                </li>
            </itemtemplate>
        </asp:repeater>
    </form>
</body>
</html>

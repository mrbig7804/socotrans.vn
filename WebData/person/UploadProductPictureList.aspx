<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadProductPictureList.aspx.cs" Inherits="person_UploadProductPictureList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css" media="all">
        .list_imgProductPreview {
            margin-top: 6px;
        }

            .list_imgProductPreview .item_imgProductPreview {
                display: block;
                float: left;
                width: 100px;
                overflow: hidden;
                margin: 8px 4px 2px;
                text-align: center;
            }

                .list_imgProductPreview .item_imgProductPreview img {
                    width: 84px;
                    height: 80px;
                    padding: 2px;
                    border: 1px solid #ccc;
                    background-color: #fff;
                    border-radius: 4px;
                    -webkit-border-radius: 4px;
                    -moz-border-radius: 4px;
                }

                .list_imgProductPreview .item_imgProductPreview a {
                    background-color: #1e90ff;
                    padding: 4px 2px;
                    color: #fff;
                    font-weight: bold;
                    cursor: pointer;
                    line-height: 28px;
                    border-radius: 3px;
                    -moz-border-radius: 3px;
                    -webkit-border-radius: 3px;
                    font-size: 11px;
                }

                    .list_imgProductPreview .item_imgProductPreview a:hover {
                        background-color: #0078ED;
                        text-decoration: none;
                    }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:repeater id="rptAttachedFiles" runat="server" onitemcommand="rptAttachedFiles_ItemCommand">
            <headertemplate><div class="list_imgProductPreview"></headertemplate>
            <footertemplate><span style="display: block; clear: both"></div></footertemplate>
            <itemtemplate>
                <span class="item_imgProductPreview">
                    <%--<a href='<%# GetFullUrl(FileUrl + ((DictionaryEntry)Container.DataItem).Key) %>' onclick="return  parent.hs.expand(this, {captionId: 'caption1'})" target="_blank">--%>
                    <img src='<%# (FileUrl + ((DictionaryEntry)Container.DataItem).Key).ToString().Replace("~/", "/") %>' alt="Image" />
                    <%--</a>--%>
                    <asp:LinkButton id="lbtnDelete" runat="server" Text="Xóa" OnClientClick="if (confirm('Bạn có chắc chắn muốn xóa ảnh này?') == false) return false;"
                        commandname="DeleteAttachedFile" commandargument='<%# FileUrl+ ((DictionaryEntry)Container.DataItem).Key.ToString() %>' />
                </span>
            </itemtemplate>
        </asp:repeater>
    </form>
</body>
</html>

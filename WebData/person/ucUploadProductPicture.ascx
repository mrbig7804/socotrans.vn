<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUploadProductPicture.ascx.cs" Inherits="person_ucUploadProductPicture" %>

<iframe allowtransparency="" frameborder="0" marginheight="0" marginwidth="0" src='/person/UploadProductPreview.aspx?ProductID=<%= this.ProductID %>'
    style="width: 76%; height: 65px; border: 0;" scrolling="no"></iframe>
<iframe allowtransparency="" id="productPictureList" name="productPictureList" frameborder="0" marginheight="0" marginwidth="0" src='/person/UploadProductPictureList.aspx?ProductID=<%= this.ProductID %>'
    style="width: 76%; min-height: 255px; border: 0;"></iframe>
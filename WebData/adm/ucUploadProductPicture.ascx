<%@ control language="C#" autoeventwireup="true" codefile="ucUploadProductPicture.ascx.cs"
    inherits="adm_ucUploadProductPicture" %>
<iframe allowtransparency="" frameborder="0" marginheight="0" marginwidth="0" src='../adm/UploadProductPreview.aspx?ProductID=<%# this.ProductID %>'
    style="width: 100%; height: 55px; border: 0;"></iframe>
<iframe allowtransparency="" id="productPictureList" frameborder="0" marginheight="0"
    marginwidth="0" src='../adm/UploadProductPictureList.aspx?ProductID=<%# this.ProductID %>'
    style="width: 100%; height: 100px; border: 0;"></iframe>

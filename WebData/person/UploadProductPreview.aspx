<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadProductPreview.aspx.cs" Inherits="person_UploadProductPreview" %>

<%@ register assembly="FUA" namespace="Subgurim.Controles" tagprefix="cc2" %>
<%@ register assembly="Utilities" namespace="WebControls" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript" language="javascript">
        function startCallback() {
            document.getElementById("processDiv").style.display = "inline"; // the progress div
            return true;
        }

        function completeCallback(response) {
            document.getElementById("processDiv").style.display = "none"; // hide progresss div
            var pictureList = parent.document.getElementById("productPictureList");
            if (pictureList != null) {
                parent.frames.productPictureList.location.reload();
            }

            if (response == "error") {
                window.alert("Mỗi tin bài không được nhiều hơn 8 ảnh.");
            }
        }

        AIM = {
            frame: function (c) {

                var n = 'f' + Math.floor(Math.random() * 99999);
                var d = document.createElement('DIV');
                d.innerHTML = '<iframe style="display:none" src="about:blank" id="' + n + '" name="' + n + '" onload="AIM.loaded(\'' + n + '\')"></iframe>';
                document.body.appendChild(d);

                var i = document.getElementById(n);
                if (c && typeof (c.onComplete) == 'function') {
                    i.onComplete = c.onComplete;
                }

                return n;
            },

            form: function (f, name) {
                f.setAttribute('target', name);
            },

            submit: function (f, c) {
                AIM.form(f, AIM.frame(c));
                if (c && typeof (c.onStart) == 'function') {
                    return c.onStart();
                } else {
                    return true;
                }
            },

            loaded: function (id) {
                var i = document.getElementById(id);
                if (i.contentDocument) {
                    var d = i.contentDocument;
                } else if (i.contentWindow) {
                    var d = i.contentWindow.document;
                } else {
                    var d = window.frames[id].document;
                }
                if (d.location.href == "about:blank") {
                    return;
                }

                if (typeof (i.onComplete) == 'function') {
                    i.onComplete(d.body.innerHTML);
                }
            }

        }
        </script>

        <asp:fileupload id="FileUpload1" runat="server" />
        <cc1:uploadbutton id="UploadButton2" runat="server" relatedfileuploadcontrolid="FileUpload1"
            onuploadclick="UploadButton1_UploadClick" text="Đăng ảnh" onstartscript="startCallback"
            oncompletescript="completeCallback" />
            
        <div id="processDiv" style="display: none">
            <img alt="Đang cập nhât..." src="../Images/indicator.gif" />
        </div>

        <div style="margin-top: 12px; background-color: #f0f0f0; padding: 5px;
                    box-sizing: border-box; -moz-box-sizing: border-box; -webkit-box-sizing: border-box;
                    border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px">
            <b>Lưu ý <span class="mss_err">(*)</span></b>: <i>bạn chỉ được đăng không quá 8 ảnh cho mỗi tin</i>
        </div>
    </form>
</body>
</html>

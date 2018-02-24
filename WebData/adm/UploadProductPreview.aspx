<%@ page language="C#" autoeventwireup="true" codefile="UploadProductPreview.aspx.cs"
    inherits="adm_UploadProductPreview" %>

<%@ register assembly="FUA" namespace="Subgurim.Controles" tagprefix="cc2" %>
<%@ register assembly="Utilities" namespace="WebControls" tagprefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body style="text-align: left;">
    <form id="Form1" runat="server">

        <script type="text/javascript" language="javascript">
        function startCallback() 
        {
            document.getElementById("processDiv").style.display = "inline";// the progress div
            return true;
        }

        function completeCallback(response) 
        {
           document.getElementById("processDiv").style.display = "none";// hide progresss div
           var pictureList = parent.document.getElementById("productPictureList");
           if (pictureList!=null)
           {
                parent.frames.productPictureList.location.reload();

           }

            if (response == "error")
            {
                window.alert("Mỗi mặt hàng không được nhiều hơn 6 ảnh minh họa");
            }
        }
        
    AIM = {
    frame : function(c) {

        var n = 'f' + Math.floor(Math.random() * 99999);
        var d = document.createElement('DIV');
        d.innerHTML = '<iframe style="display:none" src="about:blank" id="'+n+'" name="'+n+'" onload="AIM.loaded(\''+n+'\')"></iframe>';
        document.body.appendChild(d);

        var i = document.getElementById(n);
        if (c && typeof(c.onComplete) == 'function') {
            i.onComplete = c.onComplete;
        }

        return n;
    },

    form : function(f, name) {
        f.setAttribute('target', name);
    },

    submit : function(f, c) {
        AIM.form(f, AIM.frame(c));
        if (c && typeof(c.onStart) == 'function') {
            return c.onStart();
        } else {
            return true;
        }
    },

    loaded : function(id) {
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

        if (typeof(i.onComplete) == 'function') {
            i.onComplete(d.body.innerHTML);
        }
    }

}
        </script>

        <asp:fileupload id="FileUpload1" runat="server" cssclass="inputCommand" />
        <cc1:uploadbutton id="UploadButton2" runat="server" relatedfileuploadcontrolid="FileUpload1"
            onuploadclick="UploadButton1_UploadClick" text="Upload" onstartscript="startCallback"
            oncompletescript="completeCallback" cssclass="inputCommand" />
            
        <div id="processDiv" style="display: none; color: #8B4513; font-size: 10pt; font-family: Arial;">
            <img alt="Đang cập nhât..." src="Images/indicator.gif" />Đang cập nhât...
        </div>
    </form>
</body>
</html>

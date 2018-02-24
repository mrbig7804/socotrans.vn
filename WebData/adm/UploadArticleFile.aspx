<%@ page language="C#" autoeventwireup="true" codefile="UploadArticleFile.aspx.cs"
    inherits="adm_UploadArticleFile" %>

<%@ register assembly="Utilities" namespace="WebControls" tagprefix="cc1" %>

<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="AdminStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
        <script type="text/javascript">
            function startCallback() 
            {
                //document.getElementById("processDiv").style.display = "block";// the progress div
                return true;
            }

            function completeCallback(response) 
            {
               //document.getElementById("processDiv").style.display = "none";// hide progresss div
           
               document.getElementById("fileListDiv").innerHTML =  response;// update the file list

               var pictureList = parent.document.getElementById("articlePictureList");
               if (pictureList!=null)
               {
                    pictureList.setAttribute("src",pictureList.getAttribute("src"));
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

                submit: function(f, c) {
                    AIM.form(f, AIM.frame(c));
                    if (c && typeof(c.onStart) == 'function') {
                        return c.onStart();
                    } else {
                        return true;
                    }
                },

                loaded: function(id) {
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

        <div class="iuA1">
            <asp:fileupload id="FileUpload1" runat="server" cssclass="txt txt-file" />&nbsp;
            <cc1:uploadbutton id="UploadButton2" runat="server" text="Upload" cssclass="btn btn-red" relatedfileuploadcontrolid="FileUpload1"
                onuploadclick="UploadButton1_UploadClick" onstartscript="startCallback" oncompletescript="completeCallback" />
        </div>
        <div class="iuA2" id="fileListDiv">
        </div>
    </form>
</body>
</html>

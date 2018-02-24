<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="admin_UploadFile" %>
<%@ Register Assembly="Utilities" Namespace="WebControls" TagPrefix="cc1" %>
<html>
<head runat="server">
    <link href="../adm/AdminStyle.css" rel="stylesheet" type="text/css" />
    <style>
.inputCommand
{
	background: #3a312c;
	border: 1px solid #aaaaaa;
	color: #ffffff;	
}
</style>
</head>

<body style="background-color: #231e1c;	font-family:arial,sans-serif;font-size:12;color: #ffffff;margin: 0 0 0 0;">
<form runat="server">

    <script language="javascript">
        function startCallback() 
        {
            document.getElementById("processDiv").style.display = "block";// the progress div
            return true;
        }

        function completeCallback(response) 
        {
           document.getElementById("processDiv").style.display = "none";// hide progresss div
           document.getElementById("fileListDiv").innerHTML = document.getElementById("fileListDiv").innerHTML  + response+ "<BR>";// update the file list
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
    
    <fieldset title="Uploaded">
        <legend style=" color:#ffffff;">Upload a file</legend>
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="inputCommand"  />
            <cc1:UploadButton ID="UploadButton2" runat="server" RelatedFileUploadControlId="FileUpload1" OnUploadClick="UploadButton1_UploadClick" Text="Upload" OnStartScript="startCallback" OnCompleteScript="completeCallback" CssClass="inputCommand" />
        </div>
        <div id="processDiv" style="display:none; color: lightblue; font-family: Arial;" >
            <img src="Images/indicator.gif" />Đang cập nhât...
        </div>
    </fieldset>
    
    <fieldset title="Uploaded">
        <legend style=" color:#ffffff;">Những file vừa được đưa lên server</legend>
        <div id="fileListDiv" >
        </div>
    </fieldset>
    
        </form>
    </body>
</html>
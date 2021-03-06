using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    /// <summary>
    /// This is an upload button. This button can help you on file upload in somewhat gmail manner.
    /// </summary>
    [ToolboxData("<{0}:UploadButton runat=server></{0}:UploadButton>")]
    [DefaultEvent("UploadClick")]
    public class UploadButton : Button
    {
        /// <summary>
        /// Gets or sets the id of the asp file upload control
        /// </summary>
        public string RelatedFileUploadControlId
        {
            set
            {
                ViewState["RelatedFileUploadControlId"] = value;
            }
            get
            {
                return ViewState["RelatedFileUploadControlId"] == null ? null : (string)ViewState["RelatedFileUploadControlId"];
            }
        }

        /// <summary>
        /// Gets or sets the name of the javascript which will be executed on startup of file upload processing
        /// </summary>
        public string OnStartScript
        {
            set
            {
                ViewState["OnStartScript"] = value;
            }
            get
            {
                return ViewState["OnStartScript"] == null ? null : (string)ViewState["OnStartScript"];
            }
        }

        /// <summary>
        /// Gets or sets the name of the javascript which will be executed on the completion of file upload
        /// </summary>
        public string OnCompleteScript
        {
            set
            {
                ViewState["OnCompleteScript"] = value;
            }
            get
            {
                return ViewState["OnCompleteScript"] == null ? null : (string)ViewState["OnCompleteScript"];
            }
        }

        private static readonly object EventUploadClickKey = new object();
        public delegate string UploadButtonEventHandler(object sender, UploadButtonEventArgs e);
        /// <summary>
        /// Adds or reoves the click event
        /// </summary>
        public event UploadButtonEventHandler UploadClick
        {
            add
            {
                Events.AddHandler(EventUploadClickKey, value);
            }
            remove
            {
                Events.RemoveHandler(EventUploadClickKey, value);
            }
        }

        /// <summary>
        /// Basic registration of events
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.Page.LoadComplete += new EventHandler(Page_LoadComplete);
            base.OnInit(e);
            //this.Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "ScriptBlock", this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Zensoft.Website.Utilities.JScripts.AIMScript.js"));
            string onsubmitstatement = "return AIM.submit(document.forms[0], {'onStart' : " + OnStartScript + ", 'onComplete' : " + OnCompleteScript + "})";
            this.Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "OnSubmitScript", onsubmitstatement);
        }

        /// <summary>
        /// After completing page load, call the event handler on page to perform operations on uploaded file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (this.Parent.FindControl(RelatedFileUploadControlId) != null)
                {
                    FileUpload fu = this.Parent.FindControl(RelatedFileUploadControlId) as FileUpload;
                    UploadButtonEventArgs args = new UploadButtonEventArgs(fu);
                    UploadButtonEventHandler handler = (UploadButtonEventHandler)Events[EventUploadClickKey];
                    if (handler != null)
                    {
                        try
                        {
                            WriteTextToClient(handler(this, args));
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                            // do nothing
                        }
                        catch //(Exception ex)
                        {
                            WriteTextToClient("Đã có lỗi trong quá trình xử lý.");// + ex.Message);
                        }
                    }
                    else
                    {
                        WriteTextToClient("Handler not registered");
                    }
                }
            }
        }

        /// <summary>
        /// To output text to client browser
        /// </summary>
        /// <param name="text"></param>
        private void WriteTextToClient(string text)
        {
            Page.Response.Clear();
            Page.Response.Write(text);
            Page.Response.Flush();
            Page.Response.End();
        }

    }

    /// <summary>
    /// Class event argument. This class can hold a file upload control
    /// </summary>
    public class UploadButtonEventArgs : EventArgs
    {
        public FileUpload FileUploadControl;
        public UploadButtonEventArgs(FileUpload f)
        {
            FileUploadControl = f;
        }
    }

}

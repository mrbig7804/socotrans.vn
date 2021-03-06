using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.UI;

    public partial class ucPollPanel : BaseWebPart
    {
        public ucPollPanel()
        {
            this.Title = "Poll Box";
        }

        private int _pollID = -1;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable,
        WebDisplayName("Poll ID"),
        WebDescription("The ID of the poll to show")]
        public int PollID
        {
            get { return _pollID; }
            set { _pollID = value; }
        }

        public bool ShowQuestion
        {
            get { return lblQuestion.Visible; }
            set { lblQuestion.Visible = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.RegisterRequiresControlState(this);
        }

        protected override void LoadControlState(object savedState)
        {
            object[] ctlState = (object[])savedState;
            base.LoadControlState(ctlState[0]);
            this.PollID = (int)ctlState[1];
        }

        protected override object SaveControlState()
        {
            object[] ctlState = new object[2];
            ctlState[0] = base.SaveControlState();
            ctlState[1] = this.PollID;
            return ctlState;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                DoBinding();
        }

        public override void DataBind()
        {
            base.DataBind();

            DoBinding();
        }

        protected void DoBinding()
        {
            panResults.Visible = false;
            panVote.Visible = false;
            int pollID = (this.PollID == -1 ? PollsBF.CurrentPollID: this.PollID);

            if (pollID > -1)
            {
                PollsBF poll = PollsBF.GetPollsBF(pollID);
                if (poll != null)
                {
                    lblQuestion.Text = poll.QuestionText;
                    lblTotalVotes.Text = poll.Votes.ToString();

                    valRequireOption.ValidationGroup += poll.PollID.ToString();

                    btnVote.ValidationGroup = valRequireOption.ValidationGroup;

                    optlOptions.DataSource = poll.PollOptions;
                    optlOptions.DataBind();

                    rptOptions.DataSource = poll.PollOptions;
                    rptOptions.DataBind();

                    // Nếu người dùng đã bình chọn hoặc bình chọn này đã được lưu trữ thì thể hiện kết quả
                    if (poll.IsArchived || GetUserVote(pollID) > 0)
                        panResults.Visible = true;
                    else
                        panVote.Visible = true;
                }
            }
        }

        protected void btnVote_Click(object sender, EventArgs e)
        {
            int pollID = (this.PollID == -1 ? PollsBF.CurrentPollID : this.PollID);

            // Kiểm tra xem người dùng đã bình chọn chưa
            int userVote = GetUserVote(pollID);
            if (userVote == 0)
            {
                // post the vote and then create a cookie to remember this user's vote
                userVote = Convert.ToInt32(optlOptions.SelectedValue);

                PollOptionsBF.Vote(Convert.ToInt32(optlOptions.SelectedValue));

                // hide the panel with the radio buttons, and show the results
                DoBinding();
                panVote.Visible = false;
                panResults.Visible = true;

                DateTime expireDate = DateTime.Now.AddDays(7);//Globals.Settings.Polls.VotingLockInterval);

                string key = "Vote_Poll" + pollID.ToString();

                // save the result to the cookie
                //if (Globals.Settings.Polls.VotingLockByCookie)
                //{


                HttpCookie cookie = new HttpCookie(key, userVote.ToString());
                cookie.Expires = expireDate;
                this.Response.Cookies.Add(cookie);

                //}

                // lưu bình trọn vào cache trong trường hợp cookie bị vộ hiệu

                //if (Globals.Settings.Polls.VotingLockByIP)
                //{
                    Cache.Insert(
                       this.Request.UserHostAddress.ToString() + "_" + key,
                       userVote);
                //}
            }
        }

        protected int GetUserVote(int pollID)
        {
            string key = "Vote_Poll" + pollID.ToString();
            string key2 = this.Request.UserHostAddress.ToString() + "_" + key;

            // check if the vote is in the cache
            if (Cache[key2] != null) //&& Globals.Settings.Polls.VotingLockByIP 
                return (int)Cache[key2];

            // if the vote is not in cache, check if there's a client-side cookie
            //if (Globals.Settings.Polls.VotingLockByCookie)
            //{
                HttpCookie cookie = this.Request.Cookies[key];
                if (cookie != null)
                    return int.Parse(cookie.Value);
            //}

            return 0;
        }

        protected int GetFixedPercentage(object val)
        {
            int percentage = Convert.ToInt32(val);
            if (percentage == 100)
                percentage = 98;
            return percentage;
        }
    }

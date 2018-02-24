<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucNewsTab.ascx.cs" Inherits="ucNewsTab" %>
<%--<%@ Register Src="ucNewsListArticleTab.ascx" TagName="ucNewsListArticleTab" TagPrefix="uc1" %>--%>
<div id="tabContaier">
    <ul>
        <li >
<%--           <div style="position: absolute; background-image:url(/images/tabblue_left.jpg); background-repeat:no-repeat; top: 0px; left: 0px; width: 5px;">
            </div>        
--%>            <a class="active"  href="#" ref="#tab1">
            Tin Tức
        </a>
<%--            <div style="position: absolute;  background-image:url(/images/tabblue_right.jpg); background-repeat:no-repeat; top: 0px; right: 0px; width: 5px;">
            </div>
--%>        </li>
        <li><a href="#" ref="#tab2">Khuyến mãi</a></li>
    </ul>
    <!-- //Tab buttons -->
    <div class="tabDetails">
        <div id="tab1" class="tabContents">
            <%--<uc1:ucNewsListArticleTab ID="ucNewsListArticleTab1" CategoryID="11" runat="server" />--%>
        </div>
        <!-- //tab1 -->
        <div id="tab2" class="tabContents">
            <%--<uc1:ucNewsListArticleTab ID="ucNewsListArticleTab2" CategoryID="13" runat="server" />--%>
        </div>
        <!-- //tab2 -->
    </div>
    <!-- //tab Details -->
</div>
<!-- //Tab Container -->
<script type="text/javascript">
    $(document).ready(function () {
        $(".tabContents").hide(); // Hide all tab conten divs by default
        $(".tabContents:first").show(); // Show the first div of tab content by default
        $("#tabContaier ul li a").click(function () { //Fire the click event

            var activeTab = $(this).attr("ref"); // Catch the click link
            $("#tabContaier ul li a").removeClass("active"); // Remove pre-highlighted link
            $(this).addClass("active"); // set clicked link to highlight state
            $(".tabContents").hide(); // hide currently visible tab content div
            $(activeTab).fadeIn(); // show the target tab content div by matching clicked link.
        });
    });
</script>

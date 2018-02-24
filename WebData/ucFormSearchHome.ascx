<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucFormSearchHome.ascx.cs" Inherits="ucFormSearchHome" %>

<%@ Register Src="~/ucSearchProducts.ascx" TagName="ucSearchProducts" TagPrefix="uc1" %>

<script type="text/javascript">
    $(document).ready(function () {
        $(".search_detail").hide(); // Hide all tab conten divs by default
        $(".search_detail:first").show(); // Show the first div of tab content by default
        $("#tabSearch_details li a").click(function () { //Fire the click event
            var activeTab = $(this).attr("ref"); // Catch the click link
            $("#tabSearch_details li a").removeClass("active"); // Remove pre-highlighted link
            $(this).addClass("active"); // set clicked link to highlight state
            $(".search_detail").hide(); // hide currently visible tab content div
            $(activeTab).fadeIn(); // show the target tab content div by matching clicked link.
        });

        $("html:not(:animated),body:not(:animated)").animate({ scrollTop: $('.title_subpage').offset().top }, 800);
    });
</script>

<ul id="tabSearch_details">
    <li>
        <a href="javascript:void(0)" ref="#tabSearch1" class="active">Nhà đất bán</a>
    </li>
    <li>
        <a href="javascript:void(0)" ref="#tabSearch2" >Nhà đất cho thuê</a>
    </li>
</ul>
<div class="search_details">
    <div id="tabSearch1" class="search_detail">
        <uc1:ucSearchProducts runat="server" ID="ucSearchProducts" DepartmentID="80" />
    </div>
    <div id="tabSearch2" class="search_detail">
        <uc1:ucSearchProducts runat="server" ID="ucSearchProducts1" DepartmentID="82" />
    </div>
</div>

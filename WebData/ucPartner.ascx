<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPartner.ascx.cs" Inherits="ucPartner" %>

<script type="text/javascript" src="/Library/jquery.carouFredSel-5.6.1.js"></script>
<script type="text/javascript">
    $(function () {
        $("#foo_partner").carouFredSel({
            auto: {
                pauseOnHover: 'resume'
            },
            direction: "left",
            width: 960,
            height: 92,
            scroll: {
                duration: 1000
            },
        });
    });
</script>
<style type="text/css" media="all">
    #foo_partner {padding-top: 10px}
    
    .list_carousel_partner{-webkit-padding-start: 0px;}
    
    .list_carousel_partner ul{margin: 0; padding: 0; list-style: none; display: block;}
    
    .list_carousel_partner li{float: left; margin: 0 26px; display: block; text-align: center; overflow: hidden}
    
    .list_carousel_partner li img{width: 135px; height: 68px}
</style>

<ul id="foo_partner" class="list_carousel_partner">
    <li><a href="#"><img src="/Attachs/Partner/p1.jpg" /></a></li>
    <li><a href="#"><img src="/Attachs/Partner/p2.jpg" /></a></li>
    <li><a href="#"><img src="/Attachs/Partner/p3.jpg" /></a></li>
    <li><a href="#"><img src="/Attachs/Partner/p4.jpg" /></a></li>
    <li><a href="#"><img src="/Attachs/Partner/p5.jpg" /></a></li>
    <li><a href="#"><img src="/Attachs/Partner/p6.jpg" /></a></li>
</ul>

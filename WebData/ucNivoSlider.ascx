<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucNivoSlider.ascx.cs" Inherits="ucNivoSlider" %>

<link href="/Library/Slider/nivo-slider.css" rel="stylesheet" type="text/css" />
<script src="/Library/Slider/jquery.nivo.slider.pack.js" type="text/javascript"></script>
<link href="/Library/Slider/themes/default/default.css" rel="stylesheet" type="text/css" />

<div class="slider-wrapper theme-default">
    <div id="slider" class="nivoSlider">
        <asp:Repeater runat="server" ID="rptSlider" OnItemDataBound="rptSlider_ItemDataBound">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hplSlider" >
                    <asp:Image runat="server" ImageUrl='<%# Eval("PictureUrl") %>' ToolTip='<%# Eval("title") %>' />
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="htmlcaption" class="nivo-html-caption">
    </div>
</div>

<script type="text/javascript">
    $(window).load(function () {
        $('#slider').nivoSlider({
            effect: 'random', // Specify sets like: 'sliceDown, sliceDownLeft, sliceUp, sliceUpLeft, sliceUpDown, sliceUpDownLeft, fold, fade, random, slideInRight, slideInLeft, boxRandom, boxRain, boxRainReverse, boxRainGrow, boxRainGrowReverse'
            slices: 15, // For slice animations
            boxCols: 8, // For box animations
            boxRows: 4, // For box animations
            animSpeed: 800, // Slide transition speed
            pauseTime: 4000, // How long each slide will show
            startSlide: 0, // Set starting Slide (0 index)
            directionNav: true, // Next & Prev navigation
            directionNavHide: true, // Only show on hover
            controlNav: true, // 1,2,3... navigation
            controlNavThumbs: false, // Use thumbnails for Control Nav
            pauseOnHover: true, // Stop animation while hovering
            manualAdvance: false, // Force manual transitions
            prevText: 'Prev', // Prev directionNav text
            nextText: 'Next', // Next directionNav text
            randomStart: false, // Start on a random slide
            beforeChange: function () { }, // Triggers before a slide transition
            afterChange: function () { }, // Triggers after a slide transition
            slideshowEnd: function () { }, // Triggers after all slides have been shown
            lastSlide: function () { }, // Triggers when last slide is shown
            afterLoad: function () { } // Triggers when slider has loaded
        });
    });
    
</script>

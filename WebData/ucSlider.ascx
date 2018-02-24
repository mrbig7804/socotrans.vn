<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSlider.ascx.cs" Inherits="ucSlider" %>

<div id="slider-carousel" class="carousel slide" data-ride="carousel">
    <asp:Repeater runat="server" ID="rptIndicators">
        <HeaderTemplate><ol class="carousel-indicators"></HeaderTemplate>
        <FooterTemplate></ol></FooterTemplate>
        <ItemTemplate>
            <li data-target="#slider-carousel" data-slide-to='<%# Container.ItemIndex %>' class='<%# (Container.ItemIndex == 0)?"active":"" %>'></li>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater runat="server" ID="rptSlider" OnItemDataBound="rptSlider_ItemDataBound">
        <HeaderTemplate><div class="carousel-inner"></HeaderTemplate>
        <FooterTemplate></div></FooterTemplate>
        <ItemTemplate>
            <div class='item <%# (Container.ItemIndex == 0)?"active":"" %>'>
                <asp:HyperLink runat="server" ID="hplSlider" >
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PictureUrl") %>' ToolTip='<%# Eval("title") %>' />
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <a href="#slider-carousel" class="left control-carousel hidden-xs" data-slide="prev">
        <i class="glyphicon glyphicon-circle-arrow-left"></i>
    </a>
    <a href="#slider-carousel" class="right control-carousel hidden-xs" data-slide="next">
        <i class="glyphicon glyphicon-circle-arrow-right"></i>
    </a>
</div>

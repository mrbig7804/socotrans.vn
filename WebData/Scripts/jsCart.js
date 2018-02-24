

//Demo by Brij Mohan (http://techbrij.com) 
//Qty Validation and Total Calculation in Gridview Shopping Cart with jQuery

$(document).ready(function () {
    $(".txtQty").numeric({ decimal: false, negative: false }, function () { alert("Chỉ được nhập số nguyên"); this.value = ""; this.focus(); });
    $("[id*=dtlCart]input[type=text][id*=txtQty]").keyup(function (e) {
        var price = $(this).closest('tr').find("[id*=lbPrice]").text();
        var quantity = $(e.target).closest('tr').find("input[type=text][id*=txtQty]").val();
        var total = price * parseFloat(quantity);
        $(e.target).closest('tr').find("[id*=lblTotal]").text(parseFloat(price));
        GrossTotal();

    });
});
var gross;
function GrossTotal() {
    gross = 0;
    $("[id*=dtlCart][id*=lblTotal]").each(function (index, item) {
        gross = gross + parseFloat($(item).text());
    });

    $("[id*=dtlCart][id*=lblGrossTotal]").text(gross);
}
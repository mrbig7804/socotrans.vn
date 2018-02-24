function filterElement(elem)
{
    return document.getElementById(elem);
}
//------------------------------------------------------------------------------
function IsAlphabet(Digit) 
{
	return /^[a-zA-Z]$/.test(Digit);
}
//------------------------------------------------
// Function Name : Trim 
// Actions : Remove left&right space.
//------------------------------------------------
function Trim(temp) 
{
    if(temp=='')
        return temp;
        
    temp = temp + '';
    
	return RTrim(LTrim(temp));
}
//------------------------------------------------
// Function Name : LTrim 
// Actions : Remove left string.
//------------------------------------------------
function LTrim(temp) 
{    
    if(temp=='')
        return temp;
    
	return temp.replace(/^\s+/, '');
}

//------------------------------------------------
// Function Name : RTrim 
// Actions : Remove right space.
//------------------------------------------------
function RTrim(temp) 
{
    if(temp=='')
        return temp;
	return temp.replace(/\s+$/, '');
}
//
//------------------------------------------------
// Function Name : FormatCurrency
// Actions : Return Currency Formatted
//------------------------------------------------
function FormatCurrency(num,currencyCode,isReplace,justFormat)
{    
    if (num == null)
        return "";
    var num = num.toString().replace(/\$|\,/g,'');
    if(isNaN(num))
        num = "0";
    var sign = (num == (num = Math.abs(num)));    
    num = Math.floor(num*100+0.50000000001);
    cents = num%100;
    num = Math.floor(num/100).toString();
    if(cents<10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
    {
        switch(Trim(currencyCode.toLowerCase()))
        {
            case 'en-us':
            {
                num = num.substring(0,num.length-(4*i+3))+','+ num.substring(num.length-(4*i+3));
                break;
            }
            case 'vi-vn':
            {                
                num = num.substring(0,num.length-(4*i+3))+ '.' + num.substring(num.length-(4*i+3));
                break;
            }
        }
    }    
    var res='0';
    switch(Trim(currencyCode.toLowerCase()))
    {
        case 'en-us':
        {   
            if(justFormat!=null && justFormat==true)
            {
                if(isReplace==false)
                    res=(((sign)?'':'-') + num + '.' + cents);
                else
                    res=(((sign)?'':'-') + num);
            }
            else
            {
                if(isReplace==false)
                    res=(((sign)?'':'-') + '$' + num + '.' + cents);
                else
                    res=(((sign)?'':'-') + '$' + num);
            }
            break;
        }
        case 'vi-vn':
        {           
            if(justFormat!=null && justFormat==true)
            { 
                if(isReplace==false)
                    res=(((sign)?'':'-') + num + ',' + cents);
                else
                    res=(((sign)?'':'-') + num);
            }
            else
            {
                if(isReplace==false)
                    res=(((sign)?'':'-') + num + ',' + cents + '<u>đ</u>');
                else
                    res=(((sign)?'':'-') + num + '<u>đ</u>');
            }
            break;
        }
    }
    return res;
}
//
function Money_CheckCorrect(controlCheckCorrectID)
{
    var input=Trim(filterElement(controlCheckCorrectID).value.toString());
    
    if(input!=''&& !IsAlphabet(input))
    {
        var priceFor=Trim(Money2Long(input));                
        if(FormatCurrency(priceFor,'vi-vn',true,true)=="0")
        {
           filterElement(controlCheckCorrectID).value='0';
        }
        else
        {
            filterElement(controlCheckCorrectID).value=FormatCurrency(priceFor,'vi-vn',true,true);
        }        
    }
    else
    {        
        filterElement(controlCheckCorrectID).value=input.substring(0,input.length-1);
    }
} 

function Money_OnBlurChange(controlCheckCorrectID)
{
    var input=Trim(filterElement(controlCheckCorrectID).value.toString());    
    var price=Trim(Money2Long(input));
    if(price==""|| parseInt(price)<=0)
    {
       filterElement(controlCheckCorrectID).value='0';
    }    
}

function Money2Long(input)
{
    //input = Trim(input);
    return parseInt(input.replace(/\./ig,""));
}

function Money_OnBlurChangedMin(minControlCheckCorrectID,maxControlCheckCorrectID)
{
    var inputMin=Trim(filterElement(minControlCheckCorrectID).value.toString());
    var inputMax=Trim(filterElement(maxControlCheckCorrectID).value.toString());
    var minPrice="";
    var arrMinPrice=inputMin.split(".");
    if(arrMinPrice.length>1)
    {
        for(var iMin=0;iMin<arrMinPrice.length;iMin++)
        {
            minPrice+=arrMinPrice[iMin];
        }
    }
    else
    {
        minPrice=Money2Long(inputMin);
    }
    minPrice=Trim(minPrice);
    var maxPrice="";
    var arrMaxPrice=inputMax.split(".");
    if(arrMaxPrice.length>1)
    {
        for(var iMax=0;iMax<arrMaxPrice.length;iMax++)
        {
            maxPrice+=arrMaxPrice[iMax];
        }
    }
    else
    {
        maxPrice=Money2Long(inputMax);
    }
    maxPrice=Trim(maxPrice);
    if(minPrice==''||parseInt(minPrice)<1000)
    {
        filterElement(minControlCheckCorrectID).value='1.000';
    }
}

function Money_OnBlurChangedMax(minControlCheckCorrectID,maxControlCheckCorrectID)
{
    var inputMin=Trim(filterElement(minControlCheckCorrectID).value.toString());
    var inputMax=Trim(filterElement(maxControlCheckCorrectID).value.toString());
    var minPrice="";
    var arrMinPrice=inputMin.split(".");
    if(arrMinPrice.length>1)
    {
        for(var iMin=0;iMin<arrMinPrice.length;iMin++)
        {
            minPrice += arrMinPrice[iMin];
        }
    }
    else
    {
        minPrice=Money2Long(inputMin);
    } 
    minPrice=Trim(minPrice);
    var maxPrice="";
    var arrMaxPrice=inputMax.split(".");
    if(arrMaxPrice.length>1)
    {
        for(var iMax=0;iMax<arrMaxPrice.length;iMax++)
        {
            maxPrice+=arrMaxPrice[iMax];
        }
    }
    else
    {
        maxPrice=Money2Long(inputMax);
    }
    maxPrice=Trim(maxPrice);
    if(maxPrice==''||parseInt(maxPrice)<1000)
    {
        filterElement(maxControlCheckCorrectID).value='1.000';
    }
} 

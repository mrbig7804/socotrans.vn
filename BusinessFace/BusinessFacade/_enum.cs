using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public enum OrderStatusCode : int
    {
        WaitingForPayment = 1,
        Confirmed = 2,
        Verified = 3
    }

    public enum ProductSpecialCode : int
    {
        Newest = 1,
        Sale = 2
    }

}

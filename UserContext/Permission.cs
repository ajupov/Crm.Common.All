﻿namespace Crm.Common.All.UserContext
{
    public enum Permission : byte
    {
        System = 1,
        Development = 2,
        Administration = 3,
        TechnicalSupport = 4,
        AccountOwning = 5,
        ProductsManagement = 6,
        LeadsManagement = 7,
        SalesManagement = 8,
        DemoViewing = 9
    }
}
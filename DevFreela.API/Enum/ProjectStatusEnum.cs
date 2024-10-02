﻿using Microsoft.AspNetCore.Http.HttpResults;

namespace DevFreela.API.Enum
{
    public enum ProjectStatusEnum
    {
        Created = 0,
        InProgress = 1,
        Suspended = 2,
        Cancelled = 3,
        Completed = 4,
        PaymentPending = 5
    }
}
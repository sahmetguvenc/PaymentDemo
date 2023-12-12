﻿namespace PaymentDemo.Domain.Entities.Base
{
    public interface IAuditableEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
    }
}
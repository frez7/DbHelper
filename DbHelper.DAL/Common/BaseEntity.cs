﻿namespace DbHelper.DAL.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

    }
}

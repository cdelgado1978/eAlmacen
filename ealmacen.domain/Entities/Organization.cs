﻿namespace eAlmacen.Domain.Entities;

public class Organization : EntityBase
{
    public string Name { get; set; }

    public string SlugTenant { get; set; }
}
﻿using System.Collections.Generic;

namespace WebForms.Autofac.MultiTenant.Minimal.Dependencies
{
    public interface IDependency
    {
        Dictionary<string, string> GetData();
    }
}
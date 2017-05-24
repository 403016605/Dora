﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Dora.ExceptionHandling.Configuration
{
    public class MatchTypeFilter : IExceptionFilter
    {
        public Type ExceptionType { get; }

        public MatchTypeFilter(Type exceptionType)
        {
            this.ExceptionType = Guard.ArgumentAssignableTo<Exception>(exceptionType, nameof(exceptionType));
        }
        public bool Match(ExceptionContext context)
        {
            return this.ExceptionType.GetTypeInfo().IsAssignableFrom(Guard.ArgumentNotNull(context, nameof(context)).Exception.GetType());
        }
    }
}

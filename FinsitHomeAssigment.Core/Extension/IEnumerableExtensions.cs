﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FinsitHomeAssigment.Core.Extension
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<string> AddNewLine(this IEnumerable<string> strings)
        {
            return strings?
                .Select(line => string.IsNullOrEmpty(line) ? line : line + Environment.NewLine)
                .ToList();
        }
    }
}

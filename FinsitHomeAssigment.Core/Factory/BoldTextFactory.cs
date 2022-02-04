﻿using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class BoldTextFactory : IDocumentElementFactory
    {
        public string Delimiter { get; set; } = Constant.BoldTextDelimiter;

        public DocumentElement Create(string line)
        {
            if (string.IsNullOrEmpty(line)) return null;

            return line.StartsWith(Delimiter) 
                ? new BoldText(line.Replace(Delimiter, "")) 
                : null;
        }
    }
}

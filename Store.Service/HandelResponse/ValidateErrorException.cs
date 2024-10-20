﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.HandelResponse
{
    public class ValidateErrorException : CostumException
    {
        public ValidateErrorException() : base(500)
        {

        }
        public IEnumerable<string> Errors { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime GetValueEx(this DateTime? dateTime)
        {
            return dateTime.GetValueOrDefault(DateTime.Now);
        }
    }
}

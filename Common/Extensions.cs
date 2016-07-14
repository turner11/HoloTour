﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Extensions
{
    public static TimeSpan Seconds(this double secs)
    {
        return TimeSpan.FromSeconds(secs);
    }

    public static TimeSpan Minutes(this double mins)
    {
        return TimeSpan.FromMinutes(mins);
    }

    public static TimeSpan Milliseconds(this double mili)
    {
        return TimeSpan.FromMilliseconds(mili);
    }

}

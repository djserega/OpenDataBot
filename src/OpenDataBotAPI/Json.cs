﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OpenDataBotAPI
{
    internal static class Json<T> where T : class, new()
    {
        internal static List<T> DeserializeString(string input)
        {
            return new JavaScriptSerializer().Deserialize<List<T>>(input);
        }
    }
}
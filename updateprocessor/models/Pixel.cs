﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Azure.Documents;

namespace pxdraw.updateprocessor.models
{
    public class Pixel
    {
        [JsonProperty("x", Required = Required.Always)]
        public int X {get; set;}
        [JsonProperty("y", Required = Required.Always)]
        public int Y { get; set; }
        [JsonProperty("color", Required = Required.Always)]
        public int Color { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        public static Pixel FromDocument(Document doc)
        {
            return new Pixel
            {
                X = Math.Max(0, doc.GetPropertyValue<int>("x")),
                Y = Math.Max(0, doc.GetPropertyValue<int>("y")),
                Color = doc.GetPropertyValue<int>("color"),
            };
        }
    }
}

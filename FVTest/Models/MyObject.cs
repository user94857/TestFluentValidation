using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using FVTest.FluentValidation;
using Newtonsoft.Json;

namespace FVTest.Models
{
    [Validator(typeof(MyObjectValidator))]
    public class MyObject
    {
        [JsonProperty("MyObject_ID")]
        public int? ID { get; set; }

        [JsonProperty("MyObject_Name")]
        public string Name { get; set; }

        [JsonProperty("MyObject_Sub_Objects")]
        public List<SubObject> SubObjects { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using FVTest.FluentValidation;
using Newtonsoft.Json;

namespace FVTest.Models
{
    [Validator(typeof(SubObjectValidator))]
    public class SubObject
    {
        [JsonProperty("SubObject_ID")]
        public int? ID { get; set; }

        [JsonProperty("SubObject_Name")]
        public string Name { get; set; }
    }
}
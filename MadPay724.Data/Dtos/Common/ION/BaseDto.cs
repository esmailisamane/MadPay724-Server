using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MadPay724.Data.Dtos.Common.ION
{
    public abstract class BaseDto : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}
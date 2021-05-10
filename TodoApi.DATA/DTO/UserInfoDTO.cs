using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TodoApi.DATA.DTO
{
    public class UserInfoDTO
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
    }
}
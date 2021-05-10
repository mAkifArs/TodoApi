using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TodoApi.DATA.Entities;

namespace TodoApi.DATA.DTO
{
    public class UserInfoDTO
    {   
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }

    }
}
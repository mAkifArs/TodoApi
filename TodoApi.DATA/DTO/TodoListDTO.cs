using System;
using System.Text.Json.Serialization;

namespace TodoApi.DATA.DTO
{
    public class TodoListDTO
    {
        public string Content { get; set; }
        public DateTime DateofJob { get; set; }
        public int UserId { get; set; }
        public UserInfoDTO UserInfoDto { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace TodoApi.DATA.DTO
{
    public class TodoListDTO
    {
        [Required]
        [StringLength(255)]
        public string Content { get; set; }
        public DateTime DateofJob { get; set; }
        public int UserId { get; set; }
        public UserInfoDTO UserInfoDto { get; set; }
    }
}
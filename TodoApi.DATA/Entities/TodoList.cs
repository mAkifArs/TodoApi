using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApi.DATA.Entities
{
    public class TodoList
    {   
        [Key]
        public int TodoId { get; set; } 
        public string Content { get; set; }
        public DateTime DateofJob { get; set; }
        public UserInfo UserInfo { get; set; }
        
    }
}
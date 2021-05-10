using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TodoApi.DATA.Entities;

namespace TodoApi.DATA.DTO
{
    public class TodoListDTO
    {
        public string Content { get; set; }
        public DateTime DateofJob { get; set; }
        public int UserId { get; set; }
        
    }
}
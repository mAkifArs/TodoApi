using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApi.DATA.Entities
{
    public class UserInfo
    {
        [Key] 
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public List<TodoList> Todos { get; set; }
        
    }
}
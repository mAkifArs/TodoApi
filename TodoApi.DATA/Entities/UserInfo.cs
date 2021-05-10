#nullable enable
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
        public ICollection<TodoList>? TodoLists { get; set; }
        
    }
}
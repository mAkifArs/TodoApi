#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Hangfire.Annotations;

namespace TodoApi.DATA.Entities
{
    public class UserInfo
    {
        [Key] 
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        
        [Required]
        [NotNull]
        public string Name { get; set; }
        public ICollection<TodoList>? TodoLists { get; set; }
        
    }
}
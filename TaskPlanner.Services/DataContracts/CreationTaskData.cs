using System;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.Services.DataContracts
{
    public class CreationTaskData
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }

        public Guid ParentId { get; set; }


    }
}

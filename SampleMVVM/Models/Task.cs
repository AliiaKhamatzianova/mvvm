using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace SampleMVVM.Models
{
    public enum Statuses { TODO, Active, Canceled, Done}
    public enum Priorities { Low, Middle, High}

    [Serializable]
    [Table("Task")]
    public class Task
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priorities Priority { get; set; }

        public Statuses Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

    }
}

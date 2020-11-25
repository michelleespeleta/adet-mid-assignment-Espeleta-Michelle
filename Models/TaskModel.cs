using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adet_mid_assignment_Espeleta_Michelle.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //can be TODO or DONE
        public string State { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFinished { get; set; }
        [DataType(DataType.Date)]
        public string TaskDescription { get; set; }

        public int TotalHours { get; set; } //will get the total minutes (Convert to hours in view)

    }
}

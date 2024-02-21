using System.ComponentModel.DataAnnotations;

namespace medicaton.models
{
    public class Warning
    {
        [Key]
        public string WarningName { get; set; }
        public ICollection<MedicationWarningJoin>? medicationWarningJoins { get; set; }
    }
}

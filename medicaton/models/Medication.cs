using System.ComponentModel.DataAnnotations;

namespace medicaton.models
{
    public class Medication
    {
        [Key]
        public string Name { get; set; }
        public string? EnglishName { get; set; }
        public string? usedfor { get; set; }
        public string? about { get; set; }
        public ICollection<MedicationWarningJoin>? medicationWarningJoins { get; set; }
    }
}

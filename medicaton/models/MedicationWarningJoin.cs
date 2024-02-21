using System.ComponentModel.DataAnnotations.Schema;

namespace medicaton.models
{
    public class MedicationWarningJoin
    {
        public int Id { get; set; }
        [ForeignKey(nameof(medication))]
        public string MedicationName { get; set; }
        [ForeignKey(nameof(warning))]
        public string  WarningName { get; set; }

        public Medication medication { get; set; }
        public Warning warning { get; set; }
    }
}

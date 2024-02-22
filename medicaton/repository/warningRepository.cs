using medicaton.models;

namespace medicaton.repository
{
    public class warningRepository : IwarningRepository
    {
        private readonly DataContext dataContext1;
        public warningRepository(DataContext dataContext)
        {
            dataContext1= dataContext;
        }

        public bool addmedicationWarning(string medicationName, string warmimgName)
        {
            var MedicationWarningJoin = new MedicationWarningJoin()
            {
                MedicationName = medicationName,
                WarningName = warmimgName

            };
            dataContext1.medicationWarningJoins.Add(MedicationWarningJoin);
            return save(dataContext1.SaveChanges());
        }

        public bool addwarning(Warning warning, string medicationName)
        {
            dataContext1.warnings.Add(warning);
            var MedicationWarningJoin = new MedicationWarningJoin()
            {
                MedicationName = medicationName,
                WarningName = warning.WarningName
            
            };
            dataContext1.medicationWarningJoins.Add(MedicationWarningJoin);
            return save(dataContext1.SaveChanges());
            
        }

        public Warning GetWarning(string name)
        {
            return dataContext1.warnings.Where(w=>w.WarningName==name).FirstOrDefault();
            
            
        }

        public ICollection<MedicationWarningJoin> getwarningformedication(string medicationName)
        {
            return dataContext1.medicationWarningJoins.Where(w=>w.MedicationName==medicationName).ToList();
        }

        public ICollection<Warning> GetWarnings()
        {
            return dataContext1.warnings.ToList();
        }

        public bool save(int saved)
        {
            return saved>0?true:false;
        }
    }
}

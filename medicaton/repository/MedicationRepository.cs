using medicaton.models;

namespace medicaton.repository
{
    public class MedicationRepository : ImedicationRepository
    {
        private readonly DataContext _dataContext;
        public MedicationRepository(DataContext context)
        {
            _dataContext = context;
        }
        public bool addmedication(Medication medication)
        {
            _dataContext.medications.Add(medication);
           return save(_dataContext.SaveChanges());
        }

        public Medication GetMedicationbyname(string medicationName)
        {
            return _dataContext.medications.Where(m=>m.Name == medicationName||m.EnglishName==medicationName).FirstOrDefault();
            
        }

        public ICollection<Medication> GetMedications()
        {
           return _dataContext.medications.ToList();
        }

        public bool save(int saved)
        {
            return saved>0?true:false;
        }

        public bool updatemedication()
        {
            return save(_dataContext.SaveChanges());

        }
    }
}

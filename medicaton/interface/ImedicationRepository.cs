using medicaton.models;

namespace medicaton
{
    public interface ImedicationRepository
{
        //for post request
        bool addmedication(Medication medication);
        bool save(int saved);
        //for get request
        Medication GetMedicationbyname(string medicationName);
        //for get request
        ICollection<Medication> GetMedications();

        //for update
        bool updatemedication();
    }
}

using medicaton.models;

namespace medicaton
{
    public interface IwarningRepository
{
        bool save(int saved);
        bool addwarning(Warning warning,string medicationName);
        bool addmedicationWarning( string medicationName, string warmimgName);
        Warning GetWarning(string name);
        ICollection<Warning> GetWarnings();
    }
}

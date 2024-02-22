using medicaton.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medicaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly ImedicationRepository _medicationRepository;
        private readonly IwarningRepository iwarningRepository;
        public MedicationController(ImedicationRepository imedicationRepository, IwarningRepository iwarningRepository)
        {
            _medicationRepository = imedicationRepository;
            iwarningRepository = iwarningRepository;
        }
        [HttpGet]
        public IActionResult Getallmedications() 
        {
            
            var medicationlist=_medicationRepository.GetMedications();
            if (medicationlist != null)
            {
                return Ok(medicationlist);
            }else { return Ok("no medications to view"); }


        }
        [HttpGet("getMedicationByName")]
        public IActionResult GetallmedicationbyName([FromQuery] string medicationname)
        {

            var medication = _medicationRepository.GetMedicationbyname(medicationname);
            if (medication != null)
            {
                return Ok(medication);
            }
            else { return Ok("no medication with that name"); }


        }
        [HttpPost]
        public IActionResult addmedication([FromQuery] Medication medication) 
        { 
            var medicationnamechecker=_medicationRepository.GetMedicationbyname(medication.Name);
            if(medicationnamechecker == null)
            {
                try
                {
                    _medicationRepository.addmedication(medication);
                    return Ok("medication Added successfully");
                }catch (Exception ex)
                {
                    return BadRequest("failed to Add");
                }
            }
            else
            {
                return BadRequest("medication already exist");
            }
        }
        [HttpPut]
        public IActionResult updateMedicationt([FromQuery]Medication medication, [FromQuery] string oldmedicationName) 
        {
            var medicationexist=_medicationRepository.GetMedicationbyname(oldmedicationName);
            if(medicationexist != null)
            {
                medicationexist.Name = medication.Name;
                medicationexist.about = medication.about;
                medicationexist.EnglishName = medication.EnglishName;
                medicationexist.usedfor=medication.usedfor;
                try {
                    
                    _medicationRepository.updatemedication();
                    return Ok("medication Updated");
                }
                catch (Exception ex) {
                    return BadRequest($"medication can't be updated because{ex.ToString()}");
                }
            }
            else
            {
                return BadRequest("this medication not exist so it can't be updated ");
            }
        }
    }
 

}

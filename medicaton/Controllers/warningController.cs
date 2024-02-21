using medicaton.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medicaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class warningController : ControllerBase
    {

        private readonly IwarningRepository _warningrepo;
        private readonly ImedicationRepository _medicationrepo;
        public warningController(IwarningRepository iwarning, ImedicationRepository medicationrepo)
        {
            _warningrepo = iwarning;
            _medicationrepo = medicationrepo;
        }
        [HttpGet]
        public IActionResult Getallwarnings()
        {

            var warninglist = _warningrepo.GetWarnings();
            if (warninglist != null)
            {
                return Ok(warninglist);
            }
            else { return Ok("no warnings to view"); }


        }
        [HttpGet("getMedicationByName")]
        public IActionResult GetwarningbyName([FromQuery] string warningname)
        {

            var warning = _warningrepo.GetWarning(warningname);
            if (warning != null)
            {
                return Ok(warning);
            }
            else { return Ok("no warning with that name"); }


        }
        [HttpPost]
        public IActionResult addwarning([FromQuery] Warning warning , [FromQuery]  string medicationname)
        {
            var medicationnamechecker = _medicationrepo.GetMedicationbyname(medicationname);
            if (medicationnamechecker != null)
            {
                var warningchecker = _warningrepo.GetWarning(warning.WarningName);
                if (warningchecker != null)
                {
                    _warningrepo.addmedicationWarning(medicationname, warning.WarningName);
                    return Ok("medicationwarning Added successfully");
                }
                else
                {
                    try
                    {
                        _warningrepo.addwarning(warning, medicationname);
                        return Ok("warning Added successfully");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("failed to Add");
                    }
                }
            }else
            {
                return BadRequest("no medication exists for this warning you added");
            }
        }
    }
}


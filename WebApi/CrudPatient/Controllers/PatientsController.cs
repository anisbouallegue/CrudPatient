using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudPatient.Models;
using CrudPatient.Models.Repository;

namespace CrudPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IDataRepository<Patient> _dataRepository;

        public PatientsController(IDataRepository<Patient> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Patients
        [HttpGet]
        public IActionResult getAll()
        {
            IEnumerable<Patient> patients = _dataRepository.getAll();
            return Ok(patients);
        }

        // GET: api/Patients/5
        [HttpGet("{id}", Name = "getById")]
        public IActionResult getById(long id)
        {
            Patient patient = _dataRepository.getById(id);

            if (patient == null)
            {
                return NotFound("The patient record couldn't be found.");
            }

            return Ok(patient);
        }

       

        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public IActionResult updatePatient(long id, [FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest("patient is null.");
            }

            Patient patientToUpdate = _dataRepository.getById(id);
            if (patientToUpdate == null)
            {
                return NotFound("The patient record couldn't be found.");
            }

            _dataRepository.updatePatient(patientToUpdate, patient);
            return NoContent();
        }

        // POST: api/Patients
        [HttpPost]
        public IActionResult createPatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient is null.");
            }

            _dataRepository.createPatient(patient);
            return NoContent();
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public IActionResult delPatient(long id)
        {
            Patient patient = _dataRepository.getById(id);
            if (patient == null)
            {
                return NotFound("The patient record couldn't be found.");
            }

            _dataRepository.delPatient(patient);
            return NoContent();
        }

    }
}

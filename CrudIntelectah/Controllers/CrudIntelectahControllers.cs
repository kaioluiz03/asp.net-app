using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrudIntelectah.Data;
using CrudIntelectah.Models;
using CrudIntelectah.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CrudIntelectah.Controllers
{
    [ApiController]
    [Route(template:"v1")]

    public class PatientController : ControllerBase
    {   
        //Tabela 1 - Pacientes
        //GET
        [HttpGet]
        [Route(template:"patients")]

        public async Task<IActionResult> GetAsync(
            [FromServices] PatientDbContext context)
        {
            var patients = await context
                .Patients
                .AsNoTracking()
                .ToListAsync();
                
            return Ok(patients);
        }

        //GET FOR ID
        [HttpGet]
        [Route(template:"patients/{id}")]

        public async Task<IActionResult> GetByIdAsync(
            [FromServices] PatientDbContext context, 
            [FromRoute]int id)
        {
            var patient = await context
                .Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PatientId == id);

            return patient == null 
                ? NotFound()
                : Ok(patient);
        }

        //POST
        [HttpPost]
        [Route(template:"patients")]

        public async Task<IActionResult> PostAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreatePatientViewModel infoModels )
        {
            if(!ModelState.IsValid)
                return BadRequest();
                
            var patient = new Patient
            {
                Name = infoModels.Name,

                Cpf = infoModels.Cpf,

                BirthDate = infoModels.BirthDate,

                Gender = infoModels.Gender,

                Phone = infoModels.Phone,

                Email = infoModels.Email,
            };

            try
            {
                await context.Patients.AddAsync(patient);
                await context.SaveChangesAsync();
                return Created($"v1/patients/{patient.PatientId}", patient);
            }
            catch (System.Exception)
            {
                return BadRequest();                
            }
        }

        //PUT
        [HttpPut]
        [Route(template:"patients/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreatePatientViewModel infoModels,
            [FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest();
                
            var patient = await context
                .Patients
                .FirstOrDefaultAsync(x => x.PatientId == id);

            if (patient == null)
                return NotFound();
 
            try
            {
                patient.Name = infoModels.Name;
                patient.Cpf = infoModels.Cpf;
                patient.BirthDate = infoModels.BirthDate;
                patient.Gender = infoModels.Gender;
                patient.Phone = infoModels.Phone;
                patient.Email = infoModels.Email;

                context.Patients.Update(patient);
                await context.SaveChangesAsync();

                return Ok(patient);
            }
            catch (Exception e)
            {
                return BadRequest();               
            }
        }

        //DELETE
        [HttpDelete]
        [Route(template:"patients/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var patient = await context
                .Patients
                .FirstOrDefaultAsync(x => x.PatientId == id);
            try
            {
                context.Patients.Remove(patient);
                context.SaveChangesAsync();

                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        //Tabela 2 - Tipos de Exames
        //GET
    }
}
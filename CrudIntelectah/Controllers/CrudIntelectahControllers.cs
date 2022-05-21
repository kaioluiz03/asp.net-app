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
    [Route(template: "v1")]

    public class PatientController : ControllerBase
    {
        //Tabela 1 - Pacientes
        //GET
        [HttpGet]
        [Route(template: "patients")]

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
        [Route(template: "patients/{id}")]

        public async Task<IActionResult> GetByIdAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
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
        [Route(template: "patients")]

        public async Task<IActionResult> PostAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreatePatientViewModel infoModels)
        {
            if (!ModelState.IsValid)
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
        [Route(template: "patients/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreatePatientViewModel infoModels,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
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
        [Route(template: "patients/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var patient = await context
                .Patients
                .FirstOrDefaultAsync(x => x.PatientId == id);
            try
            {
                context.Patients.Remove(patient);
                await context.SaveChangesAsync();

                return Ok("Colocar Mensagem");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        //Tabela 2 - Tipos de Exames
        //GET
        [HttpGet]
        [Route(template: "typesofexams")]

        public async Task<IActionResult> GetTypeOfExamsAsync(
            [FromServices] PatientDbContext context)
        {
            var typeofexams = await context
                .TypeOfExams
                .AsNoTracking()
                .ToListAsync();

            return Ok(typeofexams);
        }

        //GET FOR ID
        [HttpGet]
        [Route(template: "typesofexams/{id}")]

        public async Task<IActionResult> GetTypeOfExamsByIdAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var typeofexams = await context
                .TypeOfExams
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TypeOfExamId == id);

            return typeofexams == null
                   ? NotFound()
                   : Ok(typeofexams);
        }

        //POST
        [HttpPost]
        [Route(template: "typesofexams")]

        public async Task<IActionResult> PostTypeOfExamsAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreateTypeOfExamViewModel infoModels)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var typeofexam = new TypeOfExam
            {
                Name = infoModels.Name,

                Description = infoModels.Description
            };

            try
            {
                await context.TypeOfExams.AddAsync(typeofexam);
                await context.SaveChangesAsync();
                return Created($"v1/typesofexams/{typeofexam.TypeOfExamId}", typeofexam);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //PUT
        [HttpPut]
        [Route(template: "typesofexams/{id}")]

        public async Task<IActionResult> PutTypeOfExamsAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreateTypeOfExamViewModel infoModels,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var typeofexams = await context
             .TypeOfExams
             .FirstOrDefaultAsync(x => x.TypeOfExamId == id);

            if (typeofexams == null)
                return NotFound();

            try
            {
                typeofexams.Name = infoModels.Name;
                typeofexams.Description = infoModels.Description;

                context.TypeOfExams.Update(typeofexams);
                await context.SaveChangesAsync();

                return Ok(typeofexams);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //DELETE
        [HttpDelete]
        [Route(template: "typeofexams/{id}")]

        public async Task<IActionResult> DeleteTypeOfExamsAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var typeofexam = await context
                .TypeOfExams
                .FirstOrDefaultAsync(x => x.TypeOfExamId == id);

            try
            {
                context.TypeOfExams.Remove(typeofexam);
                await context.SaveChangesAsync();

                return Ok("Colocar Mensagem");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
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
        [Route(template: "pacientes")]

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
        [Route(template: "pacientes/{id}")]

        public async Task<IActionResult> GetByIdAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var patient = await context
                .Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return patient == null
                ? NotFound()
                : Ok(patient);
        }

        //POST
        [HttpPost]
        [Route(template: "pacientes")]

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
                return Created($"v1/pacientes/{patient.Id}", patient);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //PUT
        [HttpPut]
        [Route(template: "pacientes/{id}")]

        public async Task<IActionResult> PutAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreatePatientViewModel infoModels,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = await context
                .Patients
                .FirstOrDefaultAsync(x => x.Id == id);

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
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //DELETE
        [HttpDelete]
        [Route(template: "pacientes/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var patient = await context
                .Patients
                .FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                context.Patients.Remove(patient);
                await context.SaveChangesAsync();

                return Ok("Colocar Mensagem");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        //Tabela 2 - Tipos de Exames
        //GET
        [HttpGet]
        [Route(template: "tiposdeexames")]

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
        [Route(template: "tiposdeexames/{id}")]

        public async Task<IActionResult> GetTypeOfExamsByIdAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var typeofexams = await context
                .TypeOfExams
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return typeofexams == null
                   ? NotFound()
                   : Ok(typeofexams);
        }

        //POST
        [HttpPost]
        [Route(template: "tiposdeexames")]

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
                return Created($"v1/tiposdeexames/{typeofexam.Id}", typeofexam);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //PUT
        [HttpPut]
        [Route(template: "tiposdeexames/{id}")]

        public async Task<IActionResult> PutTypeOfExamsAsync(
            [FromServices] PatientDbContext context,
            [FromBody] CreateTypeOfExamViewModel infoModels,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var typeofexams = await context
             .TypeOfExams
             .FirstOrDefaultAsync(x => x.Id == id);

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
        [Route(template: "tiposdeexames/{id}")]

        public async Task<IActionResult> DeleteTypeOfExamsAsync(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var typeofexam = await context
                .TypeOfExams
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.TypeOfExams.Remove(typeofexam);
                await context.SaveChangesAsync();

                return Ok("Colocar Mensagem");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        //Tabela 3 - Cadastro de Exames
        //GET
        [HttpGet]
        [Route(template: "cadastrodeexames")]

        public async Task<IActionResult> GetAsyncExamRecord(
            [FromServices] PatientDbContext context)
        {
            var examrecord = await context
                .ExamRecords
                .AsNoTracking()
                .ToListAsync();

            return Ok(examrecord);
        }

        //GET FOR ID
        [HttpGet]
        [Route(template: "cadastrodeexames/{id}")]

        public async Task<IActionResult> GetAsyncExamRecodById(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var examrecord = await context
                .ExamRecords
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return examrecord == null
                   ? NotFound()
                   : Ok(examrecord);
        }

        //POST
        [HttpPost]
        [Route(template: "cadastrodeexames")]

        public async Task<IActionResult> PostAsyncExamRecord(
            [FromServices] PatientDbContext context,
            [FromBody] CreateExamRecordViewModel infoModels)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var typeofexam = await context
                .TypeOfExams
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == infoModels.TypeOfExamId);

            var examrecord = new ExamRecord
            {
                Name = infoModels.Name,

                Observation = infoModels.Observation,

                TypeOfExamId = infoModels.TypeOfExamId
            };

            try
            {
                if (typeofexam != null)
                {
                    await context.ExamRecords.AddAsync(examrecord);
                    await context.SaveChangesAsync();

                    return Created($"v1/cadastrodeexames/{examrecord.Id}", examrecord);
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //PUT
        [HttpPut]
        [Route(template: "cadastrodeexames/{id}")]

        public async Task<IActionResult> PutAsyncExamRecord(
            [FromServices] PatientDbContext context,
            [FromBody] CreateExamRecordViewModel infoModels,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var examrecord = await context
             .ExamRecords
             .FirstOrDefaultAsync(x => x.Id == id);

            if (examrecord == null)
                return NotFound();

            var typeofexam = await context
                .TypeOfExams
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == infoModels.TypeOfExamId);

            try
            {
                if (typeofexam != null)
                {
                    examrecord.Name = infoModels.Name;
                    examrecord.Observation = infoModels.Observation;
                    examrecord.TypeOfExamId = infoModels.TypeOfExamId;

                    context.ExamRecords.Update(examrecord);
                    await context.SaveChangesAsync();

                    return Ok(examrecord);
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //DELETE
        [HttpDelete]
        [Route(template: "cadastrodeexames/{id}")]

        public async Task<IActionResult> DeleteAsyncExamRecord(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var examrecord = await context
                .ExamRecords
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.ExamRecords.Remove(examrecord);
                await context.SaveChangesAsync();

                return Ok("Colocar Mensagem");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        //Tabela 3 - Marca��o de consulta
        //GET
        [HttpGet]
        [Route(template: "marcarconsulta")]

        public async Task<IActionResult> GetAsyncAppointmentScheduling(
            [FromServices] PatientDbContext context)
        {
            var AppointmentScheduling = await context
                .AppointmentsScheduling
                .AsNoTracking()
                .ToListAsync();

            return Ok(AppointmentScheduling);
        }

        //GET FOR ID
        [HttpGet]
        [Route(template: "marcarconsulta/{id}")]

        public async Task<IActionResult> GetAsyncAppointmentSchedulingById(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var AppointmentScheduling = await context
                .AppointmentsScheduling
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return AppointmentScheduling == null
                ? NotFound()
                : Ok(AppointmentScheduling);
        }

        //POST
        [HttpPost]
        [Route(template: "marcarconsulta")]

        public async Task<IActionResult> PostAsyncAppointmentScheduling(
            [FromServices] PatientDbContext context,
            [FromBody] CreateAppointmentSchedulingViewModel infoModels)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = await context
                .Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Cpf == infoModels.PatientId || p.Name == infoModels.PatientId);

            var exam = await context
                .ExamRecords
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == infoModels.ExamRecordId);

            var date = await context
                .AppointmentsScheduling
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.ConsultationDate == infoModels.ConsultationDate);

            var AppointmentScheduling = new AppointmentScheduling
            {
                PatientId = infoModels.PatientId,
                ExamRecordId = infoModels.ExamRecordId,
                ConsultationDate = infoModels.ConsultationDate,
                ProtocolNumber = convertedConsultationUUID
            };

            try
            {
                if (patient != null && exam != null)
                {
                    if (date == null)
                    {
                        await context.AppointmentsScheduling.AddAsync(AppointmentScheduling);
                        await context.SaveChangesAsync();
                        return Created(uri: $"v1/marcarconsulta/{AppointmentScheduling.Id}", AppointmentScheduling);
                    }

                    return BadRequest();
                }
                return BadRequest();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //PUT
        [HttpPut]
        [Route(template:"marcarconsulta/{id}")]

        public async Task<IActionResult> PutAsyncAppointmentScheduling(
            [FromServices] PatientDbContext context,
            [FromBody] CreateAppointmentSchedulingViewModel infoModels,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var appointmentScheduling = await context
                .AppointmentsScheduling
                .FirstOrDefaultAsync(x => x.Id == id);

            var patient = await context
                .Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Cpf == infoModels.PatientId || p.Name == infoModels.PatientId);

            var exam = await context
                .ExamRecords
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == infoModels.ExamRecordId);

            if (appointmentScheduling == null)
                return BadRequest();

            try
            {
                if(patient != null && exam != null)
                {
                    appointmentScheduling.PatientId = infoModels.PatientId;
                    appointmentScheduling.ExamRecordId = infoModels.ExamRecordId;
                    appointmentScheduling.ConsultationDate = infoModels.ConsultationDate;
                    appointmentScheduling.ProtocolNumber = infoModels.ProtocolNumber;

                    context.AppointmentsScheduling.Update(appointmentScheduling);
                    await context.SaveChangesAsync();

                    return Ok(appointmentScheduling);
                }

                return BadRequest();
            }
            catch(System.Exception)
            {
                return BadRequest();
            }
        }

        //DELETE
        [HttpDelete]
        [Route(template: "marcarconsulta/{id}")]

        public async Task<IActionResult> DeleteAsyncAppointmentScheduling(
            [FromServices] PatientDbContext context,
            [FromRoute] int id)
        {
            var appointmentscheduling = await context
                .AppointmentsScheduling
                .FirstOrDefaultAsync(x => x.Id == id);

            if (appointmentscheduling == null)
                return NotFound();

            try
            {
                context.AppointmentsScheduling.Remove(appointmentscheduling);
                await context.SaveChangesAsync();

                return Ok("Colocar Mensagem");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
} 
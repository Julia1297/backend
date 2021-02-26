using Backend.Core.Entities;
using Backend.Core.Exceptions;
using Backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Backend.Api.Controllers
{
    [Route("api/Inscripcion")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionRepository _inscripcionRepository;
        private readonly ILogger<InscripcionController> _logger;

        public InscripcionController(IInscripcionRepository inscripcionRepository, ILogger<InscripcionController> logger)
        {
            _inscripcionRepository = inscripcionRepository;
            _logger = logger;
        }


        /// <summary>
        /// Devuelve todas las inscripciones realizadas.
        /// </summary>

        [HttpGet]
        [Route("GetInscripciones")]
        public async Task<IActionResult> GetInscripciones()
        {
            try
            {
                _logger.LogInformation("Get Incscripciones Controller");
                var inscripciones = await _inscripcionRepository.Getinscripciones();
                return Ok(inscripciones);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Excepcion Capturada");
                throw new BusinessException(error.Message);
            }

        }

        [HttpGet]
        [Route("GetMateriasEstudiante")]
        public async Task<IActionResult> GetMateriasEstudiante(int IdEstudiante)
        {
            try
            {
                _logger.LogInformation("Get Materias de un Estudiante Controller");
                var inscripciones = await _inscripcionRepository.GetMateriasPorEstudiante(IdEstudiante);
                return Ok(inscripciones);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Excepcion Capturada");
                throw new BusinessException(error.Message);
            }
        }

        [HttpGet]
        [Route("GetEstudiantesMateria")]
        public async Task<IActionResult> GetEstudiantesMateria(int IdMateria)
        {
            try
            {
                _logger.LogInformation("Get Estudiantes de una materia Controller");
                var inscripciones = await _inscripcionRepository.GetEstudiantesPorMateria(IdMateria);
                return Ok(inscripciones);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Excepcion Capturada");
                throw new BusinessException(error.Message);
            }
        }
        /// <summary>
        /// Registra una inscripcion.
        /// </summary>
        /// <param name="inscripcion">Es la inscripcion que se realizara <seealso cref="Inscripcion"/></param>
        /// <returns>Just returns bar.</returns>
        [HttpPost]
        [Route("AddInscripcion")]
        public async Task<IActionResult> AddInscripcion(Inscripcion inscripcion)
        {
            try
            {
                _logger.LogInformation("Add Inscripcion Controller");
                var ins = await _inscripcionRepository.AddInscripcion(inscripcion);
                return Ok(ins);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Excepcion Capturada");
                throw new BusinessException(error.Message);
            }
        }

        [HttpPut]
        [Route("UpdateInscripcion")]
        public async Task<IActionResult> UpdateInscripcion(Inscripcion inscripcion)
        {
            try
            {
                _logger.LogInformation("Update Inscripcion Controller");
                var ins = await _inscripcionRepository.UpdateInscripcion(inscripcion);
                return Ok(ins);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Excepcion Capturada");
                throw new BusinessException(error.Message);
            }
        }

        /// <summary>
        /// Borra una inscripcion en base al Id.
        /// </summary>
        /// <param name="idInscripcion">Es el Id de la inscripcion a borrar </param>
        /// <returns>Just returns bar.</returns>
        [HttpDelete]
        [Route("DeleteInscripcion")]
        public async Task<IActionResult> DeleteInscripcion(int idInscripcion)
        {
            try
            {
                _logger.LogInformation("Delete Inscripcion Controller");
                var ins = await _inscripcionRepository.DeleteInscripcion(idInscripcion);
                return Ok(ins);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Excepcion Capturada");
                throw new BusinessException(error.Message);
            }
        }
    }
}

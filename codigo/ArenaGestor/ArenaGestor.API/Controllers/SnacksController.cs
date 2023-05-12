using ArenaGestor.API.Filters;
using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.Business;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArenaGestor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class SnacksController : ControllerBase, ISnackAppService
    {

        private readonly ISnackService snackService;
        private readonly IMapper mapper;

        public SnacksController(ISnackService snackService, IMapper mapper)
        {
            this.snackService = snackService;
            this.mapper = mapper;
        }

        [AuthorizationFilter(RoleCode.Administrador)]
        [HttpPost()]
        public IActionResult PostSnack([FromBody] SnackDto snackDto)
        {
            try
            {

                var snack = mapper.Map<Snack>(snackDto);
                Snack updatedSnack = snackService.InsertSnack(snack);
                var resultDto = mapper.Map<SnackDto>(updatedSnack);
                return Ok(resultDto);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [AuthorizationFilter(RoleCode.Administrador)]
        [HttpPut()]
        public IActionResult PutSnack([FromBody] SnackDto snackDto)
        {
            try { 
                var snack = mapper.Map<Snack>(snackDto);
                Snack updatedSnack = snackService.UpdateSnack(snack);
                var resultDto = mapper.Map<SnackDto>(updatedSnack);
                return Ok(resultDto);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [AuthorizationFilter(RoleCode.Administrador)]
        [HttpDelete("{snackId}")]
        public IActionResult DeleteSnack([FromRoute] int snackId)
        {
            try
            {
                snackService.DeleteSnack(snackId);
                return Ok();
            }
            catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        public IActionResult PutSnackBuy(List<SnackDto> snackDto)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetSnacks()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetSnackById(int snackId)
        {
            throw new NotImplementedException();
        }
    }
}

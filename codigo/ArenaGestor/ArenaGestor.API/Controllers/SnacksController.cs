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

        [AuthorizationFilter(RoleCode.Administrador, RoleCode.Espectador, RoleCode.Vendedor)]
        [HttpPut("cart")]
        public IActionResult PutSnackBuy([FromBody] List<SnackDto> snacksDto)
        {
            try
            {
                var token = this.HttpContext.Request.Headers["token"];
                var snacks = new List<Snack>();
                foreach (SnackDto snackDto in snacksDto)
                {
                    var snack = mapper.Map<Snack>(snackDto);
                    snacks.Add(snack);
                }
                List<Snack> boughtSnacks = snackService.BuySnack(token, snacks);
                if (boughtSnacks == null || boughtSnacks.Count == 0)
                {
                    return BadRequest("No es posible procesar su pedido");
                }else
                {
                    return Ok(snacksDto);
                }
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

        [AuthorizationFilter(RoleCode.Administrador, RoleCode.Espectador, RoleCode.Vendedor)]
        [HttpGet()]
        public IActionResult GetSnacks()
        {
            try
            {
                var token = this.HttpContext.Request.Headers["token"];
                var snacks = snackService.GetSnacks(token);
                var resultDto = mapper.Map<IEnumerable<SnackDto>>(snacks);
                return Ok(resultDto);
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

        [AuthorizationFilter(RoleCode.Administrador, RoleCode.Espectador, RoleCode.Vendedor)]
        [HttpGet("{snackId}")]
        public IActionResult GetSnackById([FromRoute] int snackId)
        {
            try
            {
                var snack = snackService.GetSnackById(snackId);
                var resultDto = mapper.Map<SnackDto>(snack);
                return Ok(resultDto);
            } catch(NullReferenceException ex)
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
    }
}

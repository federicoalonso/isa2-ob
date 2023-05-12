using ArenaGestor.APIContracts.Snack;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArenaGestor.APIContracts
{
    public interface ISnackAppService
    {
        IActionResult PostSnack(SnackDto snackDto);
        IActionResult PutSnackBuy(List<SnackDto> snackDto);
        IActionResult PutSnack(SnackDto snackDto);
        IActionResult GetSnacks();
        IActionResult GetSnackById(int snackId);
        IActionResult DeleteSnack(int snackId);
    }
}


using CasoEstudio2.Models;
using CasoEstudio2.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGeneralHelper _helper;

        public CasasController(IConfiguration configuration, IGeneralHelper helper)
        {
            _configuration = configuration;
            _helper = helper;
        }
        #region Alquiler

        [HttpGet]
        public async Task<IActionResult> Alquilar()
        {
            //Query de las casas disponibles para alquilar
            using var context = _helper.CreateConnection();
            var casas = await context.QueryAsync<CasasModel>("sp_IdCasaDropdown",
                commandType: CommandType.StoredProcedure);

            if (casas == null || !casas.Any())
            {
                TempData["SinCasas"] = "No hay casas disponibles para alquilar en este momento.";
            }

            ViewBag.Casas = new SelectList(casas ?? Enumerable.Empty<CasasModel>(), "IdCasa", "DescripcionCasa");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Alquilar(CasasModel model)
        {
            using var context = _helper.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdCasa", model.IdCasa);
            parametros.Add("@UsuarioAlquiler", model.UsuarioAlquiler);
            await context.ExecuteAsync("sp_AlquilarCasa", parametros, commandType: CommandType.StoredProcedure);

            return RedirectToAction("ConsultaCasas");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPrecio(long idCasa)
        {
            using var context = _helper.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("IdCasa", idCasa);
            var precio = await context.QueryFirstOrDefaultAsync<decimal>("sp_PrecioCasaText",
                parametros, commandType: CommandType.StoredProcedure);

            return Json(precio);
        }

        #endregion

        #region Casa Consulta
        [HttpGet]
        public async Task<IActionResult> ConsultaCasas()
        {
            using var context = _helper.CreateConnection();
            var casas = await context.QueryAsync<CasasModel>(
                "sp_ConsultarCasas",
                commandType: CommandType.StoredProcedure);

            return View(casas.ToList());
        }
        #endregion
    }
}
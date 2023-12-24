using ContabilidadCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using BlazorCrud.Server.Models;
//using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;
using trySqlContabilidad00.Models;

namespace trySqlContabilidad00.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DteCabeceraController : ControllerBase
	{
		private readonly DbcrudBlazorContext _dbContext;

		public DteCabeceraController(DbcrudBlazorContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		[Route("Lista/{id_empresa}/{registros}")]
		public async Task<IActionResult> Lista(int id_empresa, int registros=1)
		{
			var responseApi = new ResponseAPI<List<DteCabeceraDTO>>();
			var listaDteCabeceraDTO = new List<DteCabeceraDTO>();

			if(registros <= 0 || id_empresa <=0)
			{
				return Ok(responseApi);
			}

			try{
				//foreach (var item in await _dbContext.DteCabeceras.Include(d => d.IdDteCabecera).ToListAsync())
				//foreach (var item in await _dbContext.DteCabeceras.ToListAsync())
				foreach (var item in await _dbContext.DteCabeceras
					.Where(e=>e.IdEmpresa == id_empresa)
					.Take(registros)
					.OrderByDescending(e=>e.FechaEmision)
					.ToListAsync()
				){
					listaDteCabeceraDTO.Add(new DteCabeceraDTO{
						IdDteCabecera = item.IdDteCabecera,
						IdEmpresa = item.IdEmpresa,
						IdTipoDte = item.IdTipoDte,
						Folio = item.Folio,
						FechaEmision = item.FechaEmision
					});

				}
				responseApi.EsCorrecto = true;
				responseApi.Valor = listaDteCabeceraDTO;
			}
			catch (Exception ex)
			{
				responseApi.EsCorrecto = false;
				responseApi.Mensaje = ex.Message;
			}

			return Ok(responseApi);
		}
	}
}

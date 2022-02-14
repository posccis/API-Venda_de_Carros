using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Vendas.API.Data;
using Sistema_Vendas.API.Models;
//using Sistema_Vendas.API.Models;

namespace Sistema_Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotocicletaController : ControllerBase
    {
        private readonly IRepository _repo;

        public MotocicletaController(IRepository repository)
        {
            _repo = repository;

        }

        [HttpGet]
        public async Task<IActionResult> getMoto() 
        {
            var motos = await _repo.GetMoto();
            if(motos == null) return BadRequest("Nenhuma moto foi encontrada.");

            return StatusCode(StatusCodes.Status200OK, motos);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> getById(int userId) 
        {
            var motos = await _repo.GetMotoById(userId);
            if(motos == null) return BadRequest("Nenhuma moto foi encontrada com esse usuário");

            return StatusCode(StatusCodes.Status200OK, motos);
        }

        [HttpGet("categoria")]
        public async Task<IActionResult> getByCateg(string categoria)
        {
            var motos = await _repo.GetMoto();
            if(motos == null) return BadRequest("Nenhuma moto foi encontrada.");

            motos = motos.Where(m => m.Categoria == categoria).ToArray();

            if(motos == null) return BadRequest("Nenhuma moto foi encontrada nessa categoria.");

            return StatusCode(StatusCodes.Status200OK, motos);
        }

        [HttpGet("marca")]
        public async Task<IActionResult> getByMarca(string marca) 
        {
            var motos = await _repo.GetMoto();

            if(motos == null) return BadRequest("Nenhuma moto foi encontrada.");

            motos = motos.Where(m => m.Marca == marca).ToArray();

            if(motos == null) return BadRequest("Nenhuma moto foi encontrada com essa categoria.");

            return StatusCode(StatusCodes.Status200OK, motos);
        }

        [HttpPost]
        public async Task<IActionResult> createMoto(Motocicleta moto)
        {
            var motos = await _repo.GetMoto();
            if(motos.Contains(moto)) return BadRequest("Essa moto já foi cadastrada.");

            _repo.Add(moto);
            if(_repo.SaveChanges()) return StatusCode(StatusCodes.Status201Created, "Moto cadastrada com sucesso.");

            return BadRequest("Não foi possivel cadastrar a moto");
        }

        [HttpPut]
        public async Task<IActionResult> updateMoto(Motocicleta moto) 
        {
            var motos = await _repo.GetMoto();

            if(motos.Contains(moto) == false) return BadRequest("Essa moto não existe no sistema.");

            _repo.Update(moto);

            if(_repo.SaveChanges()) return StatusCode(StatusCodes.Status200OK, "Moto atualizada com sucesso.");

            return BadRequest("Não foi possivel efetuar a atualização.");
        }

        [HttpDelete]
        public async Task<IActionResult> deleteMoto(Motocicleta moto) 
        {
            var motos = await _repo.GetMoto();

            if(motos.Contains(moto) == false) return BadRequest("Essa moto não existe no sistema.");

            _repo.Delete(moto);

            if(_repo.SaveChanges()) return StatusCode(StatusCodes.Status200OK, "Moto removida com sucesso.");

            return BadRequest("Não foi possivel efetuar a remoção.");
        }

    }
}
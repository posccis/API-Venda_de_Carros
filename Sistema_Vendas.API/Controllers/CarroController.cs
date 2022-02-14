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
    public class CarroController : ControllerBase
    {
        private readonly IRepository _repo;

        public CarroController(IRepository repository)
        {
            _repo = repository;

        }
        [HttpGet]
        public async Task<IActionResult> GetCarros() 
        {
            var carros = await _repo.GetCarros();
            if (carros == null) return BadRequest("Não há carros!");

            return Ok(carros);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> getById(int userId) 
        {
            var carros = await _repo.GetCarroById(userId);
            if(carros == null) return BadRequest("Esse usuario não possui carros ou não existe.");

            return Ok(carros);
        }

        [HttpGet("categoria")]
        public async Task<IActionResult> getByCateg(string categoria)
        {
            var carros = await _repo.GetCarros();
            if(carros == null) return BadRequest("Não há carros.");

            carros = carros.Where(car => car.Categoria == categoria).ToArray();

            if(carros == null) return BadRequest("Essa categoria não possui carros.");

            return Ok(carros);
        }

        [HttpGet("marca")]
        public async Task<IActionResult> getByMarca(string marca) 
        {
            var carros = await _repo.GetCarros();
            if(carros == null) return BadRequest("Não há carros.");

            carros = carros.Where(car => car.Marca == marca).ToArray();

            if(carros == null) return BadRequest("Essa marca não possui carros.");

            return Ok(carros);
        }
        [HttpPost]
        public async Task<IActionResult> postCarro(Carro carro) 
        {
            _repo.Add(carro);
            if(_repo.SaveChanges()) return StatusCode(StatusCodes.Status201Created, "Carro Salvo.");

            return BadRequest("Não foi possivel adicionar o carro.");
        }

        [HttpPut]
        public async Task<IActionResult> updateCarro(Carro carro) 
        {
            var carros = await _repo.GetCarros();
            if(carros.Contains(carro) == false) return BadRequest("Carro não encontrado.");
            
            _repo.Update(carro);

            if(_repo.SaveChanges()) return StatusCode(StatusCodes.Status200OK, "Carro atualizado com sucesso.");

            return StatusCode(StatusCodes.Status400BadRequest, "Não foi possivel atualizar o carro.");
        }

        [HttpDelete]
        public async Task<IActionResult> deleteCarro(int id) 
        {
            var carro = await _repo.GetCarroById(id);
            if(carro == null) return StatusCode(StatusCodes.Status404NotFound, "Carro não encontrado");

            _repo.Delete(carro);

            if (_repo.SaveChanges()) return StatusCode(StatusCodes.Status200OK, "Carro deletado com sucesso.");

            return StatusCode(StatusCodes.Status400BadRequest, "Não foi possivel deletar o carro.");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoque.Context;
using ControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Schema;

namespace ControleDeEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        public readonly Contexto _contexto;

        public ProdutoController(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        // Lista dos produtos
        public IActionResult Index()
        {
            var lista = _contexto.Produto.ToList();
            return View(lista);
        }

       [HttpGet]
        public IActionResult Create()
        {
            var produto = new Produto();
            return View(produto);
        }
        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            // se tudo for valido
            if (ModelState.IsValid)
            {
                _contexto.Produto.Add(produto);
                _contexto.SaveChanges();
                // RedirectToAction retorna para Index inicial
                return RedirectToAction("Index");
            }
            // se nao precher novamente 
            return View(produto);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produto = _contexto.Produto.Find(id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult Delete(Produto _produto)
        {
            var produto = _contexto.Produto.Find(_produto);
            if (produto != null)
            {
                _contexto.Produto.Remove(produto);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(produto);
        }


    }
}

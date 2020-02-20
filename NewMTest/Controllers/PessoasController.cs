using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewMTest.Data.Context;
using NewMTest.Entity;
using NewMTest.Models;
using NewMTest.Services;

namespace NewMTest.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaServices _pessoaService;

        public PessoasController(IPessoaServices pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pesquisa(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            var retorno = (await _pessoaService.GetPessoasQuery().ToListAsync()).ToListModel();
            return Json(retorno);
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var pessoa = await _pessoaService.GetPessoaAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PessoaId,Ativado,Nome,DataNascimento,Endereco,Observacao,CelularId,EmailId,CpfId,DataInclusao,DataEdicao")] Pessoa pessoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pessoa);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CpfId"] = new SelectList(_context.Documentos, "DocumentoId", "DocumentoId", pessoa.CpfId);
        //    ViewData["CelularId"] = new SelectList(_context.Contatos, "ContatoId", "ContatoId", pessoa.CelularId);
        //    ViewData["EmailId"] = new SelectList(_context.Contatos, "ContatoId", "ContatoId", pessoa.EmailId);
        //    return View(pessoa);
        //}

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            ViewData["Title"] = "Editar";

            if (id == 0)
            {
                ViewData["Title"] = "Adicionar";
                return View(new PessoaViewModel());
            }

            var pessoa = await _pessoaService.GetPessoaAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, PessoaViewModel pessoa)
        {
            if (id != pessoa.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (pessoa.PessoaId == 0)
                    {
                        await _pessoaService.InsertPessoaAsync(pessoa);
                    }
                    else
                    {
                        await _pessoaService.UpdatePessoaAsync(pessoa);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_pessoaService.GetPessoaAsync(pessoa.PessoaId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var pessoa = await _pessoaService.GetPessoaAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pessoa = await _pessoaService.DeletePessoaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerificaCPF(string cpf)
        {
            cpf = cpf.Replace("_", " ");
            var valido = CpfCnpjUtils.IsValid(cpf);
            if (!valido)
            {
                return Json($"Cpf {cpf} inválido.");
            }

            return Json(true);
        }

        private async Task<PaginatedList<PessoaViewModel>> Pesquisar(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewData["DataSortParm"] = sortOrder == "Data" ? "data_desc" : "Data";
            ViewData["CpfSortParm"] = sortOrder == "CPF" ? "cpf_desc" : "CPF";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";
            ViewData["EnderecoSortParm"] = sortOrder == "Endereco" ? "endereco_desc" : "Endereco";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var query = _pessoaService.GetPessoasQuery();

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Nome.ToLower().Contains(searchString.ToLower())
                                       || s.Email.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "nome_desc":
                    query = query.OrderByDescending(s => s.Nome);
                    break;
                case "Data":
                    query = query.OrderBy(s => s.DataNascimento);
                    break;
                case "data_desc":
                    query = query.OrderByDescending(s => s.DataNascimento);
                    break;
                case "CPF":
                    query = query.OrderBy(s => s.Cpf);
                    break;
                case "cpf_desc":
                    query = query.OrderByDescending(s => s.Cpf);
                    break;
                case "Email":
                    query = query.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    query = query.OrderByDescending(s => s.Email);
                    break;
                case "Endereco":
                    query = query.OrderBy(s => s.Endereco);
                    break;
                case "endereco_desc":
                    query = query.OrderByDescending(s => s.Endereco);
                    break;
                default:
                    query = query.OrderBy(s => s.Nome);
                    break;
            }

            var quer = query.ToListModel();
            return await PaginatedList<PessoaViewModel>.CreateAsync(quer, pageNumber ?? 1);
        }
    }
}

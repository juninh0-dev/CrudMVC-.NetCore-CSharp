using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using treinandoParaProva.Data;
using treinandoParaProva.Models;
using treinandoParaProva.ViewModels;

namespace treinandoParaProva.Controllers
{
    public class TrabalhoController : Controller
    {
        private readonly IMongoCollection<Trabalho> _trabalhos;

        public TrabalhoController(MongoDbService mongoDbService)
        {
            _trabalhos = mongoDbService.Database
                .GetCollection<Trabalho>("Trabalhos");
        }

        // LISTAR TRABALHOS
        public async Task<IActionResult> Index()
        {
            var trabalhos = await _trabalhos.Find(x => true).ToListAsync();

            var trabalhoviewModel = trabalhos.Select(t => new TrabalhoViewModel
            {
                Id = t.Id,
                Titulo = t.Titulo,
                AreaTematica = t.AreaTematica,

                QuantidadeAutores = t.Autores != null ? t.Autores.Count : 0,

                MediaNotas = t.Avaliacoes != null && t.Avaliacoes.Any() ? t.Avaliacoes.Average(a => a.Nota) : 0}).ToList();

            return View(trabalhoviewModel);
        }

        // GET: Trabalho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trabalho/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trabalho trabalho)
        {
            trabalho.Id = ObjectId.GenerateNewId().ToString();

            trabalho.DataSubmissao = DateTime.Now;

            trabalho.Avaliacoes = new List<Avaliacao>();

            await _trabalhos.InsertOneAsync(trabalho);

            return RedirectToAction(nameof(Index));
        }

        // GET: Trabalho/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
                return NotFound();

            var trabalho = await _trabalhos
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (trabalho == null)
                return NotFound();

            return View(trabalho);
        }

        // POST: Trabalho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var filter = Builders<Trabalho>.Filter.Eq(x => x.Id, id);

            await _trabalhos.DeleteOneAsync(filter);

            return RedirectToAction(nameof(Index));
        }

        // GET: Trabalho/Avaliar/5
        public async Task<IActionResult> Avaliar(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho = await _trabalhos.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }


        // POST: Trabalho/Avaliar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Avaliar(string id, int nota, string comentario)
        {
            // Busca o trabalho completo no Mongo
            var trabalho = await _trabalhos.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (trabalho == null)
            {
                return NotFound();
            }

            // Se não existir lista ainda, cria
            if (trabalho.Avaliacoes == null)
            {
                trabalho.Avaliacoes = new List<Avaliacao>();
            }

            // Cria nova avaliação
            var novaAvaliacao = new Avaliacao
            {
                Nota = nota,
                Comentario = comentario,
                DataAvaliacao = DateTime.Now
            };

            // Adiciona na lista
            trabalho.Avaliacoes.Add(novaAvaliacao);

            // Filtro do documento
            var filter = Builders<Trabalho>.Filter.Eq(x => x.Id, id);

            // Substitui documento inteiro
            await _trabalhos.ReplaceOneAsync(filter, trabalho);

            return RedirectToAction(nameof(Index));
        }

    }
}
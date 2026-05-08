using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using P1_Altair.Data;
using P1_Altair.Models;

namespace P1_Altair.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MongoDbService _mongo;
        private readonly IMongoCollection<Usuario> _usuarios; // Coleção do banco

        public UsuarioController(MongoDbService mongoDb)
        {
            _mongo = mongoDb; // Atribuindo um nome para o banco
            _usuarios = mongoDb.Database?.GetCollection<Usuario>("usuario");
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarios.Find(x => true).ToListAsync();
            return View(usuarios);
        }

        //GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _usuarios.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Clientes/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id, Nome, Senha")] Cliente cliente) //bind são os campos que podem ser enviados
        //{
        //    if (ModelState.IsValid) //verifica as verificações da model, tipo required, ou tamanho mínimo
        //    {
        //        await _clientes.InsertOneAsync(cliente);
        //        return RedirectToAction(nameof(Index)); //redireciona para outro método
        //    }
        //    return View(cliente);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome,Email,Password")] Usuario usuario)  // ← SEM ID!
        {
            usuario.Id = ObjectId.GenerateNewId().ToString();  // ← GERA ID

            await _usuarios.InsertOneAsync(usuario);  // ← Remove if(ModelState) TEMPORARIAMENTE
            return RedirectToAction(nameof(Index));
        }


        // GET: Usuarios/Edit/5

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuarios = await _usuarios.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,Nome,Password")] Usuario usuario)
        {
            if (id != usuario.Id) return NotFound();

            if (ModelState.IsValid) //verifica os inputs da view
            {
                // ✅ VERIFICA resultado do ReplaceOne
                var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);
                var result = await _usuarios.ReplaceOneAsync(filter, usuario);

                if (result.ModifiedCount == 0)  // ← NENHUM documento alterado
                {
                    ModelState.AddModelError("", "Usuario foi alterado por outro usuário.");
                    return NotFound();
                }
                else
                {
                    return RedirectToAction(nameof(Index));  // ✅ MVC correto!
                }
            }

            return View(usuario);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null) { return NotFound(); }

            var usuario = await _usuarios.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (usuario == null) { return NotFound(); }

            return View(usuario);

        }

        //deleta de fato
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);
            await _usuarios.DeleteOneAsync(filter);  // ← Simples assim!
            return RedirectToAction(nameof(Index));
        }


    }

}

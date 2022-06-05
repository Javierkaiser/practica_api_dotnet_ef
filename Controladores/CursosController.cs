namespace SSC.Controladores;

[ApiController]
[Route("[controller]")]
public class CursosController : ControllerBase
{
    private readonly ILogger<CursosController> _logger;
    private readonly SCCContext _db;

    public CursosController(ILogger<CursosController> logger, SCCContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet(Name = "GetCursos")]
    public IEnumerable<Curso> Get()
    {
        return _db.Cursos.ToList();
    }

    [HttpGet("{id}", Name = "GetCurso")]
    public Curso Get(int id)
    {
        return _db.Cursos.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost(Name = "PostCurso")]
    public IActionResult Post([FromBody] Curso curso)
    {
        if (curso == null)
        {
            return BadRequest();
        }

        _db.Cursos.Add(curso);
        _db.SaveChanges();

        return CreatedAtRoute("GetCurso", new { id = curso.Id }, curso);
    }

    [HttpPut("{id}", Name = "PutCurso")]
    public IActionResult Put(int id, [FromBody] Curso curso)
    {
        if (curso == null || curso.Id != id)
        {
            return BadRequest();
        }

        var cursoDb = _db.Cursos.FirstOrDefault(x => x.Id == id);
        if (cursoDb == null)
        {
            return NotFound();
        }

        cursoDb.Nombre = curso.Nombre;
        cursoDb.Instructor = curso.Instructor;
        cursoDb.Costo = curso.Costo;
        cursoDb.Evaluaciones = curso.Evaluaciones;
        cursoDb.Capitulos = curso.Capitulos;

        _db.Cursos.Update(cursoDb);
        _db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteCurso")]
    public IActionResult Delete(int id)
    {
        var cursoDb = _db.Cursos.FirstOrDefault(x => x.Id == id);
        if (cursoDb == null)
        {
            return NotFound();
        }

        _db.Cursos.Remove(cursoDb);
        _db.SaveChanges();

        return NoContent();
    }
}

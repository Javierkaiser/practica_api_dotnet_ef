namespace SSC.Modelos;

public class Curso : ModeloBase
{
    public string Nombre { get; set; }
    public string Instructor { get; set; }
    public float Costo { get; set; }
    public List<Evaluacion> Evaluaciones { get; set; }
    public List<Capitulo> Capitulos { get; set; }
}

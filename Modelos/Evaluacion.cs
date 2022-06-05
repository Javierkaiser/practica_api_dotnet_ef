namespace SSC.Modelos;

public class Evaluacion : ModeloBase
{
    public string Tipo { get; set; }
    public int Nota { get; set; }
    public bool Aprobado { get; set; }
    public int CursoId { get; set; }

}

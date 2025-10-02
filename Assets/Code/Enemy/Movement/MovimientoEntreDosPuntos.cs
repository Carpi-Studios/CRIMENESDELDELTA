using UnityEngine;

public class MovimientoEntreDosPuntos : IMovimiento
{
    private Vector3 PuntoInferior { get; set; }
    private Vector3 PuntoSuperior { get; set; }

    public MovimientoEntreDosPuntos(Vector3 puntoInferior, Vector3 puntoSuperior)
    {
        PuntoInferior = puntoInferior;
        PuntoSuperior = puntoSuperior;
        
    }

    public Vector3 moverse(Transform transform, float speed)
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        return Vector3.Lerp(PuntoInferior, PuntoSuperior, t);
    }
}
using UnityEngine;

public class MovimientoEntreVariosPuntos : IMovimiento
{
    private Vector3[] puntos;
    private int destinoActual = 0;

    public MovimientoEntreVariosPuntos(params Vector3[] puntosEntrada)
    {
        this.puntos = puntosEntrada;
    }

    public Vector3 moverse(Transform transform, float speed)
    {
        Vector3 movimiento = Vector3.MoveTowards(transform.position, puntos[destinoActual], speed * Time.deltaTime);
        if (Vector3.Distance(movimiento, puntos[destinoActual]) < 0.01f)
            destinoActual = (destinoActual + 1) % puntos.Length;

        return movimiento;
    }
}
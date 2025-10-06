using System;
using UnityEngine;
using UnityEngine.AI;

public class ComportamientoEnemigoGenerico
{
    public IComportamientoState State { get; set; }
    public IMovimiento movimiento;
    public NavMeshAgent Agent { get; set; }
    public Transform Transform { get; set; }
    public Transform Objetivo { get; set; }
    public float Speed { get; set; }
    public float RadioDeteccion { get; set; }
    private Vector3[] PuntosMovimientos { get; set; }

    public ComportamientoEnemigoGenerico(NavMeshAgent agent, Transform transform, Transform obj, float speed, float radioDeteccion,
    Vector3[] puntos)
    {
        Agent = agent;
        Transform = transform;
        Objetivo = obj;
        Speed = speed;
        RadioDeteccion = radioDeteccion;
        PuntosMovimientos = puntos;
        State = new QuietoComportamientoState();
    }

    public ComportamientoEnemigoGenerico()
    {
        State = new QuietoComportamientoState();
    }

    public void inicializar()
    {
        movimiento = new MovimientoEntreVariosPuntos(PuntosMovimientos);
    }

    public float distanciaHaciaObjetivo()
    {
        return Vector3.Distance(Transform.position, Objetivo.position); ;
    }
    public Vector3 direccionHaciaObjetivo()
    {
        return Objetivo.position - Transform.position;
    }


    public Boolean enDeteccion()
    {
        if (Physics.Raycast(Transform.position, direccionHaciaObjetivo(), out RaycastHit hit, RadioDeteccion))
            return hit.collider.gameObject.CompareTag("Player");
        return false;
    }

    public void enemigoEncontrado()
    {
        State.enemigoEncontrado(this);
    }
    public void enemigoPerdido()
    {
        State.enemigoPerdido(this);
    }
    public void patrullar()
    {
        State.patrullar(this);
    }
    public void quieto()
    {
        State.quieto(this);
    }
}
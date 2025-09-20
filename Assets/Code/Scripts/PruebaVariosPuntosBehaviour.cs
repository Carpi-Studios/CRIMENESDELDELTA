using UnityEngine;
using UnityEngine.AI;

public class PruebaVariosPuntosBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3[] puntos;
    [SerializeField]
    private float speed;
    private NavMeshAgent agent;
    [SerializeField]
    private float radioDeteccion = 10f;
    [SerializeField]
    private Transform objetoDetectable;
    private ComportamientoEnemigoGenerico comportamientoEnemigo;

    void Start()
    {
        comportamientoEnemigo = new ComportamientoEnemigoGenerico(GetComponent<NavMeshAgent>(),transform,objetoDetectable, speed, radioDeteccion,puntos);
        comportamientoEnemigo.quieto();
    }

    // Update is called once per frame
    void Update()
    {
        if (!comportamientoEnemigo.enDeteccion())
            comportamientoEnemigo.patrullar();
        else
            comportamientoEnemigo.enemigoEncontrado();

    }
}

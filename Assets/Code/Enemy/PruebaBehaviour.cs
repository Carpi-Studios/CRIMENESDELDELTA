using UnityEngine;

public class PruebaBehaviour : MonoBehaviour
{
    private IMovimiento movimiento;
    [SerializeField]
    private Vector3 puntoSuperiorMovimiento;
    [SerializeField]
    private Vector3 puntoInferiorMovimiento;
    [SerializeField]
    private float speed;

    void Start()
    {
        movimiento = new MovimientoEntreDosPuntos(puntoInferiorMovimiento,puntoSuperiorMovimiento);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = movimiento.moverse(transform, speed);
    }
}

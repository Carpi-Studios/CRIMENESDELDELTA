using UnityEngine;

public class Itemrotation : MonoBehaviour
{
    [Tooltip("Velocidad de rotación en grados por segundo")]
    public Vector3 velocidadRotacion = new Vector3(0, 0, 50);

    void Update()
    {
        transform.Rotate(velocidadRotacion * Time.deltaTime);
    }

}

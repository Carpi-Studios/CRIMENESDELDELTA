using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class contenedorSombreroUI : MonoBehaviour
{
    [SerializeField] private VidaUI[] hats;
    [SerializeField] private int vidaActual;

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.A))
        {
            ActivaSombrero(vidaActual);
        }

    }
    private void ActivaSombrero(int vidaActual)
    {
        for (int i = 0; i < hats.Length; i++)
        {
            if (i < vidaActual)
            {
                hats[i].ActiveHat();
            }
            else
            {
                hats[i].DeactiveHat();
            }
        }
       
    }
}

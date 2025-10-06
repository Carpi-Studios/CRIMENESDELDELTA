using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] private Transform _player;

    /// <summary>
    /// Layer for terrain
    /// </summary>
    [SerializeField] private LayerMask terrainInteractionLayer;
    [SerializeField] private float maxDistanceObstruct = 5f;
    // [SerializeField] private float rotationDegres = 90f;
    readonly List<Renderer> unrendered = new();

    void LateUpdate()
    {
        ViewObstructed();
    }

    void ViewObstructed()
    {
        if (unrendered.Count > 0)
            for (int i = unrendered.Count - 1; i >= 0; i--)
            {
                unrendered[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                unrendered.RemoveAt(i);
            }

        RaycastHit[] hits = Physics.RaycastAll(transform.position, _player.position - transform.position, maxDistanceObstruct, terrainInteractionLayer);
        if (hits.Count() > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                Renderer render = hit.collider.GetComponent<Renderer>();
                if (render == null || unrendered.IndexOf(render) > 0)
                    continue;

                if (!hit.collider.gameObject.CompareTag("Player"))
                {
                    unrendered.Add(render);
                    render.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                }
                else
                {
                    render.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
            }
        }
    }


    // void Update()
    // {
    //     if (Input.GetButtonDown("RotateRight"))
    //     {
    //         RotateCamera();
    //     }
    //     if (Input.GetButtonDown("RotateLeft"))
    //     {
    //         RotateCamera(false);
    //     }
    // }

    // void RotateCamera(bool right = true)
    // {
    //     var yRotation = (transform.rotation.y + (right ? 1 : -1) * rotationDegres) % 315;
    //     _player.gameObject.GetComponent<Movement>().AngleCorrection = yRotation;
    //     transform.Rotate(0, yRotation, 0);
    // }
}

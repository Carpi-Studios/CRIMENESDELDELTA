using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] private Transform _player;


    /// <summary>
    /// Layer for terrain
    /// </summary>
    [SerializeField] private LayerMask terrainInteractionLayer;
    [SerializeField] private float maxDistanceObstruct = 5f;
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
}

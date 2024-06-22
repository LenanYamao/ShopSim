using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    // Base for an object that can interact with other objects
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionLayer;
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            CheckInteractable();
        }
    }

    private void CheckInteractable()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, interactionRadius, Vector2.up, 0f, interactionLayer);
        if (hit)
        {
            if (hit.collider.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}

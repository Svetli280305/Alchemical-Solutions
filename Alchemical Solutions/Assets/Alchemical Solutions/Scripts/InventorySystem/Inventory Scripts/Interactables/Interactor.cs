using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform InteractionPoint;
    public LayerMask InteractionLayer;
    public float InteractionPointRadius;

    public bool IsInteraction { get; private set; }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(InteractionPoint.position, InteractionPointRadius, InteractionLayer);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            for(int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders);
                var interactable = colliders[i].GetComponent<IInteractable>();

                if (interactable != null)
                {
                    Debug.Log("Interacting");
                    StartInteraction(interactable);

                }
            }
        }
    }

    void StartInteraction(IInteractable interactable)
    {
        interactable.Interact(this, out bool interactSuccesful);
        IsInteraction = true;
    }

    void EndInteraction()
    {
        IsInteraction = false;
    }
}

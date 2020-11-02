using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Allows the player to interact with Buttons
/// </summary>
[SerializeField]
public class PlayerInteractionScript : MonoBehaviour
{

    public InteractableScript currentFocus;
    public bool useFlage = false;
    // Start is called before the first frame update
    

    public void useInteractable()
    {
        if (currentFocus != null && !useFlage)
        {
            currentFocus.activate();
            useFlage = true;
        }
    }

    public void ResetFlag()
    {
        useFlage = false;
    }



    public void setFocus(InteractableScript i)
    {
        if (currentFocus != null && currentFocus.TryGetComponent(out ButtonInteractableScript b))
        {
            b.setMaterialFrenel(0);
        }
        currentFocus = i;
        if (currentFocus != null && currentFocus.TryGetComponent(out ButtonInteractableScript b2))
        {
            b2.setMaterialFrenel(1);
        }
    }
    
}

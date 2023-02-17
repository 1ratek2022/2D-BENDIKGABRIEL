using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    //detection point
public Transform detectionPoint;
    //detectionr radius
    private const float detectionRadius = 0.2f;
    //detection layer
    public LayerMask detectionLayer;


   
    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput ())
            { //Debug skriver til console om hva som skjer
                Debug.Log("INTERACT");
            }
        }
    }
// her definerer vi InteractInput som E 
    bool InteractInput()
    {

        return Input.GetKeyDown(KeyCode.E);
    }




    bool DetectObject() 
    //her detecter box collider om den er innenfor item layer.
{
    return Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
    
}

}



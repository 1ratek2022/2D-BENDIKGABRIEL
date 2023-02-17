using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    //yOffsett hvis banen er en "vertical pitch" bane altså at  det er viktig å se det som skjer over seg så øk offset verdien.
    public float yOffset = 1f; 
    public Transform target;



    // Update is called once per frame
    void Update()
    {

         Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
         transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
         // her bytter vi kamera posijsonen til det samme som spiller posisjonen   slerp følger vekotren til spiller
    }
}

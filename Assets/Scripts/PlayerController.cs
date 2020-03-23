using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public LayerMask clickable;
    private NavMeshAgent myAgent;
    public Transform selectedTarget;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        selectedTarget = GameObject.FindGameObjectWithTag("StartPos").transform;
    }
    void Update()
    {
        if( Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast (myRay, out hitInfo, 100, clickable))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Shoot ray from mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            bool gotTarget = false; //This is so we can deselect if we didn't click anything
            foreach (RaycastHit hit in hits)
            { //Loop through all the hits
                if (hit.transform.gameObject.layer == 8)
                { //Make a new layer for targets
                  //You hit a target!
                    DeselectTarget(); //Deselect the old target
                    selectedTarget = hit.transform;
                    SelectTarget(); //Select the new target
                    gotTarget = true; //Set that we hit something
                    
                    break; //Break out because we don't need to check anymore
                }
            }
            if (!gotTarget) DeselectTarget(); //If we missed everything, deselect
           
        }
        myAgent.SetDestination(selectedTarget.transform.position);
    }
    void DeselectTarget()
    {
        selectedTarget = null;
    }
    void SelectTarget()
    {
        Debug.Log("Target Selected");
        //myAgent.SetDestination(selectedTarget.transform.position);
    }
}

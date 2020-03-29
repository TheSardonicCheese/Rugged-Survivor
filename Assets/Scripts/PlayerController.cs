using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public LayerMask clickable;
    private NavMeshAgent myAgent;
    public Transform selectedTarget;
    public GameObject target;
    public bool gotTarget = false; //This is so we can deselect if we didn't click anything


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
                DeselectTarget(); //Deselect the old target
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Shoot ray from mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            { //Loop through all the hits
                if (hit.transform.gameObject == GameObject.FindGameObjectWithTag("Animal"))
                { //Make a new layer for targets
                  //You hit a target!
                    DeselectTarget(); //Deselect the old target
                    selectedTarget = hit.transform;
                    target = hit.transform.gameObject;
                    SelectTarget(); //Select the new target
                    gotTarget = true; //Set that we hit something

                    
                    break; //Break out because we don't need to check anymore
                }
            }
            if (!gotTarget) DeselectTarget(); //If we missed everything, deselect

            
        }
        if (gotTarget == true)
        {
            myAgent.SetDestination(target.transform.position);
        }
    }
    void DeselectTarget()
    {
        selectedTarget = null;
        gotTarget = false;
        target = null;
        Debug.Log("Target Deselected");
    }
    void SelectTarget()
    {
        Debug.Log("Target Selected");
        //myAgent.SetDestination(selectedTarget.transform.position);
    }
}

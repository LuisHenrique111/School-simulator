using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    public static teste instance;


    public NavMeshAgent agent;
    public NavigationDestination[] destinations;
    public Transform pontoDeOnibus;

    int currentDestination=0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // agent = GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                agent.SetDestination(hit.point);
            }
        }
        */

        agent.SetDestination(destinations[currentDestination].destination);
        //Debug.Log(destinations[currentDestination].destination);

        if(agent.transform.position.x == destinations[currentDestination].destination.x && agent.transform.position.z == destinations[currentDestination].destination.z)
        {
            currentDestination++;
            if(currentDestination>= destinations.Length)
            {
                currentDestination = 0;
                GameManager.Instance.PerdaFelicidade(5);
            }
        }  
    }
}

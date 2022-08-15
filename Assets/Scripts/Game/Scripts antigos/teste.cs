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
    bool canChangeDestination = true;

    public int salvaAlunos;
    public List<alunoss> quantAlunos = new List<alunoss>();
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
        if(canChangeDestination)
        {
            canChangeDestination = false;
            agent.SetDestination(new Vector3(destinations[currentDestination].destination.x,transform.position.y,destinations[currentDestination].destination.z));
            StartCoroutine(canWalkAgain());
            
        }

        //Debug.Log("X: "+ Mathf.Abs(transform.position.x - destinations[currentDestination].destination.x) + "Z: "+ Mathf.Abs(transform.position.z - destinations[currentDestination].destination.z));

        if(Mathf.Abs( transform.position.x - destinations[currentDestination].destination.x)<= 15 &&Mathf.Abs( transform.position.z -  destinations[currentDestination].destination.z)<= 15)
        {
            agent.isStopped = true;
            canChangeDestination = true;
            currentDestination++;
            if(currentDestination>= destinations.Length)
            {
                currentDestination = 0;
                
            }
        }  
    }

    IEnumerator canWalkAgain()
    {
        yield return new WaitForSeconds(0.5f);
        agent.isStopped = false;

    }
}

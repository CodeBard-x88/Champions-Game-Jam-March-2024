using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class ShipMovment : MonoBehaviour
{
    NavMeshAgent nm;

    [SerializeField]
    private GameObject shipTarget;
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shipTarget != null)
        {
            Vector3 targetPos = new Vector3(shipTarget.transform.position.x, 0, shipTarget.transform.position.z);
            UnityEngine.Debug.Log(targetPos);
            UnityEngine.Debug.Log("Setting Navemsh Agent Destination");
            UnityEngine.Debug.Log("NavMeshAgent Location: "+this.transform.position);
            nm.SetDestination(targetPos);
            UnityEngine.Debug.DrawLine(shipTarget.transform.position, targetPos, color: Color.blue);
        }
        else
        {
            UnityEngine.Debug.Log("Ship Target is null.");
        }
    }
}

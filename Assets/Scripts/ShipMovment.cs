using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class ShipMovment : MonoBehaviour
{
    NavMeshAgent nm;

    [SerializeField]
    private GameObject shipTarget;

    private bool hasnotReached;
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        hasnotReached = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position == shipTarget.transform.position)
        {
            hasnotReached = false;
        }

        if(nm.isActiveAndEnabled && nm.isOnNavMesh && shipTarget != null && hasnotReached)
        {
            Vector3 targetPos = new Vector3(shipTarget.transform.position.x, this.transform.position.y, shipTarget.transform.position.z);
            UnityEngine.Debug.Log(targetPos);
            UnityEngine.Debug.Log("Setting Navemsh Agent Destination");
            UnityEngine.Debug.Log("NavMeshAgent Location: "+this.transform.position);
            nm.SetDestination(targetPos);
            UnityEngine.Debug.DrawLine(shipTarget.transform.position, targetPos, color: Color.blue);
        }
        else
        {
            if (!nm.isActiveAndEnabled)
                UnityEngine.Debug.LogWarning("NavMeshAgent is not active.");
            if (!nm.isOnNavMesh)
                UnityEngine.Debug.LogWarning("NavMeshAgent is not placed on a NavMesh.");
            if (shipTarget == null)
                UnityEngine.Debug.LogWarning("Ship Target is null.");

            if (!hasnotReached)
                UnityEngine.Debug.Log("Ship has reached the island.");
        }
    }
}

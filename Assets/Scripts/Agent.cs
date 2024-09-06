using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Transform target;

    private UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }

    public GameObject FindObjectByTag(string tag)
    {
        GameObject obj = GameObject.FindWithTag(tag);
        return obj;
    }
}
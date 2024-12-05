using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{

    public void BakeMesh(NavMeshSurface nms)
    {
        nms.BuildNavMesh();
    }
}

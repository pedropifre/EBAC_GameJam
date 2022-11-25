using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwGizmos : MonoBehaviour
{
    public Vector3 size;
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = new Color32(255, 120, 20, 170);
        Gizmos.DrawCube(transform.position, size);
    }
}

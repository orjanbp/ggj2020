using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowYPositionOnly : MonoBehaviour
{
    public Transform target;
    float offset;

    private void Awake() {
        offset = target.position.y -  transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y - offset, transform.position.z);
    }
}

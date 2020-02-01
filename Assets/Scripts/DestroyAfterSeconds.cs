using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public void WaitAndDestroy(float seconds) {
        StartCoroutine(WaitAndDestroyRoutine(seconds));
    }

    IEnumerator WaitAndDestroyRoutine(float seconds) {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}

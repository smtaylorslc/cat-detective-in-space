using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    // Destroy throwable when it leaves the screen.
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}

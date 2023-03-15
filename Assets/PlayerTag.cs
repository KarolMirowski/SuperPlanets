using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    private bool hasTrailon = false;

    public bool HasTrailon()
    {
        TrailRenderer tr = GetComponentInChildren<TrailRenderer>();
        
        hasTrailon = true;
        return hasTrailon;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm_TakingAlco : MonoBehaviour
{
    public Transform alcohol;
    public void TakeAlco()
    {
        alcohol.SetParent(transform);
    }
    public void PutAlco()
    {
        alcohol.SetParent(null);
    }

}

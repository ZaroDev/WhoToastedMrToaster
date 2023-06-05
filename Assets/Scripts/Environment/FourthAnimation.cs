using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthAnimation : MonoBehaviour
{
    public GameObject mikes_fork;
    public GameObject kitchen_fork;

    public void TakeFork()
    {
        kitchen_fork.SetActive(false);
        mikes_fork.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject jManager;
    void Awake()
    {
        if (juegoManager.instance == null)
            Instantiate(jManager);
    }
}

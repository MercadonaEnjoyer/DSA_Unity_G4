using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraMov : MonoBehaviour
{
    public Vector3 offset;
    void LateUpdate()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if(jugador != null)
        {
            Vector3 pos = jugador.transform.position;
            Camera.main.transform.position = new Vector3(pos.x, pos.y, offset.z);
        }
    }
}

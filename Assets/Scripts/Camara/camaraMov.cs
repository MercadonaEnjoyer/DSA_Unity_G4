using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camaraMov : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    GameObject jugador;

    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        jugador = tableroManager.instanciaJugador;
    }
    void Update()
    {
        if(jugador != null){
            vCam.Follow = jugador.transform;
        }else
            jugador = tableroManager.instanciaJugador;
    }
}

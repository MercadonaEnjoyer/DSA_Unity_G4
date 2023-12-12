using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine;

public class tableroManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int maximo;
        public int minimo;
        public Count(int min, int max)
        {
            minimo = min;
            maximo = max;
        }
    }
    public int columnas = 8;
    public int filas = 8;
    public Count paredesCount = new Count(5, 9);
    public Count comidaCount = new Count(1, 5);
    public GameObject salida;
    public GameObject Jugador;
    public static GameObject instanciaJugador;
    public GameObject A;
    public GameObject[] tilesSuelo;
    public GameObject[] tilesPared;
    public GameObject[] tilesComida;
    public GameObject[] tilesParedExterior;
    public GameObject[] tilesEnemigo;

    private Transform tableroHolder;
    private List<Vector3> posCelda = new List<Vector3>();

    void InicializarLista()
    {
        posCelda.Clear();

        for (int x = 1; x < columnas - 1; x++)
        {
            for (int y = 1; y < columnas - 1; y++)
            {
                posCelda.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void setUp()
    {
        string tablero = "#######################|#-----OO--------VV----#|#--CC---E---J---S--#";
        tableroHolder = new GameObject("Tablero").transform;
        char tileType;
        int x2 = 0;
        int y2 = 20;
        foreach(char c in tablero)
        {
            GameObject aIniciar;
            GameObject instancia;
            tileType = c;
            switch (tileType)
            {
                case '#':
                    aIniciar = tilesParedExterior[Random.Range(0, tilesParedExterior.Length)];
                    instancia = Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity) as GameObject;
                    instancia.transform.SetParent(tableroHolder);
                    break;
                case '-':
                    aIniciar = tilesSuelo[Random.Range(0, tilesSuelo.Length)];
                    instancia = Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity) as GameObject;
                    instancia.transform.SetParent(tableroHolder);
                    break;
                case 'E':
                    aIniciar = tilesSuelo[Random.Range(0, tilesSuelo.Length)];
                    instancia = Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity) as GameObject;
                    instancia.transform.SetParent(tableroHolder);
                    aIniciar = tilesEnemigo[Random.Range(0, tilesEnemigo.Length)];
                    Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity);
                    break;
                case 'O':
                    aIniciar = tilesSuelo[Random.Range(0, tilesSuelo.Length)];
                    instancia = Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity) as GameObject;
                    instancia.transform.SetParent(tableroHolder);
                    aIniciar = tilesPared[Random.Range(0, tilesPared.Length)];
                    Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity);
                    break;
                case 'C':
                    aIniciar = tilesSuelo[Random.Range(0, tilesSuelo.Length)];
                    instancia = Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity) as GameObject;
                    instancia.transform.SetParent(tableroHolder);
                    aIniciar = tilesComida[Random.Range(0, tilesComida.Length)];
                    Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity);
                    break;
                case 'S':
                    aIniciar = tilesSuelo[Random.Range(0, tilesSuelo.Length)];
                    instancia = Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity) as GameObject;
                    instancia.transform.SetParent(tableroHolder);
                    Instantiate(salida, new Vector3(x2, y2, 0f), Quaternion.identity);
                    break;
                case 'J':
                    aIniciar = tilesSuelo[Random.Range(0, tilesSuelo.Length)];
                    instancia = Instantiate(aIniciar, new Vector3(x2, y2, 0f), Quaternion.identity) as GameObject;
                    instancia.transform.SetParent(tableroHolder);
                    instanciaJugador = Instantiate(Jugador, new Vector3(x2, y2, 0f), Quaternion.identity);
                    break;
                case 'V':
                    break;
                case '|':
                    y2--;
                    x2 = -1;
                    break;
            }
            x2++;
        }
    }
    public void setUpEscena(int nivel)
    {
        setUp();
        InicializarLista();
        Instantiate(A, new Vector3(0, 0, 0), Quaternion.identity);
    }
}

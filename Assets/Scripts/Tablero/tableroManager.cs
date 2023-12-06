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
        public Count (int min, int max)
        {
            minimo = min;
            maximo = max;
        }
    }
    public int columnas = 8;
    public int filas = 8;
    public Count paredesCount = new Count(5,9);
    public Count comidaCount = new Count(1,5);
    public GameObject salida;
    public GameObject Jugador;
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
        tableroHolder = new GameObject("Tablero").transform;
        for (int x = - 1; x < columnas + 1; x++)
        {
            for (int y = - 1; y < columnas + 1; y++)
            {
                GameObject aIniciar = tilesSuelo[Random.Range (0, tilesSuelo.Length)]; 
                if(x == -1 || x == columnas || y == -1 || y == filas)         
                    aIniciar = tilesParedExterior[Random.Range(0, tilesParedExterior.Length)];
                GameObject instancia = Instantiate(aIniciar, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instancia.transform.SetParent(tableroHolder);
            }
        }
    }
    Vector3 posRandom()
    {
        int nRan = Random.Range(0, posCelda.Count);
        Vector3 posRandom = posCelda[nRan];
        posCelda.RemoveAt(nRan);
        return posRandom;
    }
    void colocarObjectoRandom(GameObject[] tileDist, int min, int max)
    {
        int nObjetos = Random.Range(min, max + 1);
        for (int i = 0; i < nObjetos; i++)
        {
            Vector3 pRandom = posRandom();
            GameObject eleccionTile = tileDist[Random.Range(0, tileDist.Length)];
            Instantiate(eleccionTile, pRandom, Quaternion.identity);
        }
    }
    public void setUpEscena(int nivel)
    {
        setUp();
        InicializarLista();
        colocarObjectoRandom(tilesPared, paredesCount.maximo, paredesCount.minimo);
        colocarObjectoRandom(tilesComida, comidaCount.maximo, comidaCount.minimo);
        int nEnemigos = (int)Mathf.Log(nivel, 2f);
        Instantiate(salida, new Vector3(columnas - 1, filas - 1, 0f), Quaternion.identity);
        Instantiate(Jugador, new Vector3(0, 0, 0f), Quaternion.identity);
        colocarObjectoRandom(tilesEnemigo, nEnemigos, nEnemigos);
        Instantiate(A, new Vector3(0, 0, 0), Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juegoManager : MonoBehaviour
{
    public static juegoManager instance = null;
    public tableroManager tableroScript;

    private int level = 3;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
            tableroScript = GetComponent<tableroManager>();
        initGame();
    }
    void initGame()
    {
        tableroScript.setUpEscena(level);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

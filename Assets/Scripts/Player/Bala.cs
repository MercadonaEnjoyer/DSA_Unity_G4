using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Animator anim;
    public GameObject explBala;

    public int damage;
    private void Awake()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explBala, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

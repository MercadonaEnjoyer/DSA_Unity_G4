using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explEnemigo;
    public int vida;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Proyectil"){
            takeDmg(collision.gameObject.GetComponent<Bala>().damage);
        }
    }
    void takeDmg(int damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            Instantiate(explEnemigo, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

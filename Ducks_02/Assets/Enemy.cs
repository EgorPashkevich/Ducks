using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 5;

    public void TakeDamage(int damage) {
        if (Health > damage) {
            Health -= damage;
        } else {
            Destroy(gameObject);
        }
    }
}

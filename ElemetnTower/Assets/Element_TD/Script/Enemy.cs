﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float Health = 100f;
    public float startSpeed = 10f;    
    public float RotationSpeed = 5f;
    
    //[HideInInspector]
    public float Speed;
    public float SlowFactor = 2f;

    private void Start()
    {
        Speed = startSpeed;
    }
    //Damage Method
    public void TakeDamage(float DamageAmount)
    {
        Health -= DamageAmount;
        if (Health <= 0)
        {
            Destroy(gameObject);
            BuildManager.instance.AddMoney();
        }
    }

    public void Slow()
    {
        Speed = startSpeed / 2f;
        Debug.Log(Speed);
    }
   
}
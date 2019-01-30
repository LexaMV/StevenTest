﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {
    public bool flySheep;
    public SpriteRenderer spriteRenderer;
    public float Speed;
    public float Сorrection;
    public GameObject Grass;
    public bool isSheepSelect;

    void Start () {
        isSheepSelect = false;
        Grass = GameObject.Find ("Grass");
        flySheep = true;
        Speed = 0.02f;
    }

    void OnCollisionEnter2D (Collision2D col) {

        if (col.gameObject.name == "BorderBottom") {

            flySheep = false;
            isSheepSelect = false;
            Сorrection = 1.0f;
        }

        if (col.gameObject.name == "BorderLeft") {

            spriteRenderer.flipX = false;
            Сorrection = 1.0f;
        }

        if (col.gameObject.name == "BorderRight") {

            spriteRenderer.flipX = true;
            Сorrection = -1.0f;
        }

        if (col.gameObject.name.Contains ("grass")) {

            if (flySheep == true) {

                foreach (Transform o in Grass.transform) {
                    Physics2D.IgnoreCollision (o.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
                }
            }

            if (flySheep == false) {

                Destroy (col.gameObject);
            }

        }
    }

    public void IsSheepSelect(){
    isSheepSelect = true;
    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    flySheep = true;
    }

    public void IsSheepDeselect(){

    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }

    // Update is called once per frame
    void Update () {
        if (flySheep == false && isSheepSelect == false) {

            gameObject.transform.position = new Vector3 (gameObject.transform.position.x + Speed * Сorrection, gameObject.transform.position.y);
        }
    }
}
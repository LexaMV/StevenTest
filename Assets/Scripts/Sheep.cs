using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {
    public bool flySheep;
    public SpriteRenderer spriteRenderer;
    public float Speed;
    public float Сorrection;
     public float СorrectionInTap;
    public GameObject Grass;
    public bool isSheepSelect;
    public bool repeat;
    public float _gravityScale;

    void Start () {
        _gravityScale = GetComponent<Rigidbody2D>().gravityScale;
        isSheepSelect = false;
        Grass = GameObject.Find ("Grass");
        flySheep = true;
        Speed = 0.02f;
        СorrectionInTap = 0;
    }

    void OnCollisionEnter2D (Collision2D col) {

        if (col.gameObject.name == "BorderBottom") {

            flySheep = false;
            repeat = true;
            isSheepSelect = false;

            if (СorrectionInTap == 0){
            Сorrection = 1.0f;
            }
            else {
                Сorrection = СorrectionInTap;
            }
            
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
    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    GetComponent<Rigidbody2D>().gravityScale = 0;
    isSheepSelect = true;
    flySheep = true;
    repeat = true;
    СorrectionInTap = Сorrection;
 
    }

    public void IsSheepDeselect(){
    GetComponent<Rigidbody2D>().gravityScale = _gravityScale;
    isSheepSelect = true;
    isSheepSelect = false;

    }

    // Update is called once per frame
    void Update () {


        if (flySheep == false && isSheepSelect == false) {

            gameObject.transform.position = new Vector3 (gameObject.transform.position.x + Speed * Сorrection, gameObject.transform.position.y);
        }

        if (flySheep == true && repeat == true){

        foreach (Transform o in Grass.transform) {
        Physics2D.IgnoreCollision (o.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
        }

        repeat = false;

        }

        if (flySheep == false && repeat == true){

        foreach (Transform o in Grass.transform) {
        Physics2D.IgnoreCollision (o.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> (), false);
        }

        repeat = false;

        }
        
    }
}
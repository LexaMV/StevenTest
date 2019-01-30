using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceSheep : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform borderLeft;
    public Transform borderRight;
    public Transform borderBottom;
    public Transform createButton;
    
     public GameObject sheepPrefab;

    public void CreateSheep(){
    float x = Random.Range(borderLeft.position.x+0.25f, borderRight.position.x-0.25f);
    float y = Random.Range(createButton.position.x, borderBottom.position.x);
    Instantiate(sheepPrefab, new Vector2(x,y), Quaternion.identity);
    }
   
   

    // Update is called once per frame
    void Update()
    {
        
    }
}

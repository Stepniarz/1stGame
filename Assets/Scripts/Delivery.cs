using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //Default value of bool is false
    bool hasPackage;
    [SerializeField] float destroyTime = 0.5f;
    Color32 noPackageColor = new Color32(255, 255, 255, 255);
    Color32 hasPackageColor = new Color32(205, 64, 45, 255);
   

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ooof");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && hasPackage == false)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyTime);
        }
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            spriteRenderer.color = noPackageColor;
           hasPackage = false;
        }
    }
}

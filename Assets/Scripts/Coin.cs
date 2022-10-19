using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 0;
  
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            points++;
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Coins : " + points);
    }
}

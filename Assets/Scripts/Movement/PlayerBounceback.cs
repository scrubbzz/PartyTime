using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerBounceback : MonoBehaviour
{
    [SerializeField] float bouncebackForce = 6.8f;
    [SerializeField] float bouncebackHeight = 7.2f;
    //[SerializeField] float randomness = 5;

    Rigidbody rb;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        //if (rb == null)
            //Debug.LogError("This player is missing a Rigidbody component!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //float randomisedBouceForce = Mathf.Abs(Random.Range(bouncebackForce / randomness, bouncebackForce + randomness));
            //float randomisedBouceHeight = Mathf.Abs(Random.Range(bouncebackHeight / randomness, bouncebackHeight + randomness));
            
            Vector3 directionToFling = rb.position - collision.transform.position; // get the direction vector pointing away from the other player
            rb.velocity += directionToFling  * bouncebackForce + new Vector3(0, bouncebackHeight, 0); //multiply with force factor, add to velocity 

            // make sure y speed doesn't go over a certain limit so players don't launch off
            Mathf.Clamp(rb.velocity.y, 0, rb.velocity.y * 2);
        }

    }

    

    /*IEnumerator AddCollisionForce(Rigidbody otherPlayer)
    {
        // get the player's direction relative to the other
        Vector3 directionToFling = otherPlayer.transform.position - transform.position;


        //directionToFling.Normalize();

        // push player in the opposite direction they contacted the other player
        directionToFling.y = bouncebackHeight;
        //rb.AddForce(directionToFling * bouncebackForce); 
        rb.AddForce(new Vector3(directionToFling.x * bouncebackForce,
                                   bouncebackHeight,
                                   directionToFling.z * bouncebackForce), ForceMode.Acceleration);

        yield return new WaitForFixedUpdate();
        AddCollisionForce(otherPlayer);
    }*/
}

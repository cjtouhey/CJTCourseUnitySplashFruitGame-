using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask layerMask; // Layer mask for collision detection
    public GameObject newBallPrefab;
    public int points = 100;

    private Rigidbody2D rb;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source.clip = clip;
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

            if (IsSameLayer(collision.gameObject))
            {
                
             if (rb.velocity.magnitude > collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
             {
                Destroy(gameObject);
             }

             if (rb.velocity.magnitude < collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
             {

                source.PlayOneShot(clip);

                PointManager pointManager = FindObjectOfType<PointManager>();

                if (pointManager != null)
                {
                    pointManager.points += points;
                }

                if (newBallPrefab != null)
                {

                    GameObject newFruit = Instantiate(newBallPrefab, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
             }

            }
        
    }

  
    // Check if the collided object is on the same layer as this object
    private bool IsSameLayer(GameObject otherObject)
    {
        return ((layerMask.value & (1 << otherObject.layer)) != 0);
    }
}

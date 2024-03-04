using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOnClick : MonoBehaviour
{

    public GameObject spawnPoint;
    public bool control;

    void Update()
    {
      

        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                if (!control)
                {
                    BallSelector.selectNextBall = true;
                    StartCoroutine(spawnIt());
                   
                }
            }
        }
    }

    IEnumerator spawnIt()
    {

        control = true;

        GameObject newBall = Instantiate(BallSelector.NextBall, spawnPoint.transform.position, spawnPoint.transform.rotation);

        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();

        float impulseAmount;
        impulseAmount = Random.Range(-10f, 10f);
        var Impulse = (impulseAmount * Mathf.Deg2Rad) * rb.inertia; 
        rb.AddTorque(impulseAmount, ForceMode2D.Impulse); // apply impulse to angular torque

        BallSelector.ballCleanUp.Add(newBall);

        yield return new WaitForSecondsRealtime(1);

        control = false;

        yield return null; 
    }
}

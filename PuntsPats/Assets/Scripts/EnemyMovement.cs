using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public AIPath aIPath;
    Vector2 direction;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        //this.transform.LookAt(player.transform);
    }

    void FixedUpdate() 
    {
      
    }

    void LookAtPlayer() 
    {
        //direction = aIPath.desiredVelocity;
        //transform.right = direction;

        /*Vector2 enemyDir = player.transform.position - gameObject.transform.position;
        float angle = (Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg);
        float rotationSpeed = 1f;
        Rigidbody2D enemyRb = gameObject.GetComponent<Rigidbody2D>();
        enemyRb.rotation = Mathf.Lerp(enemyRb.rotation, angle, rotationSpeed);*/

        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}

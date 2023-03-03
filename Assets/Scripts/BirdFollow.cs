using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollow : MonoBehaviour
{
    Rigidbody physic;
    Rigidbody balloonphysic;
    [SerializeField] private int direction;
    [SerializeField] private float NextSpawn = 10f;
    private float wait = 20f;
    [SerializeField] float horizontalspeed;
    [SerializeField] float verticalspeed;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        physic = GetComponent<Rigidbody>();
        balloonphysic = Player.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if(Time.time > NextSpawn)
        {
            NextSpawn = Time.time + wait;
            GetPosition();
        }
        if (Player != null)
        {
            if (Player.transform.position.y > transform.position.y)
            {
                physic.velocity = new Vector3(direction * horizontalspeed , verticalspeed * Mathf.Abs(balloonphysic.velocity.y), 0);
            }
            else if (Player.transform.position.y < transform.position.y)
            {
                physic.velocity = new Vector3(direction * horizontalspeed, -verticalspeed * Mathf.Abs(balloonphysic.velocity.y), 0);
            }
        }
    }

    private void GetPosition()
    {
        gameObject.SetActive(true);
        gameObject.transform.LookAt(Player.transform);
        Vector3 playerpos = Player.transform.position;
        int dir = direction * -1;
        Vector3 birdpos = new Vector3(playerpos.x + dir * 15, playerpos.y, playerpos.z);
        transform.position = birdpos;
    }
}

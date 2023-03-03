using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private BalloonController balloonController;

    private void Start()
    {
        balloonController = GameObject.FindObjectOfType<BalloonController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bird")
        {
            CanvasManager.Instance.GameOver();
        }
        else if (gameObject.GetComponent<Rigidbody>().velocity.y < balloonController.FastValue)
        {
            CanvasManager.Instance.GameOver();
        }
        else
        {
            CanvasManager.Instance.GameCompleted();
        }

    }
}

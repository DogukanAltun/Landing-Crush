using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField] public int FastValue = -50;
    [SerializeField] public int SlowValue = -30;
    [SerializeField] private int Xmin = -5;
    [SerializeField] private int Xmax = 3;
    [SerializeField] private int Ymax = 500;
    [SerializeField] private int Ymin = -5;
    [SerializeField] private int SpeedForce = 1;
    private Rigidbody rb;
    private Vector3 upForce;
    private Animator animator;
    private CanvasManager canvasManager;
    private bool isFast = false;
    private bool isSlow = false;
    private int Height;
    public int height { get { return Height; } set { Height = value; } }
    void Start()
    {
        animator = transform.GetChild(0).transform.GetComponent<Animator>();    
        canvasManager = GameObject.FindObjectOfType<CanvasManager>();
        Height = ((int)transform.position.y);
        canvasManager.heightSlider.maxValue = Height;
        upForce = new Vector3(0,SpeedForce, 0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Height = ((int)transform.position.y);
        UpForce();
        HorizontalMove();
        SpeedController();
    }
    private void SpeedController()
    {
        if (rb.velocity.y < FastValue && isFast == false)
        {
            isFast = true;
            canvasManager.heightText.color = Color.red;
            Falling();
        }
        else if (rb.velocity.y >= SlowValue && isSlow == false)
        {
            isSlow = true;
            canvasManager.heightText.color = Color.green;
            Flying();
        }
        else if (rb.velocity.y <= SlowValue && rb.velocity.y > FastValue)
        {
            isSlow = false;
            isFast = false;
            canvasManager.heightText.color = Color.yellow;
        }
    }
    private void Falling()
    {
        animator.SetTrigger("Falling");
    }

    private void Flying()
    {
        animator.SetTrigger("Flying");
    }
    private void HorizontalMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal * 10, 0, 0);
        rb.AddForce(movement);
        Vector3 position = new Vector3(Mathf.Clamp(rb.position.x, Xmin, Xmax), Mathf.Clamp(rb.position.y, Ymin, Ymax), 0);
        rb.position = position;
        if(rb.position.x == Xmax && rb.position.x == Xmin)
        {
            rb.velocity = new Vector3(0,0,0);
        }
        else if(rb.position.y == Ymax)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
    private void UpForce()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(upForce);
            var EmissionMode = gameObject.GetComponent<ParticleSystem>().emission;
            EmissionMode.enabled = true;
        }
        else
        {
            var EmissionMode = gameObject.GetComponent<ParticleSystem>().emission;
            EmissionMode.enabled = false;
        }
    }

}

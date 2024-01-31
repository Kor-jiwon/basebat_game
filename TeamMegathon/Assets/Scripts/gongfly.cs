using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gongfly : MonoBehaviour
{
    // Start is called before the first frame update
    public float flyangle;
    public float flypower;
    public float flyspeed;
    public float animSpeed = 1f;
    public float score;
    public Animator animator;
    void Start()
    {
        flypower = -(RotateOnClick.bally - 3)/1.6f;
        if (BallMovement.randomSign < 0 && RotateOnClick.mousex < 0)
        {
            flyangle = Random.Range(-42f, 42f);
            score = flypower * 20;
        }
        else if ((BallMovement.randomSign > 0 && RotateOnClick.mousex > 0))
        {
            flyangle = Random.Range(-42f, 42f);
            score = flypower * 20;
        }
        else if ((BallMovement.randomSign > 0 && RotateOnClick.mousex < 0))
        {
            flyangle = Random.Range(50f, 90f);
            score = flypower * 10;
        }
        else if ((BallMovement.randomSign < 0 && RotateOnClick.mousex > 0))
        {
            flyangle = Random.Range(-50f, -90f);
            score = flypower * 10;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (flyangle >= 0)
        {
            GameObject.Find("gong").transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Sin(flyangle * 3.14f / 180) * flypower, Mathf.Cos(flyangle * 3.14f / 180) * flypower - 1.4f, 0), flyspeed/100);
        }
        if (flyangle < 0)
        {
            GameObject.Find("gong").transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Sin(flyangle * 3.14f / 180) * flypower, Mathf.Cos(flyangle * 3.14f / 180) * flypower - 1.4f, 0), flyspeed/100);
        
        }
        if (!(GameObject.Find("gong").transform.position == new Vector3(Mathf.Sin(flyangle * 3.14f / 180) * flypower, Mathf.Cos(flyangle * 3.14f / 180) * flypower - 1.4f, 0) || GameObject.Find("gong").transform.position == new Vector3(Mathf.Sin(flyangle * 3.14f / 180) * flypower, Mathf.Cos(flyangle * 3.14f / 180) * flypower - 1.4f, 0)))
        {
            animator.speed = animSpeed;
        }
        else 
        {
            animator.speed = 0;
        }
    }   
}

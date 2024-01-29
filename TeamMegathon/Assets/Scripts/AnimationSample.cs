using UnityEngine;

public class AnimationSpeedExample : MonoBehaviour
{
    public float animSpeed = 1.0f;
    public Animator animator;

    void Update()
    {
        animator.speed = animSpeed;
    }
}
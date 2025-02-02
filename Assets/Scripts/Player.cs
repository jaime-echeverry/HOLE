using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveVelocity;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private InputManagerSO inputManager;
    [SerializeField] private float dashingPower = 10f;
    [SerializeField] private float dashingTime = 0.01f;
    [SerializeField] private float dashingCoolDown = 0f;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource whoosh;

    public ParticleSystem dust;
    public ParticleSystem vDust;

    private Rigidbody2D rb;
    private bool canDash = true;
    private Vector3 dirMovement;
    private float originalGravity = 1f;


    public float dashDistance = 2f;   // Distancia exacta del dash (2 bloques)
    public float dashTime = 0.2f;     // Tiempo que dura el dash
    private bool isDashing = false;
    private float stopPercentage = 0.4f;


    private void OnEnable()
    {
        inputManager.OnDashLeft += DashLeft;
        inputManager.OnDashRight += DashRight;
        inputManager.OnMomentum += Momentum;
        inputManager.OnDirection += Direction;
    }

    private void Momentum()
    {
        animator.SetTrigger("momentum");
        StartCoroutine(PauseMomentum());
        vDust.Play();
    }

    private void DashRight()
    {
        if (!isDashing)
        {
            whoosh.Play();
            dust.Play();
            animator.SetTrigger("right");
            StartCoroutine(DashCoroutine(1));
        }
    }

    private void DashLeft()
    {
        if (!isDashing)
        {
            whoosh.Play();
            dust.Play();
            animator.SetTrigger("left");
            StartCoroutine(DashCoroutine(-1));
        }
    }

    private void Direction(Vector2 ctx)
    {
        //Debug.Log(ctx.x);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator DashCoroutine(int direction)
    {
        isDashing = true;
        float elapsedTime = 0f;
        Vector2 startPosition = rb.position;
        Vector2 targetPosition = startPosition + new Vector2(dashDistance * direction, 0);

        // Desactivar gravedad mientras dura el dash
        rb.gravityScale = 0;
        //trailRenderer.emitting = true;
        while (elapsedTime < dashTime)
        {
            elapsedTime += Time.deltaTime;
            rb.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / dashTime);
            yield return null;
        }
        Debug.Log("velocidad:"+rb.velocity.y);
        rb.velocity = new Vector2(0f, rb.velocity.y-rb.velocity.y*stopPercentage);
        //trailRenderer.emitting = false;

        // Asegurar que la posición final sea exacta
        rb.position = targetPosition;

        // Restaurar la gravedad
        rb.gravityScale = originalGravity;
        yield return new WaitForSeconds(dashingCoolDown);
        isDashing = false;
    }

    private IEnumerator PauseMomentum()
    {
        whoosh.Play();
        canDash = false;
        rb.velocity = new Vector2(0, 2f);
        //trailRenderer.emitting = true;
        yield return new WaitForSeconds(0.25f);
        whoosh.Play();
        vDust.Play();
        rb.velocity = new Vector2(0, 3f);
        //.emitting = false;
        rb.gravityScale = originalGravity;
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rocks")
        {
            animator.SetTrigger("isDead");
            Debug.Log("collision");
        }
    }

}

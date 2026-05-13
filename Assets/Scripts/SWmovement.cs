using UnityEngine;

public class SWmovement : MonoBehaviour
{
    public float speed = 3f;
    public float detectionRadius = 9f;   
    public float stopDistance = 0.7f;
    public int damage = 10;
    float damageCooldown = 0.5f;
    float lastDamageTime = 0f;

    Transform player;
    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }

        float dist = Vector2.Distance(rb.position, player.position);
        if (dist > detectionRadius)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }

        if (dist <= stopDistance)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("Speed", speed);

        GetComponent<SpriteRenderer>().flipX = dir.x < -0.01f;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if(Time.time >= lastDamageTime + damageCooldown)
        {
            PlayerDeath hp = other.GetComponent<PlayerDeath>();
                if (hp != null)
                {
                    hp.TakeDamage(damage);
                    lastDamageTime = Time.time;
                }
        }
    }  
}
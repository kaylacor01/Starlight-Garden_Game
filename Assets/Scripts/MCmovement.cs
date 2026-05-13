using UnityEngine;

public class MCmovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameSettings.Load();
        speed = GameSettings.PlayerSpeed;
    }

    void Update()
    {
        speed = GameSettings.PlayerSpeed;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        body.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (horizontalInput != 0)
            spriteRenderer.flipX = horizontalInput < 0;

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        
    }
}
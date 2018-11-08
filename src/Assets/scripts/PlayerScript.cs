using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    // game level status indicators
    public bool levelPassed = false;
    private bool power_acquired = false;

    // The Collection of UI hearts that display the hp of the player.
    public GameObject[] hearts;

    public GameObject messagebox;
    public GameObject passMessage;
    public GameObject failMessage;

    // initializes the player to be facing left (example: level 1)
    public bool dir_right = false;

    // designer physics variables
    public Vector2 speed = new Vector2(50, 0);
    public float jumpForce = 7;

    // relavent game objects
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private RaycastHit2D hit;
    private Animator ani;
    public GameObject goal;
    private Component[] sr;
    private SpriteRenderer messageboxR;
    private SpriteRenderer passR;
    private SpriteRenderer failR;
    public GameObject[] passButtons;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponentsInChildren<SpriteRenderer>();
        messageboxR = messagebox.GetComponent<SpriteRenderer>();
        passR = passMessage.GetComponent<SpriteRenderer>();
        failR = failMessage.GetComponent<SpriteRenderer>();
        messageboxR.enabled = false;
        passR.enabled = false;
        failR.enabled = false;
        if (passButtons != null)
        {
            foreach (GameObject temp in passButtons)
            {
                temp.GetComponent<Image>().enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (levelPassed)
        {
            messageboxR.enabled = true;
            passR.enabled = true;
            if (passButtons != null)
            {
                foreach (GameObject temp in passButtons)
                {
                    temp.GetComponent<Image>().enabled = true;
                }
            }
            Time.timeScale = 0;
            // TODO buttons such as next level and menu.
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detects if the character is moving right. If it is, flips it
        // horizontally.
        bool flip = Input.GetKeyDown(KeyCode.RightArrow);
        if (flip)
        {
            dir_right = true;
            foreach (SpriteRenderer childsr in sr)
            {
                childsr.flipX = true;
            }
            ani.SetBool("left", false);
            ani.SetBool("right", true);
        }

        // Detects if the character is moving left. If it is, unflips it
        // horizontally.
        bool unflip = Input.GetKeyDown(KeyCode.LeftArrow);
        if (unflip)
        {
            dir_right = false;
            foreach (SpriteRenderer childsr in sr)
            {
                childsr.flipX = false;
            }
            ani.SetBool("left", true);
            ani.SetBool("right", false);
        }

        // moving horizontally
        float inputX = Input.GetAxis("Horizontal");
        if (!inputX.Equals(0))
        {
            rb.velocity = new Vector2(speed.x * inputX, rb.velocity.y);
        }
        //else {
        //    ani.SetBool("left", false);
        //    ani.SetBool("right", false);
        //}

        // jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce * (float)1.88,
                        ForceMode2D.Impulse);
        }

        // dropping a stack of books (usually used for holding buttons)
        bool drop = Input.GetKeyDown("space");

        if (drop)
        {
            DropScript drop2 = GetComponent<DropScript>();
            if (drop2 != null)
            {
                drop2.Drop();
            }
        }

        // shooting a book at an enemy (attacking)
        bool shoot = Input.GetKeyDown(KeyCode.RightShift);

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }

    }

    /* Checks if the player is touching the ground.
     * return true if player is on ground, false otherwise.
     * Currnetly used for determining whether the player can jump.
     */
    bool isGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    //private void FixedUpdate()
    //{
    //       if (levelPassed){
    //           Debug.Log("Level Passed");
    //       }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the collision object is a gem, picks it up and marks the
        // gem boolean as true.
        GemScript gem = collision.gameObject.GetComponent<GemScript>();
        if (gem != null)
        {
            power_acquired = true;
            Animator goalAni = goal.GetComponent<Animator>();
            if (goalAni != null)
            {
                goalAni.SetBool("goalReached", true);
            }
            // TODO implement what happens when power_acquired is true.
            Destroy(gem.gameObject);
        }

        // If the player touches the goal, first check if player has the gem
        // If the player has the gem, then level is cleared.
        // If not, then throw some kind of message to remind player to pick
        // up the gem.
        GoalScript goal1 = collision.gameObject.GetComponent<GoalScript>();
        if (goal1 != null)
        {
            if (power_acquired)
            {
                Collider2D goalCol = goal.GetComponent<Collider2D>();
                // TODO Player animation of goal reached
                levelPassed = true;
                goalCol.enabled = false;
            }
        }

        // If the player touches hell fire before the player successfully
        // kills it with water, the player dies. Instantly.
        FireScript fire = collision.gameObject.GetComponent<FireScript>();
        if (fire != null)
        {
            GetComponent<HealthScript>()
                .Damage(GetComponent<HealthScript>().hp);
            foreach (GameObject heart in hearts)
            {
                if (heart != null)
                {
                    Destroy(heart);
                }
            }
        }

        // Checks if the player bumps into an enemy and reduces hp for both
        // sides accordingly.
        bool damagePlayer = false;
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(1);
            }
            damagePlayer = true;
        }

        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.Damage(1);

                // Destroys one heart if player is damaged by 1.
                Destroy(hearts[playerHealth.hp]);
            }
        }
    }

}

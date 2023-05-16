using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 15f;

        private int lives = 3;
    
        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        [SerializeField] float cooldown;
        public Transform firepoint;
        public GameObject fireball;
        private float stockcooldown;
        public static bool isRight;

        private float startHealth;
        public float health;
        private int jumpLimit;

        public bool appleEaten;

        [SerializeField] Image Skillcooldown;
        [SerializeField] Text healthbar;
        [SerializeField] GameObject wall;
        [SerializeField] Transform walls;

        [SerializeField] Text livess;
        public int healthtext;

        [SerializeField] GameObject gameover;
        [SerializeField] GameObject pause;
        [SerializeField] GameObject endgame;
        




        void Start()
        {
            startHealth = health;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            stockcooldown = cooldown;
            appleEaten = false; 
            gameover.SetActive(false);
            pause.SetActive(false);
            endgame.SetActive(false);
            Time.timeScale = 1f;
        }

        private void Update()
        {   
            if(Input.GetKeyDown(KeyCode.R) && health<=0f)
            {
                Restart();
            }
            if(lives==0 && health<=0f)
            {
                gameover.SetActive(true);
            }
            if (alive)
            {
                Pause();
                Attack();
                Jump();
                Run();
                Wall();
            }
            healthtext = (int)health;
            cooldown -= Time.deltaTime;
            cooldown = Mathf.Clamp(cooldown, 0f, cooldown);
            health = Mathf.Clamp(health, 0f, startHealth);
            Skillcooldown.fillAmount = cooldown;
            healthbar.text = "HP:"+healthtext.ToString();
            livess.text = "Lives: "+lives.ToString();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
            jumpLimit = 0;
        }
        private void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "EndGame")
            {
                End();
            }
        }
        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
                isRight = false;
                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;
                isRight = true;
                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {   
            if(jumpLimit==2)
            {
                return;
            }
            if ((Input.GetButtonDown("Jump")))
            {
                anim.SetBool("isJump", true);
                 rb.velocity = Vector2.zero;
                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
                jumpLimit++;
            }
        }
        void Attack()
        {   
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(cooldown<=0f)
                {
                    anim.SetTrigger("attack");
                    Instantiate(fireball, firepoint.position, firepoint.rotation);
                    cooldown = stockcooldown; 
                }else
                {
                    Debug.Log("Skill Cooldown");
                }
            }
        }
        void Wall()
        {
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                Instantiate(wall, walls.position, walls.rotation);
            }
            if(Input.GetKeyUp(KeyCode.Alpha2))
            {
                GameObject[] wallers = GameObject.FindGameObjectsWithTag("Skywall");
                foreach(GameObject walls in wallers)
                Destroy(walls);
            }
        }
        public void Hurt(float damage)
        {   
            health -= damage;
            anim.SetTrigger("hurt");
            if (direction == 1)
                rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            if(health<=0f)          
                Die();
        }
        void Die()
        {
            
                anim.SetTrigger("die");
                alive = false;
        }
        void Restart()
        {   
                if(lives==0 && health<=0f)
                {
                    return;
                }
                health = startHealth;
                anim.SetTrigger("idle");
                alive = true;
                lives--;
        }

        public void appleEateed()
        {
            appleEaten = true;
            health = startHealth;
            Debug.Log("Apple eaten!");
        }

        public void Retry(string scenename)
        {
            SceneManager.LoadScene(scenename);
        }
        void Pause()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                pause.SetActive(true);
            }
        }
        public void Continue()
        {
            Time.timeScale = 1f;
            pause.SetActive(false);
        }
        void End()
        {
            if(appleEaten == true)
            {
                endgame.SetActive(true);
                Menu.isLevel1done = true;
            }
        }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public float initialSpeed = 10.0f;
    public float maxSpeed = 30;
   // public static float acceleration = GameSettings.PlayerAcceleration;
    public float turnSpeed = 5;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public bool shielded = false;
    public int shieldDuration = 5;
    public GameObject playerObject;
    public GameObject levelControl;
    public GameObject timerCountDown;
    public GameObject timerDisplay;
    public GameObject healthDisplay;
    public float currentSpeed;

    void Start()
    {
        currentSpeed = initialSpeed;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        CheckHealth();
    }

    public void HealHealth(int heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        else
        {     
            currentHealth += heal;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            // 禁用玩家移动并触发游戏结束逻辑
            this.enabled = false;
            
            playerObject.GetComponent<Animator>().Play("Defeat");
            levelControl.GetComponent<EndRunSequence>().enabled = true;
            timerCountDown.GetComponent<TimerCountDown>().enabled = false;
            timerDisplay.SetActive(false);
            healthDisplay.SetActive(false); 
            // 这里可以添加游戏结束逻辑，比如显示游戏结束界面等
            Debug.Log("Game Over");
        }
    }

    public void Shield()
    {
        StartCoroutine(ShieldRoutine());
    }

    private IEnumerator ShieldRoutine()
    {
        shielded = true;
        GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(shieldDuration);
        GetComponent<PlayerMove>().shielded = false;
        GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {
       // Debug.Log(acceleration);
        Debug.Log(GameSettings.PlayerAcceleration);
        if (currentSpeed < maxSpeed )
        {
            currentSpeed += GameSettings.PlayerAcceleration * Time.deltaTime;
        }

        //Move the player forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.World);

        if (timerCountDown.GetComponent<TimerCountDown>().secondsLeft == 0)
        {
            // 禁用玩家移动并触发游戏结束逻辑
            this.enabled = false;
            
            playerObject.GetComponent<Animator>().Play("Victory");
            levelControl.GetComponent<EndRunSequence>().enabled = true;
            timerCountDown.GetComponent<TimerCountDown>().enabled = false;
            timerDisplay.SetActive(false);
            healthDisplay.SetActive(false);
            // 这里可以添加游戏结束逻辑，比如显示游戏结束界面等
            Debug.Log("Victory");
        }

        //Keep player in the Boundary
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftside)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * turnSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightside)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * turnSpeed * -1);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                //Testing Damage
                //TakeDamage(2);

                if (isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Running Jump");
                    StartCoroutine(JumpSequence());
                }
            }

        }


        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }

            if (comingDown == true)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
            }

        }
    }


    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
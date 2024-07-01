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
    public float acceleration = 0.1f;
    public float turnSpeed = 4;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
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


    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            // ��������ƶ���������Ϸ�����߼�
            this.enabled = false;
            levelControl.GetComponent<LevelDistance>().enabled = false;
            playerObject.GetComponent<Animator>().Play("Breathing Idle");
            levelControl.GetComponent<EndRunSequence>().enabled = true;
            timerCountDown.GetComponent<TimerCountDown>().enabled = false;
            timerDisplay.SetActive(false);
            healthDisplay.SetActive(false); 
            // �������������Ϸ�����߼���������ʾ��Ϸ���������
            Debug.Log("Game Over");
        }
    }

    void Update()
    {
        if (currentSpeed < maxSpeed )
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        //Move the player forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.World);



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
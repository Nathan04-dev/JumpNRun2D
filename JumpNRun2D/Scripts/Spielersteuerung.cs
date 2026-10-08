using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;

public class Spielersteuerung : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public AudioSource jumpSound;

    private bool istAmBoden;
    private int sprungzaehler;

    private SpriteRenderer spriteRenderer;
    public Sprite SpielerGehen;
    public Sprite SpielerSprung;
    public Sprite SpielerNormal;
    public Sprite SpielerFallen;
    

    public GameObject Verlorentxt;

    void Start()
    {

     rb = GetComponent<Rigidbody2D>();
     spriteRenderer = GetComponent<SpriteRenderer>();
     animator = GetComponent<Animator>();
     Verlorentxt.SetActive(false);

    }


    void Update()
    {
    
        if (Keyboard.current.spaceKey.wasPressedThisFrame && sprungzaehler < 3) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6f);
            spriteRenderer.sprite = SpielerSprung;
            sprungzaehler++;
            istAmBoden = false;
            if (jumpSound != null)
            {
                jumpSound.Play();
            }
        } 
  
         if (!istAmBoden && rb.linearVelocity.y < -0.1f)
         {
            spriteRenderer.sprite = SpielerFallen;
        }
       
         if(Keyboard.current.aKey.isPressed) {
            spriteRenderer.flipX = true;
            rb.linearVelocity = new Vector2(-2f, rb.linearVelocity.y);
            if(istAmBoden) { 
            spriteRenderer.sprite = SpielerGehen;
            }
        } else if (Keyboard.current.dKey.isPressed) {
            spriteRenderer.flipX = false;
            rb.linearVelocity = new Vector2(2f, rb.linearVelocity.y);
            if (istAmBoden)
            {
                spriteRenderer.sprite = SpielerGehen;
            }
      
        }
        if(rb.linearVelocity.y == 0 && rb.linearVelocity.x == 0)
        {
            spriteRenderer.sprite = SpielerNormal;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            istAmBoden = true;
            sprungzaehler = 0;
            spriteRenderer.sprite = SpielerNormal;
       
        }
        if(collision.gameObject.CompareTag("Hinderniss"))
        {
            if(rb.position.y > collision.transform.position.y + 0.5f)
            {
              
                istAmBoden = false;
                sprungzaehler = 1;
                spriteRenderer.sprite = SpielerNormal;
            }
         
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.gameObject.CompareTag("TodesZone"))
        {
            istAmBoden = false;
            Verlorentxt.SetActive(true);
            SceneManager.LoadScene("LoadScene");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    //starting health of the player
    public int health;
    //total hearts visible in the scene view
    public int numHearts = 10;
    //10 hearts are created on canvas as raw image and used in this array
    public RawImage[] hearts;
    public GameManager gameManager;
    Transform attackTarget;

    private void Start()
    {
        attackTarget = GetComponent<Transform>();
    }

    private void Update()
    {
        //to make sure the player doesnt have more health than
        //number of hearts (useful while using health pickups)
        if(health > numHearts)
        {
            health = numHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage()
    {
        if (numHearts == 1)
        {
            gameManager.GameOver();
        }
        else
        {
            //redScreenUI.SetActive(true);
            gameManager.RedScreen();
            numHearts--;
            StartCoroutine(CloseRedScreen());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("life"))
        {
            if (numHearts == 10)
            {
                
            }
            else if (numHearts == 9)
            {
                numHearts += 1;
            }
            else if (numHearts == 3)
            {
                numHearts += 2;
            }
            else
            {
                numHearts += 3;
            }
        }
    }

    private IEnumerator CloseRedScreen()
    {
        yield return new WaitForSeconds(0.5f);
        gameManager.NormalScreen();
    }
}

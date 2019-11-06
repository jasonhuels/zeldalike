using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartManager : MonoBehaviour
{
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite halfFullHeart;
	public Sprite emptyHeart;
	public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
		InitHearts();
    }

    public void InitHearts()
	{
        for(int i = 0; i < heartContainers.initialValue; i++)
		{
			hearts[i].gameObject.SetActive(true);
			hearts[i].sprite = fullHeart;
		}
	}

    public void UpdateHearts()
    {
        int currentHealth = (int)playerCurrentHealth.RunTimeValue;
        if (currentHealth == 0)
        {
            hearts[0].sprite = emptyHeart;
            hearts[1].sprite = emptyHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 1)
        {
            hearts[0].sprite = halfFullHeart;
            hearts[1].sprite = emptyHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 2)
        {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = emptyHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 3)
        {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = halfFullHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 4)
        {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 5)
        {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = halfFullHeart;
        } 
        else if (currentHealth == 6)
        {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = fullHeart;
        }
    }

    public void Update()
    {
        UpdateHearts();
        //only needs to be called when it actually changes
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerCurrentHealth.RunTimeValue -= 1;
            Debug.Log(playerCurrentHealth.RunTimeValue);
        }
        
    }
}



//5 > 2.5 0 full 1 full 2 half

//4 > 2 > 0 full 1 full 2 empty



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
        float tempHealth = playerCurrentHealth.RunTimeValue / 2;
        for (int i =0; i < heartContainers.initialValue; i++)
        {
            if( i <= tempHealth - 1)
            {
                hearts[i].sprite = fullHeart;
            } else if ( i >= tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].sprite = halfFullHeart;
            }
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



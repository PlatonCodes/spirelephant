﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
 

public class makeBigger : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	
	GameObject Player;
	PlayerScript playerScript;
	GameObject startGame;
	// Start is called before the first frame update
	void Start()
	{
		startGame = GameObject.Find("stuffToStart");  
        Player = GameObject.Find("Player"); 
        playerScript = Player.GetComponent<PlayerScript>();
		spriteRenderer=GetComponent<SpriteRenderer>();
		if(name=="startLevel")
		{
			Time.timeScale = 0;
			
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnMouseOver()
    {
		
		if(name=="ContGame")
		{
			if(spriteRenderer.material.GetFloat("_GrayscaleAmount")!=1)
			{
				transform.localScale=new Vector3(1.5f,1.5f,0f);
				
			}
		}
		
		if((name=="save")||(name=="elephantopedia"))
		{
			transform.localScale=new Vector3(.35f,.35f,0f);
			
		}
		else if (name=="pointer")
		{
			transform.localScale=new Vector3(2f,2f,0f);
			
		}
		else if (name!="ContGame")
		{
			transform.localScale=new Vector3(1.5f,1.5f,0f);
			
		}
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
		if((name=="save")||(name=="elephantopedia"))
		{
			transform.localScale=new Vector3(.25f,.25f,0f);
			
		}
		else if (name=="pointer")
		{
			transform.localScale=new Vector3(1.5f,1.5f,0f);
			
		}
		else
		{
			transform.localScale=new Vector3(1f,1f,0f);
			
		}
    }
	
	void OnMouseDown()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //SceneManager.LoadScene("waterLevel");
		if (name=="pointer")
		{
			SceneManager.LoadScene("menuScreen");
			
		}
		if (name=="elephantopedia")
		{
			SceneManager.LoadScene("facts");
			
		}
		
		if(name=="NewGame")
		{
			SceneManager.LoadScene("menuScreen");
			
		}
		if(name=="startLevel")
		{
			Time.timeScale = 1;
			startGame.SetActiveRecursively(false);  
			
			if(SceneManager.GetActiveScene().name=="lavaLevel")
			{
				Player.transform.localScale = new Vector3(-1*Player.transform.localScale.x, Player.transform.localScale.y, Player.transform.localScale.z);
				
			}
			
		}
		if(name=="ContGame")
		{
			if(spriteRenderer.material.GetFloat("_GrayscaleAmount")!=1)
			{
				Debug.Log("Game Was loaded!");
				
				playerScript.loadMePlease();
				
				SceneManager.LoadScene("menuScreen");
				
			}
			
		}
		if(name=="Settings")
		{
			Debug.Log("No Settings Menu Yet!");	
		}
		if(name=="Exit")
		{
			Application.Quit();
		}
		
		
		//Level Selection Screen
		if(name=="lakeLevel")
		{
			if(spriteRenderer.material.GetFloat("_GrayscaleAmount")!=1)
			{
				SceneManager.LoadScene("waterLevel");
			}
		}
		if(name=="lavaLevel")
		{
			if(spriteRenderer.material.GetFloat("_GrayscaleAmount")!=1)
			{
				//SceneManager.LoadScene("menuScreen");
				SceneManager.LoadScene("lavaLevel");
			}
		}
		if(name=="fruitLevel")
		{
			if(spriteRenderer.material.GetFloat("_GrayscaleAmount")!=1)
			{
				//SceneManager.LoadScene("menuScreen");
				SceneManager.LoadScene("fruitLevel");
			}
		}
		
		if(name=="save")
		{
			Debug.Log("Game Was Saved!");
			saveSystem.savePlayer(playerScript);
			
		}

    }

}

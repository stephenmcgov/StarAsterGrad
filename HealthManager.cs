using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class HealthManager : MonoBehaviour
{
    /*public GameObject playerHealth;
    public static int health;
    
    void Awake() 
    {
		//keep object between scenes
        playerHealth = GameObject.Find("HEALTH");
        DontDestroyOnLoad(playerHealth);
	}

	 void Start()
	 {
	 	health = 10;
	 }

    void Update()
    {
		//position healthbar in scene
    	Rigidbody r = GetComponent<Rigidbody>();
    	Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
		
		if(sceneName=="Asteroids")
		{
			r.position = new Vector3(0f, 35f, 20f);
			r.transform.rotation = new Quaternion(0f, 9000f, 9000f, 0f);
		}

		if(sceneName=="Gradius")
		{
			r.position = new Vector3(0f,17.5f,0f);
			r.transform.rotation = new Quaternion(0f, 90f, 0f, 90f);
		}

		if(sceneName=="Starfox")
		{
			r.position = new Vector3(55f, 12.5f,0f);
			r.transform.rotation = new Quaternion(0f, 90f, 0f, -90f);
		}
	}*/
}
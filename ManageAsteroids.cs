using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageAsteroids : MonoBehaviour
{
	//Game Objects
	public GameObject asteroid;
	public GameObject spaceship;
	public GameObject cloneShip;
	public GameObject light;
	public GameObject bullet;
	public GameObject bulletSpawn;
	public AudioSource audioSource;
	public AudioClip audioClip;
	public Camera camera; 
	//public Image playerHealth;
	public List <GameObject> asteroids = new List <GameObject>();
	//Game Logic Variables
	public static int onScreenCount = 0;
	public static ManageAsteroids instance;
	public static int maxAsteroids = 5 + onScreenCount;
	public Vector3 spawnPos;
	public float randomiser;
	float timeLeft = 45f;
	
	//Game Setup/Management
    void Start()
    {	
    	//playerHealth = GameObject.Find("hbar_inner").GetComponent<Image> ();
    	//Debug.Log(HealthManager.health);

		if(asteroids.Count>0)
		for(int i=0; i!=asteroids.Count;i++)
			Destroy(asteroids[i]);
		
		onScreenCount = 0;
		
		for(onScreenCount=0; onScreenCount!=maxAsteroids+1; onScreenCount++)
			asteroids.Add(GameObject.Instantiate(asteroid, chooseAsteroidsSpawnPoints(), Quaternion.identity));
		
		DestroyImmediate(cloneShip, true);
		cloneShip = GameObject.Instantiate(spaceship, new Vector3(0f, 0f, 0f), Quaternion.Euler(0,90,0));
		
		light.transform.position = new Vector3(0f, 150f, 0f);
		light.transform.LookAt(new Vector3(0f, 0f, 0f));
		Camera.main.transform.position = new Vector3(0f, 65f, 0f);
		Camera.main.transform.LookAt(new Vector3(0f, 0f, 0f));
    }

    void Update()
    {			
    	//playerHealth.fillAmount = HealthManager.health/10f;

		if (Input.GetKeyDown("space"))
		{
			spawnBullet();
		}
		
		//spawn asteroid field
		asteroids.Add(GameObject.Instantiate(asteroid, chooseAsteroidsSpawnPoints(), Quaternion.identity));
		
		//survival timer
		timeLeft -= Time.deltaTime;
        if(timeLeft < 0 && GameObject.Find("arwing(Clone)") != null)
        {
            SceneManager.LoadScene("Starfox");
        }
	}  
	
	//Scenario Dependent Asteroid Instantiation
	private Vector3 chooseAsteroidsSpawnPoints()
	{    
		int randomiser = Random.Range(1,30);
		if(randomiser<5)
		spawnPos = new Vector3(-50f, Random.Range(50f,60f), 200f);
	
		if(randomiser>5&&randomiser<10)
			spawnPos = new Vector3(-150f, 0f, 100f);
		
		if(randomiser>10&&randomiser<15)
			spawnPos = new Vector3(-150f, 0f, -100f);
		
		if(randomiser>15&&randomiser<20)
			spawnPos = new Vector3(150f, 0f, -100f);
		
		if(randomiser>20&&randomiser<25)
			spawnPos = new Vector3(150f, 0f, 100f);
		
		if(randomiser>25&&randomiser<30)
			spawnPos = new Vector3(-25f, 0f, 150f);
		
		return spawnPos;
	}

	private void spawnBullet()
	{
		GameObject.Instantiate(bullet, new Vector3(cloneShip.transform.position.x,cloneShip.transform.position.y,cloneShip.transform.position.z), Quaternion.Euler(cloneShip.transform.eulerAngles.x, cloneShip.transform.eulerAngles.y, cloneShip.transform.eulerAngles.z-90));	
		audioSource.clip = audioClip;
		audioSource.Play();
	}
}

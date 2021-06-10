using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageStarfox : MonoBehaviour
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
	public static int onScreenCount=0;
	public static int currentGameLevel = 0;
	public static int maxAsteroids = 2 + currentGameLevel;
	public float randomiser;
	public Vector3 spawnPos;
	private Vector3 rotateValue;
	public float smooth = 5.0f;
	float timeLeft = 120f;
	
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
			asteroids.Add(GameObject.Instantiate(asteroid, new Vector3(1250f, Random.Range(-350f,300f), Random.Range(-500f,500f)), Quaternion.identity));
		
		DestroyImmediate(cloneShip, true);
		cloneShip = GameObject.Instantiate(spaceship, new Vector3(50f, 0f, 0f), Quaternion.Euler(0,180,0));
		light.transform.position = new Vector3(-50f, 0f, 0f);
		light.transform.LookAt(new Vector3(0f, 0f, 0f));
		Camera.main.transform.position = new Vector3(25f, 5f, 0f);
		Camera.main.transform.LookAt(new Vector3(50f, 0f, 0f));
    }

    void Update()
    {	
    	//playerHealth.fillAmount = HealthManager.health/10f;

		if (Input.GetKeyDown("space"))
		{	
			spawnBullets();
		}

		//spawn asteroid field
		asteroids.Add(GameObject.Instantiate(asteroid, new Vector3(1250f, Random.Range(-350f,300f), Random.Range(-500f,500f)), Quaternion.identity));
		
		//survival timer
		timeLeft -= Time.deltaTime;
        if(timeLeft < 0 && GameObject.Find("arwing(Clone)") != null)
        {
        	SceneManager.LoadScene("Gradius");
        }
	}  

	private void spawnBullets()
	{
		GameObject.Instantiate(bullet, new Vector3(cloneShip.transform.position.x+4f,cloneShip.transform.position.y+1f,cloneShip.transform.position.z-1f), Quaternion.Euler(cloneShip.transform.eulerAngles.x, cloneShip.transform.eulerAngles.y, cloneShip.transform.eulerAngles.z-90));
		audioSource.clip = audioClip;
		audioSource.Play();
	}
}

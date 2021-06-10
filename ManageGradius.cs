using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGradius : MonoBehaviour
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
	//public Image playerHealth;
	public List <GameObject> asteroids = new List <GameObject>();
	//Game Logic Variables
	public static int onScreenCount = 0;
	public static int maxAsteroids = 2 + onScreenCount;
	public float randomiser;
	public float timeLeft = 120f;

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
			asteroids.Add(GameObject.Instantiate(asteroid, new Vector3(0f, Random.Range(-20f,20f), 350f), Quaternion.identity));	
		
		DestroyImmediate(cloneShip, true);
		cloneShip = GameObject.Instantiate(spaceship, new Vector3(0f, 0f, 0f), Quaternion.Euler(90,90,0));
		
		light.transform.position = new Vector3(100f, 0f, 0f);
		light.transform.LookAt(new Vector3(0f, 0f, 0f));
		Camera.main.transform.position = new Vector3(75f, 0f, 0f);
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
		asteroids.Add(GameObject.Instantiate(asteroid, new Vector3(0f, Random.Range(-20f,20f), 350f), Quaternion.identity));
		
		//survival timer
		timeLeft -= Time.deltaTime;
        if(timeLeft < 0 && GameObject.Find("arwing(Clone)") != null)
        {
           SceneManager.LoadScene("Asteroids");
        }
	}  
  
	private void spawnBullet()
	{
		GameObject.Instantiate(bullet, new Vector3(cloneShip.transform.position.x+0f,cloneShip.transform.position.y+1f,cloneShip.transform.position.z+3f), Quaternion.Euler(cloneShip.transform.eulerAngles.x, cloneShip.transform.eulerAngles.y, cloneShip.transform.eulerAngles.z-90));
		audioSource.clip = audioClip;
		audioSource.Play();
	}
}

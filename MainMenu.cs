using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	//public Animator animator;
	//public bool PlayPressed = false;
	
   public void playGame()
   {
	   //FadeToLevel();
	   StartCoroutine(startGame());
   }
   
   public IEnumerator startGame()
   {
	   yield return new WaitForSecondsRealtime(1);
	   SceneManager.LoadScene("Starfox");
   }
   
   public void quitGame()
   {
	   Application.Quit();
   }
   
   //trying to fade between scenes
   /*public void FadeToLevel()
   {
		GetComponent<Animator>().SetBool("PlayPressed",true);
   }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFI.Wika
{
    public class Main : MonoBehaviour
    {
		public GameObject dialogBox;
		bool isClose;


        // Use this for initialization
        void Start()
        {
			
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadModule()
        {
			
           
        }

		void OnApplicationQuit()
		{
			dialogBox.SetActive(true);
			if (!isClose)
			{
				Application.CancelQuit();
			}
		}

		public void No()
		{
			dialogBox.SetActive(false);
			//player.Play();
		}

		public void Yes()
		{
			print ("TEST!");
			isClose = true;
			Application.Quit ();
		}

		public void OnClick() {
			StartCoroutine (delayFunction());
	

		}

		IEnumerator delayFunction() {
			yield return new WaitForSeconds(0.2f);

			if (gameObject.name == "Lesson Button (1)") {
				ModuleManager.ModuleNumber = 1;
				SceneManager.LoadScene ("Multiple Choice");
			} else if (gameObject.name == "Lesson Button (7)") {
				ModuleManager.ModuleNumber = 7;
				SceneManager.LoadScene ("Multiple Choice");
			} else if (gameObject.name == "Lesson Button (9)") {
				ModuleManager.ModuleNumber = 9;
				SceneManager.LoadScene ("Multiple Choice");
			} else if (gameObject.name == "Lesson Button (11)") {
				ModuleManager.ModuleNumber = 11;
				SceneManager.LoadScene ("Multiple Choice");
			} else if (gameObject.name == "Lesson Button (12)") {
				ModuleManager.ModuleNumber = 12;
				SceneManager.LoadScene ("Multiple Choice");
			} else if (gameObject.name == "Lesson Button (15)") {
				ModuleManager.ModuleNumber = 15;
				SceneManager.LoadScene ("Multiple Choice");
			} else if (gameObject.name == "Lesson Button (17)") {
				ModuleManager.ModuleNumber = 17;
				SceneManager.LoadScene ("Multiple Choice");
			} else if (gameObject.name == "Lesson Button (19)") {
				ModuleManager.ModuleNumber = 20;
				SceneManager.LoadScene ("Multiple Choice");
			} 

		}
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFI.WikaTM
{
    public class MainTM : MonoBehaviour
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

			if (gameObject.name == "Lesson Button (2)") {
				ModuleManagerTM.ModuleNumber = 2;
				SceneManager.LoadScene ("TrueOrFalse");
			} else if (gameObject.name == "Lesson Button (8)") {
				ModuleManagerTM.ModuleNumber = 8;
				SceneManager.LoadScene ("TrueOrFalse");
			} else if (gameObject.name == "Lesson Button (13)") {
				ModuleManagerTM.ModuleNumber = 13;
				SceneManager.LoadScene ("TrueOrFalse");
			} else if (gameObject.name == "Lesson Button (14)") {
				ModuleManagerTM.ModuleNumber = 14;
				SceneManager.LoadScene ("TrueOrFalse");
			} else if (gameObject.name == "Lesson Button (16)") {
				ModuleManagerTM.ModuleNumber = 16;
				SceneManager.LoadScene ("TrueOrFalse");
			} else if (gameObject.name == "Lesson Button (18)") {
				ModuleManagerTM.ModuleNumber = 18;
				SceneManager.LoadScene ("TrueOrFalse");
			} else if (gameObject.name == "Lesson Button (20)") {
				ModuleManagerTM.ModuleNumber = 20;
				SceneManager.LoadScene ("TrueOrFalse");
			}
		}
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TFI.Wika
{

	public class ValidateAnswer : MonoBehaviour {

		public GameObject buttonA, buttonB, buttonC, buttonD;
		public Text choiceA, choiceB, choiceC, choiceD;
		public bool isClick;

		public Questions questions;

		void Awake () {
			isClick = true;
		}

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		public void OnClick () {

			if (isClick) {
				if (gameObject.name == "ButtonA")
				{
					gameObject.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-A", typeof(Sprite));
					buttonB.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-B", typeof(Sprite));
					buttonC.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-C", typeof(Sprite));
					buttonD.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-D", typeof(Sprite));

					Validator.PlayerAnswer [questions.curItem] = choiceA.text;

				}

				if (gameObject.name == "ButtonB")
				{
					gameObject.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-B", typeof(Sprite));
					buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-A", typeof(Sprite));
					buttonC.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-C", typeof(Sprite));
					buttonD.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-D", typeof(Sprite));

					Validator.PlayerAnswer [questions.curItem] = choiceB.text;
				}

				if (gameObject.name == "ButtonC") 
				{
					gameObject.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-C", typeof(Sprite));
					buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-A", typeof(Sprite));
					buttonB.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-B", typeof(Sprite));
					buttonD.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-D", typeof(Sprite));

					Validator.PlayerAnswer [questions.curItem] = choiceC.text;
				}

				if (gameObject.name == "ButtonD") 
				{
					gameObject.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-D", typeof(Sprite));
					buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-A", typeof(Sprite));
					buttonB.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-B", typeof(Sprite));
					buttonC.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-C", typeof(Sprite));

					Validator.PlayerAnswer [questions.curItem] = choiceD.text;
				}
			}


		}
	}

}


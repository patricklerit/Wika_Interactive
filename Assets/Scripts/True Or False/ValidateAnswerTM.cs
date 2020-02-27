using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TFI.WikaTM
{

	public class ValidateAnswerTM : MonoBehaviour {

		public GameObject buttonA, buttonB;
		public Text choiceA, choiceB;
		public bool isClick;

		public QuestionsTM questions;

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

					ValidatorTM.PlayerAnswer [questions.curItem] = choiceA.text;

				}

				if (gameObject.name == "ButtonB")
				{
					gameObject.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-B", typeof(Sprite));
					buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-A", typeof(Sprite));

					ValidatorTM.PlayerAnswer [questions.curItem] = choiceB.text;
				}
			}


		}
	}

}


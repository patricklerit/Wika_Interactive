using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TFI.Wika
{
    public class ChoiceButton : MonoBehaviour
    {

		public Questions question;
		public GameObject buttonA, buttonB, buttonC, buttonD, correctImg, wrongImg;
		public Text choiceA, choiceB, choiceC, choiceD;
		public bool isReview;
		public Button submitBtn;
		public int maxItemFinal;

		void Awake () {
			isReview = false;

			if (ModuleManager.ModuleNumber == 1 || ModuleManager.ModuleNumber == 7 || ModuleManager.ModuleNumber == 9 || ModuleManager.ModuleNumber == 11 || ModuleManager.ModuleNumber == 12 || ModuleManager.ModuleNumber == 15 || ModuleManager.ModuleNumber == 17 || ModuleManager.ModuleNumber == 19) {
				maxItemFinal = 10;
			} 
			// else if (ModuleManager.ModuleNumber == 2 || ModuleManager.ModuleNumber == 3 || ModuleManager.ModuleNumber == 4) {
			// 	maxItemFinal = 20;
			// }
		}

        void Start()
        {
         
        }

		public void OnClick() {


			if (gameObject.name == "Next") {

				if (question.curNumber < maxItemFinal) {
					question.curItem += 1;
					question.curNumber += 1;
					question.GenerateItem ();

					if (isReview) {
						submitBtn.gameObject.SetActive (false);
					}
				}

			} else if (gameObject.name == "Previous") {

				if (question.curItem > 0) {
					question.curItem -= 1;
					question.curNumber -= 1;
					question.GenerateItem ();
				}
		
			}


		


//			foreach (string var in Validator.CorrectAnswerAry)
//			{
//				print(var);
//			}

			UpdateButtonColor ();
			ReviewAnswer ();
		}


		void UpdateButtonColor () {
			if (Validator.PlayerAnswer [question.curItem] == choiceA.text) {
				buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-A", typeof(Sprite));
			} else {
				buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-A", typeof(Sprite));
			}

			if (Validator.PlayerAnswer [question.curItem] == choiceB.text) {
				buttonB.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-B", typeof(Sprite));
			} else {
				buttonB.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-B", typeof(Sprite));
			}

			if (Validator.PlayerAnswer [question.curItem] == choiceC.text) {
				buttonC.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-C", typeof(Sprite));
			} else {
				buttonC.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-C", typeof(Sprite));
			}

			if (Validator.PlayerAnswer [question.curItem] == choiceD.text) {
				buttonD.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-D", typeof(Sprite));
			} else {
				buttonD.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-D", typeof(Sprite));
			}
		}

		void ReviewAnswer () {
			if (isReview) {
				if (Validator.PlayerAnswer [question.curItem] != Validator.CorrectAnswerAry [question.curItem]) {
					
					correctImg.SetActive (false);
					wrongImg.SetActive (true);

					if (Validator.CorrectAnswerAry [question.curItem] == choiceA.text) {
						buttonA.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-A", typeof(Sprite));
					} else if (Validator.CorrectAnswerAry [question.curItem] == choiceB.text) {
						buttonB.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-B", typeof(Sprite));
					} else if (Validator.CorrectAnswerAry [question.curItem] == choiceC.text) {
						buttonC.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-C", typeof(Sprite));
					} else if (Validator.CorrectAnswerAry [question.curItem] == choiceD.text) {
						buttonD.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-D", typeof(Sprite));
					}
					
				} else {
					correctImg.SetActive (true);
					wrongImg.SetActive (false);
				}
			}
		}


    }
}
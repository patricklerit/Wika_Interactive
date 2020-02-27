using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TFI.WikaTM
{
    public class ChoiceButtonTM : MonoBehaviour
    {

		public QuestionsTM question;
		public GameObject buttonA, buttonB, correctImg, wrongImg;
		public Text choiceA, choiceB;
		public bool isReview;
		public Button submitBtn;
		public int maxItemFinal;

		void Awake () {
			isReview = false;

			if (ModuleManagerTM.ModuleNumber == 2 || ModuleManagerTM.ModuleNumber == 8 || ModuleManagerTM.ModuleNumber == 13  || ModuleManagerTM.ModuleNumber == 14 || ModuleManagerTM.ModuleNumber == 16 || ModuleManagerTM.ModuleNumber == 18 || ModuleManagerTM.ModuleNumber == 20) {
				maxItemFinal = 10;
			} 
			
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


		


//			foreach (string var in ValidatorTM.CorrectAnswerAry)
//			{
//				print(var);
//			}

			UpdateButtonColor ();
			ReviewAnswer ();
		}


		void UpdateButtonColor () {
			if (ValidatorTM.PlayerAnswer [question.curItem] == choiceA.text) {
				buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-A", typeof(Sprite));
			} else {
				buttonA.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-A", typeof(Sprite));
			}

			if (ValidatorTM.PlayerAnswer [question.curItem] == choiceB.text) {
				buttonB.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/selected-B", typeof(Sprite));
			} else {
				buttonB.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("Images/Multiple Choice/default-B", typeof(Sprite));
			}
		}

		void ReviewAnswer () {
			if (isReview) {
				if (ValidatorTM.PlayerAnswer [question.curItem] != ValidatorTM.CorrectAnswerAry [question.curItem]) {
					
					correctImg.SetActive (false);
					wrongImg.SetActive (true);

					if (ValidatorTM.CorrectAnswerAry [question.curItem] == choiceA.text) {
						buttonA.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-A", typeof(Sprite));
					} else if (ValidatorTM.CorrectAnswerAry [question.curItem] == choiceB.text) {
						buttonB.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-B", typeof(Sprite));
					}
					
				} else {
					correctImg.SetActive (true);
					wrongImg.SetActive (false);
				}
			}
		}


    }
}
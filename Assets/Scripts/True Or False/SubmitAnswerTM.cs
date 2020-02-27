using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TFI.WikaTM
{
	public class SubmitAnswerTM : MonoBehaviour {

		public Text finalScore, maxItemScore, FeedbackText, CreditsTxt, IntroText, CreditBtnText;
		public GameObject feedbackBox, submitBox, correctImg, wrongImg, reviewBG;
		int score;
		int totalScore, maxItem;
		float percentage;
		public Button buttonA, buttonB, SubmitButton, nextBtn, previousBtn, exitReviewBtn;
		public QuestionsTM question;
		public Text choiceA, choiceB;
		public int maxItemFinal;
		public GameObject CreditsNew;

		void Awake () {
			//score = 0;
			if (ModuleManagerTM.ModuleNumber == 2 || ModuleManagerTM.ModuleNumber == 8 || ModuleManagerTM.ModuleNumber == 13  || ModuleManagerTM.ModuleNumber == 14 || ModuleManagerTM.ModuleNumber == 16 || ModuleManagerTM.ModuleNumber == 18 || ModuleManagerTM.ModuleNumber == 20) {
				maxItemFinal = 10;
			}
		}

		// Use this for initialization
		void Start () {


		}

		// Update is called once per frame
		void Update () {

		}

		public void OnClick () {

			if (gameObject.name == "Submit") {
				submitBox.SetActive (true);
			} else if (gameObject.name == "PlayAgain") {
				ValidatorTM.PlayerAnswer.Clear ();
				ValidatorTM.CorrectAnswerAry.Clear ();
				UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
			} else if (gameObject.name == "Exit") {
				Application.Quit ();
			} else if (gameObject.name == "Yes") {
				foreach (string corAnswer in ValidatorTM.CorrectAnswerAry) {

					foreach (string playerAnswer in ValidatorTM.PlayerAnswer) {

						if (corAnswer == playerAnswer) {
							score += 1;
						}
					}
				}
				feedbackBox.SetActive (true);
				submitBox.SetActive (false);
				finalScore.text = score.ToString ();
				maxItemScore.text = "/ " + maxItemFinal;
				SubmitButton.gameObject.SetActive (false);
				FeedbackTextValue ();
				LastItemValidatorTM ();

			} else if (gameObject.name == "No") {
				submitBox.SetActive (false);
			} else if (gameObject.name == "CreditsBtn") {
				if (gameObject.GetComponentInChildren<Text> ().text == "CREDITS") {
					IntroText.gameObject.SetActive (false);
					//CreditsTxt.gameObject.SetActive (true);
					CreditsNew.SetActive (true);
					gameObject.GetComponentInChildren<Text> ().text = "INTRO";
				} else {
					IntroText.gameObject.SetActive (true);
					//CreditsTxt.gameObject.SetActive (false);
					CreditsNew.SetActive (false);
					gameObject.GetComponentInChildren<Text> ().text = "CREDITS";
				}
			} else if (gameObject.name == "Review") {
				ReviewAnswer ();
				exitReviewBtn.gameObject.SetActive (true);
			
			} else if (gameObject.name == "ExitReview") {
				exitReviewBtn.gameObject.SetActive (false);
				reviewBG.SetActive (false);
				feedbackBox.SetActive (true);
				correctImg.SetActive (false);
				wrongImg.SetActive (false);

				question.curItem = maxItemFinal - 1;
				question.curNumber = maxItemFinal;
				question.GenerateItem ();

			}
		}


		void FeedbackTextValue () {
			totalScore = score;
			maxItem = maxItemFinal;
			percentage =  (float) totalScore / maxItem;
			percentage = percentage * 100;

			if (percentage >= 100) {
				FeedbackText.text = "Perfect!";
			} else if (percentage < 100 && percentage >= 80) {
				FeedbackText.text = "Awesome!";
			} else if (percentage < 70 && percentage >= 50) {
				FeedbackText.text = "Good Job!";
			} else if (percentage < 50) {
				FeedbackText.text = "Nice Try!";
			}
		}


		void ReviewAnswer () {
			buttonA.GetComponent<ValidateAnswerTM> ().isClick = false;
			buttonB.GetComponent<ValidateAnswerTM> ().isClick = false;

			buttonA.enabled = false;
			buttonB.enabled = false;

			nextBtn.GetComponent<ChoiceButtonTM> ().isReview = true;
			previousBtn.GetComponent<ChoiceButtonTM> ().isReview = true;


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

			feedbackBox.SetActive (false);
			reviewBG.SetActive (true);
			SubmitButton.enabled = false;

		}


		void PutItemOnArryListDummy () {
			ValidatorTM.PlayerAnswer.Clear ();
//			for (int i = 0; i < 19; i++) {
//				ValidatorTM.PlayerAnswer.Add ("Null");
//			}
		}


		void LastItemValidatorTM () {
			if (ValidatorTM.PlayerAnswer [question.curItem] != ValidatorTM.CorrectAnswerAry [question.curItem]) {
				if (ValidatorTM.CorrectAnswerAry [question.curItem] == choiceA.text) {
					buttonA.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-A", typeof(Sprite));
				} else if (ValidatorTM.CorrectAnswerAry [question.curItem] == choiceB.text) {
					buttonB.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-B", typeof(Sprite));
				}
			}
		}
	}
}



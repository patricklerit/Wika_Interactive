using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TFI.Wika
{
	public class SubmitAnswer : MonoBehaviour {

		public Text finalScore, maxItemScore, FeedbackText, CreditsTxt, IntroText, CreditBtnText;
		public GameObject feedbackBox, submitBox, correctImg, wrongImg, reviewBG;
		int score;
		int totalScore, maxItem;
		float percentage;
		public Button buttonA, buttonB, buttonC, buttonD, SubmitButton, nextBtn, previousBtn, exitReviewBtn;
		public Questions question;
		public Text choiceA, choiceB, choiceC, choiceD;
		public int maxItemFinal;
		public GameObject CreditsNew;

		void Awake () {
			//score = 0;
			if (ModuleManager.ModuleNumber == 1 || ModuleManager.ModuleNumber == 7 || ModuleManager.ModuleNumber == 9 || ModuleManager.ModuleNumber == 11 || ModuleManager.ModuleNumber == 12 || ModuleManager.ModuleNumber == 15 || ModuleManager.ModuleNumber == 17 || ModuleManager.ModuleNumber == 19) {
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
				Validator.PlayerAnswer.Clear ();
				Validator.CorrectAnswerAry.Clear ();
				UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
			} else if (gameObject.name == "Exit") {
				Application.Quit ();
			} else if (gameObject.name == "Yes") {
				foreach (string corAnswer in Validator.CorrectAnswerAry) {

					foreach (string playerAnswer in Validator.PlayerAnswer) {

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
				LastItemValidator ();

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
			buttonA.GetComponent<ValidateAnswer> ().isClick = false;
			buttonB.GetComponent<ValidateAnswer> ().isClick = false;
			buttonC.GetComponent<ValidateAnswer> ().isClick = false;
			buttonD.GetComponent<ValidateAnswer> ().isClick = false;

			buttonA.enabled = false;
			buttonB.enabled = false;
			buttonC.enabled = false;
			buttonD.enabled = false;

			nextBtn.GetComponent<ChoiceButton> ().isReview = true;
			previousBtn.GetComponent<ChoiceButton> ().isReview = true;


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

			feedbackBox.SetActive (false);
			reviewBG.SetActive (true);
			SubmitButton.enabled = false;

		}


		void PutItemOnArryListDummy () {
			Validator.PlayerAnswer.Clear ();
//			for (int i = 0; i < 19; i++) {
//				Validator.PlayerAnswer.Add ("Null");
//			}
		}


		void LastItemValidator () {
			if (Validator.PlayerAnswer [question.curItem] != Validator.CorrectAnswerAry [question.curItem]) {
				if (Validator.CorrectAnswerAry [question.curItem] == choiceA.text) {
					buttonA.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-A", typeof(Sprite));
				} else if (Validator.CorrectAnswerAry [question.curItem] == choiceB.text) {
					buttonB.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-B", typeof(Sprite));
				} else if (Validator.CorrectAnswerAry [question.curItem] == choiceC.text) {
					buttonC.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-C", typeof(Sprite));
				} else if (Validator.CorrectAnswerAry [question.curItem] == choiceD.text) {
					buttonD.GetComponentInChildren<Image> ().sprite = (Sprite)Resources.Load ("Images/Multiple Choice/correct-D", typeof(Sprite));
				}
			}
		}
	}
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

namespace TFI.WikaTM
{
    public class QuestionsTM : MonoBehaviour
    {

		ArrayList questions = new ArrayList(), corrects = new ArrayList(), wrongs1 = new ArrayList(), choices = new ArrayList();
		ArrayList  questionContainerSet1 = new ArrayList(), arryChoiceA = new ArrayList(), arryChoiceB = new ArrayList(), choicesContainer = new ArrayList();
		string questionSet, correct, wrong1;
		int randomVal, randomVal2;

		public GameObject previousBtn, nextBtn, passageBox, passageBoxButton;
		public Text questionTxt, choiceAtxt, choiceBtxt, quesNumber;
		public int curItem, curNumber, maxItem, maxItemFinal;

		public Button submitButton;

		bool isFirstShow, isLoad2ndSet, isLoad3rdSet;

		public GameObject dialogBox;
		bool isClose;

		void Awake () {

			print (ModuleManagerTM.ModuleNumber);

			if (ModuleManagerTM.ModuleNumber == 2 || ModuleManagerTM.ModuleNumber == 8 || ModuleManagerTM.ModuleNumber == 13  || ModuleManagerTM.ModuleNumber == 14 || ModuleManagerTM.ModuleNumber == 16 || ModuleManagerTM.ModuleNumber == 18 || ModuleManagerTM.ModuleNumber == 20) {
				maxItemFinal = 10;
			} 

			curItem = 0;
			curNumber = 1;
			quesNumber.text = "QUESTION " + " # " + curNumber.ToString();
			questionSet = "Set1";
			LoadXMLset ();

			PutItemOnArryListDummy ();

			maxItem = questions.Count;
			RandomizeItemSet ();
			GenerateItem ();

			isFirstShow = true;
			isLoad2ndSet = true;
			isLoad3rdSet = true;

			//submitButton.gameObject.SetActive (false);

		}


		void Start () {




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
			isClose = true;
			Application.Quit();
		}

			
		void PutItemOnArryListDummy () {

			if (ModuleManagerTM.ModuleNumber == 2 || ModuleManagerTM.ModuleNumber == 8 || ModuleManagerTM.ModuleNumber == 13  || ModuleManagerTM.ModuleNumber == 14 || ModuleManagerTM.ModuleNumber == 16 || ModuleManagerTM.ModuleNumber == 18 || ModuleManagerTM.ModuleNumber == 20) {
				for (int i = 0; i < maxItemFinal; i++) {
					ValidatorTM.PlayerAnswer.Add ("Null");
				}
			}
		}

		public void GenerateItem () {
			
			quesNumber.text = "QUESTION " + " # " + curNumber.ToString();
			questionTxt.text = questionContainerSet1 [curItem].ToString ();
			choiceAtxt.text = arryChoiceA [curItem].ToString ();
			choiceBtxt.text = arryChoiceB [curItem].ToString ();

			if (curNumber > 1) {
				previousBtn.SetActive (true);
			} else if (curNumber <= 1) {
				previousBtn.SetActive (false);
			}

			if (curNumber >= maxItemFinal) {
				nextBtn.SetActive (false);
				submitButton.gameObject.SetActive (true);
			} else if (curNumber < maxItemFinal) {
				nextBtn.SetActive (true);
				submitButton.gameObject.SetActive (false);
			}

			if (ModuleManagerTM.ModuleNumber == 2 || ModuleManagerTM.ModuleNumber == 8 || ModuleManagerTM.ModuleNumber == 13  || ModuleManagerTM.ModuleNumber == 14 || ModuleManagerTM.ModuleNumber == 16 || ModuleManagerTM.ModuleNumber == 18 || ModuleManagerTM.ModuleNumber == 20) {
				if (isLoad2ndSet) {
					questionSet = "Set2";
					LoadXMLset ();
					maxItem = questions.Count;
					RandomizeItemSet ();
					isLoad2ndSet = false;
				}
			}

			if (ModuleManagerTM.ModuleNumber == 2 || ModuleManagerTM.ModuleNumber == 8 || ModuleManagerTM.ModuleNumber == 13  || ModuleManagerTM.ModuleNumber == 14 || ModuleManagerTM.ModuleNumber == 16 || ModuleManagerTM.ModuleNumber == 18 || ModuleManagerTM.ModuleNumber == 20) {
				if (isLoad3rdSet) {
					questionSet = "Set3";
					LoadXMLset ();
					maxItem = questions.Count;
					RandomizeItemSet ();
					isLoad3rdSet = false;
				}
			}

			//if (curNumber == 5 && ModuleManagerTM.ModuleNumber == 1) {
			//	if (isFirstShow) {
			//		passageBox.SetActive (true);
			//		isFirstShow = false;
			//	}
			//}

			//if (curNumber >= 5 && curNumber < 10 && ModuleManagerTM.ModuleNumber == 1) {
			//	passageBoxButton.SetActive (true);
			//} else {
			//	passageBoxButton.SetActive (false);
			//}

			//print (curItem);
		}

		public void LoadXMLset()
		{
			string PATH = "XML/Itembank" + ModuleManagerTM.ModuleNumber;
			string NODE = "Activity/" + questionSet + "/Item";
			TextAsset textAsset = (TextAsset)Resources.Load(PATH, typeof(TextAsset));
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(textAsset.text);

			foreach (XmlNode node in xmlDoc.SelectNodes(NODE))
			{
				foreach (XmlNode innerNode in node.ChildNodes)
				{
					if (innerNode.Name == "Question") questions.Add(innerNode.InnerText);
					if (innerNode.Name == "Correct") corrects.Add(innerNode.InnerText);
					if (innerNode.Name == "Wrong1") wrongs1.Add(innerNode.InnerText);
				}
			}

		}

		public void RandomizeItemSet()
		{
			for (int i = 0; i < maxItem; i++ )
			{
				randomVal = Random.Range(0, questions.Count);

				questionContainerSet1.Add(questions[randomVal]);
				ValidatorTM.CorrectAnswerAry.Add (corrects [randomVal]);

				choicesContainer.Add (corrects [randomVal]);
				choicesContainer.Add (wrongs1 [randomVal]);

				randomVal2 = Random.Range(0, choicesContainer.Count);
				arryChoiceA.Add (choicesContainer [randomVal2]);
				choicesContainer.RemoveAt (randomVal2);

				randomVal2 = Random.Range(0, choicesContainer.Count);
				arryChoiceB.Add (choicesContainer [randomVal2]);
				choicesContainer.RemoveAt (randomVal2);

				questions.RemoveAt(randomVal);
				corrects.RemoveAt(randomVal);
				wrongs1.RemoveAt(randomVal);

			} 
		}
			
    }
}
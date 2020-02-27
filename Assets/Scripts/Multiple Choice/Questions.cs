using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

namespace TFI.Wika
{
    public class Questions : MonoBehaviour
    {

		ArrayList questions = new ArrayList(), corrects = new ArrayList(), wrongs1 = new ArrayList(), wrongs2 = new ArrayList(), wrongs3 = new ArrayList(), choices = new ArrayList();
		ArrayList  questionContainerSet1 = new ArrayList(), arryChoiceA = new ArrayList(), arryChoiceB = new ArrayList(), arryChoiceC= new ArrayList(), arryChoiceD= new ArrayList(), choicesContainer = new ArrayList();
		string questionSet, correct, wrong1, wrong2, wrong3;
		int randomVal, randomVal2;

		public GameObject previousBtn, nextBtn, passageBox, passageBoxButton;
		public Text questionTxt, choiceAtxt, choiceBtxt, choiceCtxt, choiceDtxt, quesNumber;
		public int curItem, curNumber, maxItem, maxItemFinal;

		public Button submitButton;

		bool isFirstShow, isLoad2ndSet, isLoad3rdSet;

		public GameObject dialogBox;
		bool isClose;

		void Awake () {

			// print (ModuleManager.ModuleNumber);

			if (ModuleManager.ModuleNumber == 1 || ModuleManager.ModuleNumber == 7 || ModuleManager.ModuleNumber == 9 || ModuleManager.ModuleNumber == 11 || ModuleManager.ModuleNumber == 12 || ModuleManager.ModuleNumber == 15 || ModuleManager.ModuleNumber == 17 || ModuleManager.ModuleNumber == 19) {
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

			if (ModuleManager.ModuleNumber == 1 || ModuleManager.ModuleNumber == 7 || ModuleManager.ModuleNumber == 9 || ModuleManager.ModuleNumber == 11 || ModuleManager.ModuleNumber == 12 || ModuleManager.ModuleNumber == 15 || ModuleManager.ModuleNumber == 17 || ModuleManager.ModuleNumber == 19) {
				for (int i = 0; i < maxItemFinal; i++) {
					Validator.PlayerAnswer.Add ("Null");
				}
			}
		}

		public void GenerateItem () {
			
			quesNumber.text = "QUESTION " + " # " + curNumber.ToString();
			questionTxt.text = questionContainerSet1 [curItem].ToString ();
			choiceAtxt.text = arryChoiceA [curItem].ToString ();
			choiceBtxt.text = arryChoiceB [curItem].ToString ();
			choiceCtxt.text = arryChoiceC [curItem].ToString ();
			choiceDtxt.text = arryChoiceD [curItem].ToString ();

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

			if (curNumber == 4 && ModuleManager.ModuleNumber == 1 || ModuleManager.ModuleNumber == 7 || ModuleManager.ModuleNumber == 9 || ModuleManager.ModuleNumber == 11 || ModuleManager.ModuleNumber == 12 || ModuleManager.ModuleNumber == 15 || ModuleManager.ModuleNumber == 17 || ModuleManager.ModuleNumber == 19) {
				if (isLoad2ndSet) {
					questionSet = "Set2";
					LoadXMLset ();
					maxItem = questions.Count;
					RandomizeItemSet ();
					isLoad2ndSet = false;
				}
			}

			if (curNumber == 8 && ModuleManager.ModuleNumber == 1 || ModuleManager.ModuleNumber == 7 || ModuleManager.ModuleNumber == 9 || ModuleManager.ModuleNumber == 11 || ModuleManager.ModuleNumber == 12 || ModuleManager.ModuleNumber == 15 || ModuleManager.ModuleNumber == 17 || ModuleManager.ModuleNumber == 19) {
				if (isLoad3rdSet) {
					questionSet = "Set3";
					LoadXMLset ();
					maxItem = questions.Count;
					RandomizeItemSet ();
					isLoad3rdSet = false;
				}
			}

			//if (curNumber == 5 && ModuleManager.ModuleNumber == 1) {
			//	if (isFirstShow) {
			//		passageBox.SetActive (true);
			//		isFirstShow = false;
			//	}
			//}

			//if (curNumber >= 5 && curNumber < 10 && ModuleManager.ModuleNumber == 1) {
			//	passageBoxButton.SetActive (true);
			//} else {
			//	passageBoxButton.SetActive (false);
			//}

			//print (curItem);
		}

		public void LoadXMLset()
		{
			string PATH = "XML/Itembank" + ModuleManager.ModuleNumber;
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
					if (innerNode.Name == "Wrong2") wrongs2.Add(innerNode.InnerText);
					if (innerNode.Name == "Wrong3") wrongs3.Add(innerNode.InnerText);
				}
			}

		}

		public void RandomizeItemSet()
		{
			for (int i = 0; i < maxItem; i++ )
			{
				randomVal = Random.Range(0, questions.Count);

				questionContainerSet1.Add(questions[randomVal]);
				Validator.CorrectAnswerAry.Add (corrects [randomVal]);

				choicesContainer.Add (corrects [randomVal]);
				choicesContainer.Add (wrongs1 [randomVal]);
				choicesContainer.Add (wrongs2 [randomVal]);
				choicesContainer.Add (wrongs3 [randomVal]);

				randomVal2 = Random.Range(0, choicesContainer.Count);
				arryChoiceA.Add (choicesContainer [randomVal2]);
				choicesContainer.RemoveAt (randomVal2);

				randomVal2 = Random.Range(0, choicesContainer.Count);
				arryChoiceB.Add (choicesContainer [randomVal2]);
				choicesContainer.RemoveAt (randomVal2);

				randomVal2 = Random.Range(0, choicesContainer.Count);
				arryChoiceC.Add (choicesContainer [randomVal2]);
				choicesContainer.RemoveAt (randomVal2);

				randomVal2 = Random.Range(0, choicesContainer.Count);
				arryChoiceD.Add (choicesContainer [randomVal2]);
				choicesContainer.RemoveAt (randomVal2);

				questions.RemoveAt(randomVal);
				corrects.RemoveAt(randomVal);
				wrongs1.RemoveAt(randomVal);
				wrongs2.RemoveAt(randomVal);
				wrongs3.RemoveAt(randomVal);

			} 
		}
			
    }
}
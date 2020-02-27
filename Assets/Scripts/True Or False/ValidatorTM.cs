using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFI.WikaTM
{
	public static class ValidatorTM
	{
		static ArrayList playerAnswer = new ArrayList (), correctAnswerAry = new ArrayList();
		static string correctAns, moduleNumber;

		public static string CorrectAns
		{
			set { PlayerPrefs.SetString("CorrectAns", value); }
			get { return PlayerPrefs.GetString("CorrectAns"); }
		}

		public static string ModuleNumber
		{
			set { PlayerPrefs.SetString("ModuleNumber", value); }
			get { return PlayerPrefs.GetString("ModuleNumber"); }
		}

		public static ArrayList PlayerAnswer {

			set { playerAnswer = value; }
			get { return playerAnswer; }

		}

		public static ArrayList CorrectAnswerAry {

			set { correctAnswerAry = value; }
			get { return correctAnswerAry; }

		}

	
	}

}


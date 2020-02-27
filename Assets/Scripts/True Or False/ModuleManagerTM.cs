using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFI.WikaTM
{
    public static class ModuleManagerTM 
    {
        public static int ModuleNumber { set; get; }
        public static string ModuleTitle { set; get; }
        public static bool ShowQuestions { set; get; }
        public static List<string> ModuleAnswers { set; get; }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator TransitionFadeOut; //The animator component that holds the animation I want to play
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onTransit()
    {
        TransitionFadeOut.SetTrigger("onTransit");
    }
}

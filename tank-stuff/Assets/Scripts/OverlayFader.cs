using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayFader : MonoBehaviour
{
	[SerializeField] private float fadeTime;
	
    // Start is called before the first frame update
    void Start()
    {
        fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void fadeOut(){
		LeanTween.value(gameObject, (value) => {gameObject.GetComponent<Image>().color = value;}, new Color(0f, 0f, 0f, 1f), new Color(0f, 0f, 0f, 0f), fadeTime).setEase(LeanTweenType.easeOutQuad);
	}
}

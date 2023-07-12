using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlideAnimatorScript : MonoBehaviour
{
	[SerializeField] private float slideTime;
	[SerializeField] private GameObject menuBar;
	[SerializeField] private GameObject targetPosition;
	[SerializeField] private float delay;
	
    // Start is called before the first frame update
    void Start()
    {
        slideInUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void slideInUI(){
		LeanTween.moveLocal(menuBar, targetPosition.transform.localPosition, slideTime).setEase(LeanTweenType.easeInOutCubic).setDelay(delay);
	}
	
	
}

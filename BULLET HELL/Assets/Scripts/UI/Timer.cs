using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    public GameObject WinScreen;
    float elapsedTime;
    public Transform textLocation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(WinScreen.activeSelf==false){
            elapsedTime+=Time.deltaTime;
        }else{
            textLocation.localPosition=new Vector2(35,21);
        }
        int minutes = Mathf.FloorToInt(elapsedTime/60);
        int seconds = Mathf.FloorToInt(elapsedTime%60);

        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}

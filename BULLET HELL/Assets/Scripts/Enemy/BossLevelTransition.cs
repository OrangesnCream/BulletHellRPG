using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossLevelTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
           Debug.Log("exit collision");
        if(boss==null){
            Debug.Log("scene Transition");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}

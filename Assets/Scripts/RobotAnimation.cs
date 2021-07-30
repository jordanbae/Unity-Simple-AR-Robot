using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class RobotAnimation : MonoBehaviour
{
    [SerializeField] GameObject robot;
    [SerializeField] GameObject menuPopup;
    [SerializeField] GameObject controlPopup;
    [SerializeField] GameObject startButton;
    [SerializeField] Transform startPos;
    [SerializeField] Transform belowstartPos;
    [SerializeField] GameObject onTopBarrel;
    [SerializeField] GameObject onTopBox;
    [SerializeField] GameObject barrelplacement;
    [SerializeField] GameObject boxplacement;
    [SerializeField] GameObject RestartButton;
    public CollisionEvent collisionEvent;
    Animation m_animation;
    
    Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
       m_animation=robot.GetComponent<Animation>();
       m_animator=robot.GetComponent<Animator>();
       collisionEvent = GameObject.Find("Robot").GetComponent<CollisionEvent>();
       menuPopup.SetActive(false);
       controlPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnImageTracked(){
        m_animator.SetTrigger("moveup");
        StartCoroutine(delayMenuPopup());
        RestartButton.SetActive(false);
        
    }
    public void OnImageLostTracked(){
       onTopBarrel.SetActive(false);
       onTopBox.SetActive(false);
       barrelplacement.SetActive(false);
       boxplacement.SetActive(false);
       robot.GetComponent<Animator>().enabled = true;
       collisionEvent.ResetCounter();
       collisionEvent.ResetPlacement();
       collisionEvent.ResetWeight();
       SetPosAndRot();
       m_animator.SetTrigger("idle");
        
    }

    public void SceneRestart()
    {
        OnImageLostTracked();
        OnImageTracked();
    }

    public void SetPosAndRot()
    {
        robot.transform.localRotation = Quaternion.identity;
        robot.transform.localPosition = new Vector3(36.81f, -3.0f, 23.14f);
    }
    public void StartbtnEvent()
    {
        menuPopup.SetActive(false);
        controlPopup.SetActive(true);
        RestartButton.SetActive(false);
    }
    public void RestartButtonTrigger(){
        if(PlacedCounter.itemCounter == 10 && WeightCounter.itemCounter >= 35)
        {
            RestartButton.SetActive(true);
        }
        else{
            RestartButton.SetActive(false);
        }
    }    
    IEnumerator delayMenuPopup()
    {
        yield return new WaitForSeconds(1);
        menuPopup.SetActive(true);
    }
    IEnumerator tesetDelay()
    {
        yield return new WaitForSeconds(1);
    }
}
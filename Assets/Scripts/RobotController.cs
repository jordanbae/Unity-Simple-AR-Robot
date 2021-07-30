using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    RobotMovement robotMovement;

    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = gameObject.transform;
    }

    // Update is called once per frame
        void Update()
    {
 
    }


    private void OnTriggerEnter(Collider other){
        if( other.transform.tag == "spawnpoint"){
            robotMovement = other.gameObject.GetComponent<RobotMovement>();
        }
        //Debug.Log(other.transform.tag);
    }

    private void OnTriggerStay(Collider other){
        if(robotMovement == null && other.transform.tag == "spawnpoint"){
            robotMovement = other.gameObject.GetComponent<RobotMovement>();
        }
        //Debug.Log(other.transform.tag);
    }

    private void OnTriggerExit(Collider other){
        robotMovement = null;
        //Debug.Log(other.transform.tag);
    }
    
    public void UpPointerDOWN()
    {
        if(robotMovement != null){
            robotMovement.MoveForward(m_transform);
        }

    }

        public void UpPointerUP()
    {
        
    }

        public void DownPointerDOWN()
    {
        if(robotMovement != null){
            robotMovement.MoveBackward(m_transform);
        }
    }

        public void DownPointerUP()
    {
        
    }

        public void LeftPointerDOWN()
    {
        if(robotMovement != null){
            robotMovement.MoveLeft(m_transform);
        }
    }

        public void LeftPointerUP()
    {
        
    }

        public void RightPointerDOWN()
    {
        if(robotMovement != null){
            robotMovement.MoveRight(m_transform);
        }
    }

        public void RightPointerUP()
    {
        
    }

    public void StopAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }
}

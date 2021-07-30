using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public Transform forward;
    public Transform backward;
    public Transform left;
    public Transform right;


    private Transform m_transform;

    private void Awake()
    {
        m_transform = gameObject.transform;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveForward(Transform robot)
    {
        if(forward!=null){
            LeanTween.rotateLocal(robot.gameObject, new Vector3(0.5f,-178.2f,0.015f), 0.3f);

            LeanTween.moveLocal(robot.gameObject, new Vector3(forward.localPosition.x, robot.localPosition.y, forward.localPosition.z),2.0f);
        }
    }
    public void MoveBackward(Transform robot)
    {
        if(backward!=null){
            LeanTween.rotateLocal(robot.gameObject, new Vector3(-0.5f,0f,0f), 0.3f);
 
            LeanTween.moveLocal(robot.gameObject, new Vector3(backward.localPosition.x, robot.localPosition.y, backward.localPosition.z),2.0f);
        }
    }
    public void MoveLeft(Transform robot)
    {
        if(left!=null){
            LeanTween.rotateLocal(robot.gameObject, new Vector3(0.035f,94f,0.5f), 0.3f);

            LeanTween.moveLocal(robot.gameObject, new Vector3(left.localPosition.x, robot.localPosition.y, left.localPosition.z),2.0f);
        }
    }
    public void MoveRight(Transform robot)
    {
        if(right!=null){
            LeanTween.rotateLocal(robot.gameObject, new Vector3(0f,-90f,0.5f), 0.3f);

            LeanTween.moveLocal(robot.gameObject, new Vector3(right.localPosition.x, robot.localPosition.y, right.localPosition.z),2.0f);
        }
    }

}

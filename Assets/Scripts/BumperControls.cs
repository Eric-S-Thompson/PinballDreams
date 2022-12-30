using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperControls : MonoBehaviour
{
    [Header("Flippers")]
    [SerializeField] private GameObject Lflipper;
    [SerializeField] private GameObject Rflipper;
    [SerializeField] private float flipperSpeed; //Make this negative for right hinge to go up

    //Hinge joints for flippers
    private HingeJoint2D Ljoint;
    private HingeJoint2D Rjoint;

    private JointMotor2D Lmotor;
    private JointMotor2D Rmotor;

    //Keys user is pressing to control flipper
    private bool left;
    private bool right;

    // Start is called before the first frame update
    void Start()
    {
        Ljoint = Lflipper.GetComponent<HingeJoint2D>();
        Rjoint = Rflipper.GetComponent<HingeJoint2D>();

        Lmotor = Ljoint.motor;
        Rmotor = Rjoint.motor;
    }

    void Update()
    {
        //Get user input
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);
    }

    void FixedUpdate()
    {
        if (left)
        {
            Lmotor.motorSpeed = flipperSpeed;
            Ljoint.motor = Lmotor;
            Ljoint.useMotor = true;
        }
        else
        {
            Lmotor.motorSpeed = -flipperSpeed;
            Ljoint.motor = Lmotor;
            //Ljoint.useMotor = false;
        }

        if(right)
        {
            Rmotor.motorSpeed = -flipperSpeed;
            Rjoint.motor = Rmotor;
            Rjoint.useMotor = true;
        }
        else
        {
            Rmotor.motorSpeed = flipperSpeed;
            Rjoint.motor = Rmotor;
            //Rjoint.useMotor = false;
        }
    }
}

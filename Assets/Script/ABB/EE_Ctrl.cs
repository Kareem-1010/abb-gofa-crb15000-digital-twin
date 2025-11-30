// System
using System;
// Unity 
using UnityEngine;
using Debug = UnityEngine.Debug;

using static Robot_Ctrl;

public class EE_Ctrl : MonoBehaviour
{
    // Translation of the fingers before the start
    private Vector3 init_finger_1_translation = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 init_finger_2_translation = new Vector3(0.0f, 0.0f, 0.0f);

    // GameObject of the end-effector
    public GameObject finger_1, finger_2;

    // Other variables
    public static readonly float velocity = 0.00006f;
    private float current_fingers_pos;

    // Start is called before the first frame update
    void Start()
    {
        init_finger_1_translation = finger_1.transform.localPosition;
        init_finger_2_translation = finger_2.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GlobalVariables_Main_Control.Is_Connected == true && ABB_TCP_Control.EE_Config == 1) {
            // Calculate the position between the points with the specified velocity
            if(ABB_TCP_Control.EE_Open == 1)
            {
                current_fingers_pos = Mathf.MoveTowards(current_fingers_pos, 0.0f, velocity * Time.deltaTime);
            }
            else if(ABB_TCP_Control.EE_Close == 1)
            {
                current_fingers_pos = Mathf.MoveTowards(current_fingers_pos, 0.00006f, velocity * Time.deltaTime);
            }

            // Transformation of the fingers depending on the previous calculation
            finger_1.transform.localPosition = new Vector3(init_finger_1_translation.x - current_fingers_pos, init_finger_1_translation.y, init_finger_1_translation.z);
            finger_2.transform.localPosition = new Vector3(init_finger_2_translation.x + current_fingers_pos, init_finger_2_translation.y, init_finger_2_translation.z);
        }
    }
}

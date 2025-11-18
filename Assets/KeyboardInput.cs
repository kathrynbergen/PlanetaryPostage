using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Chuck Chuck;
    //CHANGE TO GAMEPARAMETERS.DOUBLEPRESSTIME
    //Could be changed with an accessibility slider?
    //doublePressThreshold (normal) = 0.15f
    //doublePressThreshold (generous) = 0.25f
    private float doublePressThreshold = 0.15f;

    private bool canSuccessfullyUpPulse;
    private bool canSuccessfullyDownPulse;
    private float upPulseTimer;
    private float downPulseTimer;
    
    void Update()
    {
        //Pulse UP
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.R))
        {
            if (!canSuccessfullyUpPulse)
            {
                //start timer
                canSuccessfullyUpPulse = true;
                upPulseTimer = 0f;
            }
            else
            {
                //if within threshold, pulse
                Debug.Log("UP PULSE");
                Chuck.Pulse();
                canSuccessfullyUpPulse = false;
            }
        }
        if (canSuccessfullyUpPulse)
        {
            //check if button press is still in threshold
            upPulseTimer += Time.deltaTime;
            if (upPulseTimer >= doublePressThreshold)
            {
                //reset timer
                canSuccessfullyUpPulse = false;
            }
        }
        
        //pulse DOWN
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.F))
        {
            if (!canSuccessfullyDownPulse)
            {
                canSuccessfullyDownPulse = true;
                downPulseTimer = 0f;
            }
            else
            {
                Debug.Log("DOWN PULSE");
                Chuck.Pulse();
                canSuccessfullyDownPulse = false;
            }
        }
        if (canSuccessfullyDownPulse)
        {
            downPulseTimer += Time.deltaTime;
            if (downPulseTimer >= doublePressThreshold)
            {
                canSuccessfullyDownPulse = false;
            }
        }
        
        //Movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.R))
        {
            Chuck.Move(new Vector2(0, 1));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.F))
        {
            Chuck.Move(new Vector2(0, -1));
        }
        
        //Parry
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Chuck.Parry();
        }
        
        //boost
        if (Input.GetKeyDown(KeyCode.B))
        {
            Chuck.Boost();
        }
        
    }
}

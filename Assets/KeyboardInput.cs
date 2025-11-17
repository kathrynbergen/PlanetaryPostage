using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Chuck Chuck;
    //CHANGE TO GAMEPARAMETERS.DOUBLEPRESSTIME
    public float doublePressThreshold = 0.25f;

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
                canSuccessfullyUpPulse = true;
                upPulseTimer = 0f;
            }
            else
            {
                Debug.Log("UP PULSE");
                canSuccessfullyUpPulse = false;
            }
        }
        if (canSuccessfullyUpPulse)
        {
            upPulseTimer += Time.deltaTime;
            if (upPulseTimer >= doublePressThreshold)
            {
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
        
    }
}

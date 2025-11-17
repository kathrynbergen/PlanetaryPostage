using UnityEngine;
using System.Collections;

public class Chuck : MonoBehaviour
{
    public SpriteRenderer ChuckSpriteRenderer;
    public Sprite NormalSprite;
    public Sprite ParrySprite;
    
    //Player States
    private bool isParrying = false;
    private bool isBoosting = false;
    private bool isPulsing = false;
    private bool isShooting = false;
    
    //State Access
    private bool canParry = true;
    
    public void Move(Vector2 direction)
    {
        //CHANGE TO GAMEPARAMETERS.CHUCKMOVESPEED
        float ChuckMoveSpeed = 5f;
        float yAmount = direction.y * ChuckMoveSpeed * Time.deltaTime;
        
        ChuckSpriteRenderer.transform.Translate(0, yAmount, 0f);
        //CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    public void Parry()
    {
        if (canParry)
        {
            ChangeToParrySprite();
            isParrying = true;
            Debug.Log("Parry!");
            StartCoroutine(ParryTimer());
        }
    }

    IEnumerator ParryTimer()
    {
        //CHNGE TO GAMEPARAMETERS.PARRYTIME
        yield return new WaitForSeconds(0.2f);
        ReturnFromParry();
    }
    
    private void ReturnFromParry()
    {
        Debug.Log("Returning from Parry!");
        ChangeToNormalSprite();
        isParrying = false;
        canParry = false;
        StartCoroutine(ParryCooldown());
    }
    
    IEnumerator ParryCooldown()
    {
        //CHNGE TO GAMEPARAMETERS.PARRYCOOLDOWN
        Debug.Log("Cooldown Start");
        yield return new WaitForSeconds(5f);
        canParry = true;
        Debug.Log("Cooldown Over");
    }
    
    //Unused, for now
    private void ReturnToNormal()
    {
        Debug.Log("Returning to Normal");
        isPulsing = false;
        isParrying = false;
        isBoosting = false;
        isShooting = false;
        ChangeToNormalSprite();
    }

    private void ChangeToParrySprite()
    {
        ChuckSpriteRenderer.sprite = ParrySprite;
    }

    private void ChangeToNormalSprite()
    {
        ChuckSpriteRenderer.sprite = NormalSprite;
    }
}

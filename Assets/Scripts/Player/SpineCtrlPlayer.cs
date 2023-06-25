using UnityEngine;
using System.Collections;
using Spine;
using Spine.Unity;

public class SpineCtrlPlayer : MonoBehaviour
{
    #region Inspector

    [SpineAnimation]
    public string runAnimation;

    [SpineAnimation]
    public string runAnimationShield;

    [SpineAnimation]
    public string idleAnimation1;

    [SpineAnimation]
    public string idleAnimation2;

    [SpineAnimation]
    public string idleAnimation3;

    [SpineAnimation]
    public string walkAnimation;

    [SpineAnimation]
    public string walkAnimationShield;

    [SpineAnimation]
    public string atkAnimationSword;

    [SpineAnimation]
    public string atkAnimationShield;

    [SpineAnimation]
    public string jumpAnimation;

    [SpineAnimation]
    public string hitAnimation;

    [SpineAnimation]
    public string deathAnimation;

    [SpineAnimation]
    public string stunAnimation;

    [SpineAnimation]
    public string buffAnimation1;
    [SpineAnimation]
    public string buffAnimation2;
    [SpineAnimation]
    public string buffAnimation3;

    #endregion

    SkeletonAnimation skeletonAnimation;

   
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
    }

    public void running()
    {
        spineAnimationState.SetAnimation(0, runAnimation, true);
    }
    public void runningShield()
    {
        spineAnimationState.SetAnimation(0, runAnimationShield, true);
    }
    public void walking()
    {
        spineAnimationState.SetAnimation(0, walkAnimation, true);
    }
    public void walkingShield()
    {
        spineAnimationState.SetAnimation(0, walkAnimationShield, true);
    }
    public void idle1()
    {
        spineAnimationState.SetAnimation(0, idleAnimation1, true);
    }
    public void idle2()
    {
        spineAnimationState.SetAnimation(0, idleAnimation2, true);
    }
    public void idle3()
    {
        spineAnimationState.SetAnimation(0, idleAnimation3, true);
    }
    public void jump()
    {
        spineAnimationState.SetAnimation(0, jumpAnimation, true);
    }
    public void getHit()
    {
        spineAnimationState.SetAnimation(0, hitAnimation, false);
    }
    public void death()
    {
        spineAnimationState.SetAnimation(0, deathAnimation, false);
    }
    public void stun()
    {
        spineAnimationState.SetAnimation(0, stunAnimation, false);
    }
    public void attack_1()
    {
        spineAnimationState.SetAnimation(0, atkAnimationSword, false);
    }
    public void attack_2()
    {
        spineAnimationState.SetAnimation(0, atkAnimationShield, false);
    }
    public void skillBuff_1()
    {
        spineAnimationState.SetAnimation(0, buffAnimation1, false);
    }
    public void skillBuff_2()
    {
        spineAnimationState.SetAnimation(0, buffAnimation2, false);
    }
    public void skillBuff_3()
    {
        spineAnimationState.SetAnimation(0, buffAnimation3, false);
    }
    public void win()
    {
        spineAnimationState.SetAnimation(0, buffAnimation2, true);
    }

}

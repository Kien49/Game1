using UnityEngine;
using System.Collections;
using Spine;
using Spine.Unity;

public class SpineCtrlEnemy : MonoBehaviour
{
    #region Inspector
    [SpineAnimation]
    public string idleTurn;

    [SpineAnimation]
    public string runAnimation;

    [SpineAnimation]
    public string shootAnimation;

    [SpineAnimation]
    public string deathAnimation;

    [SpineAnimation]
    public string hoverboardAnimation;

    [SpineAnimation]
    public string portalAnimation;
    [SpineAnimation]
    public string jumpAnimation;


    #endregion

    SkeletonAnimation skeletonAnimation;

   
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        enemyController = GetComponent<EnemyController>();
    }
    public void Hit()
    {
        spineAnimationState.SetAnimation(0, idleTurn, false);
    }
    public void running()
    {
        spineAnimationState.SetAnimation(0, runAnimation, true);
    }
    public void shoot()
    {
        spineAnimationState.SetAnimation(0, shootAnimation, false);
        StartCoroutine(DelayAnimAtk(.2f));
    }
    public void death()
    {
        spineAnimationState.SetAnimation(0, deathAnimation, false);
        StartCoroutine(desTroy(1f));
    }
    public void hoverBoard()
    {
        spineAnimationState.SetAnimation(0, hoverboardAnimation, false);
    }
    public void portal()
    {
        spineAnimationState.SetAnimation(0, portalAnimation, false);
    }
    public void jump()
    {
        spineAnimationState.SetAnimation(0, jumpAnimation, true);
    }

    private IEnumerator desTroy(float time)
    {
        yield return new WaitForSeconds(time);
        if(GameCtrl.ins.statusAtkBoss) GameCtrl.ins.isSpawnBoss = true;
        if (GameCtrl.ins.statusAtkNormal) GameCtrl.ins.isSpawnNormal = true;
        Destroy(gameObject);
    }

    private IEnumerator DelayAnimAtk(float time)
    {

        yield return new WaitForSeconds(time);
        PlayerController.ins.TakeDamege(enemyController.dameEnemy);
    }

}

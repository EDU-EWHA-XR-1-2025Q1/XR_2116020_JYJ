using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Door의 애니메이터를 컨트롤하는 클래스입니다.
/// </summary>
public class Door_Controller : MonoBehaviour
{
    /// <summary>
    /// Door의 Animator
    /// </summary>
    public Animator Animator;
    /// <summary>
    /// 바깥인지 감지할 Laycast의 거리
    /// </summary>
    public float rayDistance = 3f;

    private void Update()
    {
       
        /* 실제 레이캐스트 로직 */
        Ray InsideRay = new Ray(transform.position, transform.forward);//안
        RaycastHit InsideHit;

        if (Physics.Raycast(InsideRay, out InsideHit, rayDistance))
        {
            Debug.Log("플레이어 안인상태");
            Animator.SetBool("IsOutdoor", false);
        
        }

        Ray OutsideRay = new Ray(transform.position , -transform.forward);//밖
        RaycastHit OutsideHit;

        if (Physics.Raycast(OutsideRay, out OutsideHit, rayDistance))
        {
            Debug.Log("플레이어 바깥인상태");
            Animator.SetBool("IsOutdoor", true);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Animator.SetInteger("status", 1);
        //만약 바깥으로 갔다면
        
    }

    private void OnTriggerExit(Collider other)
    {
        Animator.SetInteger("status", 2);
    }
}

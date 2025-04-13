using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vehicle의 움직임을 제어하는 스크립트입니다.
/// </summary>
public class Vehicle_Controller : MonoBehaviour
{
    /// <summary>
    /// Vehicle의 애니메이터
    /// </summary>
    public Animator Animator;

    private void Update()
    {
        /*Room2도달 시, Room1향하도록 재조정*/
        float MyZ = this.transform.position.z;

        if (Mathf.Abs(MyZ - (28.79f)) < 0.1f)
        {
            Animator.SetBool("IsMoveToRoom1", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("플레이어 탑승!");
        //애니메이션 재생 시작
        Animator.speed = 1f;
        Animator.SetBool("IsRiding", true);
        Debug.Log("IsRiding을 true로");
        //충돌대상 위에 태우기
        other.gameObject.transform.SetParent(this.transform);
        other.gameObject.transform.position = this.transform.position + Vector3.up * 2f;
    }
    private void OnTriggerExit(Collider other)
    {
        //애니메이션 재생 중지
        Animator.speed = 0f;
        Animator.SetBool("IsRiding", false);
        Debug.Log("IsRiding을 false로");
        //대상 차량에서 내려주기
        other.gameObject.transform.SetParent(null);
    }

}

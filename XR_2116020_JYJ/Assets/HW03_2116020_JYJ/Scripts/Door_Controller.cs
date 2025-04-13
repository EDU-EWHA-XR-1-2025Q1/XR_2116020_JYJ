using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Door�� �ִϸ����͸� ��Ʈ���ϴ� Ŭ�����Դϴ�.
/// </summary>
public class Door_Controller : MonoBehaviour
{
    /// <summary>
    /// Door�� Animator
    /// </summary>
    public Animator Animator;
    /// <summary>
    /// �ٱ����� ������ Laycast�� �Ÿ�
    /// </summary>
    public float rayDistance = 3f;

    private void Update()
    {
       
        /* ���� ����ĳ��Ʈ ���� */
        Ray InsideRay = new Ray(transform.position, transform.forward);//��
        RaycastHit InsideHit;

        if (Physics.Raycast(InsideRay, out InsideHit, rayDistance))
        {
            Debug.Log("�÷��̾� ���λ���");
            Animator.SetBool("IsOutdoor", false);
        
        }

        Ray OutsideRay = new Ray(transform.position , -transform.forward);//��
        RaycastHit OutsideHit;

        if (Physics.Raycast(OutsideRay, out OutsideHit, rayDistance))
        {
            Debug.Log("�÷��̾� �ٱ��λ���");
            Animator.SetBool("IsOutdoor", true);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Animator.SetInteger("status", 1);
        //���� �ٱ����� ���ٸ�
        
    }

    private void OnTriggerExit(Collider other)
    {
        Animator.SetInteger("status", 2);
    }
}

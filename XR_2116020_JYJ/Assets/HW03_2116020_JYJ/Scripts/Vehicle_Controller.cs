using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vehicle�� �������� �����ϴ� ��ũ��Ʈ�Դϴ�.
/// </summary>
public class Vehicle_Controller : MonoBehaviour
{
    /// <summary>
    /// Vehicle�� �ִϸ�����
    /// </summary>
    public Animator Animator;

    private void Update()
    {
        /*Room2���� ��, Room1���ϵ��� ������*/
        float MyZ = this.transform.position.z;

        if (Mathf.Abs(MyZ - (28.79f)) < 0.1f)
        {
            Animator.SetBool("IsMoveToRoom1", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�÷��̾� ž��!");
        //�ִϸ��̼� ��� ����
        Animator.speed = 1f;
        Animator.SetBool("IsRiding", true);
        Debug.Log("IsRiding�� true��");
        //�浹��� ���� �¿��
        other.gameObject.transform.SetParent(this.transform);
        other.gameObject.transform.position = this.transform.position + Vector3.up * 2f;
    }
    private void OnTriggerExit(Collider other)
    {
        //�ִϸ��̼� ��� ����
        Animator.speed = 0f;
        Animator.SetBool("IsRiding", false);
        Debug.Log("IsRiding�� false��");
        //��� �������� �����ֱ�
        other.gameObject.transform.SetParent(null);
    }

}

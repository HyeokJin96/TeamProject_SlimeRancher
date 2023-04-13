using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_fuckingHole : MonoBehaviour
{
    public GameObject blackhole;

    GameObject[] stars;

    float time;

    Vector3 dir;

    bool fuckU;

    private void Start()
    {
        blackhole.SetActive(false);

        // "Star"�� �±׷� �ް��ִ� ���ӿ�����Ʈ�� ã�Ƽ� Star �迭�� ��´�.
        // stars = GameObject.FindGameObjectsWithTag("Star");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            blackhole.SetActive(true);
            fuckU= true;
        }

        time += Time.deltaTime;

        if (fuckU)
        {
            foreach (GameObject star in stars)
            {
                // ����Ȧ�� �༺�� �ǽð� �Ÿ��� �����Ѵ�.
                float dis = Vector3.Distance(this.transform.position, star.transform.position);

                // 1�ʰ� ������ ��(= ����Ȧ�� �����ǰ� 1�ʰ� ������ ��)
                if (time > 1)
                {
                    // �༺���κ��� ����Ȧ�� ���ϴ� ������ ���Ѵ�.
                    dir = blackhole.transform.position - star.transform.position;
                    // �༺�� ��ġ�� ����Ȧ�� �������� õõ�� �̵���Ų��.
                    star.transform.position += dir * 1f * Time.deltaTime;
                }
                // ����Ȧ�� �༺�� �Ÿ��� 0.3f���ϰ� �Ǹ�
                if (dis <= 0.3f)
                {
                    // �༺�� ����Ȧ�� ���� �� ������ �̵���Ų��.
                    star.transform.position += dir * 3f * Time.deltaTime;
                }
                // ����Ȧ�� �༺�� �Ÿ��� 0.05f ���ϰ� �Ǹ�
                if (dis <= 0.05f)
                {
                    // �༺�� ����Ȧ�� �� ������ �̵���Ų��.
                    star.transform.position += dir * 5f * Time.deltaTime;
                    // �༺�� ũ�⸦ �����Ӹ��� 0.9�� �۾����� �����.
                    star.transform.localScale *= 0.9f;
                }
                // ����Ȧ�� �������� 10�ʰ� ������
                if (time >= 10)
                {
                    // ����Ȧ�� ��������.
                    blackhole.gameObject.SetActive(false);
                    // ���Ƶ帰 �༺�� ���� ���������� �ƴϸ� �ǵ������� ���� ���� �ʿ信 ���� Ŀ��������
                }
            }
        }


    }
}

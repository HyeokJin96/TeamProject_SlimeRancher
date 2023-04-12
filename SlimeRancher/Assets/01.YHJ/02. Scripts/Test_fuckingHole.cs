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

        // "Star"를 태그로 달고있는 게임오브젝트를 찾아서 Star 배열에 담는다.
        stars = GameObject.FindGameObjectsWithTag("Star");
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
                // 블랙홀과 행성의 실시간 거리를 측정한다.
                float dis = Vector3.Distance(this.transform.position, star.transform.position);

                // 1초가 지났을 때(= 블랙홀이 생성되고 1초가 지났을 때)
                if (time > 1)
                {
                    // 행성으로부터 블랙홀로 향하는 방향을 구한다.
                    dir = blackhole.transform.position - star.transform.position;
                    // 행성의 위치를 블랙홀의 방향으로 천천히 이동시킨다.
                    star.transform.position += dir * 1f * Time.deltaTime;
                }
                // 블랙홀과 행성의 거리가 0.3f이하가 되면
                if (dis <= 0.3f)
                {
                    // 행성을 블랙홀로 조금 더 빠르게 이동시킨다.
                    star.transform.position += dir * 3f * Time.deltaTime;
                }
                // 블랙홀과 행성의 거리가 0.05f 이하가 되면
                if (dis <= 0.05f)
                {
                    // 행성을 블랙홀로 더 빠르게 이동시킨다.
                    star.transform.position += dir * 5f * Time.deltaTime;
                    // 행성의 크기를 프레임마다 0.9씩 작아지게 만든다.
                    star.transform.localScale *= 0.9f;
                }
                // 블랙홀이 생성된지 10초가 지나면
                if (time >= 10)
                {
                    // 블랙홀을 꺼버린다.
                    blackhole.gameObject.SetActive(false);
                    // 빨아드린 행성을 같이 꺼버리던가 아니면 되돌리던가 등은 각자 필요에 따라 커스텀하자
                }
            }
        }


    }
}

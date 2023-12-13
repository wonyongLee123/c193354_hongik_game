using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPillar3 : BTNode
{
    private BossPillar bossPillar = Resources.Load<BossPillar>("BossPillar");
    public override BTNodeStatus Execute()
    {
        float distanceFromOrigin = Random.Range(2, 4);
        for (int i = 0; i < 3; i++)
        {
            // 360도를 numberOfObjects로 나누어 각도를 계산
            float angle = i * (360f / 3);

            // 각도에 따른 원의 좌표를 계산하여 위치 설정
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * distanceFromOrigin;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * distanceFromOrigin;

            // 정해진 위치에 오브젝트 생성
            Object.Instantiate(bossPillar, new Vector3(x, y, 0f), Quaternion.identity);
        }
        
        return BTNodeStatus.Success;
    }
}

public class SpawnPillar5 : BTNode
{
    private BossPillar bossPillar = Resources.Load<BossPillar>("BossPillar");
    public override BTNodeStatus Execute()
    {
        float distanceFromOrigin = Random.Range(2, 4);
        for (int i = 0; i < 5; i++)
        {
            // 360도를 numberOfObjects로 나누어 각도를 계산
            float angle = i * (360f / 5);

            // 각도에 따른 원의 좌표를 계산하여 위치 설정
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * distanceFromOrigin;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * distanceFromOrigin;

            // 정해진 위치에 오브젝트 생성
            Object.Instantiate(bossPillar, new Vector3(x, y, 0f), Quaternion.identity);
        }
        return BTNodeStatus.Success;
    }
}

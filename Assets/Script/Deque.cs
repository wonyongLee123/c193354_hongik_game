using System.Collections.Generic;
using UnityEngine;

/*
 *  rewind(되감기)를 위한 위치 정보를 기록하는 recorder는 삽입 시 FIFO(후입선출)을 필요로 하고
 *  후에 rewind를 실행할 때 LIFO(선입선출)을 필요로 합니다. 따라서 양 끝 삽입/삭제에 상수시간을 소요하는
 *  덱(deque)자료형이 필요했기에 LinkedList를 사용했습니다. 
 */

public class Deque
{
    private LinkedList<Vector2> list = new LinkedList<Vector2>();

    public void AddFront(Vector2 item)
    {
        list.AddFirst(item);
    }

    public void AddBack(Vector2 item)
    {
        list.AddLast(item);
    }

    public Vector2 RemoveFront()
    {
        if (list.Count == 0) return new Vector2();

        Vector2 value = list.First.Value;
        list.RemoveFirst();
        return value;
    }

    public Vector2 RemoveBack()
    {
        if (list.Count == 0) return new Vector2();

        Vector2 value = list.Last.Value;
        list.RemoveLast();
        return value;
    }

    public int Count
    { // 프로퍼티 설정
        get { return list.Count; }
    }
}

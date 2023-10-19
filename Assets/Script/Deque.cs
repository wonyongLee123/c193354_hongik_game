using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 *  rewind(�ǰ���)�� ���� ��ġ ������ ����ϴ� recorder�� ���� �� FIFO(���Լ���)�� �ʿ�� �ϰ�
 *  �Ŀ� rewind�� ������ �� LIFO(���Լ���)�� �ʿ�� �մϴ�. ���� �� �� ����/������ ����ð��� �ҿ��ϴ�
 *  ��(deque)�ڷ����� �ʿ��߱⿡ LinkedList�� ����߽��ϴ�. 
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

    public void Empty(){
        list.Clear();
    }

    public int Count
    { get { return list.Count; } }
}

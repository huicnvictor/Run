using UnityEngine;
using DG.Tweening;

public class MoveAlongPath : MonoBehaviour
{
    public Transform[] waypoints;  // ·��������
    public float duration = 5f;    // ��������ʱ��
    public PathType pathType = PathType.CatmullRom; // ·������

    void Start()
    {
        if (waypoints.Length < 2)
        {
            Debug.LogError("·�����������㣬������Ҫ����·���㡣");
            return;
        }

        // ����·��������
        Vector3[] path = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            path[i] = waypoints[i].position;
        }

        // ʹ��DOTween��·����������
        transform.DOPath(path, duration, pathType)
                 .SetOptions(false)  // ����·���պϣ����·�����պϿ�������Ϊfalse
                 .SetEase(Ease.Linear)  // ���ö�����������
                 .SetLookAt(0.01f);  // ���ó���·���ķ���
                 //.SetLoops(1, LoopType.Yoyo);  // ����ѭ����Yoyoģʽ
    }
}
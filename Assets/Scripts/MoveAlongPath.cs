using UnityEngine;
using DG.Tweening;

public class MoveAlongPath : MonoBehaviour
{
    public Transform[] waypoints;  // 路径点数组
    public float duration = 5f;    // 动画持续时间
    public PathType pathType = PathType.CatmullRom; // 路径类型

    void Start()
    {
        if (waypoints.Length < 2)
        {
            Debug.LogError("路径点数量不足，至少需要两个路径点。");
            return;
        }

        // 创建路径点数组
        Vector3[] path = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            path[i] = waypoints[i].position;
        }

        // 使用DOTween的路径动画功能
        transform.DOPath(path, duration, pathType)
                 .SetOptions(false)  // 设置路径闭合，如果路径不闭合可以设置为false
                 .SetEase(Ease.Linear)  // 设置动画缓动类型
                 .SetLookAt(0.01f);  // 设置朝向路径的方向
                 //.SetLoops(1, LoopType.Yoyo);  // 设置循环，Yoyo模式
    }
}
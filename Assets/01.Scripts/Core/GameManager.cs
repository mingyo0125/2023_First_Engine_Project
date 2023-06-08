using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEvent GameOver;
    public static GameManager Instance;

    [SerializeField]
    PoolingListSO _poolingListSO;

    [SerializeField]
    CanvasScaler _canvasScaler;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is running! Check!");
        }
        Instance = this;
        MakePool();
        Setresolution();
    }

    private void Setresolution()
    {
        //Default �ػ� ����
        float fixedAspectRatio = 9f / 16f;

        //���� �ػ��� ����
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        //���� �ػ� ���� ������ �� �� ���
        if (currentAspectRatio > fixedAspectRatio) _canvasScaler.matchWidthOrHeight = 1;
        //���� �ػ��� ���� ������ �� �� ���
        else if (currentAspectRatio < fixedAspectRatio) _canvasScaler.matchWidthOrHeight = 0;
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolingListSO.List.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount)); //����Ʈ�� �ִ� ���
    }

    public void GameOverDebug()
    {
        Debug.Log("GameOver");
    }


}

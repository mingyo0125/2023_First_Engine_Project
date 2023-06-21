using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        //Default 해상도 비율
        float fixedAspectRatio = 9f / 16f;

        //현재 해상도의 비율
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        //현재 해상도 가로 비율이 더 길 경우
        if (currentAspectRatio > fixedAspectRatio) _canvasScaler.matchWidthOrHeight = 1;
        //현재 해상도의 세로 비율이 더 길 경우
        else if (currentAspectRatio < fixedAspectRatio) _canvasScaler.matchWidthOrHeight = 0;
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolingListSO.List.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount)); //리스트에 있는 모든
    }

    public void GameOverDebug()
    {
        Debug.Log("GameOver");
    }

    public void TimeControl()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void SceneReload()
    {
        SceneManager.LoadScene("SampleScene");
    }


}

using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {
    // 不需要做成单例类

    private static Dictionary<string, GameState> m_GameStateMap = null;
    private static GameState m_CurrState = null;

    void Start () {
        // 这里或许有点晚
        m_GameStateMap = new Dictionary<string, GameState>();
        m_CurrState = null;
        LoadScene(1);
    }

    /// <summary>
    /// 设置状态
    /// </summary>
    private static void SetState(GameState state)
    {
        if (state == null)
        {
            return;
        }
        if (state != m_CurrState)
        {
            if (m_CurrState != null)
            {
                m_CurrState.Stop();
            }
            m_CurrState = state;
            m_CurrState.Start();
        }
    }

    /// <summary>
    /// 加载场景，坐在GamestateMgr不合适，或许需要一个SceneMgr
    /// </summary>
    /// <param name="sceneId">场景表ID</param>
    public static void LoadScene(int sceneId)
    {
        SceneData sceneData = DataManager.sceneDataManager.GetData(sceneId);

        if (sceneData == null)
        {
            Debug.Log("Error sceneID " + sceneId);
            return;
        }

        GameState state = null;
        if (!m_GameStateMap.TryGetValue(sceneData.GameState, out state))
        {
            state = Assembly.GetExecutingAssembly().CreateInstance(sceneData.GameState) as GameState;
            if (state == null)
            {
                Debug.Log("state wrong:" + sceneData.GameState);
                return;
            }
            m_GameStateMap.Add(sceneData.GameState, state);
        }
        SetState(state);

        // 状态设置完成，开始Load场景
        DownloadManager.Instance.LoadScene(sceneData.LevelName, state.LoadComplete);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDot : MonoBehaviour {

    private Dictionary<string, Transform> m_DotDic = new Dictionary<string, Transform>();
    public List<Transform> DotList = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < DotList.Count; i++)
        {
            var DotListi = DotList[i];
            if (!m_DotDic.ContainsKey(DotListi.name))
            {
                // 后续战斗中会根据这些点dot索引出位置。
                m_DotDic.Add(DotListi.name, DotListi);
            }
        }
    }

    /// <summary>
    /// 根据这些点dotName索引出位置。
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Transform GetEffectDot(string name)
    {
        return m_DotDic.ContainsKey(name) ? m_DotDic[name] : null;
    }
}

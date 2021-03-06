using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
public class AddLightmap : MonoBehaviour {

    public Texture2D far;
    public Texture2D near;
    private bool assigned = false;
[HideInInspector]
	public bool enter = false;
	
	public void Update () {

        if (!assigned && enter && Application.isEditor && !Application.isPlaying )
        {      
            
         LightmapData data = new LightmapData();
			// copy to folder and import the copied and assign them
			if(far!=null)
        data.lightmapColor = far;
			if(near!=null)
        data.lightmapDir = near;
 

            int i = 0;
            bool exists = false;
            foreach (LightmapData dt in LightmapSettings.lightmaps)
            {
                if (dt.lightmapColor == far && dt.lightmapDir == near)
                {
                    this.GetComponent<Renderer>().lightmapIndex = i;
                    exists = true;
                    break;
                }

                i++;

            }
            if (!exists)
            {
                ResizeArray.Add(LightmapSettings.lightmaps.Length , data);
                this.GetComponent<Renderer>().lightmapIndex = LightmapSettings.lightmaps.Length-1;
            }

            assigned = true;
            DestroyImmediate(this);
        }
	}
	

}

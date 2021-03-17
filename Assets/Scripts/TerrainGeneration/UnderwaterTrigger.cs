using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnderwaterTrigger : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile profile;
    public float waterLevel = 2f;
    
    private void Start()
    {
        vol = gameObject.AddComponent<PostProcessVolume>();
        vol.isGlobal = true;
        vol.profile = profile;
        vol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUnderWater())
        {
            vol.enabled = true;
            LensDistortion lens = vol.profile.GetSetting<LensDistortion>();
            lens.centerX.value = Mathf.Cos(Time.realtimeSinceStartup / 2.2314f);
            lens.centerY.value = Mathf.Sin((Time.realtimeSinceStartup *1.3f) / 3.2348765f);
        }
        else
        {
            vol.enabled = false;
        }
    }

    private bool IsUnderWater()
    {
        return transform.position.y < waterLevel;
    }
}

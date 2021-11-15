using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class Property_vs_Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private VisualEffect m_TargetVisualEffect;
    private VFXEventAttribute m_EventAttribute;
    private float m_WaitTime = 0.2f;

    private static readonly int s_FireAID = Shader.PropertyToID("fire_A");
    private static readonly int s_FireBID = Shader.PropertyToID("fire_B");
    private static readonly int s_ColorID = Shader.PropertyToID("color");
    private static readonly int s_ExposedColorID = Shader.PropertyToID("exposed_color");

    // Update is called once per frame
    void Update()
    {
        m_WaitTime -= Time.deltaTime;
        if (m_WaitTime < 0.0f)
        {

            m_WaitTime = 0.2f;

            if (m_TargetVisualEffect == null)
                m_TargetVisualEffect = GetComponent<VisualEffect>();

            if (m_EventAttribute == null)
                m_EventAttribute = m_TargetVisualEffect.CreateVFXEventAttribute();

            //Using exposed property
            m_TargetVisualEffect.SetVector3(s_ExposedColorID, new Vector3(1, 0, 0));
            m_TargetVisualEffect.SendEvent(s_FireAID, m_EventAttribute);

            m_TargetVisualEffect.SetVector3(s_ExposedColorID, new Vector3(0, 1, 0));
            m_TargetVisualEffect.SendEvent(s_FireAID, m_EventAttribute);

            m_TargetVisualEffect.SetVector3(s_ExposedColorID, new Vector3(0, 0, 1));
            m_TargetVisualEffect.SendEvent(s_FireAID, m_EventAttribute);

            //Using event attribute data
            //Spawn 1 Red
            m_EventAttribute.SetVector3(s_ColorID, new Vector3(1, 0, 0));
            m_TargetVisualEffect.SendEvent(s_FireBID, m_EventAttribute);

            //Spawn 1 Green
            m_EventAttribute.SetVector3(s_ColorID, new Vector3(0, 1, 0));
            m_TargetVisualEffect.SendEvent(s_FireBID, m_EventAttribute);

            //Spawn 1 Blue
            m_EventAttribute.SetVector3(s_ColorID, new Vector3(0, 0, 1));
            m_TargetVisualEffect.SendEvent(s_FireBID, m_EventAttribute);

        }
    }
}

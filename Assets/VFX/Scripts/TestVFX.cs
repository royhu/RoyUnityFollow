using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TestVFX : MonoBehaviour
{
    public VisualEffect m_VisualEffect = null;
    public int m_EmitCountPerFrame = 5;

    private static int s_ColorId = Shader.PropertyToID("color");
    private static int s_PostionId = Shader.PropertyToID("position");
    private static int s_EventId = Shader.PropertyToID("Emit");

    private Vector3 m_Color = Vector3.forward;
    private Vector3 m_Position = new Vector3(0, 0, 0);
    private VFXEventAttribute m_EventAttr;

    private void Update()
    {
        // seems not supporting
        m_VisualEffect ??= GetComponent<VisualEffect>();

        if (m_VisualEffect == null)
        {
            return;
        }
        if (m_EventAttr == null)
        {
            m_EventAttr = m_VisualEffect.CreateVFXEventAttribute();
        }

        for (int i = 0; i < m_EmitCountPerFrame; i++)
        {
            m_Color.x = Random.Range(0.1f, 1.0f);
            m_Color.y = Random.Range(0.1f, 1.0f);
            m_Color.z = Random.Range(0.1f, 1.0f);

            m_Position.x = Random.Range(-5.0f, 5.0f);
            m_Position.y = Random.Range(-5.0f, 5.0f);
            m_Position.z = Random.Range(-5.0f, 5.0f);

            m_EventAttr.SetVector3(s_ColorId, m_Color);
            m_EventAttr.SetVector3(s_PostionId, m_Position);
            m_VisualEffect.SendEvent(s_EventId, m_EventAttr);
        }
    }
}

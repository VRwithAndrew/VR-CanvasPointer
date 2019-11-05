using UnityEngine;

public class OculusInputModule : VRInputModule
{
    /*
    public OVRInput.Controller m_Source = OVRInput.Controller.RTrackedRemote;
    public OVRInput.Button m_Click = OVRInput.Button.Any;
    */
    public override void Process()
    {
        base.Process();

        /*
        // Press
        if (OVRInput.GetDown(m_Click, m_Source))
            Press();

        // Release
        if (OVRInput.GetUp(m_Click, m_Source))
            Release();
        */
    }
}

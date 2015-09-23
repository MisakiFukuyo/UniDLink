using UnityEngine;
using System.Collections;
using UniDLink;

public class PositionCursor : MonoBehaviour
{
    public Transform xCursor;
    public Transform yCursor;
    public Transform zCursor;

    private UniDCaptureLinker<float, Transform> xLink;
    private UniDCaptureLinker<float, Transform> yLink;
    private UniDCaptureLinker<float, Transform> zLink;
    private UniDCaptureLinker<Vector3, Transform> cursorSelf;
    
    void Awake()
    {
        xLink = new UniDCaptureLinker<float, Transform>(xCursor, (t) => t.position.x, (t, f) => t.position = new Vector3(f, t.position.y, t.position.z));
        yLink = new UniDCaptureLinker<float, Transform>(yCursor, (t) => t.position.y, (t, f) => t.position = new Vector3(t.position.x, f, t.position.z));
        zLink = new UniDCaptureLinker<float, Transform>(zCursor, (t) => t.position.z, (t, f) => t.position = new Vector3(t.position.x, t.position.y, f));

        cursorSelf = new UniDCaptureLinker<Vector3, Transform>(transform, (t) => transform.position, (t, v3) => t.position = v3);

        cursorSelf.AddOnSignaled((v3) => { 
            xLink.LinkedValue = v3.x;
            yLink.LinkedValue = v3.y;
            zLink.LinkedValue = v3.z;
        });
    }
	
	void Update ()
    {
        cursorSelf.Signaling();
	}
}

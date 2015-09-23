using UnityEngine;
using System.Collections;
using UniDLink;

public class PositionCursorDualLink : MonoBehaviour {

    public Transform xCursor;
    public Transform yCursor;
    public Transform zCursor;

    private UniDCaptureLinker<float, Transform> xLink;
    private UniDCaptureLinker<float, Transform> yLink;
    private UniDCaptureLinker<float, Transform> zLink;

    private UniDCaptureLinker<float, Transform> xLinkSelf;
    private UniDCaptureLinker<float, Transform> yLinkSelf;
    private UniDCaptureLinker<float, Transform> zLinkSelf;

    private UniDDualLinker<float> xDualLink;
    private UniDDualLinker<float> yDualLink;
    private UniDDualLinker<float> zDualLink;


    void Awake()
    {
        xLink = new UniDCaptureLinker<float, Transform>(xCursor, (t) => t.position.x, (t, f) => t.position = new Vector3(f, t.position.y, t.position.z));
        yLink = new UniDCaptureLinker<float, Transform>(yCursor, (t) => t.position.y, (t, f) => t.position = new Vector3(t.position.x, f, t.position.z));
        zLink = new UniDCaptureLinker<float, Transform>(zCursor, (t) => t.position.z, (t, f) => t.position = new Vector3(t.position.x, t.position.y, f));

        xLinkSelf = new UniDCaptureLinker<float, Transform>(transform, (t) => t.position.x, (t, f) => t.position = new Vector3(f, t.position.y, t.position.z));
        yLinkSelf = new UniDCaptureLinker<float, Transform>(transform, (t) => t.position.y, (t, f) => t.position = new Vector3(t.position.x, f, t.position.z));
        zLinkSelf = new UniDCaptureLinker<float, Transform>(transform, (t) => t.position.z, (t, f) => t.position = new Vector3(t.position.x, t.position.y, f));

        xDualLink = UniDDualLinker<float>.DualLink(xLink, xLinkSelf);
        yDualLink = UniDDualLinker<float>.DualLink(yLink, yLinkSelf);
        zDualLink = UniDDualLinker<float>.DualLink(zLink, zLinkSelf);

    }
	void Start () 
    {
	
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.right * Time.deltaTime;
            xLinkSelf.Signaling();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime;
            xLinkSelf.Signaling();
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime;
            yLinkSelf.Signaling();
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * Time.deltaTime;
            yLinkSelf.Signaling();
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.forward * Time.deltaTime;
            zLinkSelf.Signaling();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= Vector3.forward * Time.deltaTime;
            zLinkSelf.Signaling();
        }


        if (Input.GetKey(KeyCode.T))
        {
            xCursor.position += Vector3.right * Time.deltaTime;
            xLink.Signaling();
        }
        if (Input.GetKey(KeyCode.G))
        {
            xCursor.position -= Vector3.right * Time.deltaTime;
            xLink.Signaling();
        }

        if (Input.GetKey(KeyCode.Y))
        {
            yCursor.position += Vector3.up * Time.deltaTime;
            yLink.Signaling();
        }
        if (Input.GetKey(KeyCode.H))
        {
            yCursor.position -= Vector3.up * Time.deltaTime;
            yLink.Signaling();
        }

        if (Input.GetKey(KeyCode.U))
        {
            zCursor.position += Vector3.forward * Time.deltaTime;
            zLink.Signaling();
        }
        if (Input.GetKey(KeyCode.J))
        {
            zCursor.position -= Vector3.forward * Time.deltaTime;
            zLink.Signaling();
        }
	}
}

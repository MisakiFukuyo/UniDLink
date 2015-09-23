using UnityEngine;
using System.Collections;
using UniDLink;

public class PositionCursorDualLink : MonoBehaviour {

    public float moveSpeed = 3;

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
            xLinkSelf.LinkedValue += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xLinkSelf.LinkedValue -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            yLinkSelf.LinkedValue += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yLinkSelf.LinkedValue -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            zLinkSelf.LinkedValue += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            zLinkSelf.LinkedValue -= moveSpeed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.T))
        {
            xLink.LinkedValue += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.G))
        {
            xLink.LinkedValue -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Y))
        {
            yLink.LinkedValue += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.H))
        {
            yLink.LinkedValue -= moveSpeed* Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.U))
        {
            zLink.LinkedValue += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J))
        {
            zLink.LinkedValue -= moveSpeed * Time.deltaTime;
        }
	}
}

using UnityEngine;
using System.Collections;

public class LaserPointer : MonoBehaviour {
	
	private const float LINE_WIDTH = 0.02f;
	
	public Color color1 = Color.magenta;
	public Color color2 = Color.magenta;
	
	public LineRenderer lineRenderer;
	
	void Start () {
		lineRenderer = (LineRenderer) gameObject.AddComponent("LineRenderer");
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(color1, color2);
		lineRenderer.SetWidth(LINE_WIDTH, LINE_WIDTH);
		lineRenderer.SetVertexCount(2);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 origin = transform.position;
		Vector3 forwardDirection = transform.forward;
		origin.y = origin.y + 0.1f;
		Vector3 endPoint = origin + forwardDirection * 500f;
		RaycastHit hit = new RaycastHit();
		
		lineRenderer.SetPosition(0, origin);
		if (Physics.Raycast (origin, forwardDirection, out hit))
			endPoint = hit.point;
		lineRenderer.SetPosition(1, endPoint);
	
	}
}

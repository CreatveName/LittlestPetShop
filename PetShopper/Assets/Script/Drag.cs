using UnityEngine;

public class Drag : MonoBehaviour
{
	public LayerMask m_DragLayers;

	[Range (0.0f, 100.0f)]
	public float m_Damping = 1.0f;

	[Range (0.0f, 100.0f)]
	public float m_Frequency = 5.0f;

	public bool m_DrawDragLine = true;
	public Color m_Color = Color.cyan;

	public float forceNum = 10f;

	public float maxSpeed = 5f;

	private TargetJoint2D m_TargetJoint;

	void Update ()
	{
		// Calculate the world position for the mouse.
		var worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Input.GetMouseButtonDown (0))
		{
			// Fetch the first collider.
			// NOTE: We could do this for multiple colliders.
			var collider = Physics2D.OverlapPoint (worldPos, m_DragLayers);
			if (!collider)
				return;

			// Fetch the collider body.
			var body = collider.attachedRigidbody;
			if (!body)
				return;

			// Add a target joint to the Rigidbody2D GameObject.
			m_TargetJoint = body.gameObject.AddComponent<TargetJoint2D> ();
			m_TargetJoint.dampingRatio = m_Damping;
			m_TargetJoint.frequency = m_Frequency;

			// Attach the anchor to the local-point where we clicked.
			m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint (worldPos);		
		}
		else if (Input.GetMouseButtonUp (0))
		{
			Destroy (m_TargetJoint);
			m_TargetJoint = null;
			return;
		}

		// Update the joint target.
		if (m_TargetJoint)
		{
			m_TargetJoint.target = worldPos;

			// Draw the line between the target and the joint anchor.
			if (m_DrawDragLine)
				Debug.DrawLine (m_TargetJoint.transform.TransformPoint (m_TargetJoint.anchor), worldPos, m_Color);

            //apply directional force on key press
            Rigidbody2D heldBody = m_TargetJoint.GetComponent<Rigidbody2D>();
            if (heldBody != null)
            {
				Vector2 moveDirection = Vector2.zero;

				if (Input.GetKey(KeyCode.D))
    				moveDirection += Vector2.left;
				if (Input.GetKey(KeyCode.A))
    				moveDirection += Vector2.right;

				if (moveDirection != Vector2.zero)
				{
    				heldBody.AddForce(moveDirection.normalized * forceNum * Time.deltaTime, ForceMode2D.Force);
				}

				if (heldBody.linearVelocity.magnitude > maxSpeed)
				{
    				heldBody.linearVelocity = heldBody.linearVelocity.normalized * maxSpeed;
				}
            }
        }
	}
}
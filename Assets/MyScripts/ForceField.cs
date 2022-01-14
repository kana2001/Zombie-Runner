using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public ParticleSystemForceFieldShape m_Shape = ParticleSystemForceFieldShape.Sphere;
    public float m_StartRange = 0.0f;
    public float m_EndRange = 3.0f;
    public Vector3 m_Direction = Vector3.zero;
    public float m_Gravity = 0.0f;
    public float m_GravityFocus = 0.0f;
    public float m_RotationSpeed = 0.0f;
    public float m_RotationAttraction = 0.0f;
    public Vector2 m_RotationRandomness = Vector2.zero;
    public float m_Drag = 0.0f;
    public bool m_MultiplyDragByParticleSize = false;
    public bool m_MultiplyDragByParticleVelocity = false;

    private ParticleSystemForceField m_ForceField;

    void Start()
    {
        // Create a Force Field
        var go = new GameObject("ForceField", typeof(ParticleSystemForceField));
        go.transform.position = new Vector3(0, 2, 0);
        go.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));

        m_ForceField = go.GetComponent<ParticleSystemForceField>();

        // Configure Particle System
        transform.position = new Vector3(0, -4, 0);
        transform.rotation = Quaternion.identity;
        var ps = GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startSize = new ParticleSystem.MinMaxCurve(0.05f, 0.2f);
        main.startSpeed = new ParticleSystem.MinMaxCurve(1.5f, 2.5f);
        main.maxParticles = 100000;

        var emission = ps.emission;
        emission.rateOverTime = 0.0f;
        emission.burstCount = 1;
        emission.SetBurst(0, new ParticleSystem.Burst(0.0f, 200, 200, -1, 0.1f));

        var shape = ps.shape;
        shape.shapeType = ParticleSystemShapeType.SingleSidedEdge;
        shape.radius = 5.0f;
        shape.radiusMode = ParticleSystemShapeMultiModeValue.BurstSpread;
        shape.randomPositionAmount = 0.1f;
        shape.randomDirectionAmount = 0.05f;

        var forces = ps.externalForces;
        forces.enabled = true;
    }

    void Update()
    {
        m_ForceField.shape = m_Shape;
        m_ForceField.startRange = m_StartRange;
        m_ForceField.endRange = m_EndRange;
        m_ForceField.directionX = m_Direction.x;
        m_ForceField.directionY = m_Direction.y;
        m_ForceField.directionZ = m_Direction.z;
        m_ForceField.gravity = m_Gravity;
        m_ForceField.gravityFocus = m_GravityFocus;
        m_ForceField.rotationSpeed = m_RotationSpeed;
        m_ForceField.rotationAttraction = m_RotationAttraction;
        m_ForceField.rotationRandomness = m_RotationRandomness;
        m_ForceField.drag = m_Drag;
        m_ForceField.multiplyDragByParticleSize = m_MultiplyDragByParticleSize;
        m_ForceField.multiplyDragByParticleVelocity = m_MultiplyDragByParticleVelocity;
    }

    void OnGUI()
    {
        GUIContent[] shapeLabels = Enum.GetNames(typeof(ParticleSystemForceFieldShape)).Select(n => new GUIContent(n)).ToArray();
        m_Shape = (ParticleSystemForceFieldShape)GUI.SelectionGrid(new Rect(25, 25, 400, 25), (int)m_Shape, shapeLabels, 4);

        float y = 80.0f;
        float spacing = 40.0f;

        GUI.Label(new Rect(25, y, 140, 30), "Start Range");
        m_StartRange = GUI.HorizontalSlider(new Rect(165, y + 5, 100, 30), m_StartRange, 0.0f, 2.0f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "End Range");
        m_EndRange = GUI.HorizontalSlider(new Rect(165, y + 5, 100, 30), m_EndRange, 2.0f, 3.0f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "Direction");
        m_Direction.x = GUI.HorizontalSlider(new Rect(165, y + 5, 40, 30), m_Direction.x, -1.0f, 1.0f);
        m_Direction.y = GUI.HorizontalSlider(new Rect(210, y + 5, 40, 30), m_Direction.y, -1.0f, 1.0f);
        m_Direction.z = GUI.HorizontalSlider(new Rect(255, y + 5, 40, 30), m_Direction.z, -1.0f, 1.0f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "Gravity");
        m_Gravity = GUI.HorizontalSlider(new Rect(165, y + 5, 100, 30), m_Gravity, -0.05f, 0.05f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "Gravity Focus");
        m_GravityFocus = GUI.HorizontalSlider(new Rect(165, y + 5, 100, 30), m_GravityFocus, 0.0f, 1.0f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "Rotation Speed");
        m_RotationSpeed = GUI.HorizontalSlider(new Rect(165, y + 5, 100, 30), m_RotationSpeed, -10.0f, 10.0f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "Rotation Attraction");
        m_RotationAttraction = GUI.HorizontalSlider(new Rect(165, y + 5, 100, 30), m_RotationAttraction, 0.0f, 0.01f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "Rotation Randomness");
        m_RotationRandomness.x = GUI.HorizontalSlider(new Rect(165, y + 5, 60, 30), m_RotationRandomness.x, 0.0f, 1.0f);
        m_RotationRandomness.y = GUI.HorizontalSlider(new Rect(230, y + 5, 60, 30), m_RotationRandomness.y, 0.0f, 1.0f);
        y += spacing;

        GUI.Label(new Rect(25, y, 140, 30), "Drag");
        m_Drag = GUI.HorizontalSlider(new Rect(165, y + 5, 100, 30), m_Drag, 0.0f, 20.0f);
        y += spacing;

        m_MultiplyDragByParticleSize = GUI.Toggle(new Rect(25, y, 220, 30), m_MultiplyDragByParticleSize, "Multiply Drag by Particle Size");
        y += spacing;

        m_MultiplyDragByParticleVelocity = GUI.Toggle(new Rect(25, y, 220, 30), m_MultiplyDragByParticleVelocity, "Multiply Drag by Particle Velocity");
        y += spacing;
    }
}
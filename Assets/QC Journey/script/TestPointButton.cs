using UnityEngine;

public class TestPointButton : MonoBehaviour
{
    public QCPointSystem qcSystem;

    public void AddTestPoint()
    {
        qcSystem.AddTestPoint(10); // ���� 10 �������͡�
    }
}

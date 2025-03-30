using UnityEngine;

public class TestPointButton : MonoBehaviour
{
    public QCPointSystem qcSystem;

    public void AddTestPoint()
    {
        qcSystem.AddTestPoint(10); // เพิ่ม 10 แต้มเมื่อกด
    }
}

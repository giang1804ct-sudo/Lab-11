/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Lớp có sẵn từ hệ thống cũ, giả định không được phép chỉnh sửa mã nguồn
public sealed class LegacySmokeDetector
{
    private int smokeLevel; // Thang đo từ 0 đến 1000

    public LegacySmokeDetector(int smokeLevel)
    {
        this.smokeLevel = smokeLevel;
    }

    public int GetSmokeLevel() => smokeLevel; // 0..1000
    public string GetDescription() => "Legacy smoke detector";

    public void SetSmokeLevel(int value)
    {
        smokeLevel = Math.Clamp(value, 0, 1000);
    }
}

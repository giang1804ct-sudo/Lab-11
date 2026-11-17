/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Adapter chuyển đổi giao diện và thang đo của LegacySmokeDetector sang ISensor
public sealed class SmokeSensorAdapter : ISensor
{
    private readonly LegacySmokeDetector legacy;

    public SmokeSensorAdapter(LegacySmokeDetector legacy)
    {
        this.legacy = legacy ?? throw new ArgumentNullException(nameof(legacy));
    }

    // Chuyển đổi thang đo 0..1000 của thiết bị cũ thành 0..100%
    public double ReadValue()
    {
        return legacy.GetSmokeLevel() / 10.0;
    }

    // Đơn vị chuẩn phần trăm khói
    public string GetUnit() => "% smoke";
}

/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Thiết bị còi báo động khẩn cấp
public sealed class Alarm
{
    private bool isRinging;

    public void SoundAlarm()
    {
        isRinging = true;
        Console.WriteLine("[CÒI BÁO ĐỘNG]: RENG... RENG...! BẬT CÒI BÁO CHÁY KHẨN CẤP!");
    }

    public void StopAlarm()
    {
        isRinging = false;
        Console.WriteLine("[CÒI BÁO ĐỘNG]: ĐÃ TẮT CÒI BÁO ĐỘNG.");
    }

    public bool IsRinging => isRinging;
}

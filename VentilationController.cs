/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Thiết bị điều khiển hệ thống quạt thông gió và hút khói
public sealed class VentilationController
{
    private bool isExhaustRunning;

    public void StartExhaust()
    {
        isExhaustRunning = true;
        Console.WriteLine("[HỆ THỐNG THÔNG GIÓ]: BẬT QUẠT HÚT KHÓI CÔNG SUẤT TỐI ĐA ĐỂ THOÁT KHÍ ĐỘC!");
    }

    public void StopExhaust()
    {
        isExhaustRunning = false;
        Console.WriteLine("[HỆ THỐNG THÔNG GIÓ]: ĐÃ DỪNG HỆ THỐNG HÚT KHÓI.");
    }

    public bool IsExhaustRunning => isExhaustRunning;
}

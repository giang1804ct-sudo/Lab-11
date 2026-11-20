/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Bridge Observer: Cầu nối lắng nghe cảnh báo từ SensorMonitor và kích hoạt Mediator khi mức độ là CRITICAL
public sealed class EmergencyBridgeObserver : IAlertObserver
{
    private readonly IEmergencyMediator mediator;

    public EmergencyBridgeObserver(IEmergencyMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public void Update(AlertEvent alertEvent)
    {
        // Tiêu chí quan trọng: Chỉ khi đạt ngưỡng CRITICAL (>= 70%) mới kích hoạt ứng phó khẩn cấp
        if (alertEvent.Severity == "CRITICAL")
        {
            Console.WriteLine(
                $"[CẦU NỐI KHẨN CẤP]: Phát hiện sự cố NGUY CẤP (CRITICAL) từ {alertEvent.SensorName} " +
                $"({alertEvent.Value:F1}{alertEvent.Unit})! Gửi lệnh FIRE_DETECTED sang Mediator...");

            mediator.TriggerEmergency("FIRE_DETECTED");
        }
        else
        {
            Console.WriteLine(
                $"[CẦU NỐI KHẨN CẤP]: Mức {alertEvent.Severity} chưa đạt ngưỡng CRITICAL -> Không kích hoạt ứng phó khẩn cấp.");
        }
    }
}

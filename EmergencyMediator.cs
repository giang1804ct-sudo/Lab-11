/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Mediator phối hợp hoạt động của Alarm, DoorController và VentilationController
public sealed class EmergencyMediator : IEmergencyMediator
{
    private readonly Alarm alarm;
    private readonly DoorController doorController;
    private readonly VentilationController ventilationController;

    public EmergencyMediator(
        Alarm alarm,
        DoorController doorController,
        VentilationController ventilationController)
    {
        this.alarm = alarm ?? throw new ArgumentNullException(nameof(alarm));
        this.doorController = doorController ?? throw new ArgumentNullException(nameof(doorController));
        this.ventilationController = ventilationController ?? throw new ArgumentNullException(nameof(ventilationController));
    }

    public void TriggerEmergency(string eventType)
    {
        if (eventType == "FIRE_DETECTED")
        {
            Console.WriteLine("\n>>> [MEDIATOR]: NHẬN TÍN HIỆU HỎA HOẠN KHẨN CẤP (FIRE_DETECTED) -> TIẾN HÀNH ĐIỀU PHỐI ĐỒNG BỘ:");
            // 1. Kích hoạt còi báo động
            alarm.SoundAlarm();
            // 2. Mở toàn bộ cửa thoát hiểm
            doorController.UnlockAllDoors();
            // 3. Khởi động quạt hút khói công suất tối đa
            ventilationController.StartExhaust();
            Console.WriteLine(">>> [MEDIATOR]: ĐÃ HOÀN THÀNH QUY TRÌNH ỨNG PHÓ KHẨN CẤP BAN ĐẦU!\n");
        }
        else
        {
            Console.WriteLine($"[MEDIATOR]: Sự kiện chưa có kịch bản xử lý: {eventType}");
        }
    }
}

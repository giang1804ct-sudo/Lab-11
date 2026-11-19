/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

namespace CampusSafetyHub;

// Hợp đồng điều phối khẩn cấp (Mediator Interface)
public interface IEmergencyMediator
{
    void TriggerEmergency(string eventType);
}

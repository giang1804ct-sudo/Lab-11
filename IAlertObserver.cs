/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

namespace CampusSafetyHub;

// Hợp đồng nhận cảnh báo (Observer interface)
public interface IAlertObserver
{
    void Update(AlertEvent alertEvent);
}

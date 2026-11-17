/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

namespace CampusSafetyHub;

// Giao diện chuẩn mà module giám sát sử dụng để đọc giá trị cảm biến
public interface ISensor
{
    double ReadValue();
    string GetUnit();
}

/*****************/
// Mã sinh viên: 202418889
// Họ tên: Đặng Thị Hương Giang
/*****************/

using System;

namespace CampusSafetyHub;

// Observer gửi email cảnh báo tự động cho ban quản trị
public sealed class EmailAlertObserver : IAlertObserver
{
    private readonly string recipientEmail;

    public EmailAlertObserver(string recipientEmail = "admin-safety@campus.edu.vn")
    {
        this.recipientEmail = recipientEmail;
    }

    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[GỬI EMAIL TỚI {recipientEmail}]: Cảnh báo {alertEvent.Severity}! " +
            $"Khu vực: {alertEvent.SensorName}, Nồng độ khói: {alertEvent.Value:F1}{alertEvent.Unit}");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerWithDetailAsync();
        Boolean AddCustomer(Customer infor);
        Task<bool> CustomerExists(string id, string email);

        // Lấy thông tin khách hàng theo ID
        Task<Customer?> GetCustomerByIdAsync(string customerId);

        // Cập nhật thông tin khách hàng
        Task<Boolean> UpdateCustomerAsync(Customer customer);

        // Xóa khách hàng dựa trên ID
        Task<Boolean> DeleteCustomerAsync(string customerId);

        // Lấy danh sách đơn hàng cá của khách hàng
        Task<List<OrderKoi>> GetCustomerKoiOrdersAsync(string customerId);

        // Lấy danh sách đơn hàng chuyến đi của khách hàng
        Task<List<OrderTrip>> GetCustomerTripOrdersAsync(string customerId);

        // Lấy danh sách phản hồi của khách hàng
        Task<List<Feedback>> GetCustomerFeedbacksAsync(string customerId);

        // Thêm phản hồi mới
        Task<bool> AddFeedbackAsync(Feedback feedback);

        // Lấy tất cả phản hồi
        Task<List<Feedback>> GetAllFeedbacksAsync();

        Task<Customer?> GetCustomerByEmail(string email);
        Task<bool> ValidateCustomerLogin(string email, string password);
    }
}

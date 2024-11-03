using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using System.Globalization;

namespace ShopCaKoi.Services
{
    public interface IGuestService
    {
        // Lấy tất cả các trang trại cá Koi tại Nhật
        List<KoiFarm> GetAllKoiFarmsInJapan();

        // Lấy danh sách các giống cá Koi trong một trang trại
        List<Koi> GetKoiBreedsByFarm(string farmId);

        // Lấy thông tin chi tiết của trang trại cá Koi
        KoiFarm GetFarmDetails(string farmId);

        // Lấy chi tiết về một giống cá Koi
        Koi GetKoiDetails(string koiId);

        // Lấy danh sách các chuyến đi tham quan các trang trại cá Koi
        List<Trip> GetAllKoiFarmTours();

        // Lọc chuyến đi theo các tiêu chí như trang trại, mức giá, loại cá và ngày khởi hành
        List<Trip> FilterTours(string farmId, string priceRange, string koiType, DateTime? date);

        // Tạo tài khoản mới cho khách vãng lai
        bool RegisterGuestAccount(ShopCaKoiAccount account);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using System.Globalization;

namespace ShopCaKoi.Repositores
{
    public interface IGuestRepository
    {
        // Lấy tất cả các trang trại cá Koi ở Nhật
        List<KoiFarm> GetAllKoiFarmsInJapan();

        // Lấy tất cả các giống cá Koi trong một trang trại
        List<Koi> GetAllKoiBreedsByFarm(string farmId);

        // Lấy thông tin chi tiết của một trang trại cá Koi
        KoiFarm GetFarmDetails(string farmId);

        // Lấy thông tin chi tiết của một giống cá Koi
        Koi GetKoiDetails(string koiId);

        // Lấy danh sách các chuyến tham quan trang trại cá Koi
        List<Trip> GetAllKoiFarmTours();

        // Lọc các chuyến tham quan theo tiêu chí
        List<Trip> FilterTours(string farmId, string priceRange, string koiType, DateTime? date);

        // Tạo tài khoản cho khách vãng lai để sử dụng dịch vụ
        bool CreateAccount(ShopCaKoiAccount account);

    }
}

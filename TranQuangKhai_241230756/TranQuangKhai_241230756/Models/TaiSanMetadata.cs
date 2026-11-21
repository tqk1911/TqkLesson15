using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace TranQuangKhai_241230756.Models;
[ModelMetadataType(typeof(TaiSanMetadata))]
public partial class TaiSan { }
public class TaiSanMetadata
{
    [Required(ErrorMessage ="Tiêu đề tài sản không được để trống")]
    public string? TenTs { get; set; }
    [Required(ErrorMessage ="Vui lòng nhập nguyên giá")]
    [Range(1, 2000, ErrorMessage ="Nguyên giá phải từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }
    [RegularExpression(@"(?i)^.+\.(jpg|jpeg|png|webp)$", ErrorMessage ="Định dạng ảnh không hợp lệ")]
    public string? Anh { get; set; }
}

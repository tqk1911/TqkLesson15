using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace TranQuangKhai_241230756_De02.Models;

[ModelMetadataType(typeof(TaiSanMetadata))]
public partial class TaiSan { }

public class TaiSanMetadata
{
    [Required(ErrorMessage ="Tên tài sản không được để trống")]
    public string? TenTs { get; set; }
    [Required(ErrorMessage ="Vui lòng nhập nguyên giá")]
    [Range(1, 2000, ErrorMessage ="Nguyên giá phải từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }
    [RegularExpression(@"(?i)^.+\.(jpg|jpeg|png|webp)$", ErrorMessage ="Ảnh sai định dạng")]
    public string? Anh { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyBanHang.Data.Class
{
    public static class StringExtensions
    {
        public static string GenerateSlug(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = input.ToLower().Trim();

            // bỏ dấu tiếng Việt
            input = Regex.Replace(input, "[áàạảãâấầậẩẫăắằặẳẵ]", "a");
            input = Regex.Replace(input, "[éèẹẻẽêếềệểễ]", "e");
            input = Regex.Replace(input, "[íìịỉĩ]", "i");
            input = Regex.Replace(input, "[óòọỏõôốồộổỗơớờợởỡ]", "o");
            input = Regex.Replace(input, "[úùụủũưứừựửữ]", "u");
            input = Regex.Replace(input, "[ýỳỵỷỹ]", "y");
            input = Regex.Replace(input, "đ", "d");

            // bỏ ký tự đặc biệt
            input = Regex.Replace(input, @"[^a-z0-9\-]", "-");
            input = Regex.Replace(input, @"-+", "-");

            return input.Trim('-');
        }
    }
}

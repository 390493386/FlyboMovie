using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.ViewModels
{
    public class MovieUploadViewModel
    {
        [Required(ErrorMessage = "请填写视频名称")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "名称长度3-100")]
        [DisplayName("视频名称")]
        public string Title { get; set; }

        [DisplayName("试播时间")]
        public int? TrySeconds { get; set; }

        [Required(ErrorMessage ="请添加视频封面海报")]
        [DisplayName("视频封面海报")]
        public IFormFile Poster { get; set; }

        [Required(ErrorMessage ="请添加视频")]
        [DisplayName("视频")]
        public IFormFile Movie { get; set; }
    }
}

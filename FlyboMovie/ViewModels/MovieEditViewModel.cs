using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlyboMovie.ViewModels
{
    public class MovieEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="请输入视频名称")]
        [DisplayName("视频名称")]
        public string Name { get; set; }

        [DisplayName("试播时间/秒")]
        public int? TrySeconds { get; set; }
    }
}

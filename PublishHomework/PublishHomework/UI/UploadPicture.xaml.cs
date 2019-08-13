using Cvte.EasiNote;
using Cvte.Net.Http;
using Cvte.Paint.Features.Elements.Images;
using PublishHomework.ViewModels;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;

namespace PublishHomework
{
    /// <summary>
    /// UploadPicture.xaml 的交互逻辑
    /// </summary>
    public partial class UploadPicture : Window
    {
        public UploadPicture(IList<string> pictures)
        {
            InitializeComponent();
            PublishViewModel.Instance.Pictures.Clear();
            PublishViewModel.Instance.Tips = string.Empty;
            foreach (var pic in pictures)
            {
                string imagePath = pic.Replace(@"file:///", string.Empty);
                var fileStream = new FileStream(imagePath,FileMode.Open, FileAccess.Read, FileShare.Read);
                if (fileStream.Length > 1048576)
                {
                    PublishViewModel.Instance.Tips = "单张图片不能大于1M，请重新选择图片";
                    PublishViewModel.Instance.Pictures.Clear();
                    break;
                }
                else
                {
                    PublishViewModel.Instance.Pictures.Add(new PictureInfo
                    {
                        FilePath = pic,
                        IsChecked = true
                    });
                }                
            }                      
        }    
    }
}

using System.ComponentModel;

namespace PublishHomework.Models
{
    public enum Subject
    {
        [Description("语文")]
        Chinese = 01,

        [Description("数学")]
        Math = 02,

        [Description("英语")]
        English = 03,

        [Description("其它")]
        Others = 04
    }
}
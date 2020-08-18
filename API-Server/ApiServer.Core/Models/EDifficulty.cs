using System.ComponentModel;

namespace ApiServer.Core.Models
{
    public enum EDifficulty
    {
        [Description("EASY")]
        Eesy,

        [Description("MEDIUM")]
        Medium,

        [Description("DIFFICULT")]
        Difficult
    }
}
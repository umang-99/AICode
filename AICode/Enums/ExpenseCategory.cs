using System.ComponentModel;
using System.Runtime.Serialization;

namespace AICode.Contracts
{
    public enum ExpenseCategory
    {
        [Description("Food")]
        [EnumMember(Value = "food")]
        Food = 1,

        [Description("Housing")]
        [EnumMember(Value = "housing")]
        Housing = 2,

        [Description("Transportation")]
        [EnumMember(Value = "transportation")]
        Transportation = 3,

        [Description("Utilities")]
        [EnumMember(Value = "utilities")]
        Utilities = 4,

        [Description("Healthcare")]
        [EnumMember(Value = "healthcare")]
        Healthcare = 5,

        [Description("Entertainment")]
        [EnumMember(Value = "entertainment")]
        Entertainment = 6,

        [Description("Education")]
        [EnumMember(Value = "education")]
        Education = 7,

        [Description("Other")]
        [EnumMember(Value = "other")]
        Other = 8
    }
}
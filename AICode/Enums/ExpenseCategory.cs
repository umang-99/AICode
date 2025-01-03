using System.ComponentModel;
using System.Runtime.Serialization;
namespace AICode.Contracts
{
    public enum ExpenseCategory
    {
        [Description("Housing")]
        [EnumMember(Value = "housing")]
        Housing = 1,
        [Description("Food & Dining")]
        [EnumMember(Value = "food_and_dining")]
        FoodAndDining = 2,
        [Description("Transportation")]
        [EnumMember(Value = "transportation")]
        Transportation = 3,
        [Description("Health & Fitness")]
        [EnumMember(Value = "health_and_fitness")]
        HealthAndFitness = 4,
        [Description("Entertainment")]
        [EnumMember(Value = "entertainment")]
        Entertainment = 5,
        [Description("Travel")]
        [EnumMember(Value = "travel")]
        Travel = 6,
        [Description("Shopping")]
        [EnumMember(Value = "shopping")]
        Shopping = 7,
        [Description("Education")]
        [EnumMember(Value = "education")]
        Education = 8,
        [Description("Savings & Investments")]
        [EnumMember(Value = "savings_and_investments")]
        SavingsAndInvestments = 9,
        [Description("Insurance")]
        [EnumMember(Value = "insurance")]
        Insurance = 10,
        [Description("Family & Kids")]
        [EnumMember(Value = "family_and_kids")]
        FamilyAndKids = 11,
        [Description("Pets")]
        [EnumMember(Value = "pets")]
        Pets = 12,
        [Description("Personal Care")]
        [EnumMember(Value = "personal_care")]
        PersonalCare = 13,
        [Description("Utilities & Bills")]
        [EnumMember(Value = "utilities_and_bills")]
        UtilitiesAndBills = 14,
        [Description("Miscellaneous")]
        [EnumMember(Value = "miscellaneous")]
        Miscellaneous = 15
    }
}
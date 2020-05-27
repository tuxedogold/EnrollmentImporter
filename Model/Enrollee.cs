using System;
using System.Globalization;

namespace Model
{
    public class Enrollee
    {
        public Enrollee(string[] args)
        {
            Args = args;
        }
        public Enrollee()
        {
            Args = new string[5];
        }
        public string[] Args;
        public const string DateFormat = "MMddyyyy"; 

        public string FirstName
        {
            get
            {
                return Args[0];
            }
            set
            {
                Args[0] = value;
            }
        }
        
        public string LastName
        {
            get
            {
                return Args[1];
            }
            set
            {
                Args[1] = value;
            }
        }
        
        public DateTime DateOfBirth
        {
            get
            {
                string[] formats = { DateFormat };
                DateTime date;
                DateTime.TryParseExact(Args[2], formats, new CultureInfo("en-US"),
                                            DateTimeStyles.None, out date);
                return date;
            }
            set
            {
                Args[2] = value.ToString(DateFormat);
            }
        }
        public PlanType PlanType
        {
            get
            {
                PlanType result;
                return Enum.TryParse(Args[3], true, out result) ? result : PlanType.Invalid;
            }
            set
            {
                Args[3] = value.ToString();
            }
        }
        public DateTime EffectiveDate
        {
            get
            {
                string[] formats = {DateFormat};
                DateTime date;
                DateTime.TryParseExact(Args[4], formats, new CultureInfo("en-US"),
                                            DateTimeStyles.None, out date);
                return date;
            }
            set
            {
                Args[4] = value.ToString(DateFormat);
            }
        }
        
        public ProcessingStatus ProcessingStatus;
    }
}
         

public enum PlanType
    {
        Invalid,
        HSA,
        HRA,
        FSA
    }
    
    public enum ProcessingStatus
    {
        Unprocessed,
        InvalidData,
        Rejected,
        Approved
    }

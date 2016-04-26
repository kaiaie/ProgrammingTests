using System;

namespace Entities
{
    public class Employment
    {
        public Person Employee { get; set; }

        public DateTime EmployementStartDate { get; set; }

        public DateTime? EmploymentEndDate { get; set; }

        /// <summary>
        ///     Return the number of Years that a employee has been Employed
        /// </summary>
        /// <returns></returns>
        public double NumberOfYearsEmployed
        {
            get
            {
                return Math.Abs(
                    (EmploymentEndDate.HasValue ? EmploymentEndDate.Value.Year : DateTime.Now.Year) 
                    - EmployementStartDate.Year
                );
            }
        }
    }
}
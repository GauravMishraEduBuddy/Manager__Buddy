using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EduBuddyApp.Models
{
    public class Bus
    {
        public int BusID { get; set; }
        [Required]
        public string BusNumber { get; set; }
        public int SchoolId { get; set; }
        public int Capacity { get; set; }
        public string? MaintenanceSchedule { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? InsuranceDetails { get; set; }
        public bool IsActive { get; set; }
        [Required]
        //validation DriverID >0
        [RequiredNonDefault(ErrorMessage = "Driver selection is required.")]
        public int DriverID { get; set; }
        public virtual School? School { get; set; }
        public virtual Employee? Driver  { get; set; }
    }
    public class RequiredNonDefaultAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue && intValue == 0)
                return new ValidationResult("This field is required.", new[] { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }

    public class Route
    {
        public int RouteID { get; set; }
        public string RouteName { get; set; }
        public int SchoolId { get; set; }
        public string? Description { get; set; }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
        public double? TotalDistance { get; set; }
        public double? EstimatedDuration { get; set; }
        public bool IsActive { get; set; }
        public int BusId { get; set; }

        public virtual School? School { get; set; }
        public virtual ICollection<Stop>? Stops { get; set; }
        public virtual Bus? Bus { get; set; }
       

    }
    public class Stop
    {
        public int StopID { get; set; }
        public string StopName { get; set; }
        //public int SchoolId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public decimal Fees { get; set; }
        public double? Distance { get; set; }
        public int RouteID { get; set; }
        public bool IsActive { get; set; }
        public virtual Route Route { get; set; }
        //public virtual School? School { get; set; }
    }
    public class StudentTransport
    {
        public int StudentTransportID { get; set; }
        public int StudentID { get; set; }
        //public int BusID { get; set; }
        public int StopID { get; set; }
        public bool IsUsing { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Comments { get; set; }
        //public virtual Bus? Bus { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Stop? Stop { get; set; }

    }
    public class StudentTransportViewModel
    {
        public int StudentTransportID { get; set; }
        public int StudentID { get; set; }
        public string? ExternalStudentID { get; set; }
        public int SchoolId { get; set; }
        public int BusID { get; set; }
        public int StopID { get; set; }
        public bool IsUsing { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Comments { get; set; }
        public string? StudentName { get; set; }
        public string? SectionName { get; set; }
        public string? ClassName { get; set; }
        public string? BusNumber { get; set; }
        public string? StopName { get; set; }
       public string? RouteName { get; set; }
        public decimal Fees { get; set; }
        //fathername
        public string? FatherName { get; set; }
        //fathermobile
        public string? FatherMobileNo { get; set; }

    }

   



}

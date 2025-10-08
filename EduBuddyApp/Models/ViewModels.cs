using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
namespace EduBuddyApp.Models
{
    public class StudentGridViewModel
    {
        public string ExternalStudentID { get; set; } // For external ID systems

        [Required]
        public string StudentName { get; set; }

        public string FatherName { get; set; }

        public bool IsStudying { get; set; }

        public string SessionName { get; set; } // From AcademicSession

        public string SectionName { get; set; } // From Section

        public string ClassName { get; set; } // From Class

        // Additional properties or methods if necessary
        // For example, formatting or derived properties
    }
    public class StudentIDCardViewModel
    {
        public int StudentId { get; set; }
        public int? StudentExternalId { get; set; }
        public string? StudentName { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? FatherName { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? StudentImageUrl { get; set; }
        public string? StudentAddress { get; set; }
        public string? OpenExamName { get; set; }
       
    }
    public class StudentTransferCertificateViewModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? MotherName { get; set; }
        public string? FatherName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsStudying { get; set; }
        public string? Pen { get; set; }
        public string? LastInstitution { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DateOfRemoval { get; set; }
        public string? LeavingReason { get; set; }
        public string? Class { get; set; }
        public string? Year { get; set; }
    }


    public class SchoolClassViewModel
    {
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
        public string? SchoolName { get; set; }
        public string? AcademicSession { get; set; }
        public int? SchoolId { get; set; }
        public string? Sections { get; set; }
        public string NewSectionName { get; set; } // Temporary property for new section name
        //public List<SectionViewModel>? Sections { get; set; } //

        // Add additional properties if needed
    }

    public class SchoolViewModel
    {
        public int SchoolId { get; set; }
        public string? SchoolName { get; set; }
        // add for Property SchoolName, SchoolCode, Address, PrincipalNam
        public string? SchoolCode { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public BoardOfEducation? BoardOfEducation { get; set; }
        //PartnerProvider
        public string? PartnerProvider { get; set; }
        //GlobalAdministrator
        public string? GlobalAdministrator { get; set; }
        public SchoolRegion? SchoolRegion { get; set; }

        public string? PrincipalName { get; set; }
        public string? SchoolContact { get; set; }
        public string? SchoolWebsite { get; set; }
        public string? SchoolLogoUrl { get; set; }
        public int? StudentCount { get; set; }
        public int? EmployeeCount { get; set; }
        public int? ReceiptCount { get; set; }
        public int? ActiveUserCount { get; set; }
        public EduBuddy_Status? EduBuddy_Status { get; set; }
        public Running_Status? Running_Status { get; set; }
        public bool IsCurrentlyActive { get; set; }
        //id created date
        public DateTime? CreatedDate { get; set; }

        //starting date
        public DateTime? StartingDate { get; set; }
        //Cost_Details
        public string? Cost_Details { get; set; }


    }
    //for resync in CreateFeeRecrods
    public class StudentSectionViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public bool IsNewStudent { get; set; }
        // Add any other properties you need
    }

    //SectionViewModel
    public class SectionViewModel
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string? ClassName { get; set; }
        public string? AcademicSession { get; set; }
        public int AcademicSessionId { get; set; }
        public string? SchoolName { get; set; }
        public int? TeacherId { get; set; }
        public string? EmployeeName { get; set; }
        public int? NoofStudents { get; set; }
        public int? SchoolClassId { get; set; }
        public int? SubjectCount { get; set; }
        public int? WeeklyLoad { get; set; }
        public string? ClassNameSectionName { get; set; }


        // Add additional properties if needed
    }
    public class SectionSummaryViewModel
    {
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public int StudyingCount { get; set; }
        public int NotStudyingCount { get; set; }
        // Add any other properties relevant to your display requirements
    }
    public class AdmissionReferenceSummaryViewModel
    {
        public string AdmissionReference { get; set; }
        public int StudyingCount { get; set; }
        public int NotStudyingCount { get; set; }
    }
    public class AdmissionReferenceBatchData
    {
        public string AdmissionReference { get; set; }
        public Dictionary<int, int> BatchData { get; set; } = new Dictionary<int, int>();
        public int Total => BatchData.Values.Sum(); // Calculates total by summing the values in BatchData dictionary

        // Optional property if needed:
        public int StudyingCount => BatchData.Values.Sum(); // Calculates the total studying count from BatchData
    }



    //AcademicSession ViewModel
    public class AcademicSessionViewModel
    {
        public int AcademicSessionId { get; set; }
        public string AcademicSessionName { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCode { get; set; }

        public bool IsOpen { get; set; }

        public bool IsNewSession { get; set; }


    }
    // StudentCategory Viewmodel
    public class StudentCategoryViewModel
    {
        public int StudentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCode { get; set; }
        public int SchoolId { get; set; }
    }

    //StudentHouse Viewmodel
    public class StudentHouseViewModel
    {
        public int StudentHouseId { get; set; }
        public string HouseName { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCode { get; set; }
        public int SchoolId { get; set; }
    }

    //Employee ViewModel
    //viewmodel used for Create New Student
    public class StudentViewModelCreateNew
    {

        public string? ExternalStudentID { get; set; } // For external ID systems
        [Required(ErrorMessage = "Student Name is required.")]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Father Name is required.")]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string FatherName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsStudying { get; set; }
        public bool IsCommonFeesExempt { get; set; }

        public int? StudentHouseID { get; set; }
        public int? StudentCategoryID { get; set; }
        public string? SubCatergory { get; set; }
        [Required(ErrorMessage = "Academic Session Required")]
        public int AcademicSessionId { get; set; } // Link to AcademicSession

        public DateTime? AdmissionDate { get; set; }
        public int? SectionId { get; set; }

        [Phone]
        public string? FatherMobileNo { get; set; }
        public string? Address { get; set; }
        public int? BatchID { get; set; }
        public Branch? Branch { get; set; }
        public StuStatus? StuStatus { get; set; }
        public string? MotherName { get; set; }

        public Gender? Gender { get; set; }
        public NccOption? NccOption { get; set; }
        public bool Olympiad { get; set; } = false;


    }
    //student ViewModel
    public class StudentViewModel
    {
        public int StudentID { get; set; } // Primary Key

        public int? SchoolID { get; set; } // Link to School

        public string? ExternalStudentID { get; set; } // For external ID systems

        public int AcademicSessionId { get; set; } // Link to AcademicSession
        public string? AcademicSessionName { get; set; }
        public bool? IsNewAdmission { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string StudentName { get; set; }

        public string? FatherName { get; set; }
        public bool IsStudying { get; set; }

        public int? StudentHouseID { get; set; }
        public string? HouseName { get; set; }
        public int? SiblingGroupId { get; set; }
        public string? ClassName { get; set; }
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }
        public int? StudentCategoryID { get; set; }
        public string? SubCatergory { get; set; }
        public string? CategoryName { get; set; }
        public string? ClassTeacherName { get; set; }
        //for college
        public int? BatchID { get; set; }
        public string? BatchName { get; set; }
        public Branch? BranchStu { get; set; }
        public StuStatus? StuStatusStu { get; set; }

        //audit
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //AdmissionDate
        public DateTime? StuDateOfBirth { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public MarkupString? FeeRecordsHtml { get; set; }
        public MarkupString? ReceiptRecordsHtmlString { get; set; }
        public string? Address { get; set; }
        public string? StudentMobileNo { get; set; }
        public string? StudentEmail { get; set; }
        [Phone]
        public string? FatherMobileNo { get; set; }
        public string? MotherName { get; set; }
        public string? MotherMobileNo { get; set; }
        public string? AdmissionSource { get; set; }

        public string? AdharCardNo { get; set; }
        public string? AdharCardFather { get; set; }
        public string? AdmissionReference { get; set; }
        public string? PEN { get; set; }
        public string? APARId { get; set; }
        public string? Password { get; set; }

        public bool? IsUsingTransport { get; set; }
        //IsUsingHostel
        public int? StudentTransportID { get; set; }
        public bool? IsUsingHostel { get; set; }
        public StudentRecordsViewModel? StudentRecords { get; set; } = new StudentRecordsViewModel();
        public Section? Section { get; set; }

        public decimal? TotalAmountDue { get; set; }
        public decimal? TotalAmountPaid { get; set; }
        public decimal? TotalAmountDiscount { get; set; }
        public List<FeeRecord>? FeeRecordsList { get; set; } = new List<FeeRecord>();
        public List<FeeRecordViewAgain>? FeesRecordListAgain { get; set; } = new List<FeeRecordViewAgain>();
        public List<Receipt>? ReceiptsList { get; set; } = new List<Receipt>();
        public virtual FeeRecord FeeRecord { get; set; }
        public List<ReceiptViewModel> ReceiptsViewModelList { get; set; }
        public decimal? PendingFees { get; set; } // Stores the fetched pending fees
        public bool IsPendingFeesLoaded { get; set; } = false; // Tracks if fees are already fetched
        public bool IsLoadingFees { get; set; } = false; // Tracks if fees are currently being loaded

        //new properties
        public Gender? Gender { get; set; }
        public bool IsRTEAdmission { get; set; }
        public bool IsEmployeeChild { get; set; }
        public string? Employee_Parent_Name { get; set; }
        public bool IsCommonFeesExempt { get; set; }
        public string? PreviousSchool { get; set; }
        public string? University_RollNo { get; set; }



        //new for Instittute
        public string? BachName { get; set; }
        public Branch? Branch { get; set; }
        public StuStatus? StuStatus { get; set; }

    }

    public class StudentViewShortModel
    {
        // Used for primary-key, URL building (photo, links), and aggregates
        public int StudentID { get; set; }

        // Shown in the “Student Name” column and counted in aggregates
        public string StudentName { get; set; } = null!;

        // Shown in the “Father” column
        public string? FatherName { get; set; }

        // Shown in the “Scholar No.” column
        public string? ExternalStudentID { get; set; }

        // Shown in the “Is New” column and used for the badge + custom footer count
        public bool? IsNewAdmission { get; set; }

        public string? Address { get; set; }
        public string? StudentMobileNo { get; set; }
        [Phone]
        public string? FatherMobileNo { get; set; }
        public string? MotherName { get; set; }
        public string? MotherMobileNo { get; set; }
        public Gender? Gender { get; set; }
        public bool IsRTEAdmission { get; set; }       

        //new for Instittute
        public string? BachName { get; set; }
        public Branch? Branch { get; set; }
        public StuStatus? StuStatus { get; set; }
    }

    public class StudentRecordsViewModel
    {
        public int StudentRecordsID { get; set; }
        public int StudentID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //Gender
        public Gender? Gender { get; set; }
        public string? MotherName { get; set; }
        //Address
        public string? Address { get; set; }
        //FatherMobileNo 
        public string? FatherMobileNo { get; set; }
        //MotherMobileNo
        public string? MotherMobileNo { get; set; }
        //StudentMobileNo
        public string? StudentMobileNo { get; set; }
        [StringLength(5, ErrorMessage = "Must be less than 5 characters.")]
        public string? BloodGroup { get; set; }
        //FatherEmail
        public string? FatherEmail { get; set; }
        //MotherEmail
        public string? MotherEmail { get; set; }
        //StudentEmail
        public string? StudentEmail { get; set; }
        //DateOfBirth
        public string? StudentNameHindi { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? FatherNameHindi { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? MotherNameHindi { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdharCardNo { get; set; }
        [Phone]
        public string? WhatsAppNo { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50characters.")]
        public string? ParentIncome { get; set; }
        public bool? IsNewStudent { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? PreviousSchool { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? PEN { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? APARId { get; set; }
        public string? AdmissionSource { get; set; }

        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdharCardFather { get; set; }

        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdharCardMother { get; set; }

        [StringLength(255)]
        public string? University_Enrollment { get; set; }
        [StringLength(255)]
        public string? University_RollNo { get; set; }

        public bool IsRTEAdmission { get; set; }
        public int? EmployeeChild { get; set; }
        public string? AdmissionReference { get; set; }
        public decimal? CautionMoneyAmount { get; set; }
        public string? CautionMoneyDetails { get; set; }
        public decimal? CautionMoneyReturnAmount { get; set; }
        public string? CautionMoneyReturnDetails { get; set; }
        public string? Password { get; set; }


    }
    public class StudentViewModelforReport
    {
        public int StudentID { get; set; } // Primary Key

        public int? SchoolID { get; set; } // Link to School

        public string? ExternalStudentID { get; set; } // For external ID systems

        public int? AcademicSessionId { get; set; } // Link to AcademicSession
        public bool? IsNewAdmission { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? StudentName { get; set; }

        public string? FatherName { get; set; }
        public bool? IsStudying { get; set; }

        public int? StudentHouseID { get; set; }
        public string? HouseName { get; set; }
        public string? ClassName { get; set; }
        public string? BatchName { get; set; }
        public Branch? Branch { get; set; }
        public StuStatus? StuStatus { get; set; }
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }
        public int? StudentCategoryID { get; set; }
        public string? SubCatergory { get; set; }
        public string? CategoryName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? AdmissionDate { get; set; }
        //Gender
        public Gender? Gender { get; set; }
        public string? MotherName { get; set; }
        //Address
        public string? Address { get; set; }
        //FatherMobileNo 
        public string? FatherMobileNo { get; set; }
        //MotherMobileNo
        public string? MotherMobileNo { get; set; }
        //StudentMobileNo
        public string? StudentMobileNo { get; set; }
        //FatherEmail
        public string? FatherEmail { get; set; }
        //MotherEmail
        public string? MotherEmail { get; set; }
        //StudentEmail
        public string? StudentEmail { get; set; }
        //DateOfBirth
        public string? StudentNameHindi { get; set; }

        public string? FatherNameHindi { get; set; }
        public string? MotherNameHindi { get; set; }

        public string? AdharCardNo { get; set; }

        public string? WhatsAppNo { get; set; }

        public string? ParentIncome { get; set; }
        public bool? IsNewStudent { get; set; }

        public string? PreviousSchool { get; set; }

        public string? PEN { get; set; }
        public string? AdmissionSource { get; set; }

        public string? AdmissionReference { get; set; }
        public bool? IsAdmissionSessionOpen { get; set; }

        // New property for login counts
        public int UserLogins { get; set; }
        public string? Blank1 { get; set; }
        public string? Blank2 { get; set; }
        public string? Blank3 { get; set; }

    }

    public class SchoolPivotViewModel
    {
        public string PartnerProvider { get; set; }
        public string GlobalAdministrator { get; set; }
        public string BoardOfEducation { get; set; }
        public string? City { get; set; }

        public int SchoolCount { get; set; }
        //other properties of school
        public bool IsCurrentlyActive { get; set; }
        public int ActiveUserCount { get; set; }
        public SchoolRegion? SchoolRegion { get; set; }

    }
    public class StudentViewModelforPivot
    {
        public int StudentID { get; set; } // Primary Key

        public int? SchoolID { get; set; } // Link to School       

        public int? AcademicSessionId { get; set; } // Link to AcademicSession
        public bool? IsNewAdmission { get; set; }


        public bool? IsStudying { get; set; }


        public string? HouseName { get; set; }
        public string? ClassName { get; set; }
        public string? BatchName { get; set; }
        public Branch? Branch { get; set; }
        public StuStatus? StuStatus { get; set; }

        public string? SectionName { get; set; }

        public string? SubCatergory { get; set; }
        public string? CategoryName { get; set; }
        //Gender
        public Gender? Gender { get; set; }


        public string? PreviousSchool { get; set; }

        public string? AdmissionSource { get; set; }

        public string? AdmissionReference { get; set; }

    }


    public class StudentDocumentViewModel
    {
        // Student Basic Details
        public int StudentID { get; set; } // Primary Key
        public int? SchoolID { get; set; } // Link to School
        public string? ExternalStudentID { get; set; } // For external ID systems
        public int? AcademicSessionId { get; set; } // Link to AcademicSession
        public string? AcademicSessionName { get; set; }
        public string? StudentName { get; set; }
        public bool? IsNewAdmission { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DateOfLeaving { get; set; }
        public string? LeavingReason { get; set; }

        // Family Details
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? MotherMobileNo { get; set; }
        public string? StudentMobileNo { get; set; }

        // Student's Address and Contact Information
        public string? Address { get; set; }
        public string? FatherEmail { get; set; }
        public string? MotherEmail { get; set; }
        public string? StudentEmail { get; set; }
        public string? WhatsAppNo { get; set; }

        // Personal Details
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }  // Enums: Male, Female, Other
        public string? AdharCardNo { get; set; }
        public bool? IsStudying { get; set; }
        public bool? IsNewStudent { get; set; }

        // School & Academic Information
        public string? ClassName { get; set; } // E.g., "Class 10-A"
        public string? SectionName { get; set; }
        public int? SectionId { get; set; }
        public string? HouseName { get; set; }
        public string? ClassTeacherName { get; set; }
        public Branch? Branch { get; set; }
        public StuStatus? StuStatus { get; set; }

        // Additional Properties for Document Customization
        public string? AdmissionSource { get; set; }
        public string? AdmissionReference { get; set; }
        public string? PreviousSchool { get; set; }
        public string? PEN { get; set; }
        public string? ParentIncome { get; set; }

        // Transport Details
        public string? BusNumber { get; set; }
        public string? RouteName { get; set; }
        public string? StopName { get; set; }


        // Blank fields for custom needs (placeholders)
        public string? Blank1 { get; set; }
        public string? Blank2 { get; set; }
        public string? Blank3 { get; set; }

        // New property for storing the student image URL
        public string? StudentImageUrl { get; set; }
    }


    public class SubjectViewModel   //was just a trial
    {
        // Include all properties from the Subject model except IsElective
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string? SubjectCode { get; set; }

        public int SectionId { get; set; }
        public string? DisplayText { get; set; }
        //ReportCardOrder
        //public ReportCardStatus? ReportCardStatus { get; set; }
        public int? ReportCardOrder { get; set; }

        // ... other properties ...

        // No IsElective property here
    }

    // Model for SubjectDetails
    public class SubjectDetailsViewModel
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string TeacherName { get; set; }
        public int NumberOfBooks { get; set; }
    }


    public class SubjectNewViewModel //used when creating new model
    {

        public string SubjectName { get; set; }
        public int SectionId { get; set; }
        [Required(ErrorMessage = "Selecting a teacher is required.")]
        public int TeacherId { get; set; }
        public Byte? WeeklyLoad { get; set; }

        // public int SectionId { get; set; }
        // ... other properties ...

        // No IsElective property here
    }
    public class SubjectListViewModel   //show in grid
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public ReportCardStatus? ReportCardStatus { get; set; }
        // public bool IsElective { get; set; }
        public bool IsNotInUse { get; set; }
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }
        public string? ClassName { get; set; }
        public string? EmployeeName { get; set; }
        public Byte? WeeklyLoad { get; set; }
        public int? EmployeeId { get; set; }
        public int? ClassTeacherId { get; set; }
        public int? TotalAllottedPeriods { get; set; }
        public int? CountOfTakenPeriods { get; set; }
        public int? CountOfSubjectMaterials { get; set; }

        // ... other properties as needed ...
    }
    //for subject materials heatmap
    public class SubjectEmployeeHeatMapViewModel
    {
        public Dictionary<int, int> Subject1 { get; set; } = new Dictionary<int, int>(); // subjectid -> CountOfSubjectMaterials
        public Dictionary<int, int> Subject2 { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> Subject3 { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> Subject4 { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> Subject5 { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> Subject6 { get; set; } = new Dictionary<int, int>();

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }


    public class SectionDisplayModel
    {
        public int SectionId { get; set; }
        public string DisplayText { get; set; }
        public int? NumberofSubjects { get; set; }
    }

    public class SectionViewModelDetailed //for SectionHome
    {

        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
        public string? AcademicSession { get; set; }
        public string? ClassTeacherName { get; set; }
        public int? ClassTeacherId { get; set; }
        public int? NoofStudents { get; set; }
        public List<SubjectViewModelList>? Subjects { get; set; } = new List<SubjectViewModelList>();
        public List<BooksViewModel>? Books { get; set; } = new List<BooksViewModel>();
        public List<StudentViewModel>? Students { get; set; } = new List<StudentViewModel>();
        public List<PeriodEntryViewModel>? PeriodEntries { get; set; } = new List<PeriodEntryViewModel>();
        public List<AttendanceViewModel>? Attendance { get; set; } = new List<AttendanceViewModel>();


    }
    public class AttendanceViewModel
    {
        public int? AttendanceId { get; set; }
        public int? StudentId { get; set; }
        public string? StudentName { get; set; } // To display the student's name
        public int? SectionId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public string? SMS { get; set; } // Optional
        public string? FatherName { get; set; }
        public string? FatherMobileNo { get; set; }

        public string? University_RollNo { get; set; } // Optional

        // Add any additional properties that might be useful for the UI
    }
    public class DailyAttendanceSummaryViewModel
    {
        public DateTime Date { get; set; }
        public double PresentPercentage { get; set; }  // 0 - 100%
        public bool IsWorkingDay { get; set; }
    }
    public class SectionAttendanceSummaryViewModel
    {
        public DateTime Date { get; set; }
        public double PresentPercentage { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
    }
    public class StudentAttendanceSummaryViewModel
    {
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }

    public class StudentDayAttendanceViewModel
    {
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty; // "P" or "A"
        public int StudentId { get; set; }
    }

    public class DailyLoginSummaryViewModel
    {
        public DateTime Date { get; set; }
        public int LoginCount { get; set; }
    }

   

    public class AttendanceDayViewModel
    {
        public int AttendanceDayId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int SchoolID { get; set; }
        public bool IsOpen { get; set; }
        public string? Comments { get; set; }
        public List<AttendanceViewModel>? Attendances { get; set; }


    }

    //for syncfusion bar chart
    public class StackedAttendanceData
    {
        public string StudentName { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
    }
    // Class for the chart data
    public class PeriodAttendanceChartData
    {
        public string PeriodLabel { get; set; } // Label for the period (Date and Period number)
        public int PresentCount { get; set; } // Number of students present
        public int AbsentCount { get; set; } // Number of students absent
    }


    public class SubjectViewModelList //for SectionHome
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsNotInUse { get; set; }
        public string? SubjectCode { get; set; }

        [Required(ErrorMessage = "Teacher is required.")]
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public string? SchoolClassId { get; set; }
        public string? ClassName { get; set; }
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }
        public string? Class_Section { get; set; }

        public int? WeeklyLoad { get; set; }
        public ReportCardStatus? ReportCardStatus { get; set; }
        //public string? ReportCardStatusName { get; set; }
        public int? ReportCardOrder { get; set; }

        // public virtual ICollection<BooksViewModel>? Books { get; set; }
        public MarkupString? BookLinks { get; set; }
        public int? TotalAllottedPeriods { get; set; }
        public int? CountOfTakenPeriods { get; set; }


        // Add other properties as needed
    }

    //new BooksViewModel
    public class BooksViewModel
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public int? SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public int? SectionId { get; set; }
        public string? Class_Section { get; set; }
        public List<ChaptersViewModel> Chapters { get; set; } = new List<ChaptersViewModel>();
        // Additional properties to manage UI state
        public bool IsSelected { get; set; }
        public int? ChapterNumbers { get; set; }

    }

    public class BooksShortViewModel
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string? BookPublisher { get; set; }
        public int? SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public List<ChaptersViewModel> Chapters { get; set; } = new List<ChaptersViewModel>();

        public int? ChapterNumbers { get; set; }

    }

    public class ChaptersViewModel
    {
        public int ChapterID { get; set; }
        public int? BookID { get; set; }
        [Range(0, 255, ErrorMessage = "Number must be between 0 and 255")]
        public int ChapterNumber { get; set; }
        public string ChapterTitle { get; set; }
        public int? ChapterExcercises { get; set; }
        public int? ChapterAllottedLectures { get; set; }
        public DifficultyLevel? DifficultyLevel { get; set; }

        public string? Topics { get; set; }
        public string? ChapterActivity { get; set; }

        public int? CountofPeriodEntries { get; set; }
        public string? EntryDetails { get; set; }
        public string? ExamNamesConcatenated { get; set; }
        // Include the collection of ChapterExamLinks
        public List<ChapterExamLinkViewModel> ChapterExamLinks { get; set; } = new List<ChapterExamLinkViewModel>();


    }
    public class ChapterExamLinkViewModel
    {
        public int ChapterID { get; set; }
        public int ExamID { get; set; }
        public string ExamName { get; set; } // Assume we also store ExamName for display purposes
    }

    public class PeriodEntryViewModel
    {
        public int PeriodEntryID { get; set; }
        public int? SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public int EmployeeId { get; set; }
        public string TeacherName { get; set; }
        public int? LectureTypeId { get; set; }
        public string LectureTypeName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LectureDate { get; set; }
        public int LecturePeriod { get; set; }
        public int? LectureSlot { get; set; }

        public string? Details { get; set; }

        public int? ChapterId { get; set; }
        public string? ChapterTitle { get; set; }
        public int? ChapterNumber { get; set; }
        public int? SectionId { get; set; }
        public string? Class_Section { get; set; }

    }
    public class LectureDayViewModel
    {
        public DateTime LectureDate { get; set; }
        public string? Period1Details { get; set; }
        public string? Period2Details { get; set; }
        public string? Period3Details { get; set; }
        public string? Period4Details { get; set; }
        public string? Period5Details { get; set; }
        public string? Period6Details { get; set; }
        public string? Period7Details { get; set; }
        public string? Period8Details { get; set; }

        // ... up to Period9Details
        public string? Period9Details { get; set; }
    }
    public class SchoolPeriodEntryViewModel
    {
        public DateTime LectureDate { get; set; }
        public string? ClassSectionName { get; set; }
        public string? Period1Details { get; set; }
        public string? Period2Details { get; set; }
        public string? Period3Details { get; set; }
        public string? Period4Details { get; set; }
        public string? Period5Details { get; set; }
        public string? Period6Details { get; set; }
        public string? Period7Details { get; set; }
        public string? Period8Details { get; set; }

        // ... up to Period9Details
        public string? Period9Details { get; set; }
    }

    public class DailyPeriodEntryCountViewModel
    {
        public DateTime Date { get; set; }
        public int PeriodEntryCount { get; set; }
    }
    public class PeriodEntrybySubjectViewModel
    {
        public int? PeriodEntryID { get; set; }
        public int SubjectId { get; set; }
        public string? PeriodTypeName { get; set; }
        public string? LectureDate { get; set; }
        public int LecturePeriod { get; set; }

        public int? LectureSlot { get; set; }

        public string? Details { get; set; }

        public int? ChapterId { get; set; }

        public int? ChapterID { get; set; }
        public int? ChapterNumber { get; set; }

        public string? ChapterTitle { get; set; }

        public int? BookID { get; set; }

        public int? ChapterExcercises { get; set; }

        public int? ChapterAllottedLectures { get; set; }

        public string? BookName { get; set; }

        public int? PeriodsTaken { get; set; }
    }



    public class UserViewModel
    {
        public string UserName { get; set; }
        public string? MobileNumber { get; set; }
        //public string UserType { get; set; }

        public string? Roles { get; set; } // For role names
    }

    public class AttendanceDaySheetViewModel
    {
        public int? AttendanceDayId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool IsOpen { get; set; }
        public string? Comments { get; set; }
        public int NumberOfSectionsWithAttendance { get; set; }
        public int PresentStudentsCount { get; set; }
        public int AbsentStudentsCount { get; set; }
        public int NotFilledStudentsCount { get; set; }
        public bool? IsSMSSent { get; set; }
    }

    public class DailyAttendanceViewModel
    {
        public DateTime Date { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }

    }
    public class AttendanceDaySectionViewModel
    {
        public int? AttendanceDayId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }
        public int? ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? SectionClassName { get; set; }
        public int? PresentStudentsCount { get; set; }
        public int? AbsentStudentsCount { get; set; }
        public int? NotFilledStudentsCount { get; set; }
        public int? TotalStudentsCount { get; set; }
        public bool? IsSMSSent { get; set; }
        public string? ClassTeacherName { get; set; }
        public int? ClassTeacherId { get; set; }


    }
    public class AttendanceBarChartViewModel
    {
        public string? SectionName { get; set; }
        public int? PresentStudentsCount { get; set; }
        public int? AbsentStudentsCount { get; set; }
    }

    public class SectionSyllabusViewModel
    {
        public int SectionId { get; set; }
        public string? SectionName { get; set; }
        public string? ClassName { get; set; }
        public int? ExamId { get; set; }
        public string? ExamName { get; set; }
        public int? SubjectId { get; set; } // Added for subject-specific syllabus
        public string? SubjectName { get; set; } // Added for subject-specific syllabus
        public List<SyllabusItem> SyllabusItems { get; set; } = new List<SyllabusItem>();
    }

    public class SyllabusItem
    {
        public string SubjectName { get; set; }
        public string BookName { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterTitle { get; set; }
        public int? ChapterExcercises { get; set; }
        public int? ChapterAllottedLectures { get; set; }
        public string? ExamNames { get; set; } // New property for concatenated exam names
        public int? PeriodsTaken { get; set; } // New property for periods taken
        public int? ChapterID { get; set; }
        public DifficultyLevel? DifficultyLevel { get; set; }
        public string? Topics { get; set; }
        public string? ChapterActivity { get; set; }

    }
    public class SyllabusSummaryItem
    {
        public string ExamName { get; set; }
        public int ChapterCount { get; set; }
        public int ExercisesSum { get; set; }
        public int AllottedLecturesSum { get; set; }
        public int PeriodsTakenSum { get; set; }
    }

    public class StudentRegistrationForm
    {
        // Personal Details
        public Branch Branch { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? StudentCategoryID { get; set; }
        public string Address { get; set; }
        public string StudentMobileNo { get; set; }
        public string GuardianMobileNo { get; set; }
        public string AdharCardNo { get; set; }
        public string PAN { get; set; }
        public string StudentEmailId { get; set; }
        public string ParentIncome { get; set; }
        public string AdmissionSource { get; set; }
        public string AdmissionReference { get; set; }
        public int? Batch { get; set; }
        public bool IsStudying { get; set; }
        public int? StudentHouseID { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public int AcademicSessionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class CarouselItemViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageFileName { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string School { get; set; }
    }

    class BranchBatchViewModel
    {
        public string BranchName { get; set; }
        public Dictionary<int, int> BatchData { get; set; }
        public int Total { get; set; }
    }

    class BatchViewModel
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }

        // public string? AcademicSession { get; set; }       
        //public int? NoofStudents { get; set; }
    }


    public class ClassSectionStudentCountViewModel
    {
        public string ClassName { get; set; }
        public Dictionary<string, int> SectionStudentCounts { get; set; } = new Dictionary<string, int>();

        public int TotalStudentCount => SectionStudentCounts.Values.Sum(); // Calculate total student count

        public ClassSectionStudentCountViewModel(string className)
        {
            ClassName = className;
        }

        public void AddSectionCount(string sectionName, int count)
        {
            if (!SectionStudentCounts.ContainsKey(sectionName))
            {
                SectionStudentCounts[sectionName] = count;
            }
            else
            {
                SectionStudentCounts[sectionName] += count;
            }
        }
    }

    public class ClassSectionGenderCountViewModel
    {
        public string ClassName { get; set; }
        public Dictionary<string, GenderCounts> SectionGenderCounts { get; set; } = new Dictionary<string, GenderCounts>();

        public ClassSectionGenderCountViewModel(string className)
        {
            ClassName = className;
        }

        public void AddSectionGenderCount(string sectionName, int maleCount, int femaleCount, int notSpecifiedCount)
        {
            if (!SectionGenderCounts.ContainsKey(sectionName))
            {
                SectionGenderCounts[sectionName] = new GenderCounts(maleCount, femaleCount, notSpecifiedCount);
            }
            else
            {
                SectionGenderCounts[sectionName].MaleCount += maleCount;
                SectionGenderCounts[sectionName].FemaleCount += femaleCount;
                SectionGenderCounts[sectionName].NotSpecifiedCount += notSpecifiedCount;
            }
        }
    }


    public class GenderCounts
    {
        public int MaleCount { get; set; }
        public int FemaleCount { get; set; }
        public int NotSpecifiedCount { get; set; }

        public GenderCounts(int maleCount, int femaleCount, int notSpecifiedCount)
        {
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            NotSpecifiedCount = notSpecifiedCount;
        }
    }


    public class ClassSectionCategoryCountViewModel
    {
        public string ClassName { get; set; }
        public Dictionary<string, Dictionary<int, int>> SectionCategoryCounts { get; set; } = new Dictionary<string, Dictionary<int, int>>();

        public ClassSectionCategoryCountViewModel(string className)
        {
            ClassName = className;
        }

        public void AddSectionCategoryCount(string sectionName, int categoryId, int count)
        {
            if (!SectionCategoryCounts.ContainsKey(sectionName))
            {
                SectionCategoryCounts[sectionName] = new Dictionary<int, int>();
            }

            if (!SectionCategoryCounts[sectionName].ContainsKey(categoryId))
            {
                SectionCategoryCounts[sectionName][categoryId] = count;
            }
            else
            {
                SectionCategoryCounts[sectionName][categoryId] += count;
            }
        }
    }

    public class SectionOption
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class PropertyOption
    {
        public string DisplayName { get; set; } // What the user sees
        public string Value { get; set; }       // The actual property name to use in the grid
    }

    public class StudentEnrollmentViewModel
    {
       
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public int StudentEnrollmentID { get; set; }
        public bool IsActive { get; set; }

        public int SectionId { get; set; }
        public int SessionId { get; set; }
        public string AcademicSessionName { get; set; } = default!;
    }

    public class ClassPivotData
    {
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string BatchName { get; set; }
        public string BranchName { get; set; }
        public string StuStatus { get; set; }
        public string StudentCategory { get; set; }
        public string AcademicSessionName { get; set; } // New Property
        public bool IsStudying { get; set; } // New Property
        public int TotalStudents { get; set; }
    }

    //Veiwmodle for PieChart
    public class PieChartDataModel
    {
        public string Label { get; set; }
        public decimal Value { get; set; }
    }
    public class DailyComparisonModel
    {
        /// <summary>
        /// The date for this comparison (e.g., one day).
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The category data for the day. For example, if you have Attendance categories,
        /// each item could have Label = "Present" or "Absent" and a Value count.
        /// </summary>
        public List<PieChartDataModel> Data { get; set; } = new List<PieChartDataModel>();
    }


    public class LightweightStudentViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? ExternalStudentID { get; set; }
        public string? AcademicSessionName { get; set; }
        public int AcademicSessionID { get; set; }
        public string ClassSectionName { get; set; }
        public bool IsStudying { get; set; }
    }

    // View model used for displaying voucher lists with the total amount.
     // SubscriptionWarningState.cs
    public class SubscriptionWarningState
    {
        /// <summary>
        /// Has the warning been shown already in this circuit?
        /// </summary>
        public bool HasBeenShown { get; set; }
    }
    /// <summary>
    /// Represents a row pairing a student with one of their siblings. Used for grids
    /// that display both students in the same line.
    /// </summary>
    public class StudentSiblingRowViewModel
    {
        // Primary student information
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentClass { get; set; }
        public string? StudentSection { get; set; }

        // Corresponding sibling information
        public int SiblingId { get; set; }
        public string? SiblingName { get; set; }
        public string? SiblingClass { get; set; }
        public string? SiblingSection { get; set; }
        public List<int> SiblingIds { get; set; } = new();
        public string AllNames { get; set; } = string.Empty;
        public string AllIds { get; set; }
    }

    public class EnumItem<T>
    {
        public T Value { get; set; }
        public string Text { get; set; }
    }

    /// <summary>
    /// Simple DTO for dropdowns displaying school name and id together.
    /// </summary>
    public class SchoolLookup
    {
        public int SchoolId { get; set; }
        public string DisplayText { get; set; } = string.Empty;
    }

    /// <summary>
    /// Simple DTO for dropdowns displaying facility name and id together.
    /// </summary>
    public class EduBuddyFacilityLookup
    {
        public int EduBuddyFacilityId { get; set; }
        public string DisplayText { get; set; } = string.Empty;
    }

    public class PeriodTypeViewModel
    {
        public int PeriodTypeId { get; set; }

            public string PeriodTypeName { get; set; }
        public int SchoolId { get; set; }

        // Additional properties as needed, e.g., Description, IsActive, etc.
    }



    public class SchoolBasicViewModel
    {
        public int SchoolId { get; set; }
        public string? SchoolName { get; set; }
        public string? City { get; set; }
        public bool IsCollege { get; set; } // Indicates if the school is a college
    }





}

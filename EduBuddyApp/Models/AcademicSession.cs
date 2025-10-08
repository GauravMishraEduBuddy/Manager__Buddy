using System.Security.Claims;
using static System.Collections.Specialized.BitVector32;
using  System.ComponentModel.DataAnnotations;
using System;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBuddyApp.Models;


    public class School
    {
        [Required]
        public int SchoolID { get; set; }
        //[Required]
        [Required(ErrorMessage = "SchoolName is required.")]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string SchoolName { get; set; }

        [StringLength(15, ErrorMessage = "Must be less than 15 characters.")]
        public string? SchoolNameShort { get; set; }
        public string? SchoolCode { get; set; }
        public SchoolRegion? SchoolRegion { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        
        public string? Website { get; set; }
        public string? PrincipalName { get; set; }
       // [YearRange(1800)]
        public int? EstablishedYear { get; set; }
        public InstituteType? InstituteType { get; set; }

        public SchoolType? SchoolType { get; set; }
        public BoardOfEducation? BoardOfEducation { get; set; }
        public bool IsCurrentlyActive { get; set; }
        public TimeZone? TimeZone { get; set; }
        //max lenght 50
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? Language { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public string? AdditionalContacts { get; set; } // Could be JSON or another complex type
        public string? BlobStorageConnectionString { get; set; }
        public string? PartnerProvider { get; set; }
        public string? GlobalAdministrator { get; set; }
        public string? PartnersContacts { get; set; }

        //addtional properties
        public bool AllowMonthlyFee { get; set; }
        public bool DateAllowinReceipt { get; set; }
        public bool? HideDiscount { get; set; }
        public bool? IsFeesFixed { get; set; }
        public bool ShowAccountantinReceipt { get; set; }
        public bool AllowFeesReceiptItemChange { get; set; }
        public bool AllowFeesReceiptAmountTransfer { get; set; }
        public bool AllowIsCommonFeesExempt { get; set; }
        public bool AllowFeesItemPriority { get; set; }
        public bool ShowAllPendingReceipt { get; set; }//Set Old Receipt Create Page:
        public bool ShowRollNoinAttendance { get; set; }
        public bool HasSubjectMaterialFacility { get; set; }
        public bool HasScheduler { get; set; }
        public bool HasHostel { get; set; }
        public bool HasSubjectGroup { get; set; }
        //for IsAIEnabled, HasAdminMessage
        public bool IsAIEnabled { get; set; }
        public bool HasAdminMessage { get; set; }

        public bool HasWhatsApp { get; set; }
        public bool HasSMS { get; set; }
        public bool SinglePageFees { get; set; }

        public bool ReceiptShowPendingAmount { get; set; }
        public bool IsFineEnabled { get; set; }
        public bool IsExpenseBuddyActive { get; set; } = false;
        public bool IsStaffSalaryEnabled { get; set; } = false;
        public bool ShowHeadersEditinReceipt { get; set; }
        public FeeRecordsVisible FeeRecordsVisible { get; set; }
        public bool ReceiptKOTPrinter { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? WebSiteLink { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Facebooklink { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Twitterlink { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Linkedinlink { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Youtubelink { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Instagramlink { get; set; }

        public int? AdmissionTarget { get; set; }

        //Running/SeduBuddy Status
        public EduBuddy_Status? EduBuddy_Status { get; set; }
        public Running_Status? Running_Status { get; set; }

        //id created date
        public DateTime? CreatedDate { get; set; }

        //starting date
        public DateTime? StartingDate { get; set; }
        //Cost_Details
        public string? Cost_Details { get; set; }
        //GPS Coordinates
        [Column(TypeName = "decimal(9,6)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal? Longitude { get; set; }

        public decimal? AttendanceDistance { get; set; } // Distance in kilometers for attendance


        // Navigation properties
        public virtual ICollection<AcademicSession>? AcademicSessions { get; set; }
        public virtual ICollection<SchoolClass>? SchoolClasses { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        //public virtual ICollection<FacilityLocation>? FacilityLocations { get; set; }
        //public virtual ICollection<AssetCategory>? AssetCategories { get; set; }
        //public virtual ICollection<Asset>? Assets { get; set; }

        //public virtual ICollection<Subject> Subjects { get; set; }
        // Other properties and methods

        public string? InstamojoClientId { get; set; }
        public string? InstamojoClientSecret { get; set; }

        //employee salary Probation
       // public ProrationMode DefaultProration { get; set; } = ProrationMode.StandardMonth;
    }
    public enum EduBuddy_Status
    {
        Running,
        Not_Running,
        ToStart_from_April,
        Waiting_for_Data,
        Waiting_for_Installation
    }
    public enum Running_Status
    {
        Full_Use,
        Only_Fees,
        Only_ReportCard,
        Only_AI,
        Not_Using
    }
    public enum InstituteType
    {
        School,
        College
    }
    public enum SchoolType
    {
        Public,
        Private,
        Charter,
        Magnet,
        Online,
        Homeschool,
        // Add other school types as needed
    }
    public enum SchoolRegion
    {
        UP_East,
        UP_West,       
        // Add other regions as needed
    }

    public enum BoardOfEducation
    {
        CBSE,         // Central Board of Secondary Education
        CISCE,        // Council for the Indian School Certificate Examinations
        UPBoard,      // Uttar Pradesh Board
        IB,     // International Baccalaureate
        IGCSE,        // International General Certificate of Secondary Education
        Other,        // Add other boards as needed
        Pharmacy,
        Graduation,
        Nursing,
        Engineering,
        Medical,
        Madarsa_Education,
        Law
    }

    public enum FeeRecordsVisible
    {
        AllPending,
        PresentPendingOnly 
    }

    public enum TimeZone
    {
        IST,          // Indian Standard Time
                      // Add other time zones as needed
    }

    public class YearRangeAttribute : ValidationAttribute
    {
        private readonly int _minimumYear;

        public YearRangeAttribute(int minimumYear)
        {
            _minimumYear = minimumYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                if (year >= _minimumYear && year <= DateTime.Now.Year)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"Year must be between {_minimumYear} and {DateTime.Now.Year}.");
            }

            return new ValidationResult("Invalid year.");
        }
    }

    public class SubscriptionWarning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionWarningId { get; set; }

        /// <summary>
        /// FK to your Schools table
        /// </summary>
        [Required]
        public int SchoolId { get; set; }

        /// <summary>
        /// true = allowed / paid, false = warning
        /// </summary>
        [Required]
        public bool SchoolAllowed { get; set; }
    }

    public class AcademicSession
    {
        [Required]
        public int AcademicSessionId { get; set; }
        [Required]
        public int SchoolID { get; set; } // Link to a specific school
        [Required]
        public string SessionName { get; set; }
        public bool IsOpen { get; set; }

        [NotMapped]
        public bool IsArchive => SessionStatus == SessionStatus.Archived;
        //public bool IsArchive { get; set; }

        public bool IsNewSession { get; set; }

        public SessionStatus SessionStatus { get; set; }

        // Navigation properties
        public virtual School School { get; set; } // Reference to the School entity
        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
    }
    public enum SessionStatus
    {
        Running,
        Proposed,
        Archived
    }
    public class Batch
    {
        public int BatchID { get; set; }
        [Required]
        public string BatchName { get; set; }
        public bool BatchActive { get; set; }
        public int SchoolId { get; set; }
        public int? BatchComplete_AcademicYear { get; set; }
        public short? Duration { get; set; } // Duration in years

        // Navigation properties
        public virtual ICollection<Student> Students { get; set; }
        public virtual School School { get; set; }
    }
  


    public class SchoolClass
    {
        [Required]
        public int SchoolClassId { get; set; } // Renamed from VGSClassId for clarity
        [Required]
        public string ClassName { get; set; }
        [Required]
        public int SchoolID { get; set; } // Link to a specific school
        [Required]
        public int AcademicSessionId { get; set; }
       // public List<int>? SemesterID { get; set; } // List of semesters in the class

        // Navigation properties
        public virtual School School { get; set; } // Reference to the School entity
        public virtual AcademicSession AcademicSession { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; } // Nullable collection of Semesters
     
    }
    public class Semester
    {
        public int SemesterID { get; set; }
        public int SchoolClassId { get; set; } // Links to SchoolClass instead of Batch
        [Required]
        public string SemesterName { get; set; }
        public bool SemOpen { get; set; } // Indicates if the semester is currently active

        // Navigation properties
        public virtual SchoolClass SchoolClass { get; set; }
        public virtual ICollection<Section> Sections { get; set; } // Optional if Sections are managed both directly and through Semesters
    }



    public class Section
    {
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string SectionName { get; set; }
        [Required]
        public int SchoolClassId { get; set; } // Renamed from VGSClassId
        [Required]
        public int? EmployeeId { get; set; } // For the class teacher
        public int? SemesterID { get; set; } // Nullable if a section might not belong to a semester
        // Navigation properties
        public virtual Employee? Employee { get; set; } // SchoolClass Teacher
        public virtual SchoolClass? SchoolClass { get; set; } // Reference to the SchoolClass entity
        public virtual ICollection<Subject>? Subjects { get; set; }
        public virtual ICollection<StudentEnrollment>? StudentEnrollments { get; set; }
       // public List<PeriodEntry>? PeriodEntries { get; set; } 
        public virtual ICollection<Attendance>? Attendances { get; set; }
        public virtual Semester? Semester { get; set; } // Ensure this property exists to navigate to Semester
        // New navigation property for ExamSectionObservation
        public virtual ExamSectionObservation? ExamSectionObservation { get; set; }
        [NotMapped]
        public string? ClassName => $"{SchoolClass?.ClassName}-{SchoolClass?.AcademicSession.SessionName}";
        [NotMapped]
        public string? ClassAndSectionName => $"{SchoolClass?.ClassName}-{SectionName}" +
            $"- {SchoolClass?.AcademicSession.SessionName}-{SchoolClass?.AcademicSession.IsOpen}"; // Combines class and section names


    }

    public class Subject
    {
        [Required]
        public int SubjectID { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string SubjectName { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? SubjectCode { get; set; }
        public bool? IsElective { get; set; } = false;
        public bool IsNotInUse { get; set; }

        public int SectionId { get; set; }
        [Range(0, 20, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? WeeklyLoad { get; set; }
        public ReportCardStatus? ReportCardStatus { get; set; }
        [Range(0, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? ReportCardOrder { get; set; }

     

        public virtual ICollection<Book>? Books { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<TeacherSubjectSection>? TeacherSubjectSections { get; set; }
        public virtual ICollection<PeriodEntry>? PeriodEntries { get; set; }
        public virtual ICollection<ExamMarks>? ExamMarks { get; set; }
        public virtual SubjectObservation? SubjectObservation { get; set; }


        //Groups
        public int? GroupId { get; set; } // Nullable if a subject might not belong to a group
        public virtual Group Group { get; set; }

        // New navigation property for associated periods
        public virtual ICollection<PeriodSubject> PeriodSubjects { get; set; }

        public string ClassAndSectionName
        {
            get
            {
                if (Section?.SchoolClass != null)
                {
                    return $"{Section.SchoolClass.ClassName}-{Section.SectionName}";
                }
                return Section?.SectionName ?? string.Empty;
            }
        }

    }
    public enum ReportCardStatus
    {
        NotIncluded,
        WithMarks,
        WithGrades
    }

  
   


    public class Student
    {
        [Required]
        public int StudentID { get; set; } // Primary Key
        [Required]
        public int SchoolID { get; set; } // Link to School
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? ExternalStudentID { get; set; } // For external ID systems
        public int AcademicSessionId { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string StudentName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string FatherName { get; set; }
        public bool IsStudying { get; set; }

        public int? StudentCategoryID { get; set; } // Link to StudentCategory table
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? SubCatergory { get; set; }
        public int? StudentHouseID { get; set; } // Updated from HouseID
        //DOB
        //public DateTime? StuDateOfBirth { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DateofLeaving { get; set; }
        public string? LeavingReason { get; set; }
        // add new properties NCCOPtion
        //public NccOption? NccOption { get; set; }
       // public bool Olympiad { get; set; } = false;
        //for college
        public int? BatchID { get; set; }
        public Branch? Branch { get; set; }
        public StuStatus? StuStatus { get; set; }


        // Navigation properties
        public virtual School School { get; set; }
        public virtual StudentRecords StudentRecords { get; set; }
        public virtual AcademicSession AcademicSession { get; set; }
        public virtual ICollection<StudentEnrollment> Enrollments { get; set; }
        //for ExamStudentObservation
        //public virtual ICollection<ExamStudentObservation> ExamStudentObservations { get; set; }
        public virtual StudentHouse StudentHouse { get; set; }
        //public virtual StudentRecords Records { get; set; }
        public virtual StudentCategory StudentCategory { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
        public virtual ICollection<ExamStudentObservation>? ExamStudentObservations { get; set; }
        public virtual ICollection<FeeRecord>? FeeRecords { get; set; }
        public virtual ICollection<Receipt>? Receipts { get; set; }
        public virtual StudentTransport? StudentTransport { get; set; }
        //public virtual StudentLeft? StudentLeft { get; set; }
       // public virtual HostelEntry? HostelEntry { get; set; }
        public virtual Batch? Batch { get; set; }

        //Audit properties
        [StringLength(50, ErrorMessage = "The name must be less than 50 characters.")]
        public string? CreatedBy { get; set; }
        
        public DateTime? CreatedDate { get; set; }

        [StringLength(50, ErrorMessage = "The name must be less than 50 characters.")]
        public string? ModifiedBy { get; set; }
        [StringLength(50, ErrorMessage = "The name must be less than 50 characters.")]
        public string? NotStudyingBy { get; set; }
        public DateTime? ModifiedDate { get; set; }


        // Navigation property back to ApplicationUser
        //public ApplicationUser? ApplicationUser { get; set; }
        //navigation to siblings
       //public virtual List<StudentSibling>? StudentSiblings { get; set; }
        public virtual ICollection<StudentSibling> StudentSiblings { get; set; } = new List<StudentSibling>();




    }
    public enum Branch
    {
        AG, Civil, CS, CS_AI_ML, CS_IoT, CS_DS, ME, EN, EC, Fitter, Electrician, BBA, BCA, MBA,DPharma, 
        BPharma, Nursing, BCom,  BA, BSc, LLB , MA , MSc, MCom, MTech, MPhil, PhD, Other, ANM, GNM
    }
    public enum NccOption
    {
        None = 0,
        IsNCC = 1,
        IsScotGuide = 2
    }
    public enum StuStatus
    {
        Regular_Studying, Regular_Conditional,
        [Display(Name = "Drop Out")] Not_Studying,
        Graduated, Lateral_Regular, Lateral_Conditional, ReAdmit_Regular, ReAdmit_Conditional , Direct_admission , JEECUP, CUET , Other
    }
    public class StudentRecords
    {
        [Required]
        public int StudentRecordsID { get; set; }
        [Required]
        public int StudentID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
      
        public NccOption? NccOption { get; set; }
        public bool Olympiad { get; set; } = false;
        public string? MotherName { get; set; }
        public string? Address { get; set; }
        [Phone]
        public string? FatherMobileNo { get; set; }
        [Phone]
        public string? MotherMobileNo { get; set; }
        [Phone]

        public string? StudentMobileNo { get; set; }
        [EmailAddress]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? FatherEmailId { get; set; }
        [EmailAddress]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string ? MotherEmailId { get; set; }
        [EmailAddress]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? StudentEmailId { get; set; }
        /* new fields  */
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? StudentNameHindi { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? FatherNameHindi { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? MotherNameHindi { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdharCardNo { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdharCardFather { get; set; }

        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdharCardMother { get; set; }

        public bool IsRTEAdmission { get; set; } // non-nullable with default = false

        public int? EmployeeChild { get; set; }

        [StringLength(5, ErrorMessage = "Must be less than 5 characters.")]
        public string? BloodGroup { get; set; }

        // this tells EF “EmployeeChild is the FK for EmployeeChildNavigation”
        [ForeignKey(nameof(EmployeeChild))]
        public virtual Employee? EmployeeChildNavigation { get; set; }



        [Phone]
        public string? WhatsAppNo { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50characters.")]
        public string? ParentIncome { get; set; }
        public bool? IsNewStudent { get; set; }
        public bool IsCommonFeesExempt { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? PreviousSchool { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? PEN { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string?APARId { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdmissionSource { get; set; }
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string? AdmissionReference { get; set; }

        //Student Records for Collegium
        [StringLength(255)]
        public string? City { get; set; }
        [StringLength(255)]
        public string? Decided_fees { get; set; }
        [StringLength(255)]
        public string? Decided_fees22 { get; set; }
        [StringLength(255)]
        public string? SKType { get; set; }
        [StringLength(255)]
        public string? Fees_comments { get; set; }
        [StringLength(255)]
        public string? TenthSchool { get; set; }
        [StringLength(255)]
        public string? TenthSchoolCity { get; set; }
        [StringLength(255)]
        public string? TenthPercentage  { get; set; }
        [StringLength(255)]
        public string? TenthRollNumber { get; set; }
      
        public BoardType? TenthBoard { get; set; }
        [StringLength(255)]
        public string? TwelthSchool { get; set; }
        [StringLength(255)]
        public string? TwelthSchoolCity { get; set; }
        [StringLength(255)]
        public string? TwelthPercentage { get; set; }
        [StringLength(255)]
        public string? TwelthRollNumber { get; set; }
       
        public BoardType? TwelthBoard { get; set; }
        [StringLength(255)]
        public string? DiplomaCollege { get; set; }
        [StringLength(255)]
        public string? DiplomaCollegeCity { get; set; }
        [StringLength(255)]
        public string? DiplomaRollNumber { get; set; }
        [StringLength(255)]
        public string? DiplomaPercentage { get; set; }
        public string? University_Enrollment { get; set; }
        [StringLength(255)]
        public string? University_RollNo { get; set; }
        [StringLength(255)]
        public string? SKNotReceived { get; set; }
        [StringLength(255)]
        public string? SKNotReceivedComments { get; set; }
        [StringLength(255)]
        public string? Emailofficial { get; set; }
        [StringLength(255)]
        public string? Pending2022 { get; set; }
        [StringLength(255)]
        public string? Pending2022Comments { get; set; }

        public decimal? CautionMoneyAmount { get; set; }
        [StringLength(255)]
        public string? CautionMoneyDetails { get; set; }
        public decimal? CautionMoneyReturnAmount { get; set; }
        [StringLength(255)]
        public string? CautionMoneyReturnDetails { get; set; }
        public string? Password { get; set; }

        //cusomterization properties
        public bool? HaveDarkTheme { get; set; }

        public virtual Student Student { get; set; }
    }
    public enum Gender 
        {
        Male, Female, Unknown
        }
    public enum BoardType
    {
        CBSE,
        CISCE,
        UPBoard,
        Cambridge,
        IB,
        IGCSE,
        BTE,
        Other
    }
    public class StudentCategory
    {
        [Required]
        public int StudentCategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; } // General, OBC, SC, ST, Minority
        [Required]
        public int SchoolID { get; set; }

        // Navigation properties
        public virtual ICollection<Student> Students { get; set; }
        public virtual School School { get; set; }
    }
    public class StudentHouse
    {
        [Required]
        public int StudentHouseID { get; set; }
        [Required]
        public string HouseName { get; set; } // For example: Krishna_Green, Narmada_Blue, etc.
        [Required]
        public int SchoolID { get; set; }

        // Navigation properties
        public virtual ICollection<Student> Students { get; set; }
        public virtual School School { get; set; }
    }

    public class StudentEnrollment
    {
        [Required]
        public int StudentEnrollmentID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int SectionId { get; set; }


        //public int AcademicSessionID { get; set; }

        public bool IsActive { get; set; } // To track active enrollment

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Section Section { get; set; }
       // public virtual ICollection<StudentElective>? StudentElectives { get; set; }
    }

    public class TeacherSubjectSection
    {
        [Required]
        public int TeacherSubjectSectionID { get; set; }
        [Required]
        public int EmployeeID { get; set; } // TeacherID
        [Required]
        public int SubjectID { get; set; }
        [Required]    
        public virtual Employee Teacher { get; set; }
        public virtual Subject Subject { get; set; }
        //public virtual Section Section { get; set; }
    }
    public class Book
    {
        public int BookID { get; set; }
        public int SubjectID { get; set; }
            [Required]
            [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
            public string BookTitle { get; set; }
        public string? Publisher { get; set; }
        // ... other book properties

        // Navigation properties
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Chapter>? Chapters { get; set; }
    }
    public class Chapter
    {
        public int ChapterID { get; set; }
        [Range(0, 255, ErrorMessage = "Number must be between 0 and 255")]
        public int ChapterNumber { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string ChapterTitle { get; set; }
        public int BookID { get; set; }
        public int? ChapterExcercises { get; set; }
        public int? ChapterAllottedLectures { get; set; }
        public DifficultyLevel? DifficultyLevel { get; set; }
        public string? Topics { get; set; }
        // ... other chapter properties

        // Navigation properties
        public virtual Book Book { get; set; }
        public virtual ICollection<ChapterExamLink> ChapterExamLinks { get; set; }
        public virtual ICollection<PeriodEntry> PeriodEntries { get; set; }
    }

    //enum DifficultyLevel
    public enum DifficultyLevel
    {
        Very_Easy,
        Easy,
        Modest,
        Difficult,
        Very_Difficult
    }


    //ChapterExamLink Model (Junction Table)
    //The ChapterExamLink junction table captures which chapters are relevant for which exam types.

    public class ChapterExamLink
    {
        public int ChapterID { get; set; }
        public int ExamID { get; set; }

        // Navigation properties
        public virtual Chapter Chapter { get; set; }
        public virtual Exam Exam { get; set; }
    }

    public class AttendanceDay
    {
        public int AttendanceDayId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int SchoolID { get; set; }
        public bool IsOpen { get; set; }
        public string? Comments { get; set; }
        public bool? IsSMSSent { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }
    }
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; } // Adjusted to StdudentId from Stunewid
        public int AttendanceDayId { get; set; }
        public DateTime AttendanceDate { get; set; } // Renamed for consistency
        public bool IsPresent { get; set; } // Renamed for clarity
        public int SectionId { get; set; } // Link to Section
        //public int SchoolID { get; set; } // Link to School for multi-tenancy
        public string? SMS { get; set; } // Optional, for SMS notification tracking


        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Section Section { get; set; }
        public virtual AttendanceDay AttendanceDay { get; set; }
        //public virtual School School { get; set; } // New navigation property
    }
    public class PeriodAttendance
    {
        public int PeriodAttendanceId { get; set; }
        public int StudentId { get; set; }
        public int PeriodEntryId { get; set; } // Tracks the specific period (linked to PeriodEntry)
        public bool IsPresent { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual PeriodEntry PeriodEntry { get; set; }
    }


    

    public class PeriodEntry
    {
        public int PeriodEntryId { get; set; }
        public int? SubjectId { get; set; }
        public int EmployeeId { get; set; }
        public int PeriodTypeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LectureDate { get; set; }

        [Required]
        [Range(1, 9, ErrorMessage = "Value must be between 1 (first period) and 9 (last period)")]
        public int LecturePeriod { get; set; }

        [Range(1, 9, ErrorMessage = "Lecture slot must be between 1 and 9")]
        public int? LectureSlot { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 15, ErrorMessage = "Details must be between 15 and 2000 characters")]
        public string? Details { get; set; }

        public int? ChapterId { get; set; }

        // Navigation properties
        public virtual Employee Employee { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual PeriodType LectureType { get; set; }
    }
    public class PeriodType
    {
        public int PeriodTypeId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Lecture type name must be under 50 characters")]
        public string PeriodTypeName { get; set; }
        public int SchoolId { get; set; }

        // Additional properties as needed, e.g., Description, IsActive, etc.
    }

    

    public class BlobItemTable
    {
        public int BlobItemTableId { get; set; } // Auto-incrementing primary key
        public BlobItemType BlobItemType { get; set; } // Enum for ReportCard, AdmitCard, IDCard
        public string BlobName { get; set; } // Name of the blob file
        public bool IsActive { get; set; } // Indicates if it's the active template for the school
        public int SchoolId { get; set; } // Foreign key for the school
        public DateTime? CreatedDate { get; set; } // Date the file was created
        public DateTime? UpdatedDate { get; set; } // Date the file was last updated
        //BlobDetails
        public string? BlobDetails { get; set; } // Additional details about the blob file

        // New properties for tiling
        public bool IsCompositeExam { get; set; } // Whether Simple of Composite exams
        public bool IsMultipleonPage { get; set; } //if one page has more than 1 blobs

        // Navigation properties for School
        public virtual School School { get; set; }



    }
    //BlobItemType- ReportCard, AdmitCard, IDCard, EmployeeDocuments
    public enum BlobItemType
    {
        ReportCard,
        StudentDocuments,
        EmployeeDocuments,
        FeesDocuments
    }

    public class TemplateBlobItemTable
    {
        public int TemplateBlobItemTableId { get; set; } // Auto-incrementing primary key

        // Basic Details
        public string TemplateName { get; set; } // Name of the template
        public string? Description { get; set; } // Short details about the template
        public string? ThumbnailUrl { get; set; } // URL for the thumbnail image

        // Blob Storage Details
        public string? BlobName { get; set; } // Blob file name
        public BlobItemType BlobItemType { get; set; } // Enum for types (ReportCard, AdmitCard, etc.)
        public bool IsActive { get; set; } // Indicates if it's the active template
        public bool IsCompositeExam { get; set; } // Whether for composite exams
        public bool IsMultipleOnPage { get; set; } // Whether the template includes multiple copies on a single page       

        // User & Timestamps
        public string? UploadedBy { get; set; } // Name of the uploader
        public DateTime? CreatedDate { get; set; } // Date the template was created
        public DateTime? UpdatedDate { get; set; } // Date the template was last updated
    }


    public class SubjectMaterial
    {
        public int SubjectMaterialId { get; set; } // Primary key
        public SubjectMaterialType SubjectMaterialType { get; set; } // Notes, PPT, Assignment, QuestionPaper
        public string BlobName { get; set; } // File name
        public bool IsActive { get; set; } // If it's active or not
        public int SubjectId { get; set; } // Foreign key for Subject
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        [StringLength(500, ErrorMessage = "Must be less than 500 characters.")]
        public string? SubjectMaterialDescription { get; set; }
    }
    public enum SubjectMaterialType
    {
        Notes,
        PPT,
        Assignment,
        QuestionPaper,
        ResearchPaper,
        Ebook,
        VideoLinks,
        Other
    }


    public class AppointmentData
    {
        [Key]
        public int Id { get; set; }
        // Field for School identification
        [Required]
        public int SchoolID { get; set; }  // Foreign key for the School entity


        [Required]
        public string Subject { get; set; }

        public string? Location { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? Description { get; set; }

        public bool IsAllDay { get; set; }

        public string? RecurrenceRule { get; set; }

        public string? RecurrenceException { get; set; }

        public int? RecurrenceID { get; set; }
        // Additional fields for color coding and timezone handling
        public string? CategoryColor { get; set; } // Optional for color differentiation

       public DateTime? StartTimezone { get; set; } // Optional for timezone handling

        public DateTime? EndTimezone { get; set; }   // Optional for timezone handling

    }

    public class SubjectObservation
    {
        [Required]
        public int SubjectObservationId { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        //Data
        public int PercentTimeLapsed { get; set; }
        public string? SyllabusCoveredStatus { get; set; } // AI-generated and editable
        

        // Observations
        public string? SubjectSyllabusObservation { get; set; } // AI-generated and editable
        public string? SubjectPeriodEntryObservation { get; set; } // AI-generated and editable

        // Optional properties to add metadata about the observations
        public string? CreatedBy { get; set; } // For tracking who made the observation
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    //siblings
    public class SiblingGroup
    {
        public int SiblingGroupId { get; set; } // Primary Key
        public int SchoolId { get; set; } // Foreign Key to identify the school
        public List<StudentSibling> StudentSiblings { get; set; } // Navigation property for students in the group
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual School School { get; set; } // Navigation property to School
    }
    public class StudentSibling
    {
        public int StudentId { get; set; } // Foreign Key to Student
        public int SiblingGroupId { get; set; } // Foreign Key to SiblingGroup

        public virtual Student Student { get; set; } // Navigation property to Student
        public virtual SiblingGroup SiblingGroup { get; set; } // Navigation property to SiblingGroup
    }

